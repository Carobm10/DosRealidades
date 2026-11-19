
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

    private Transform visualJugador;

    // Identidad del jugador
    private bool esElian;
    public bool EsElian => esElian;
    public bool RolConfigurado { get; private set; }

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        ResolverReferenciasVisuales();
    }

    // =====================================
    // BUSCAR VISUAL DEL HIJO
    // =====================================

    private void ResolverReferenciasVisuales()
    {
        visualJugador = transform.Find("VisualJugador");

        if (visualJugador != null)
        {
            SpriteRenderer spriteVisual =
                visualJugador.GetComponent<SpriteRenderer>();

            Animator animatorVisual =
                visualJugador.GetComponent<Animator>();

            if (spriteVisual != null)
                spriteJugador = spriteVisual;

            if (animatorVisual != null)
                animatorJugador = animatorVisual;
        }

        // Respaldo si el prefab no tiene hijo visual.
        if (visualJugador == null)
        {
            if (spriteJugador == null)
                spriteJugador = GetComponent<SpriteRenderer>();

            if (animatorJugador == null)
                animatorJugador = GetComponent<Animator>();
        }

        Debug.Log(
            "PLAYER VISUAL | " +
            "VisualJugador: " + (visualJugador != null) +
            " | SpriteRenderer: " + (spriteJugador != null) +
            " | Animator: " + (animatorJugador != null)
        );
    }

    // =====================================
    // CREACION EN RED
    // =====================================

    public override void OnNetworkSpawn()
    {
        SceneManager.sceneLoaded += AlCargarEscena;

        string escenaActual =
            SceneManager.GetActiveScene().name;

        ConfigurarPersonaje(escenaActual);

        // IMPORTANTE:
        // La visibilidad también se configura al aparecer
        // el jugador, no solamente al cambiar de escena.

        AplicarVisibilidad(escenaActual);

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
        {
            Debug.LogError(
                "PLAYER: No se encontró Animator en VisualJugador."
            );
            return;
        }

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

        if (controladorOriginal == null &&
            (nombreEscena != ESCENA_P3 ||
             controladorP3 == null))
        {
            Debug.LogError(
                "PLAYER: Falta el Animator Controller de " +
                (esElian ? "Elian" : "Lia")
            );
        }

        Debug.Log(
            "PERSONAJE CONFIGURADO | " +
            (esElian ? "Elian" : "Lia") +
            " | Escena: " + nombreEscena
        );
    }

    // =====================================
    // VISIBILIDAD DEL PERSONAJE
    // =====================================

    private void AplicarVisibilidad(string nombreEscena)
    {
        bool mostrarJugador =
            nombreEscena != "01_MainMenu";

        // Activar el objeto visual completo.

        if (visualJugador != null &&
            visualJugador.gameObject.activeSelf != mostrarJugador)
        {
            visualJugador.gameObject.SetActive(mostrarJugador);
        }

        // Activar el SpriteRenderer correcto.

        if (spriteJugador != null)
        {
            spriteJugador.enabled = mostrarJugador;

            if (mostrarJugador)
                spriteJugador.color = Color.white;
        }

        Debug.Log(
            "PLAYER VISIBILIDAD | " +
            (esElian ? "Elian" : "Lia") +
            " | Visible: " + mostrarJugador
        );
    }

    // =====================================
    // CAMBIO DE ESCENA
    // =====================================

    private void AlCargarEscena(
        Scene escena,
        LoadSceneMode modo)
    {
        ResolverReferenciasVisuales();

        ConfigurarPersonaje(escena.name);

        AplicarVisibilidad(escena.name);
    }
}
