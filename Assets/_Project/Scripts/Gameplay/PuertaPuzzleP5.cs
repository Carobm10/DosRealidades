using UnityEngine;
using Unity.Netcode;

public class PuertaPuzzleP5 : MonoBehaviour
{
    [SerializeField]
    private int numeroPuerta;

    [SerializeField]
    private PuzzlePuertasP5 controlador;

    private void Awake()
    {
        if (controlador == null)
        {
            controlador =
                FindAnyObjectByType<PuzzlePuertasP5>();
        }
    }

    private void OnTriggerEnter2D(
        Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null)
            return;

        // Cada dispositivo solamente reporta
        // su propio jugador.
        if (!jugador.IsOwner)
            return;

        if (controlador == null)
            return;

        controlador.IntentarPuerta(
            numeroPuerta
        );
    }
}