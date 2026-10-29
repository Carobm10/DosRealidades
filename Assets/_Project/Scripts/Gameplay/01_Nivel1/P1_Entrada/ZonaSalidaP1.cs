using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ZonaSalidaP1 : NetworkBehaviour
{
    private HashSet<ulong> jugadoresEnZona =
        new HashSet<ulong>();

    private bool cambiandoEscena = false;

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (cambiandoEscena)
            return;

        if (!IsSpawned)
            return;

        if (NetworkManager.Singleton == null ||
            !NetworkManager.Singleton.IsListening)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null)
            return;

        if (!jugador.IsOwner)
            return;

        RegistrarEntradaRpc();
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        // Cuando estamos cambiando de escena,
        // Unity dispara TriggerExit mientras destruye objetos.
        // Ya no debemos enviar RPC.
        if (cambiandoEscena)
            return;

        if (!IsSpawned)
            return;

        if (NetworkManager.Singleton == null ||
            !NetworkManager.Singleton.IsListening)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null)
            return;

        if (!jugador.IsOwner)
            return;

        RegistrarSalidaRpc();
    }

    [Rpc(SendTo.Server)]
    private void RegistrarEntradaRpc(
        RpcParams rpcParams = default
    )
    {
        if (cambiandoEscena)
            return;

        ulong jugadorId =
            rpcParams.Receive.SenderClientId;

        jugadoresEnZona.Add(jugadorId);

        Debug.Log(
            "Jugadores en la puerta: " +
            jugadoresEnZona.Count +
            "/2"
        );

        if (jugadoresEnZona.Count >= 2)
        {
            Debug.Log(
                "P1 COMPLETADO: ambos jugadores estan en la puerta."
            );

            if (NetworkManager.Singleton != null &&
                NetworkManager.Singleton.IsServer)
            {
                cambiandoEscena = true;

                NetworkManager.Singleton.SceneManager.LoadScene(
                    "P2_Recepcion",
                    LoadSceneMode.Single
                );
            }
        }
    }

    [Rpc(SendTo.Server)]
    private void RegistrarSalidaRpc(
        RpcParams rpcParams = default
    )
    {
        if (cambiandoEscena)
            return;

        ulong jugadorId =
            rpcParams.Receive.SenderClientId;

        jugadoresEnZona.Remove(jugadorId);

        Debug.Log(
            "Jugadores en la puerta: " +
            jugadoresEnZona.Count +
            "/2"
        );
    }
}