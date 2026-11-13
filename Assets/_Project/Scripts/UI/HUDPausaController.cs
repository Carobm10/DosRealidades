
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class HUDPausaController : MonoBehaviour
{
    public static HUDPausaController Instancia
        { get; private set; }

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

    private bool reinicioSolicitado;

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
            botonMenuPrincipal.onClick.AddListener(
                VolverMenuPrincipal
            );

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
            botonMenuPrincipal.onClick.RemoveListener(
                VolverMenuPrincipal
            );

        if (botonSalir != null)
            botonSalir.onClick.RemoveListener(SalirJuego);

        Instancia = null;
    }

    // =====================================
    // JUGADOR LOCAL
    // =====================================

    private void ObtenerMovimientoLocal()
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red == null ||
            red.LocalClient == null ||
            red.LocalClient.PlayerObject == null)
        {
            movimientoLocal = null;
            return;
        }

        movimientoLocal =
            red.LocalClient.PlayerObject
                .GetComponent<NetworkPlayerMovement>();
    }

    // =====================================
    // ABRIR PAUSA
    // =====================================

    public void AbrirPausa()
    {
        if (pausaAbierta || reinicioSolicitado)
            return;

        if (panelReconectando != null &&
            panelReconectando.activeInHierarchy)
            return;

        if (panelPausa == null)
        {
            Debug.LogError(
                "PAUSA: no se asigno PanelPausa."
            );
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
    }

    // =====================================
    // CONTINUAR
    // =====================================

    public void Continuar()
    {
        if (!pausaAbierta || reinicioSolicitado)
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
    }

    // =====================================
    // OCULTAR CONTROLES
    // =====================================

    public void OcultarControlesJuego()
    {
        if (controlesOcultos ||
            elementosHUDJuego == null)
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
    // RESTAURAR CONTROLES
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
        estadosOriginales = null;
    }

    // =====================================
    // RECONEXION
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
    }

    // =====================================
    // REINICIO COOPERATIVO
    // =====================================

    public void ReiniciarNivel()
    {
        if (reinicioSolicitado)
            return;

        NetworkManager red = NetworkManager.Singleton;

        if (red == null || !red.IsListening)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name
            );
            return;
        }

        ReinicioNivelCooperativo controlador =
            ReinicioNivelCooperativo.Instancia;

        if (controlador == null ||
            !controlador.IsSpawned)
        {
            Debug.LogError(
                "REINICIO: falta ReinicioNivelCooperativo " +
                "activo y sincronizado en la escena."
            );
            return;
        }

        reinicioSolicitado = true;

        controlador.SolicitarReinicio();

        Debug.Log(
            "PAUSA: reinicio cooperativo solicitado."
        );
    }

    // =====================================
    // PREPARAR PARA REINICIO
    // =====================================

    public void PrepararParaReinicio()
    {
        pausaAbierta = false;
        reinicioSolicitado = false;

        movimientoBloqueadoAntesPausa = false;

        if (panelPausa != null)
            panelPausa.SetActive(false);

        RestaurarControlesJuego();

        ObtenerMovimientoLocal();

        if (movimientoLocal != null)
        {
            movimientoLocal.ActivarModoPuente(false);
            movimientoLocal.BloquearMovimiento(false);
        }

        Debug.Log(
            "PAUSA: controles restaurados para reinicio."
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
    // SALIR
    // =====================================

    public void SalirJuego()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
