
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(NetworkObject))]
public class ZonaCaidaCamino : NetworkBehaviour
{
    private bool contactoProcesado;

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (!IsSpawned || contactoProcesado)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        if (!IdentidadJugadorLocal.EsLia())
            return;

        contactoProcesado = true;

        RegistrarCaidaRpc();
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador != null && jugador.IsOwner)
            contactoProcesado = false;
    }

    [Rpc(
        SendTo.Server,
        InvokePermission = RpcInvokePermission.Everyone
    )]
    private void RegistrarCaidaRpc(RpcParams rpcParams = default)
    {
        if (!IsServer)
            return;

        ulong jugadorId = rpcParams.Receive.SenderClientId;

        if (jugadorId == NetworkManager.ServerClientId)
            return;

        VidasEquipo vidas = VidasEquipo.Instancia;

        if (vidas == null)
            return;

        bool puedeRecuperarse = vidas.PerderVidaServidor();

        if (puedeRecuperarse)
        {
            ControlCheckpointCamino control =
                FindFirstObjectByType<ControlCheckpointCamino>();

            control?.RecuperarJugador(jugadorId);
        }

        Debug.Log("LIA CAYÓ AL VACÍO");
    }
}
