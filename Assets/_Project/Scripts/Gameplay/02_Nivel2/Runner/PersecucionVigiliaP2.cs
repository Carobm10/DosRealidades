
using System.Collections;
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(Rigidbody2D))]
public class PersecucionVigiliaP2 : MonoBehaviour
{
    [Header("Identidad")]
    [SerializeField] private bool persigueAElian = false;

    [Header("Movimiento de La Vigilia")]
    [SerializeField] private float velocidadPersecucion = 2.5f;

    [Header("Velocidad al atravesar puertas")]
    [SerializeField] private float velocidadPuerta = 1.8f;

    [Header("Animacion")]
    [SerializeField] private Animator animator;

    [Header("Control de dano")]
    [SerializeField] private float intervaloEntreGolpes = 1.5f;

    private Transform objetivo;
    private NetworkObject jugadorObjetivo;
    private Rigidbody2D cuerpo;

    private bool persecucionActiva;
    private float siguienteGolpePermitido;

    private int zonasPuertaActivas;
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
        zonasPuertaActivas = 0;

        rutinaIdentificacion =
            StartCoroutine(IdentificarJugadorLocal());
    }

    private IEnumerator IdentificarJugadorLocal()
    {
        // Esperar a que Netcode configure al jugador.
        yield return new WaitUntil(() =>
        {
            NetworkManager red = NetworkManager.Singleton;

            return red != null &&
                   red.IsListening &&
                   red.LocalClient != null &&
                   red.LocalClient.PlayerObject != null;
        });

        NetworkManager red = NetworkManager.Singleton;

        jugadorObjetivo = red.LocalClient.PlayerObject;

        NetworkPlayerSetup setup =
            jugadorObjetivo.GetComponent<NetworkPlayerSetup>();

        yield return new WaitUntil(() =>
            setup != null && setup.RolConfigurado
        );

        // Cada Vigilia persigue exclusivamente a su personaje.
        bool correspondeAlJugador =
            setup.EsElian == persigueAElian;

        if (!correspondeAlJugador)
        {
            Debug.Log(
                "P2 | Vigilia desactivada en esta realidad: " +
                (persigueAElian ? "Elian" : "Lia")
            );

            rutinaIdentificacion = null;
            gameObject.SetActive(false);
            yield break;
        }

        objetivo = jugadorObjetivo.transform;
        persecucionActiva = true;

        siguienteGolpePermitido = 0f;

        Debug.Log(
            "P2 | Vigilia activada para: " +
            (persigueAElian ? "Elian" : "Lia")
        );

        rutinaIdentificacion = null;
    }

    // =====================================
    // PERSECUCION
    // =====================================

    private void FixedUpdate()
    {
        if (!persecucionActiva ||
            objetivo == null ||
            cuerpo == null)
            return;

        float diferenciaX =
            objetivo.position.x - cuerpo.position.x;

        if (Mathf.Abs(diferenciaX) < 0.05f)
            return;

        float direccion = Mathf.Sign(diferenciaX);

        // SOLO SE MODIFICA LA VELOCIDAD DE LA VIGILIA.
        float velocidadActual =
            zonasPuertaActivas > 0
            ? velocidadPuerta
            : velocidadPersecucion;

        Vector2 nuevaPosicion =
            cuerpo.position +
            Vector2.right *
            direccion *
            velocidadActual *
            Time.fixedDeltaTime;

        cuerpo.MovePosition(nuevaPosicion);

        if (animator != null)
        {
            animator.SetBool(
                "MirandoIzquierda",
                direccion < 0
            );
        }
    }

    // =====================================
    // ZONAS DE PUERTAS
    // =====================================

    public void EntrarZonaPuerta()
    {
        zonasPuertaActivas++;

        Debug.Log(
            "P2 | Vigilia " +
            (persigueAElian ? "Elian" : "Lia") +
            " entra en puerta. Velocidad: " +
            velocidadPuerta
        );
    }

    public void SalirZonaPuerta()
    {
        zonasPuertaActivas =
            Mathf.Max(0, zonasPuertaActivas - 1);

        if (zonasPuertaActivas == 0)
        {
            Debug.Log(
                "P2 | Vigilia recupera velocidad: " +
                velocidadPersecucion
            );
        }
    }

    // =====================================
    // DETECTAR CONTACTO CON SU PERSONAJE
    // =====================================

    private void OnTriggerStay2D(Collider2D otro)
    {
        if (!persecucionActiva ||
            jugadorObjetivo == null)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        // IMPEDIR DAÑO CRUZADO.
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

        if (vidas == null || !vidas.IsSpawned)
        {
            Debug.LogError(
                "P2 | No se encontró VidasEquipo."
            );
            return;
        }

        if (vidas.VidasActuales <= 0)
            return;

        if (Time.time < siguienteGolpePermitido)
            return;

        siguienteGolpePermitido =
            Time.time + intervaloEntreGolpes;

        AplicarImpacto();

        Debug.Log(
            "P2 | VIGILIA DE " +
            (persigueAElian ? "ELIAN" : "LIA") +
            " GOLPEÓ A SU PERSONAJE."
        );
    }

    // =====================================
    // APLICAR DAÑO
    // =====================================

    private void AplicarImpacto()
    {
        VidasEquipo vidas = VidasEquipo.Instancia;

        if (vidas == null)
            return;

        // Descontar vida compartida.
        // No modificar la velocidad de ningún jugador.
        vidas.PerderVida();

        Debug.Log(
            "P2 | Vida descontada. Personaje: " +
            (persigueAElian ? "Elian" : "Lia")
        );
    }

    // =====================================
    // MODIFICAR VELOCIDAD
    // =====================================

    public void ModificarVelocidad(float nuevaVelocidad)
    {
        velocidadPersecucion =
            Mathf.Max(0f, nuevaVelocidad);
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
