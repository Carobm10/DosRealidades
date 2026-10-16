using UnityEngine;
using Unity.Netcode;

public class CamaraJugadorLocal : NetworkBehaviour
{
    [Header("Camara del jugador")]
    [SerializeField] private Camera camaraJugador;

    [SerializeField] private AudioListener audioListenerJugador;

    private void Awake()
    {
        // Si olvidamos asignar la cámara en el Inspector,
        // intenta encontrarla automáticamente entre los hijos.
        if (camaraJugador == null)
        {
            camaraJugador = GetComponentInChildren<Camera>(true);
        }

        // Busca también el Audio Listener automáticamente.
        if (audioListenerJugador == null && camaraJugador != null)
        {
            audioListenerJugador =
                camaraJugador.GetComponent<AudioListener>();
        }
    }

    public override void OnNetworkSpawn()
    {
        if (camaraJugador == null)
        {
            Debug.LogError(
                "No se encontró CamaraJugador dentro del NetworkPlayer."
            );

            return;
        }

        bool esJugadorLocal = IsOwner;

        camaraJugador.gameObject.SetActive(esJugadorLocal);

        if (audioListenerJugador != null)
        {
            audioListenerJugador.enabled = esJugadorLocal;
        }
    }
}