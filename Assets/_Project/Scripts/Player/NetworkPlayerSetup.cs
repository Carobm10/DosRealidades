using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class NetworkPlayerSetup : NetworkBehaviour
{
    [Header("Visual del jugador")]
    [SerializeField] private SpriteRenderer spriteJugador;

    private void Awake()
    {
        if (spriteJugador == null)
        {
            spriteJugador = GetComponent<SpriteRenderer>();
        }
    }

    public override void OnNetworkSpawn()
    {
        // Colores provisionales mientras llega el arte final.
        if (OwnerClientId == 0)
        {
            spriteJugador.color = Color.blue;
        }
        else
        {
            spriteJugador.color = Color.magenta;
        }

        SceneManager.sceneLoaded += AlCargarEscena;

        ActualizarVisibilidad(SceneManager.GetActiveScene().name);

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

    private void AlCargarEscena(Scene escena, LoadSceneMode modo)
    {
        ActualizarVisibilidad(escena.name);
    }

    private void ActualizarVisibilidad(string nombreEscena)
    {
        // En el Main Menu el jugador existe en red,
        // pero no debe verse.
        bool mostrarJugador =
            nombreEscena != "01_MainMenu";

        if (spriteJugador != null)
        {
            spriteJugador.enabled = mostrarJugador;
        }
    }
}