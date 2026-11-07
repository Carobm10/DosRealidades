
using UnityEngine;

public class HUDInteraccion : MonoBehaviour
{
    public static HUDInteraccion Instancia { get; private set; }

    [SerializeField] private GameObject botonInteractuar;

    private ZonaInteraccion zonaActual;

    private void Awake()
    {
        Instancia = this;

        if (botonInteractuar != null)
            botonInteractuar.SetActive(false);
    }

    private void OnDestroy()
    {
        if (Instancia == this)
            Instancia = null;
    }

    public void MostrarBoton(
        string accion,
        ZonaInteraccion zona)
    {
        zonaActual = zona;

        if (botonInteractuar != null)
            botonInteractuar.SetActive(true);
    }

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

    // Ocultar el botón cuando termina la interacción.
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

    // Interacciones normales.
    public void Interactuar()
    {
        if (zonaActual == null)
            return;

        zonaActual.Interactuar();
    }

    // Comienza la pulsación mantenida.
    public void ComenzarMantener()
    {
        if (zonaActual == null)
            return;

        zonaActual.ComenzarMantener();
    }

    // Termina la pulsación mantenida.
    public void TerminarMantener()
    {
        if (zonaActual == null)
            return;

        zonaActual.TerminarMantener();
    }
}
