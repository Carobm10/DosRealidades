using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class PosicionarJugadorLobby : MonoBehaviour
{
    [Header("Puntos de aparicion")]
    [SerializeField] private Transform spawnJugadorA;
    [SerializeField] private Transform spawnJugadorB;

    private IEnumerator Start()
    {
        // Esperamos a que Netcode tenga creado el jugador local.
        yield return new WaitUntil(() =>
            NetworkManager.Singleton != null &&
            NetworkManager.Singleton.LocalClient != null &&
            NetworkManager.Singleton.LocalClient.PlayerObject != null
        );

        NetworkObject jugadorLocal =
            NetworkManager.Singleton.LocalClient.PlayerObject;

        // Host = Jugador A
        // Client = Jugador B
        Transform puntoInicio =
            NetworkManager.Singleton.IsHost
            ? spawnJugadorA
            : spawnJugadorB;

        jugadorLocal.transform.position = puntoInicio.position;

        Debug.Log(
            NetworkManager.Singleton.IsHost
            ? "Jugador A colocado en su spawn."
            : "Jugador B colocado en su spawn."
        );
    }
}