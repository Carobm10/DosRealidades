
using System.Collections;
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(Rigidbody2D))]
public class PersecucionVigiliaP8 : MonoBehaviour
{
    [Header("Identidad")]
    [SerializeField] private bool persigueAElian;

    [Header("Movimiento")]
    [SerializeField] private float velocidadPersecucion = 1.5f;

    [Header("Animacion")]
    [SerializeField] private Animator animator;

    [Header("Control de dano")]
    [SerializeField] private float intervaloEntreGolpes = 1.5f;

    private Rigidbody2D cuerpo;
    private Transform objetivo;
    private NetworkObject jugadorObjetivo;

    private bool persecucionActiva;
    private float siguienteGolpePermitido;

    private Coroutine rutinaIdentificacion;

    private void Awake()
    {
        cuerpo = GetComponent<Rigidbody2D>();

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        persecucionActiva = false;
        objetivo = null;
        jugadorObjetivo = null;

        rutinaIdentificacion =
            StartCoroutine(IdentificarJugadorLocal());
    }

    // =====================================
    // IDENTIFICAR PERSONAJE
    // =====================================

    private IEnumerator IdentificarJugadorLocal()
    {
        yield return new WaitUntil(() =>
        {
            NetworkManager red = NetworkManager.Singleton;

            return red != null &&
                   red.IsListening &&
                   red.LocalClient != null &&
                   red.LocalClient.PlayerObject != null;
        });

        jugadorObjetivo =
            NetworkManager.Singleton.LocalClient.PlayerObject;

        NetworkPlayerSetup setup =
            jugadorObjetivo.GetComponent<NetworkPlayerSetup>();

        yield return new WaitUntil(() =>
            setup != null && setup.RolConfigurado
        );

        // Cada Vigilia solo pertenece a su personaje.
        bool correspondeAlJugador =
            setup.EsElian == persigueAElian;

        if (!correspondeAlJugador)
        {
            Debug.Log(
                "P8 | Vigilia de " +
                (persigueAElian ? "Elian" : "Lia") +
                " desactivada para el jugador contrario."
            );

            rutinaIdentificacion = null;
            gameObject.SetActive(false);
            yield break;
        }

        objetivo = jugadorObjetivo.transform;
        persecucionActiva = true;

        Debug.Log(
            "P8 | Vigilia activa: " +
            (persigueAElian ? "Elian" : "Lia")
        );

        rutinaIdentificacion = null;
    }

    // =====================================
    // MOVIMIENTO
    // =====================================

    private void FixedUpdate()
    {
        if (!persecucionActiva ||
            objetivo == null ||
            cuerpo == null)
            return;

        Vector2 diferencia =
            (Vector2)objetivo.position - cuerpo.position;

        if (diferencia.sqrMagnitude < 0.0025f)
            return;

        Vector2 direccion = diferencia.normalized;

        cuerpo.MovePosition(
            cuerpo.position +
            direccion * velocidadPersecucion *
            Time.fixedDeltaTime
        );

        ActualizarAnimacion(direccion);
    }

    private void ActualizarAnimacion(Vector2 direccion)
    {
        if (animator == null)
            return;

        animator.SetFloat("DireccionX", direccion.x);
        animator.SetFloat("DireccionY", direccion.y);
    }

    // =====================================
    // DETECTAR CONTACTO
    // =====================================

    private void OnTriggerStay2D(Collider2D otro)
    {
        if (!persecucionActiva ||
            jugadorObjetivo == null)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        // VALIDACION LOCAL DEL PERSONAJE.
        if (jugador == null ||
            jugador != jugadorObjetivo ||
            !jugador.IsOwner)
            return;

        NetworkPlayerSetup setup =
            jugador.GetComponent<NetworkPlayerSetup>();

        if (setup == null ||
            !setup.RolConfigurado ||
            setup.EsElian != persigueAElian)
            return;

        VidasEquipo vidas = VidasEquipo.Instancia;

        if (vidas == null || !vidas.IsSpawned ||
            vidas.VidasActuales <= 0)
            return;

        if (Time.time < siguienteGolpePermitido)
            return;

        siguienteGolpePermitido =
            Time.time + intervaloEntreGolpes;

        AplicarImpacto();

        Debug.Log(
            "P8 | IMPACTO DE VIGILIA " +
            (persigueAElian ? "ELIAN" : "LIA") +
            " CONTRA SU PERSONAJE."
        );
    }

    // =====================================
    // SOLICITAR DAÑO
    // =====================================

    private void AplicarImpacto()
    {
        VidasEquipo vidas = VidasEquipo.Instancia;

        if (vidas == null)
            return;

        // ENVIAR IDENTIDAD AL SERVIDOR.
        vidas.SolicitarDanioP8(persigueAElian);
    }

    // =====================================
    // VELOCIDAD
    // =====================================

    public void ModificarVelocidad(float velocidad)
    {
        velocidadPersecucion = Mathf.Max(0f, velocidad);
    }

    public float ObtenerVelocidad()
    {
        return velocidadPersecucion;
    }

    // =====================================
    // LIMPIEZA
    // =====================================

    private void OnDisable()
    {
        persecucionActiva = false;
        objetivo = null;
        jugadorObjetivo = null;

        if (rutinaIdentificacion != null)
        {
            StopCoroutine(rutinaIdentificacion);
            rutinaIdentificacion = null;
        }
    }
}
