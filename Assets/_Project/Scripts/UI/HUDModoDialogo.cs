
using UnityEngine;

public class HUDModoDialogo : MonoBehaviour
{
    [Header("Elementos del HUD que se ocultan")]
    [SerializeField] private CanvasGroup[] elementosHUD;

    private float[] alphasOriginales;
    private bool[] interactivosOriginales;
    private bool[] raycastsOriginales;

    private bool hudOculto;

    public void OcultarHUD()
    {
        if (hudOculto || elementosHUD == null)
            return;

        int cantidad = elementosHUD.Length;

        alphasOriginales = new float[cantidad];
        interactivosOriginales = new bool[cantidad];
        raycastsOriginales = new bool[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            CanvasGroup grupo = elementosHUD[i];

            if (grupo == null)
                continue;

            alphasOriginales[i] = grupo.alpha;
            interactivosOriginales[i] = grupo.interactable;
            raycastsOriginales[i] = grupo.blocksRaycasts;

            grupo.alpha = 0f;
            grupo.interactable = false;
            grupo.blocksRaycasts = false;
        }

        hudOculto = true;
    }

    public void RestaurarHUD()
    {
        if (!hudOculto)
            return;

        for (int i = 0; i < elementosHUD.Length; i++)
        {
            CanvasGroup grupo = elementosHUD[i];

            if (grupo == null)
                continue;

            grupo.alpha = alphasOriginales[i];
            grupo.interactable = interactivosOriginales[i];
            grupo.blocksRaycasts = raycastsOriginales[i];
        }

        hudOculto = false;
    }

    private void OnDisable()
    {
        RestaurarHUD();
    }
}
