
using UnityEngine;
using UnityEngine.UI;

public class VisualBotonInteractuar : MonoBehaviour
{
    [SerializeField] private Image imagenBoton;

    [Header("Sprites")]
    [SerializeField] private Sprite botonElian;
    [SerializeField] private Sprite botonLia;

    private void Awake()
    {
        if (imagenBoton == null)
            imagenBoton = GetComponent<Image>();
    }

    private void Start()
    {
        AplicarVisual();
    }

    private void AplicarVisual()
    {
        if (imagenBoton == null)
        {
            Debug.LogWarning(
                "VisualBotonInteractuar: falta asignar la imagen."
            );
            return;
        }

        imagenBoton.sprite = IdentidadJugadorLocal.EsElian()
            ? botonElian
            : botonLia;
    }
}
