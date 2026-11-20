
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(NetworkObject))]
public class DispositivosLlavesP8 : NetworkBehaviour
{
    [Header("Identificadores")]
    [SerializeField] private string idLlaveElian = "Llave_Elian";
    [SerializeField] private string idLlaveLia = "Llave_lia";

    [Header("Visuales de los dispositivos")]
    [SerializeField] private GameObject llaveColocadaElian;
    [SerializeField] private GameObject llaveColocadaLia;

    [Header("Puerta final")]
    [SerializeField] private Animator animatorPuerta;
    [SerializeField] private string triggerAbrirPuerta = "AbrirPuerta";

    private NetworkVariable<bool> elianActivo =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private NetworkVariable<bool> liaActiva =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private bool aperturaSolicitada;

    public bool AmbasLlavesColocadas =>
        elianActivo.Value && liaActiva.Value;

    // =====================================
    // INICIO
    // =====================================

    public override void OnNetworkSpawn()
    {
        elianActivo.OnValueChanged += ActualizarElian;
        liaActiva.OnValueChanged += ActualizarLia;

        ActualizarVisuales();

        if (IsServer)
        {
            elianActivo.Value = false;
            liaActiva.Value = false;
            aperturaSolicitada = false;
        }
    }

    public override void OnNetworkDespawn()
    {
        elianActivo.OnValueChanged -= ActualizarElian;
        liaActiva.OnValueChanged -= ActualizarLia;
    }

    // =====================================
    // SOLICITAR COLOCACION
    // =====================================

    public void SolicitarColocarLlave(bool esDispositivoElian)
    {
        if (!IsSpawned || AmbasLlavesColocadas)
            return;

        string idEsperado = esDispositivoElian
            ? idLlaveElian
            : idLlaveLia;

        InventarioUI ui = InventarioUI.Instancia;

        if (ui == null ||
            ui.ObjetoPreparado == null ||
            ui.ObjetoPreparado.Id != idEsperado)
        {
            Debug.Log("P8 | Prepara la llave correspondiente.");
            return;
        }

        if (IsServer)
        {
            ColocarLlaveServidor(
                NetworkManager.Singleton.LocalClientId,
                esDispositivoElian
            );
        }
        else
        {
            SolicitarColocacionRpc(esDispositivoElian);
        }
    }

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void SolicitarColocacionRpc(
        bool esDispositivoElian,
        RpcParams rpcParams = default)
    {
        ulong clienteId = rpcParams.Receive.SenderClientId;

        ColocarLlaveServidor(
            clienteId,
            esDispositivoElian
        );
    }

    // =====================================
    // VALIDACION DEL SERVIDOR
    // =====================================

    private void ColocarLlaveServidor(
        ulong clienteId,
        bool esDispositivoElian)
    {
        if (!IsServer || AmbasLlavesColocadas)
            return;

        if (!NetworkManager.Singleton.ConnectedClients.TryGetValue(
            clienteId, out NetworkClient cliente))
            return;

        if (cliente.PlayerObject == null)
            return;

        NetworkPlayerSetup setup =
            cliente.PlayerObject.GetComponent<NetworkPlayerSetup>();

        InventarioJugador inventario =
            cliente.PlayerObject.GetComponent<InventarioJugador>();

        if (setup == null ||
            !setup.RolConfigurado ||
            inventario == null)
            return;

        // Validar que cada jugador utilice su dispositivo.

        if (esDispositivoElian && !setup.EsElian)
            return;

        if (!esDispositivoElian && setup.EsElian)
            return;

        string id = esDispositivoElian
            ? idLlaveElian
            : idLlaveLia;

        bool yaColocada = esDispositivoElian
            ? elianActivo.Value
            : liaActiva.Value;

        if (yaColocada)
            return;

        // Comprobar que tenga la llave.

        if (!inventario.TieneObjeto(id))
        {
            Debug.LogWarning(
                "P8 | El jugador no tiene la llave: " + id
            );
            return;
        }

        // Eliminar la llave del inventario.

        if (!inventario.EliminarObjetoDesdeServidor(id))
            return;

        // Activar el dispositivo correspondiente.

        if (esDispositivoElian)
            elianActivo.Value = true;
        else
            liaActiva.Value = true;

        Debug.Log(
            "P8 | Llave colocada: " + id +
            " | Jugador: " + clienteId
        );

        // Si ambas están colocadas, abrir la puerta.

        if (AmbasLlavesColocadas && !aperturaSolicitada)
        {
            aperturaSolicitada = true;

            Debug.Log(
                "P8 | AMBAS LLAVES COLOCADAS. ABRIENDO PUERTA."
            );

            AbrirPuertaRpc();
        }
    }

    // =====================================
    // ACTUALIZAR VISUALES
    // =====================================

    private void ActualizarElian(bool anterior, bool nuevo)
    {
        ActualizarVisuales();

        if (nuevo)
            DesprepararLlaveLocal(idLlaveElian);
    }

    private void ActualizarLia(bool anterior, bool nuevo)
    {
        ActualizarVisuales();

        if (nuevo)
            DesprepararLlaveLocal(idLlaveLia);
    }

    private void ActualizarVisuales()
    {
        if (llaveColocadaElian != null)
            llaveColocadaElian.SetActive(elianActivo.Value);

        if (llaveColocadaLia != null)
            llaveColocadaLia.SetActive(liaActiva.Value);
    }

    // =====================================
    // DESPREPARAR LLAVE DEL INVENTARIO
    // =====================================

    private void DesprepararLlaveLocal(string id)
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red == null ||
            red.LocalClient == null ||
            red.LocalClient.PlayerObject == null)
            return;

        InventarioJugador inventario =
            red.LocalClient.PlayerObject
                .GetComponent<InventarioJugador>();

        if (inventario != null &&
            inventario.IsOwner &&
            inventario.TieneObjeto(id))
        {
            InventarioUI.Instancia?.DesprepararObjeto(id);
        }
    }

    // =====================================
    // APERTURA DE PUERTA SINCRONIZADA
    // =====================================

    [Rpc(SendTo.Everyone)]
    private void AbrirPuertaRpc()
    {
        if (animatorPuerta == null)
        {
            Debug.LogError(
                "P8 | No se asignó el Animator de la puerta."
            );
            return;
        }

        animatorPuerta.SetTrigger(triggerAbrirPuerta);

        Debug.Log(
            "P8 | Animación de apertura ejecutada."
        );
    }
}
