
using UnityEngine;

public class PuertaPuzzleP5 : MonoBehaviour
{
    [Header("Configuracion de puerta")]
    [SerializeField] private int numeroPuerta;

    [SerializeField] private PuzzlePuertasP5 controlador;

    [Header("Animacion")]
    [SerializeField] private Animator animatorPuerta;

    [Header("Transicion")]
    [SerializeField] private string escenaDestino;

    public int NumeroPuerta => numeroPuerta;
    public string EscenaDestino => escenaDestino;
    public Transform PuntoEnfoque => transform;

    private void Awake()
    {
        if (controlador == null)
            controlador = FindAnyObjectByType<PuzzlePuertasP5>();

        if (animatorPuerta == null)
            animatorPuerta = GetComponent<Animator>();

        // La puerta comienza cerrada.
        if (animatorPuerta != null)
            animatorPuerta.enabled = false;
    }

    public void IntentarAbrir()
    {
        if (controlador == null)
        {
            Debug.LogError(
                "P5: No se encontro PuzzlePuertasP5."
            );
            return;
        }

        controlador.IntentarPuerta(numeroPuerta);
    }

    public void AbrirVisualLocal()
    {
        if (animatorPuerta == null)
        {
            Debug.LogError(
                "P5: La puerta " + numeroPuerta +
                " no tiene Animator."
            );
            return;
        }

        animatorPuerta.enabled = true;
        animatorPuerta.Play(0, 0, 0f);
    }
}
