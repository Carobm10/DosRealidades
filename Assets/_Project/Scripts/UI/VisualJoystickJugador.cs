using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

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
        // Para pruebas directas en Editor:
        // si no hay NetworkManager, mostramos Elian.
        if (NetworkManager.Singleton == null)
        {
            AplicarElian();
            return;
        }

        // TEMPORAL:
        // Host = Elian
        // Client = Lia
        if (NetworkManager.Singleton.IsHost)
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
        imagenCentro.sprite = centroElian;
        imagenBase.sprite = baseElian;
        imagenBolita.sprite = bolitaElian;
    }

    private void AplicarLia()
    {
        imagenCentro.sprite = centroLia;
        imagenBase.sprite = baseLia;
        imagenBolita.sprite = bolitaLia;
    }
}