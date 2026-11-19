
using System.Collections;
using UnityEngine;

public class DiagnosticoVisualJugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float intervaloRevision = 0.5f;
    [SerializeField] private int cantidadRevisiones = 10;

    private SpriteRenderer sprite;
    private Animator animator;
    private NetworkPlayerSetup setup;
    private NetworkPlayerMovement movimiento;

    private Vector3 posicionAnterior;
    private int ultimoEstado;
    private string ultimoSprite;
    private bool inicializado;

    private IEnumerator Start()
    {
        // Buscar referencias.
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        setup = GetComponentInParent<NetworkPlayerSetup>();
        movimiento = GetComponentInParent<NetworkPlayerMovement>();

        yield return new WaitForSeconds(0.5f);

        posicionAnterior = transform.position;

        Debug.Log(
            "========== DIAGNOSTICO JUGADOR =========="
        );

        Debug.Log(
            "Objeto: " + transform.parent.name
        );

        Debug.Log(
            "Visual activo: " + gameObject.activeInHierarchy
        );

        Debug.Log(
            "SpriteRenderer encontrado: " + (sprite != null)
        );

        Debug.Log(
            "Animator encontrado: " + (animator != null)
        );

        Debug.Log(
            "NetworkPlayerSetup encontrado: " + (setup != null)
        );

        Debug.Log(
            "NetworkPlayerMovement encontrado: " + (movimiento != null)
        );

        if (setup != null)
        {
            Debug.Log(
                "PERSONAJE: " +
                (setup.EsElian ? "ELIAN" : "LIA") +
                " | Rol configurado: " + setup.RolConfigurado
            );
        }

        if (animator != null)
        {
            Debug.Log(
                "CONTROLLER: " +
                (animator.runtimeAnimatorController != null
                    ? animator.runtimeAnimatorController.name
                    : "NULL")
            );

            Debug.Log(
                "ANIMATOR ENABLED: " + animator.enabled
            );
        }

        inicializado = true;

        // Revisar varias veces al inicio.
        for (int i = 0; i < cantidadRevisiones; i++)
        {
            RevisarEstado();

            yield return new WaitForSeconds(intervaloRevision);
        }

        Debug.Log(
            "========== FIN DIAGNOSTICO INICIAL =========="
        );
    }

    private void RevisarEstado()
    {
        if (!inicializado)
            return;

        string nombreSprite = "NULL";

        if (sprite != null && sprite.sprite != null)
            nombreSprite = sprite.sprite.name;

        bool visible =
            sprite != null &&
            sprite.enabled &&
            sprite.gameObject.activeInHierarchy &&
            sprite.color.a > 0.01f &&
            sprite.sprite != null;

        float distancia =
            Vector3.Distance(posicionAnterior, transform.position);

        bool moviendose = distancia > 0.001f;

        posicionAnterior = transform.position;

        Debug.Log(
            "[DIAGNOSTICO VISUAL] " +
            "Sprite: " + nombreSprite +
            " | Visible: " + visible +
            " | Activo: " +
            (sprite != null && sprite.gameObject.activeInHierarchy) +
            " | Renderer: " +
            (sprite != null && sprite.enabled) +
            " | Alpha: " +
            (sprite != null ? sprite.color.a : 0)
        );

        if (animator != null && animator.isActiveAndEnabled)
        {
            AnimatorStateInfo estado =
                animator.GetCurrentAnimatorStateInfo(0);

            float velocidad = 0f;

            foreach (AnimatorControllerParameter parametro
                in animator.parameters)
            {
                if (parametro.name == "Velocidad" &&
                    parametro.type == AnimatorControllerParameterType.Float)
                {
                    velocidad = animator.GetFloat("Velocidad");
                    break;
                }
            }

            Debug.Log(
                "[DIAGNOSTICO ANIMACION] " +
                "Estado Hash: " + estado.fullPathHash +
                " | Tiempo: " + estado.normalizedTime +
                " | Velocidad: " + velocidad
            );

            AnimatorClipInfo[] clips =
                animator.GetCurrentAnimatorClipInfo(0);

            foreach (AnimatorClipInfo clip in clips)
            {
                Debug.Log(
                    "[DIAGNOSTICO CLIP] " +
                    (clip.clip != null ? clip.clip.name : "NULL")
                );
            }
        }
        else
        {
            Debug.LogError(
                "[DIAGNOSTICO] Animator desactivado o no disponible."
            );
        }

        if (moviendose)
        {
            Debug.Log(
                "[DIAGNOSTICO MOVIMIENTO] " +
                "El personaje se está desplazando."
            );
        }
        else
        {
            Debug.Log(
                "[DIAGNOSTICO MOVIMIENTO] " +
                "El personaje permanece quieto."
            );
        }

        if (sprite != null && sprite.sprite == null)
        {
            Debug.LogError(
                "[DIAGNOSTICO] EL SPRITERENDERER NO TIENE SPRITE."
            );
        }
    }
}
