
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ZonaSalidaP2 : NetworkBehaviour
{
    [Header("Escena siguiente")]
    [SerializeField] private string escenaSiguiente;

    private HashSet<ulong> jugadoresEnZona =
        new HashSet<ulong>();

    private bool cambiandoEscena = false;

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (cambiandoEscena || !IsSpawned)
            return;

        if (NetworkManager.Singleton == null ||
            !NetworkManager.Singleton.IsListening)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        RegistrarEntradaRpc();
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        if (cambiandoEscena || !IsSpawned)
            return;

        if (NetworkManager.Singleton == null ||
            !NetworkManager.Singleton.IsListening)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        RegistrarSalidaRpc();
    }

    [Rpc(SendTo.Server)]
    private void RegistrarEntradaRpc(
        RpcParams rpcParams = default)
    {
        if (cambiandoEscena)
            return;

        ulong jugadorId =
            rpcParams.Receive.SenderClientId;

        jugadoresEnZona.Add(jugadorId);

        Debug.Log(
            "Jugadores en salida P2: " +
            jugadoresEnZona.Count + "/2"
        );

        if (jugadoresEnZona.Count >= 2)
        {
            if (NetworkManager.Singleton != null &&
                NetworkManager.Singleton.IsServer)
            {
                cambiandoEscena = true;

                Debug.Log(
                    "P2 COMPLETADO: ambos jugadores llegaron."
                );

                NetworkManager.Singleton.SceneManager.LoadScene(
                    escenaSiguiente,
                    LoadSceneMode.Single
                );
            }
        }
    }

    [Rpc(SendTo.Server)]
    private void RegistrarSalidaRpc(
        RpcParams rpcParams = default)
    {
        if (cambiandoEscena)
            return;

        ulong jugadorId =
            rpcParams.Receive.SenderClientId;

        jugadoresEnZona.Remove(jugadorId);

        Debug.Log(
            "Jugadores en salida P2: " +
            jugadoresEnZona.Count + "/2"
        );
    }
}
