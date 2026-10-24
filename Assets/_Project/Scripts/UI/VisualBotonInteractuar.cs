using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class VisualBotonInteractuar : MonoBehaviour
{
    [SerializeField] private Image imagenBoton;

    [Header("Sprites")]
    [SerializeField] private Sprite botonElian;
    [SerializeField] private Sprite botonLia;

    private void Start()
    {
        if (imagenBoton == null)
        {
            imagenBoton = GetComponent<Image>();
        }

        AplicarVisual();
    }

    private void AplicarVisual()
    {
        if (imagenBoton == null)
            return;

        // TEMPORAL:
        // Host = Elian
        // Client = Lia
        if (NetworkManager.Singleton != null &&
            !NetworkManager.Singleton.IsHost)
        {
            imagenBoton.sprite = botonLia;
        }
        else
        {
            imagenBoton.sprite = botonElian;
        }
    }
}