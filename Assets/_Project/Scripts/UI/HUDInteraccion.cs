
using UnityEngine;

public class HUDInteraccion : MonoBehaviour
{
    public static HUDInteraccion Instancia { get; private set; }

    [Header("Boton de interaccion")]
    [SerializeField] private GameObject botonInteractuar;

    [Header("Camara del juego")]
    [SerializeField] private Camera camaraJuego;

    private ZonaInteraccion zonaActual;

    private RectTransform botonRect;
    private RectTransform canvasRect;
    private Canvas canvas;

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        Instancia = this;

        if (botonInteractuar != null)
        {
            botonRect =
                botonInteractuar.GetComponent<RectTransform>();

            canvas =
                botonInteractuar.GetComponentInParent<Canvas>();

            if (canvas != null)
            {
                canvas = canvas.rootCanvas;
                canvasRect = canvas.transform as RectTransform;
            }

            botonInteractuar.SetActive(false);
        }

        if (camaraJuego == null)
            camaraJuego = Camera.main;
    }

    private void LateUpdate()
    {
        if (zonaActual != null)
            ActualizarPosicion();

        if (camaraJuego == null)
            camaraJuego = Camera.main;
    }

    // =====================================
    // MOSTRAR BOTON
    // =====================================

    public void MostrarBoton(
        string accion,
        ZonaInteraccion zona)
    {
        if (zona == null)
            return;

        zonaActual = zona;

        if (botonInteractuar != null)
            botonInteractuar.SetActive(true);

        ActualizarPosicion();
    }

    // =====================================
    // POSICION MANUAL DEL EMPTY
    // =====================================

    
    private void ActualizarPosicion()
    {
        if (zonaActual == null ||
            botonRect == null ||
            camaraJuego == null)
            return;

        if (camaraJuego == null)
            camaraJuego = Camera.main;

        if (camaraJuego == null)
            return;

        RectTransform padreRect =
            botonRect.parent as RectTransform;

        if (padreRect == null)
            return;

        Vector3 posicionMundo =
            zonaActual.ObtenerPosicionIndicador();

        Vector3 posicionPantalla =
            camaraJuego.WorldToScreenPoint(posicionMundo);

        if (posicionPantalla.z <= 0f)
            return;

        Camera camaraUI = null;

        if (canvas != null &&
            canvas.renderMode != RenderMode.ScreenSpaceOverlay)
        {
            camaraUI = canvas.worldCamera != null
                ? canvas.worldCamera
                : camaraJuego;
        }

        bool convertido =
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                padreRect,
                new Vector2(
                    posicionPantalla.x,
                    posicionPantalla.y
                ),
                camaraUI,
                out Vector2 posicionLocal
            );

        if (convertido)
        {
            botonRect.anchoredPosition = posicionLocal;
        }
    }


    // =====================================
    // OCULTAR BOTON
    // =====================================

    public void OcultarBoton(ZonaInteraccion zona)
    {
        if (zonaActual != zona)
            return;

        ZonaInteraccion anterior = zonaActual;
        zonaActual = null;

        anterior.TerminarMantener();

        if (botonInteractuar != null)
            botonInteractuar.SetActive(false);
    }

    public void OcultarBotonActual()
    {
        if (zonaActual != null)
        {
            ZonaInteraccion anterior = zonaActual;
            zonaActual = null;

            anterior.TerminarMantener();
        }

        if (botonInteractuar != null)
            botonInteractuar.SetActive(false);
    }

    // =====================================
    // INTERACCION NORMAL
    // =====================================

    public void Interactuar()
    {
        if (zonaActual == null)
            return;

        zonaActual.Interactuar();
    }

    // =====================================
    // PULSACION MANTENIDA P3
    // =====================================

    public void ComenzarMantener()
    {
        if (zonaActual == null)
            return;

        zonaActual.ComenzarMantener();
    }

    public void TerminarMantener()
    {
        if (zonaActual == null)
            return;

        zonaActual.TerminarMantener();
    }

    // =====================================
    // CIERRE
    // =====================================

    private void OnDestroy()
    {
        if (Instancia == this)
            Instancia = null;
    }
}
