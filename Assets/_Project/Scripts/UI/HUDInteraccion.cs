
using UnityEngine;
using Unity.Netcode;

public class HUDInteraccion : MonoBehaviour
{
    public static HUDInteraccion Instancia { get; private set; }

    [Header("Boton de interaccion")]
    [SerializeField] private GameObject botonInteractuar;

    [Header("Camara del juego - opcional")]
    [SerializeField] private Camera camaraJuego;

    [Header("Ventanas que ocultan INTERACTUAR")]
    [SerializeField] private GameObject[] ventanasBloqueantes;

    private ZonaInteraccion zonaActual;
    private RectTransform botonRect;
    private RectTransform padreRect;
    private Canvas canvas;

    private float posicionZOriginal;

    // =====================================
    // INICIO
    // =====================================

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
        if (botonInteractuar == null)
            return;

        // Mientras una ventana del puzzle esta abierta,
        // no permitir mostrar el boton flotante.

        if (HayVentanaBloqueanteAbierta())
        {
            if (botonInteractuar.activeSelf)
                botonInteractuar.SetActive(false);

            return;
        }

        // No existe ninguna zona de interaccion actual.
        if (zonaActual == null)
        {
            if (botonInteractuar.activeSelf)
                botonInteractuar.SetActive(false);

            return;
        }

        // Si el jugador sigue dentro de la zona
        // y cerro el puzzle, recuperar el boton.

        if (!botonInteractuar.activeSelf)
            botonInteractuar.SetActive(true);

        ActualizarPosicion();
    }

    // =====================================
    // DETECTAR VENTANAS ABIERTAS
    // =====================================

    private bool HayVentanaBloqueanteAbierta()
    {
        if (ventanasBloqueantes == null)
            return false;

        foreach (GameObject ventana in ventanasBloqueantes)
        {
            if (ventana != null &&
                ventana.activeInHierarchy)
            {
                return true;
            }
        }

        return false;
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

        if (HayVentanaBloqueanteAbierta())
        {
            if (botonInteractuar != null)
                botonInteractuar.SetActive(false);

            return;
        }

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

        // Conservamos localPosition para respetar
        // el PuntoIndicador y la configuracion
        // actual del RectTransform del boton.

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
        if (zonaActual == null ||
            HayVentanaBloqueanteAbierta())
        {
            return;
        }

        zonaActual.Interactuar();

        // Comprobar si esta interaccion abrio
        // alguna ventana del rompecabezas.

        if (HayVentanaBloqueanteAbierta() &&
            botonInteractuar != null)
        {
            botonInteractuar.SetActive(false);
        }
    }

    // =====================================
    // COMPATIBILIDAD P3
    // =====================================

    public void ComenzarMantener()
    {
        if (zonaActual == null ||
            HayVentanaBloqueanteAbierta())
        {
            return;
        }

        zonaActual.ComenzarMantener();
    }

    public void TerminarMantener()
    {
        if (zonaActual == null)
            return;

        zonaActual.TerminarMantener();
    }

    // =====================================
    // LIMPIEZA
    // =====================================

    private void OnDestroy()
    {
        if (Instancia == this)
            Instancia = null;
    }
}
