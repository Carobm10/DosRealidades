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

    public void MostrarBoton(string accion, ZonaInteraccion zona)
    {
        zonaActual = zona;

        if (botonInteractuar != null)
            botonInteractuar.SetActive(true);
    }

    public void OcultarBoton(ZonaInteraccion zona)
    {
        if (zonaActual != zona)
            return;

        zonaActual = null;

        if (botonInteractuar != null)
            botonInteractuar.SetActive(false);
    }

    public void Interactuar()
    {
        if (zonaActual == null)
            return;

        zonaActual.Interactuar();
    }
}