
using UnityEngine;
using UnityEngine.EventSystems;

public class PulsacionMantenidaHUD : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerExitHandler
{
    private bool presionando;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (presionando)
            return;

        presionando = true;
        HUDInteraccion.Instancia?.ComenzarMantener();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        FinalizarPresion();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FinalizarPresion();
    }

    private void FinalizarPresion()
    {
        if (!presionando)
            return;

        presionando = false;
        HUDInteraccion.Instancia?.TerminarMantener();
    }

    private void OnDisable()
    {
        FinalizarPresion();
    }
}
