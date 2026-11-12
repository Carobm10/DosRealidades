
using UnityEngine;
using Unity.Netcode;

public class HUDInteraccion : MonoBehaviour
{
    public static HUDInteraccion Instancia { get; private set; }

    [Header("Boton de interaccion")]
    [SerializeField] private GameObject botonInteractuar;

    [Header("Camara del juego - opcional")]
    [SerializeField] private Camera camaraJuego;

    private ZonaInteraccion zonaActual;
    private RectTransform botonRect;
    private RectTransform padreRect;
    private Canvas canvas;

    private float posicionZOriginal;

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

            if (botonRect != null)
            {
                padreRect =
                    botonRect.parent as RectTransform;

                posicionZOriginal =
                    botonRect.localPosition.z;
            }

            canvas =
                botonInteractuar.GetComponentInParent<Canvas>();

            if (canvas != null)
                canvas = canvas.rootCanvas;

            botonInteractuar.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        if (zonaActual == null)
            return;

        ActualizarPosicion();
    }

    // =====================================
    // OBTENER CAMARA DEL JUGADOR LOCAL
    // =====================================

    private Camera ObtenerCamaraLocal()
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red != null &&
            red.LocalClient != null &&
            red.LocalClient.PlayerObject != null)
        {
            Camera[] camaras =
                red.LocalClient.PlayerObject
                    .GetComponentsInChildren<Camera>(true);

            foreach (Camera camara in camaras)
            {
                if (camara != null &&
                    camara.isActiveAndEnabled)
                {
                    return camara;
                }
            }
        }

        if (camaraJuego != null &&
            camaraJuego.isActiveAndEnabled)
        {
            return camaraJuego;
        }

        return Camera.main;
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
    // POSICION EXACTA EN PUNTO INDICADOR
    // =====================================

    private void ActualizarPosicion()
    {
        if (zonaActual == null ||
            botonRect == null ||
            padreRect == null)
        {
            return;
        }

        Camera camara = ObtenerCamaraLocal();

        if (camara == null)
            return;

        Vector3 posicionMundo =
            zonaActual.ObtenerPosicionIndicador();

        Vector3 posicionPantalla =
            camara.WorldToScreenPoint(posicionMundo);

        if (posicionPantalla.z <= 0f)
            return;

        Camera camaraUI = null;

        if (canvas != null &&
            canvas.renderMode != RenderMode.ScreenSpaceOverlay)
        {
            camaraUI = canvas.worldCamera != null
                ? canvas.worldCamera
                : camara;
        }

        bool convertido =
            RectTransformUtility
                .ScreenPointToLocalPointInRectangle(
                    padreRect,
                    new Vector2(
                        posicionPantalla.x,
                        posicionPantalla.y
                    ),
                    camaraUI,
                    out Vector2 posicionLocal
                );

        if (!convertido)
            return;

        // IMPORTANTE:
        // localPosition toma como referencia
        // el pivot del objeto padre.
        //
        // No depende de los anchors del boton.

        botonRect.localPosition = new Vector3(
            posicionLocal.x,
            posicionLocal.y,
            posicionZOriginal
        );
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

        if (anterior != null)
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

            if (anterior != null)
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
    // COMPATIBILIDAD P3
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

    private void OnDestroy()
    {
        if (Instancia == this)
            Instancia = null;
    }
}
