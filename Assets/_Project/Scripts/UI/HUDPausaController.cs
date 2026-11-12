
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class HUDPausaController : MonoBehaviour
{
    public static HUDPausaController Instancia { get; private set; }

    [Header("Panel de pausa")]
    [SerializeField] private GameObject panelPausa;

    [Header("Panel de reconexion")]
    [SerializeField] private GameObject panelReconectando;

    [Header("Boton que abre la pausa")]
    [SerializeField] private Button botonAbrirPausa;

    [Header("Botones del panel")]
    [SerializeField] private Button botonCerrar;
    [SerializeField] private Button botonContinuar;
    [SerializeField] private Button botonReiniciar;
    [SerializeField] private Button botonMenuPrincipal;
    [SerializeField] private Button botonSalir;

    [Header("Elementos del HUD que se ocultan")]
    [SerializeField] private GameObject[] elementosHUDJuego;

    private NetworkPlayerMovement movimientoLocal;

    private bool pausaAbierta;
    private bool movimientoBloqueadoAntesPausa;

    private bool controlesOcultos;
    private bool[] estadosOriginales;

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            Destroy(this);
            return;
        }

        Instancia = this;

        if (botonAbrirPausa != null)
            botonAbrirPausa.onClick.AddListener(AbrirPausa);

        if (botonCerrar != null)
            botonCerrar.onClick.AddListener(Continuar);

        if (botonContinuar != null)
            botonContinuar.onClick.AddListener(Continuar);

        if (botonReiniciar != null)
            botonReiniciar.onClick.AddListener(ReiniciarNivel);

        if (botonMenuPrincipal != null)
            botonMenuPrincipal.onClick.AddListener(VolverMenuPrincipal);

        if (botonSalir != null)
            botonSalir.onClick.AddListener(SalirJuego);
    }

    private void Start()
    {
        if (panelPausa != null)
            panelPausa.SetActive(false);

        ObtenerMovimientoLocal();
    }

    private void OnDestroy()
    {
        if (Instancia != this)
            return;

        if (botonAbrirPausa != null)
            botonAbrirPausa.onClick.RemoveListener(AbrirPausa);

        if (botonCerrar != null)
            botonCerrar.onClick.RemoveListener(Continuar);

        if (botonContinuar != null)
            botonContinuar.onClick.RemoveListener(Continuar);

        if (botonReiniciar != null)
            botonReiniciar.onClick.RemoveListener(ReiniciarNivel);

        if (botonMenuPrincipal != null)
            botonMenuPrincipal.onClick.RemoveListener(VolverMenuPrincipal);

        if (botonSalir != null)
            botonSalir.onClick.RemoveListener(SalirJuego);

        Instancia = null;
    }

    // =====================================
    // OBTENER JUGADOR LOCAL
    // =====================================

    private void ObtenerMovimientoLocal()
    {
        if (NetworkManager.Singleton == null ||
            NetworkManager.Singleton.LocalClient == null ||
            NetworkManager.Singleton.LocalClient.PlayerObject == null)
        {
            movimientoLocal = null;
            return;
        }

        movimientoLocal =
            NetworkManager.Singleton.LocalClient.PlayerObject
                .GetComponent<NetworkPlayerMovement>();
    }

    // =====================================
    // ABRIR PAUSA
    // =====================================

    public void AbrirPausa()
    {
        if (pausaAbierta)
            return;

        // No permitir pausa durante reconexion.

        if (panelReconectando != null &&
            panelReconectando.activeInHierarchy)
        {
            return;
        }

        if (panelPausa == null)
        {
            Debug.LogError("No se asigno PanelPausa.");
            return;
        }

        ObtenerMovimientoLocal();

        if (movimientoLocal != null)
        {
            movimientoBloqueadoAntesPausa =
                movimientoLocal.MovimientoBloqueado;

            movimientoLocal.BloquearMovimiento(true);
        }

        pausaAbierta = true;

        OcultarControlesJuego();

        panelPausa.SetActive(true);

        Debug.Log("PAUSA: abierta.");
    }

    // =====================================
    // CONTINUAR
    // =====================================

    public void Continuar()
    {
        if (!pausaAbierta)
            return;

        pausaAbierta = false;

        if (panelPausa != null)
            panelPausa.SetActive(false);

        RestaurarControlesJuego();

        ObtenerMovimientoLocal();

        if (movimientoLocal != null)
        {
            movimientoLocal.BloquearMovimiento(
                movimientoBloqueadoAntesPausa
            );
        }

        Debug.Log("PAUSA: juego reanudado.");
    }

    // =====================================
    // OCULTAR CONTROLES DEL HUD
    // =====================================

    public void OcultarControlesJuego()
    {
        if (controlesOcultos)
            return;

        if (elementosHUDJuego == null)
            return;

        estadosOriginales =
            new bool[elementosHUDJuego.Length];

        for (int i = 0; i < elementosHUDJuego.Length; i++)
        {
            if (elementosHUDJuego[i] == null)
                continue;

            estadosOriginales[i] =
                elementosHUDJuego[i].activeSelf;

            elementosHUDJuego[i].SetActive(false);
        }

        controlesOcultos = true;
    }

    // =====================================
    // RESTAURAR CONTROLES DEL HUD
    // =====================================

    public void RestaurarControlesJuego()
    {
        if (!controlesOcultos ||
            estadosOriginales == null)
            return;

        for (int i = 0; i < elementosHUDJuego.Length; i++)
        {
            if (elementosHUDJuego[i] == null)
                continue;

            elementosHUDJuego[i].SetActive(
                estadosOriginales[i]
            );
        }

        controlesOcultos = false;
    }

    // =====================================
    // CERRAR PAUSA POR RECONEXION
    // =====================================

    public void CerrarPausaPorReconectar()
    {
        pausaAbierta = false;

        if (panelPausa != null)
            panelPausa.SetActive(false);

        ObtenerMovimientoLocal();

        if (movimientoLocal != null)
            movimientoLocal.BloquearMovimiento(true);

        OcultarControlesJuego();

        Debug.Log(
            "HUD: controles ocultos por reconexion."
        );
    }

    // =====================================
    // REINICIAR NIVEL
    // =====================================

    public void ReiniciarNivel()
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red == null || !red.IsListening)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name
            );

            return;
        }

        // Por ahora el reinicio lo ejecuta el Host.
        // Despues conectaremos la solicitud del Client.

        if (!red.IsHost)
        {
            Debug.LogWarning(
                "El reinicio cooperativo debe solicitarse al Host."
            );

            return;
        }

        string escenaActual =
            SceneManager.GetActiveScene().name;

        Debug.Log(
            "PAUSA: reiniciando nivel " + escenaActual
        );

        red.SceneManager.LoadScene(
            escenaActual,
            LoadSceneMode.Single
        );
    }

    // =====================================
    // VOLVER AL MENU PRINCIPAL
    // =====================================

    public void VolverMenuPrincipal()
    {
        if (GestorMultijugador.Instancia != null)
        {
            GestorMultijugador.Instancia
                .VolverAlMenuPrincipal();
        }
        else
        {
            SceneManager.LoadScene("01_MainMenu");
        }
    }

    // =====================================
    // SALIR DEL JUEGO
    // =====================================

    public void SalirJuego()
    {
        Debug.Log("PAUSA: salir del juego.");

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
