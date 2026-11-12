
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[RequireComponent(typeof(NetworkObject))]
[RequireComponent(typeof(Collider2D))]
public class ZonaSalidaCompartida : NetworkBehaviour
{
    [Header("Siguiente escena")]
    [SerializeField] private string siguienteEscena =
        "NOMBRE_EXACTO_DE_LA_ESCENA";

    private Dictionary<ulong, int> jugadoresEnZona =
        new Dictionary<ulong, int>();

    private bool cambiandoEscena;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            jugadoresEnZona.Clear();
            cambiandoEscena = false;
        }

        Debug.Log("ZONA DE SALIDA COMPARTIDA ACTIVADA.");
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (!IsSpawned || cambiandoEscena)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        RegistrarEntradaRpc();
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        if (!IsSpawned || cambiandoEscena)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        RegistrarSalidaRpc();
    }

    [Rpc(
        SendTo.Server,
        InvokePermission = RpcInvokePermission.Everyone
    )]
    private void RegistrarEntradaRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer || cambiandoEscena)
            return;

        ulong jugadorId =
            rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients
            .ContainsKey(jugadorId))
            return;

        if (jugadoresEnZona.ContainsKey(jugadorId))
            jugadoresEnZona[jugadorId]++;
        else
            jugadoresEnZona.Add(jugadorId, 1);

        Debug.Log(
            "JUGADOR EN SALIDA: " + jugadorId +
            " | JUGADORES: " + jugadoresEnZona.Count + "/2"
        );

        ComprobarSalida();
    }

    [Rpc(
        SendTo.Server,
        InvokePermission = RpcInvokePermission.Everyone
    )]
    private void RegistrarSalidaRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer || cambiandoEscena)
            return;

        ulong jugadorId =
            rpcParams.Receive.SenderClientId;

        if (!jugadoresEnZona.ContainsKey(jugadorId))
            return;

        jugadoresEnZona[jugadorId]--;

        if (jugadoresEnZona[jugadorId] <= 0)
            jugadoresEnZona.Remove(jugadorId);

        Debug.Log(
            "JUGADOR SALIO DE LA ZONA | " +
            "JUGADORES: " + jugadoresEnZona.Count + "/2"
        );
    }

    private void ComprobarSalida()
    {
        if (!IsServer || cambiandoEscena)
            return;

        if (NetworkManager.Singleton.ConnectedClientsIds.Count < 2)
            return;

        if (jugadoresEnZona.Count < 2)
            return;

        if (string.IsNullOrWhiteSpace(siguienteEscena))
        {
            Debug.LogError(
                "FALTA CONFIGURAR LA SIGUIENTE ESCENA."
            );
            return;
        }

        cambiandoEscena = true;

        Debug.Log(
            "AMBOS JUGADORES LLEGARON. " +
            "CARGANDO: " + siguienteEscena
        );

        NetworkManager.Singleton.SceneManager.LoadScene(
            siguienteEscena,
            LoadSceneMode.Single
        );
    }
}
