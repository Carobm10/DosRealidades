
using UnityEngine;
using UnityEngine.UI;

public class VisualJoystickJugador : MonoBehaviour
{
    [Header("Componentes del joystick")]
    [SerializeField] private Image imagenCentro;
    [SerializeField] private Image imagenBase;
    [SerializeField] private Image imagenBolita;

    [Header("Elian - Azul")]
    [SerializeField] private Sprite centroElian;
    [SerializeField] private Sprite baseElian;
    [SerializeField] private Sprite bolitaElian;

    [Header("Lia - Morado")]
    [SerializeField] private Sprite centroLia;
    [SerializeField] private Sprite baseLia;
    [SerializeField] private Sprite bolitaLia;

    private void Start()
    {
        AplicarVisualJugador();
    }

    private void AplicarVisualJugador()
    {
        if (IdentidadJugadorLocal.EsElian())
        {
            AplicarElian();
        }
        else
        {
            AplicarLia();
        }
    }

    private void AplicarElian()
    {
        if (imagenCentro != null)
            imagenCentro.sprite = centroElian;

        if (imagenBase != null)
            imagenBase.sprite = baseElian;

        if (imagenBolita != null)
            imagenBolita.sprite = bolitaElian;
    }

    private void AplicarLia()
    {
        if (imagenCentro != null)
            imagenCentro.sprite = centroLia;

        if (imagenBase != null)
            imagenBase.sprite = baseLia;

        if (imagenBolita != null)
            imagenBolita.sprite = bolitaLia;
    }
}
