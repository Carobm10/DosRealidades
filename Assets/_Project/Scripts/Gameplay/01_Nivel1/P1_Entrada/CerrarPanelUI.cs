using UnityEngine;

public class CerrarPanelUI : MonoBehaviour
{
    [Header("Panel que se va a cerrar")]
    [SerializeField] private GameObject panelACerrar;

    [Header("Controlador del puzzle")]
    [SerializeField] private PuzzleRecepcionController puzzleController;

    public void CerrarPanel()
    {
        // Reiniciar el acertijo.
        if (puzzleController != null)
        {
            puzzleController.SolicitarReinicio();
        }

        // Cerrar la ventana correspondiente.
        if (panelACerrar != null)
        {
            panelACerrar.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}