using UnityEngine;
using TMPro;

public class HUDInteraccion : MonoBehaviour
{
    public static HUDInteraccion Instancia { get; private set; }

    [Header("Interaccion")]
    [SerializeField] private GameObject botonInteractuar;
    [SerializeField] private TMP_Text textoBoton;

    private ZonaInteraccion zonaActual;

    private void Awake()
    {
        Instancia = this;

        botonInteractuar.SetActive(false);
    }

    public void MostrarBoton(
        string accion,
        ZonaInteraccion zona
    )
    {
        zonaActual = zona;

        textoBoton.text = accion;
        botonInteractuar.SetActive(true);
    }

    public void OcultarBoton(ZonaInteraccion zona)
    {
        // Evitamos que otro trigger apague
        // una interacción diferente.
        if (zonaActual != zona)
            return;

        zonaActual = null;

        botonInteractuar.SetActive(false);
    }

    public void Interactuar()
    {
        if (zonaActual == null)
            return;

        zonaActual.Interactuar();
    }
}