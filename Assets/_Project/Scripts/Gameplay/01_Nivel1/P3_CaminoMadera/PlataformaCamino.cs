
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(NetworkObject))]
[RequireComponent(typeof(Collider2D))]
public class PlataformaCamino : NetworkBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private bool esSeguro;

    private NetworkVariable<bool> destruida =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private Collider2D[] colisiones;
    private SpriteRenderer sprite;
    private bool procesado;

    private void Awake()
    {
        colisiones = GetComponents<Collider2D>();
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

        if (!referencia.TryGet(out NetworkObject plataforma))
            return;

        if (plataforma != NetworkObject)
            return;

        ControlCheckpointCamino control =
            FindFirstObjectByType<ControlCheckpointCamino>();

        if (esSeguro)
        {
            Debug.Log("TABLON SEGURO");

            if (control != null)
            {
                control.RegistrarCheckpointServidor(
                    jugadorId,
                    transform.position
                );
            }
        }
        else
        {
            Debug.Log("TABLON INCORRECTO");

            destruida.Value = true;

            VidasEquipo vidas = VidasEquipo.Instancia;

            if (vidas != null)
            {
                bool puedeRecuperarse =
                    vidas.PerderVidaServidor();

                if (puedeRecuperarse && control != null)
                    control.RecuperarJugador(jugadorId);
            }
        }
    }

    private void AlCambiarEstado(bool anterior, bool nuevo)
    {
        AplicarEstado(nuevo);
    }

    private void AplicarEstado(bool estaDestruida)
    {
        if (sprite != null)
            sprite.enabled = !estaDestruida;

        if (colisiones == null)
            return;

        foreach (Collider2D colision in colisiones)
        {
            if (colision != null)
                colision.enabled = !estaDestruida;
        }
    }

    public void RestablecerServidor()
    {
        if (!IsServer)
            return;

        procesado = false;
        destruida.Value = false;

        AplicarEstado(false);
    }
}
