
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PanelSimbolosUI : MonoBehaviour
{
    public static PanelSimbolosUI Instancia { get; private set; }

    [Header("Ventana")]
    [SerializeField] private GameObject ventanaPanel;
    [SerializeField] private Image imagenPanel;
    [SerializeField] private TMP_Text textoResultado;

    [Header("Boton cerrar")]
    [SerializeField] private Button botonCerrar;

    [Header("Controlador del puzzle")]
    [SerializeField] private P1ElUmbralController controladorPuzzle;

    [Header("Sprites del panel")]
    [SerializeField] private Sprite panelNormal;
    [SerializeField] private Sprite panelCirculo;
    [SerializeField] private Sprite panelTriangulo;
    [SerializeField] private Sprite panelCuadrado;

    [Header("Tiempos")]
    [SerializeField] private float tiempoMensaje = 0.5f;

    private Coroutine rutinaResultado;

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

        if (controladorPuzzle == null)
        {
            controladorPuzzle =
                FindAnyObjectByType<P1ElUmbralController>();
        }

        if (botonCerrar != null)
        {
            botonCerrar.onClick.AddListener(CerrarPanel);
        }

        RestablecerPanel();
    }

    private void OnDestroy()
    {
        if (botonCerrar != null)
        {
            botonCerrar.onClick.RemoveListener(CerrarPanel);
        }

        if (Instancia == this)
        {
            Instancia = null;
        }
    }

    // =====================================
    // SELECCION DE SIMBOLOS
    // =====================================

    public void SeleccionarCirculo()
    {
        MostrarSeleccion(panelCirculo, false);
    }

    public void SeleccionarTriangulo()
    {
        MostrarSeleccion(panelTriangulo, true);
    }

    public void SeleccionarCuadrado()
    {
        MostrarSeleccion(panelCuadrado, false);
    }

    // =====================================
    // MOSTRAR RESULTADO
    // =====================================

    private void MostrarSeleccion(
        Sprite spriteSeleccionado,
        bool correcto)
    {
        if (rutinaResultado != null)
        {
            StopCoroutine(rutinaResultado);
        }

        rutinaResultado = StartCoroutine(
            AnimarResultado(spriteSeleccionado, correcto)
        );
    }

    private IEnumerator AnimarResultado(
        Sprite spriteSeleccionado,
        bool correcto)
    {
        if (imagenPanel != null &&
            spriteSeleccionado != null)
        {
            imagenPanel.sprite = spriteSeleccionado;
        }

        if (textoResultado != null)
        {
            textoResultado.gameObject.SetActive(true);

            textoResultado.text = correcto
                ? "CORRECTO"
                : "INCORRECTO";
        }

        yield return new WaitForSeconds(tiempoMensaje);

        if (textoResultado != null)
        {
            textoResultado.gameObject.SetActive(false);
        }

        if (correcto)
        {
            if (ventanaPanel != null)
                ventanaPanel.SetActive(false);
        }
        else
        {
            if (imagenPanel != null && panelNormal != null)
            {
                imagenPanel.sprite = panelNormal;
            }
        }

        rutinaResultado = null;
    }

    // =====================================
    // CERRAR PANEL
    // =====================================

    public void CerrarPanel()
    {
        if (controladorPuzzle == null)
        {
            controladorPuzzle =
                FindAnyObjectByType<P1ElUmbralController>();
        }

        if (controladorPuzzle != null)
        {
            controladorPuzzle.SolicitarReinicioPuzzle();
        }

        if (ventanaPanel != null)
        {
            ventanaPanel.SetActive(false);
        }

        RestablecerPanel();

        Debug.Log(
            "P1: jugador cerro el panel. " +
            "Solicitud de reinicio enviada."
        );
    }

    // =====================================
    // RESTABLECER INTERFAZ
    // =====================================

    public void RestablecerPanel()
    {
        if (rutinaResultado != null)
        {
            StopCoroutine(rutinaResultado);
            rutinaResultado = null;
        }

        if (textoResultado != null)
        {
            textoResultado.gameObject.SetActive(false);
            textoResultado.text = "";
        }

        if (imagenPanel != null && panelNormal != null)
        {
            imagenPanel.sprite = panelNormal;
        }
    }
}
