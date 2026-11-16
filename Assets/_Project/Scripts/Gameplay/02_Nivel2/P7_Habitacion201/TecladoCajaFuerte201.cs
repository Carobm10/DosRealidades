
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class TecladoCajaFuerte201 : MonoBehaviour
{
    [Header("Codigo")]
    [SerializeField] private string codigoCorrecto = "1590";
    [SerializeField] private int cantidadDigitos = 4;

    [Header("Textos")]
    [SerializeField] private TMP_Text codigoEscrito;
    [SerializeField] private TMP_Text textoMensaje;

    [Header("HUD que se oculta")]
    [SerializeField] private GameObject[] elementosHUDOcultar;

    [Header("Botones del teclado")]
    [SerializeField] private Button[] botonesBloquearAlAcertar;

    [Header("Configuracion")]
    [SerializeField] private float tiempoMensaje = 1.2f;

    [Header("Evento al acertar")]
    [SerializeField] private UnityEvent alCodigoCorrecto;

    private string codigoActual = "";
    private bool codigoAceptado;

    private bool[] estadosAnterioresHUD;
    private Coroutine rutinaMensaje;

    private void Awake()
    {
        ActualizarPantalla();

        if (textoMensaje != null)
            textoMensaje.text = "";
    }

    private void OnEnable()
    {
        GuardarYOcultarHUD();

        if (!codigoAceptado)
        {
            codigoActual = "";

            ActualizarPantalla();

            if (textoMensaje != null)
                textoMensaje.text = "";

            ActivarBotones(true);
        }
    }

    // =====================================
    // INGRESAR NUMEROS
    // =====================================

    public void AgregarDigito(string digito)
    {
        if (codigoAceptado)
            return;

        if (string.IsNullOrEmpty(digito) ||
            digito.Length != 1 ||
            !char.IsDigit(digito[0]))
            return;

        if (codigoActual.Length >= cantidadDigitos)
            return;

        codigoActual += digito;

        ActualizarPantalla();

        LimpiarMensaje();
    }

    // =====================================
    // BORRAR CODIGO
    // =====================================

    public void BorrarCodigo()
    {
        if (codigoAceptado)
            return;

        codigoActual = "";

        ActualizarPantalla();

        LimpiarMensaje();
    }

    // =====================================
    // CONFIRMAR CODIGO
    // =====================================

    public void ConfirmarCodigo()
    {
        if (codigoAceptado)
            return;

        if (codigoActual.Length != cantidadDigitos)
        {
            MostrarMensaje("Completa los cuatro digitos.");
            return;
        }

        if (codigoActual == codigoCorrecto)
        {
            codigoAceptado = true;

            MostrarMensaje("¡Bien! Codigo correcto.");

            ActivarBotones(false);

            Debug.Log("CAJA FUERTE 201: CODIGO CORRECTO");

            alCodigoCorrecto?.Invoke();
        }
        else
        {
            if (rutinaMensaje != null)
                StopCoroutine(rutinaMensaje);

            rutinaMensaje =
                StartCoroutine(MensajeIncorrecto());
        }
    }

    private IEnumerator MensajeIncorrecto()
    {
        if (textoMensaje != null)
            textoMensaje.text = "¡No! Codigo incorrecto.";

        yield return new WaitForSeconds(tiempoMensaje);

        codigoActual = "";

        ActualizarPantalla();

        if (textoMensaje != null)
            textoMensaje.text = "";

        rutinaMensaje = null;
    }

    // =====================================
    // ACTUALIZAR PANTALLA
    // =====================================

    private void ActualizarPantalla()
    {
        if (codigoEscrito == null)
            return;

        string guiones = new string(
            '_',
            Mathf.Max(0, cantidadDigitos - codigoActual.Length)
        );

        codigoEscrito.text = codigoActual + guiones;
    }

    private void MostrarMensaje(string mensaje)
    {
        if (textoMensaje != null)
            textoMensaje.text = mensaje;
    }

    private void LimpiarMensaje()
    {
        if (rutinaMensaje != null)
        {
            StopCoroutine(rutinaMensaje);
            rutinaMensaje = null;
        }

        if (textoMensaje != null)
            textoMensaje.text = "";
    }

    // =====================================
    // CERRAR PANEL
    // =====================================

    public void CerrarPanel()
    {
        gameObject.SetActive(false);
    }

    // =====================================
    // OCULTAR HUD
    // =====================================

    private void GuardarYOcultarHUD()
    {
        if (elementosHUDOcultar == null)
            return;

        estadosAnterioresHUD =
            new bool[elementosHUDOcultar.Length];

        for (int i = 0; i < elementosHUDOcultar.Length; i++)
        {
            GameObject elemento = elementosHUDOcultar[i];

            if (elemento == null)
                continue;

            estadosAnterioresHUD[i] = elemento.activeSelf;

            elemento.SetActive(false);
        }
    }

    private void RestaurarHUD()
    {
        if (elementosHUDOcultar == null ||
            estadosAnterioresHUD == null)
            return;

        for (int i = 0;
             i < elementosHUDOcultar.Length &&
             i < estadosAnterioresHUD.Length;
             i++)
        {
            if (elementosHUDOcultar[i] != null)
            {
                elementosHUDOcultar[i].SetActive(
                    estadosAnterioresHUD[i]
                );
            }
        }

        estadosAnterioresHUD = null;
    }

    private void ActivarBotones(bool estado)
    {
        if (botonesBloquearAlAcertar == null)
            return;

        foreach (Button boton in botonesBloquearAlAcertar)
        {
            if (boton != null)
                boton.interactable = estado;
        }
    }

    private void OnDisable()
    {
        if (rutinaMensaje != null)
        {
            StopCoroutine(rutinaMensaje);
            rutinaMensaje = null;
        }

        RestaurarHUD();
    }
}
