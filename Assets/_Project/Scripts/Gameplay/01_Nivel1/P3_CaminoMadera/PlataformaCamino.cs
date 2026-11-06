
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(NetworkObject))]
[RequireComponent(typeof(Collider2D))]
public class PlataformaCamino : NetworkBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private bool esSeguro;

    [Header("Punto de recuperacion si falla")]
    [SerializeField] private Transform puntoRespawnSiFalla;

    private NetworkVariable<bool> destruida =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private Collider2D colision;
    private SpriteRenderer sprite;
    private bool procesado;

    private void Awake()
    {
        colision = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public override void OnNetworkSpawn()
    {
        destruida.OnValueChanged += AlCambiarEstado;
        AplicarEstado(destruida.Value);
    }

    public override void OnNetworkDespawn()
    {
        destruida.OnValueChanged -= AlCambiarEstado;
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (!IsSpawned || destruida.Value || procesado)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        if (!IdentidadJugadorLocal.EsLia())
            return;

        procesado = true;

        ProcesarPlataformaRpc(
            new NetworkObjectReference(NetworkObject)
        );
    }

    [Rpc(
        SendTo.Server,
        InvokePermission = RpcInvokePermission.Everyone
    )]
    private void ProcesarPlataformaRpc(
        NetworkObjectReference referencia,
        RpcParams rpcParams = default)
    {
        if (!IsServer || destruida.Value)
            return;

        ulong jugadorId =
            rpcParams.Receive.SenderClientId;

        if (jugadorId == NetworkManager.ServerClientId)
            return;

        if (!referencia.TryGet(
            out NetworkObject plataforma))
            return;

        if (plataforma != NetworkObject)
            return;

        if (esSeguro)
        {
            Debug.Log("TABLON SEGURO: " + gameObject.name);
            return;
        }

        Debug.Log("TABLON INCORRECTO: " + gameObject.name);

        // Eliminar visualmente el tablon para ambos.
        destruida.Value = true;

        VidasEquipo vidas = VidasEquipo.Instancia;

        if (vidas == null)
        {
            Debug.LogError("No se encontro VidasEquipo.");
            return;
        }

        bool puedeRecuperarse =
            vidas.PerderVidaServidor();

        // Si todavia quedan vidas, recuperar a Lia.
        if (puedeRecuperarse)
        {
            ControlCheckpointCamino control =
                FindFirstObjectByType<ControlCheckpointCamino>();

            if (control != null)
            {
                if (puntoRespawnSiFalla != null)
                {
                    control.RecuperarJugador(
                        jugadorId,
                        puntoRespawnSiFalla.position
                    );
                }
                else
                {
                    Debug.LogError(
                        "Falta asignar el punto de respawn en: " +
                        gameObject.name
                    );

                    control.RecuperarJugador(jugadorId);
                }
            }
        }
    }

    private void AlCambiarEstado(
        bool anterior,
        bool nuevo)
    {
        AplicarEstado(nuevo);
    }

    private void AplicarEstado(bool estaDestruida)
    {
        if (sprite != null)
            sprite.enabled = !estaDestruida;

        if (colision != null)
            colision.enabled = !estaDestruida;
    }

    public void RestablecerServidor()
    {
        if (!IsServer)
            return;

        procesado = false;
        destruida.Value = false;

        AplicarEstado(false);

        RestablecerProcesadoClientRpc();
    }

    [ClientRpc]
    private void RestablecerProcesadoClientRpc()
    {
        procesado = false;
    }
}
