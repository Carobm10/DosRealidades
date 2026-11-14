
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIObjetoRecolectado : MonoBehaviour
{
    [Header("Ventana")]
    [SerializeField] private GameObject panelPrincipal;

    [Header("Contenido")]
    [SerializeField] private Image imagenObjeto;
    [SerializeField] private TMP_Text textoTitulo;
    [SerializeField] private TMP_Text textoDescripcion;

    [Header("Boton")]
    [SerializeField] private Button botonCerrar;

    [Header("HUD que se oculta al mostrar la recompensa")]
    [SerializeField] private GameObject[] elementosHUDOcultar;

    private bool[] estadosAnterioresHUD;

    private Action accionAlCerrar;
    private bool ventanaAbierta;

    private void Awake()
    {
        if (panelPrincipal == null)
            panelPrincipal = gameObject;

        if (botonCerrar != null)
            botonCerrar.onClick.AddListener(Cerrar);

        panelPrincipal.SetActive(false);
    }

    public void Mostrar(
        string titulo,
        string descripcion,
        Sprite imagen,
        Action alCerrar = null)
    {
        if (ventanaAbierta)
            return;

        accionAlCerrar = alCerrar;
        ventanaAbierta = true;

        if (textoTitulo != null)
            textoTitulo.text = titulo;

        if (textoDescripcion != null)
            textoDescripcion.text = descripcion;

        if (imagenObjeto != null)
        {
            imagenObjeto.sprite = imagen;
            imagenObjeto.enabled = imagen != null;
        }

        OcultarHUD();

        panelPrincipal.SetActive(true);
    }

    private void OcultarHUD()
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

            // Guardar su estado original.
            estadosAnterioresHUD[i] = elemento.activeSelf;

            elemento.SetActive(false);
        }
    }

    private void RestaurarHUD()
    {
        if (elementosHUDOcultar == null ||
            estadosAnterioresHUD == null)
            return;

        int cantidad = Mathf.Min(
            elementosHUDOcultar.Length,
            estadosAnterioresHUD.Length
        );

        for (int i = 0; i < cantidad; i++)
        {
            GameObject elemento = elementosHUDOcultar[i];

            if (elemento == null)
                continue;

            // Restaurar exactamente como estaba.
            elemento.SetActive(estadosAnterioresHUD[i]);
        }

        estadosAnterioresHUD = null;
    }

    public void Cerrar()
    {
        if (!ventanaAbierta)
            return;

        ventanaAbierta = false;

        Action accion = accionAlCerrar;
        accionAlCerrar = null;

        panelPrincipal.SetActive(false);

        RestaurarHUD();

        // Continuar con la accion del nivel,
        // si se ha configurado alguna.
        accion?.Invoke();
    }

    public bool EstaAbierta => ventanaAbierta;

    private void OnDestroy()
    {
        if (botonCerrar != null)
            botonCerrar.onClick.RemoveListener(Cerrar);

        if (ventanaAbierta)
            RestaurarHUD();
    }
}
