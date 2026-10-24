using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class NetworkPlayerSetup : NetworkBehaviour
{
    [Header("Visual del jugador")]
    [SerializeField] private SpriteRenderer spriteJugador;
    [SerializeField] private Animator animatorJugador;

    [Header("Personajes")]
    [SerializeField] private RuntimeAnimatorController controladorElian;
    [SerializeField] private RuntimeAnimatorController controladorLia;

    private void Awake()
    {
        if (spriteJugador == null)
        {
            spriteJugador = GetComponent<SpriteRenderer>();
        }

        if (animatorJugador == null)
        {
            animatorJugador = GetComponent<Animator>();
        }
    }

    public override void OnNetworkSpawn()
    {
        ConfigurarPersonaje();

        SceneManager.sceneLoaded += AlCargarEscena;

        ActualizarVisibilidad(
            SceneManager.GetActiveScene().name
        );

        Debug.Log(
            "Jugador creado | ClientId: " + OwnerClientId +
            " | IsOwner: " + IsOwner +
            " | IsServer: " + IsServer
        );
    }

    public override void OnNetworkDespawn()
    {
        SceneManager.sceneLoaded -= AlCargarEscena;
    }

    private void ConfigurarPersonaje()
    {
        if (animatorJugador == null)
            return;

        if (spriteJugador != null)
        {
            spriteJugador.color = Color.white;
        }

        bool esElian =
            OwnerClientId ==
            NetworkManager.ServerClientId;

        if (esElian)
        {
            animatorJugador.runtimeAnimatorController =
                controladorElian;
        }
        else
        {
            animatorJugador.runtimeAnimatorController =
                controladorLia;
        }
    }

    private void AlCargarEscena(
        Scene escena,
        LoadSceneMode modo
    )
    {
        ActualizarVisibilidad(escena.name);
    }

    private void ActualizarVisibilidad(
        string nombreEscena
    )
    {
        bool mostrarJugador =
            nombreEscena != "01_MainMenu";

        if (spriteJugador != null)
        {
            spriteJugador.enabled = mostrarJugador;
        }
    }
}