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

    [Header("Sprites del panel")]
    [SerializeField] private Sprite panelNormal;
    [SerializeField] private Sprite panelCirculo;
    [SerializeField] private Sprite panelTriangulo;
    [SerializeField] private Sprite panelCuadrado;

    [Header("Tiempos")]
    [SerializeField] private float tiempoMensaje = 0.5f;

    private Coroutine rutinaResultado;

    private void Awake()
    {
        Instancia = this;

        if (textoResultado != null)
        {
            textoResultado.gameObject.SetActive(false);
        }

        if (imagenPanel != null && panelNormal != null)
        {
            imagenPanel.sprite = panelNormal;
        }
    }

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

    private void MostrarSeleccion(Sprite spriteSeleccionado, bool correcto)
    {
        if (rutinaResultado != null)
        {
            StopCoroutine(rutinaResultado);
        }

        rutinaResultado =
            StartCoroutine(AnimarResultado(spriteSeleccionado, correcto));
    }

    private IEnumerator AnimarResultado(
        Sprite spriteSeleccionado,
        bool correcto
    )
    {
        if (imagenPanel != null && spriteSeleccionado != null)
        {
            imagenPanel.sprite = spriteSeleccionado;
        }

        if (textoResultado != null)
        {
            textoResultado.gameObject.SetActive(true);

            if (correcto)
            {
                textoResultado.text = "CORRECTO";
                textoResultado.color = Color.green;
            }
            else
            {
                textoResultado.text = "INCORRECTO";
                textoResultado.color = Color.red;
            }
        }

        yield return new WaitForSeconds(tiempoMensaje);

        if (textoResultado != null)
        {
            textoResultado.gameObject.SetActive(false);
        }

        if (correcto)
        {
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

    private void OnDestroy()
    {
        if (Instancia == this)
        {
            Instancia = null;
        }
    }
}