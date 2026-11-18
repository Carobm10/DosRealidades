
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ZonaSalidaP2 : NetworkBehaviour
{
    [Header("Escena siguiente")]
    [SerializeField] private string escenaSiguiente;

    private readonly HashSet<ulong> jugadoresEnZona =
        new HashSet<ulong>();

    private bool cambiandoEscena;

    // =====================================
    // ENTRADA A LA SALIDA
    // =====================================

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (cambiandoEscena || !IsSpawned)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        RegistrarEntradaRpc();
    }

    // =====================================
    // SALIDA DE LA ZONA
    // =====================================

    private void OnTriggerExit2D(Collider2D otro)
    {
        if (cambiandoEscena || !IsSpawned)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        RegistrarSalidaRpc();
    }

    // =====================================
    // REGISTRAR ENTRADA EN SERVIDOR
    // =====================================

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void RegistrarEntradaRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer || cambiandoEscena)
            return;

        ulong jugadorId =
            rpcParams.Receive.SenderClientId;

        NetworkManager red = NetworkManager.Singleton;

        if (red == null ||
            !red.ConnectedClients.ContainsKey(jugadorId))
            return;

        jugadoresEnZona.Add(jugadorId);

        Debug.Log(
            "P2: Jugadores en salida " +
            jugadoresEnZona.Count + "/2"
        );

        if (jugadoresEnZona.Count < 2)
            return;

        if (red.ConnectedClientsIds.Count != 2)
            return;

        foreach (ulong id in red.ConnectedClientsIds)
        {
            if (!jugadoresEnZona.Contains(id))
                return;
        }

        if (string.IsNullOrWhiteSpace(escenaSiguiente))
        {
            Debug.LogError(
                "P2: No se ha asignado la escena siguiente."
            );
            return;
        }

        cambiandoEscena = true;

        Debug.Log(
            "P2 COMPLETADO: ambos jugadores llegaron."
        );

        red.SceneManager.LoadScene(
            escenaSiguiente,
            LoadSceneMode.Single
        );
    }

    // =====================================
    // REGISTRAR SALIDA EN SERVIDOR
    // =====================================

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void RegistrarSalidaRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer || cambiandoEscena)
            return;

        ulong jugadorId =
            rpcParams.Receive.SenderClientId;

        jugadoresEnZona.Remove(jugadorId);

        Debug.Log(
            "P2: Jugadores en salida " +
            jugadoresEnZona.Count + "/2"
        );
    }

    public override void OnNetworkDespawn()
    {
        jugadoresEnZona.Clear();
        cambiandoEscena = false;
    }
}
