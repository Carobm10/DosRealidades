
using UnityEngine;
using Unity.Netcode;
using System.Collections;

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

    [Header("Cinematica de la puerta")]
    [SerializeField] private Transform puntoCamaraPuerta;
    [SerializeField] private float esperaAntesDeAbrir = 0.3f;
    [SerializeField] private float duracionApertura = 1.5f;

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

    private Coroutine rutinaCinematicaLocal;

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

        if (rutinaCinematicaLocal != null)
            StopCoroutine(rutinaCinematicaLocal);

        if (rutinaHabilitarSalida != null)
            StopCoroutine(rutinaHabilitarSalida);
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

        if (!inventario.TieneObjeto(id))
            return;

        if (!inventario.EliminarObjetoDesdeServidor(id))
            return;

        if (esDispositivoElian)
            elianActivo.Value = true;
        else
            liaActiva.Value = true;

        Debug.Log("P8 | Llave colocada: " + id);

        if (AmbasLlavesColocadas && !aperturaSolicitada)
        {
            aperturaSolicitada = true;

            Debug.Log(
                "P8 | AMBAS LLAVES COLOCADAS. INICIANDO CINEMATICA."
            );

            IniciarCinematicaPuertaRpc();
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
    // DESPREPARAR LLAVE
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

        if (inventario != null && inventario.IsOwner)
        {
            InventarioUI.Instancia?.DesprepararObjeto(id);
        }
    }

    // =====================================
    // CINEMATICA SINCRONIZADA
    // =====================================

    [Rpc(SendTo.Everyone)]
    private void IniciarCinematicaPuertaRpc()
    {
        if (rutinaCinematicaLocal != null)
            StopCoroutine(rutinaCinematicaLocal);

        rutinaCinematicaLocal =
            StartCoroutine(CinematicaPuertaLocal());
    }

    private IEnumerator CinematicaPuertaLocal()
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red == null ||
            red.LocalClient == null ||
            red.LocalClient.PlayerObject == null)
            yield break;

        NetworkObject jugador =
            red.LocalClient.PlayerObject;

        NetworkPlayerMovement movimiento =
            jugador.GetComponent<NetworkPlayerMovement>();

        CamaraJugadorLocal camara =
            jugador.GetComponent<CamaraJugadorLocal>();

        // BLOQUEAR MOVIMIENTO

        if (movimiento != null)
            movimiento.BloquearMovimiento(true);

        Debug.Log("P8 | Cinematica iniciada.");

        float transicionZoom = 0.35f;

        // ACERCAR CAMARA A LA PUERTA

        if (camara != null && puntoCamaraPuerta != null)
        {
            transicionZoom = camara.DuracionTransicionZoom;

            camara.EnfocarConZoom(
                puntoCamaraPuerta.position,
                esperaAntesDeAbrir + duracionApertura
            );
        }
        else
        {
            Debug.LogError(
                "P8 | Falta la cámara local o el punto de enfoque de la puerta."
            );
        }

        // ESPERAR HASTA QUE LA CAMARA LLEGUE

        yield return new WaitForSecondsRealtime(
            transicionZoom + esperaAntesDeAbrir
        );

        // ABRIR PUERTA

        if (animatorPuerta != null)
        {
            animatorPuerta.enabled = true;

            animatorPuerta.ResetTrigger(triggerAbrirPuerta);
            animatorPuerta.SetTrigger(triggerAbrirPuerta);

            Debug.Log("P8 | PUERTA ABIERTA.");
        }
        else
        {
            Debug.LogError("P8 | Animator de puerta no asignado.");
        }

        // ESPERAR APERTURA Y REGRESO DE CAMARA

        yield return new WaitForSecondsRealtime(
            duracionApertura + transicionZoom
        );

        // RECUPERAR MOVIMIENTO

        if (movimiento != null)
            movimiento.BloquearMovimiento(false);

        Debug.Log("P8 | Cinematica terminada.");

        rutinaCinematicaLocal = null;
    }

    // =====================================
    // HABILITAR SALIDA
    // =====================================

}
