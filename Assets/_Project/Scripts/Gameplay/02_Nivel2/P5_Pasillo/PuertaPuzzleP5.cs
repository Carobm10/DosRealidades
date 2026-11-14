
using UnityEngine;
using Unity.Netcode;

public class PuertaPuzzleP5 : MonoBehaviour
{
    [Header("Configuracion de puerta")]
    [SerializeField] private int numeroPuerta;
    [SerializeField] private PuzzlePuertasP5 controlador;

    [Header("Animator anterior (respaldo)")]
    [SerializeField] private Animator animatorPuerta;

    [Header("Animaciones por realidad")]
    [SerializeField] private Animator animatorPuertaElian;
    [SerializeField] private Animator animatorPuertaLia;
    [SerializeField] private string nombreTriggerAbrir = "Abrir";

    [Header("Enfoque de camara por realidad")]
    [SerializeField] private Transform puntoEnfoqueElian;
    [SerializeField] private Transform puntoEnfoqueLia;

    [Header("Transicion")]
    [SerializeField] private string escenaDestino;

    public int NumeroPuerta => numeroPuerta;
    public string EscenaDestino => escenaDestino;

    // Compatibilidad con otros scripts.
    public Transform PuntoEnfoque => transform;

    public Transform PuntoEnfoqueLocal
    {
        get
        {
            bool esElian = EsElianLocal();

            Transform punto = esElian
                ? puntoEnfoqueElian
                : puntoEnfoqueLia;

            return punto != null ? punto : transform;
        }
    }

    public float DuracionApertura
    {
        get
        {
            float elian = DuracionAnimator(animatorPuertaElian);
            float lia = DuracionAnimator(animatorPuertaLia);
            float anterior = DuracionAnimator(animatorPuerta);

            return Mathf.Max(elian, lia, anterior);
        }
    }

    private void Awake()
    {
        if (controlador == null)
            controlador = FindAnyObjectByType<PuzzlePuertasP5>();

        if (animatorPuerta == null &&
            animatorPuertaElian == null &&
            animatorPuertaLia == null)
        {
            animatorPuerta = GetComponent<Animator>();
        }

        // Las puertas comienzan cerradas.
        if (animatorPuerta != null)
            animatorPuerta.enabled = false;

        if (animatorPuertaElian != null)
            animatorPuertaElian.enabled = false;

        if (animatorPuertaLia != null)
            animatorPuertaLia.enabled = false;
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
        bool esElian = EsElianLocal();

        // Antes de abrir, desactivar el brillo
        // para que no interfiera con la animacion.
        if (animatorPuertaLia != null)
        {
            BrilloPuertaLiaP5 brillo =
                animatorPuertaLia.GetComponent<BrilloPuertaLiaP5>();

            if (brillo != null)
                brillo.PrepararApertura();
        }

        // Cada jugador anima la puerta de su realidad.
        Animator animator = esElian
            ? animatorPuertaElian
            : animatorPuertaLia;

        // Respaldo del sistema anterior.
        if (animator == null)
            animator = animatorPuerta;

        if (animator == null)
        {
            Debug.LogError(
                "P5: No hay Animator para la puerta " +
                numeroPuerta + " de " +
                (esElian ? "Elian" : "Lia")
            );
            return;
        }

        if (animator.runtimeAnimatorController == null)
        {
            Debug.LogError(
                "P5: La puerta " + numeroPuerta +
                " no tiene Animator Controller asignado."
            );
            return;
        }

        animator.enabled = true;
        animator.Rebind();
        animator.Update(0f);

        bool tieneTrigger = false;

        foreach (AnimatorControllerParameter parametro
                 in animator.parameters)
        {
            if (parametro.name == nombreTriggerAbrir &&
                parametro.type ==
                AnimatorControllerParameterType.Trigger)
            {
                tieneTrigger = true;
                break;
            }
        }

        if (tieneTrigger)
        {
            animator.ResetTrigger(nombreTriggerAbrir);
            animator.SetTrigger(nombreTriggerAbrir);
        }
        else
        {
            Debug.LogWarning(
                "P5: Falta el Trigger '" +
                nombreTriggerAbrir +
                "' en la puerta " + numeroPuerta
            );
        }

        Debug.Log(
            "P5: Abriendo puerta " + numeroPuerta +
            " para " + (esElian ? "Elian" : "Lia")
        );
    }

    private static float DuracionAnimator(Animator animator)
    {
        if (animator == null ||
            animator.runtimeAnimatorController == null)
            return 0f;

        float duracion = 0f;

        foreach (AnimationClip clip in
                 animator.runtimeAnimatorController.animationClips)
        {
            if (clip != null)
                duracion = Mathf.Max(duracion, clip.length);
        }

        return duracion;
    }

    private static bool EsElianLocal()
    {
        bool esElian =
            NetworkManager.Singleton != null &&
            NetworkManager.Singleton.IsHost;

#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
            esElian = RolPruebaJugador.Instancia.EsElian();
#endif

        return esElian;
    }
}
