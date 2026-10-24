using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class CamaraJugadorLocal : NetworkBehaviour
{
    [Header("Camara del jugador")]
    [SerializeField] private Camera camaraJugador;

    [SerializeField] private AudioListener audioListenerJugador;

    private void Awake()
    {
        if (camaraJugador == null)
        {
            camaraJugador = GetComponentInChildren<Camera>(true);
        }

        if (audioListenerJugador == null && camaraJugador != null)
        {
            audioListenerJugador =
                camaraJugador.GetComponent<AudioListener>();
        }
    }

    public override void OnNetworkSpawn()
    {
        SceneManager.sceneLoaded += AlCargarEscena;

        ActualizarCamara(SceneManager.GetActiveScene().name);
    }

    public override void OnNetworkDespawn()
    {
        SceneManager.sceneLoaded -= AlCargarEscena;
    }

    private void AlCargarEscena(Scene escena, LoadSceneMode modo)
    {
        ActualizarCamara(escena.name);
    }

    private void ActualizarCamara(string nombreEscena)
    {
        if (camaraJugador == null)
            return;

        bool escenaJugable =
            nombreEscena != "01_MainMenu";

        bool activar =
            IsOwner && escenaJugable;

        camaraJugador.gameObject.SetActive(activar);

        if (audioListenerJugador != null)
        {
            audioListenerJugador.enabled = activar;
        }
    }
}