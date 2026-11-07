
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class NetworkPlayerSetup : NetworkBehaviour
{
    [Header("Visual del jugador")]
    [SerializeField] private SpriteRenderer spriteJugador;
    [SerializeField] private Animator animatorJugador;

    [Header("Controladores originales")]
    [SerializeField] private RuntimeAnimatorController controladorElian;
    [SerializeField] private RuntimeAnimatorController controladorLia;

    [Header("Overrides exclusivos P3")]
    [SerializeField] private RuntimeAnimatorController overrideElianP3;
    [SerializeField] private RuntimeAnimatorController overrideLiaP3;

    private const string ESCENA_P3 = "P3_CaminoMadera";

    private void Awake()
    {
        if (spriteJugador == null)
            spriteJugador = GetComponent<SpriteRenderer>();

        if (animatorJugador == null)
            animatorJugador = GetComponent<Animator>();
    }

    public override void OnNetworkSpawn()
    {
        SceneManager.sceneLoaded += AlCargarEscena;

        ConfigurarPersonaje(
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

    private void ConfigurarPersonaje(string nombreEscena)
    {
        if (animatorJugador == null)
            return;

        if (spriteJugador != null)
            spriteJugador.color = Color.white;

        bool esElian;

#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
        {
            esElian = RolPruebaJugador.Instancia.EsElian();
        }
        else
        {
            esElian =
                OwnerClientId == NetworkManager.ServerClientId;
        }
#else
        esElian =
            OwnerClientId == NetworkManager.ServerClientId;
#endif

        RuntimeAnimatorController controladorOriginal =
            esElian ? controladorElian : controladorLia;

        RuntimeAnimatorController controladorP3 =
            esElian ? overrideElianP3 : overrideLiaP3;

        if (nombreEscena == ESCENA_P3 &&
            controladorP3 != null)
        {
            animatorJugador.runtimeAnimatorController =
                controladorP3;
        }
        else
        {
            animatorJugador.runtimeAnimatorController =
                controladorOriginal;
        }

        Debug.Log(
            "ANIMATOR CONFIGURADO | Personaje: " +
            (esElian ? "Elian" : "Lia") +
            " | Escena: " + nombreEscena
        );
    }

    private void AlCargarEscena(
        Scene escena,
        LoadSceneMode modo
    )
    {
        ConfigurarPersonaje(escena.name);

        bool mostrarJugador =
            escena.name != "01_MainMenu";

        if (spriteJugador != null)
            spriteJugador.enabled = mostrarJugador;
    }
}
