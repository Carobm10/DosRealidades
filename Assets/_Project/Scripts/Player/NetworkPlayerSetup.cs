
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

    // Identidad del jugador
    private bool esElian;
    public bool EsElian => esElian;
    public bool RolConfigurado { get; private set; }

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
            " | Personaje: " + (esElian ? "Elian" : "Lia") +
            " | IsOwner: " + IsOwner +
            " | IsServer: " + IsServer
        );
    }

    public override void OnNetworkDespawn()
    {
        SceneManager.sceneLoaded -= AlCargarEscena;
    }

    // =====================================
    // IDENTIFICAR PERSONAJE
    // =====================================

    private bool DeterminarPersonaje()
    {
#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
        {
            return RolPruebaJugador.Instancia.EsElian();
        }
#endif

        return OwnerClientId == NetworkManager.ServerClientId;
    }

    // =====================================
    // CONFIGURAR PERSONAJE
    // =====================================

    private void ConfigurarPersonaje(string nombreEscena)
    {
        esElian = DeterminarPersonaje();
        RolConfigurado = true;

        if (spriteJugador != null)
            spriteJugador.color = Color.white;

        if (animatorJugador == null)
            return;

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
            "PERSONAJE CONFIGURADO | " +
            (esElian ? "Elian" : "Lia") +
            " | Escena: " + nombreEscena
        );
    }

    // =====================================
    // CAMBIO DE ESCENA
    // =====================================

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
