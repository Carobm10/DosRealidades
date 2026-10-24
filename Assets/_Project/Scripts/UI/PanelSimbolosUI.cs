using UnityEngine;
using TMPro;
using System.Collections;

public class PanelSimbolosUI : MonoBehaviour
{
    public static PanelSimbolosUI Instancia { get; private set; }

    [Header("Ventana")]
    [SerializeField] private GameObject ventanaPanel;
    [SerializeField] private TMP_Text textoTitulo;

    [Header("Tiempos")]
    [SerializeField] private float tiempoMensaje = 0.8f;

    private string textoOriginal;
    private Color colorOriginal;

    private Coroutine rutinaResultado;

    private void Awake()
    {
        Instancia = this;

        textoOriginal = textoTitulo.text;
        colorOriginal = textoTitulo.color;
    }

    public void MostrarResultado(bool correcto)
    {
        if (rutinaResultado != null)
        {
            StopCoroutine(rutinaResultado);
        }

        rutinaResultado =
            StartCoroutine(AnimarResultado(correcto));
    }

    private IEnumerator AnimarResultado(bool correcto)
    {
        if (correcto)
        {
            textoTitulo.text = "CORRECTO";
            textoTitulo.color = Color.green;

            yield return new WaitForSeconds(tiempoMensaje);

            ventanaPanel.SetActive(false);
        }
        else
        {
            textoTitulo.text = "INCORRECTO";
            textoTitulo.color = Color.red;

            yield return new WaitForSeconds(tiempoMensaje);

            textoTitulo.text = textoOriginal;
            textoTitulo.color = colorOriginal;
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