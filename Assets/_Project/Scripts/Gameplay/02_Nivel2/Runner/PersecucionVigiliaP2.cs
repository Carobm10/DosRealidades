
using System.Collections;
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(Rigidbody2D))]
public class PersecucionVigiliaP2 : MonoBehaviour
{
    [Header("Movimiento de La Vigilia")]
    [SerializeField] private float velocidadPersecucion = 3.6f;

    [Header("Velocidad al atravesar puertas")]
    [SerializeField] private float velocidadPuerta = 0.6f;

    [Header("Animacion")]
    [SerializeField] private Animator animator;

    [Header("Velocidad de Lia")]
    [SerializeField] private float velocidadNormalLia = 3f;
    [SerializeField] private float velocidadGolpeadaLia = 1.8f;
    [SerializeField] private float duracionLentitud = 1.5f;

    [Header("Control de dano")]
    [SerializeField] private float intervaloEntreGolpes = 1.5f;

    private Transform objetivo;
    private Rigidbody2D cuerpo;

    private bool persecucionActiva;
    private float siguienteGolpePermitido;

    private Coroutine rutinaLentitud;

    // Contador de zonas de puertas.
    private int zonasPuertaActivas;

    private void Awake()
    {
        cuerpo = GetComponent<Rigidbody2D>();

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ConfigurarObjetivo();
    }

    private void ConfigurarObjetivo()
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red == null || red.LocalClient == null)
            return;

        NetworkObject jugador = red.LocalClient.PlayerObject;

        if (jugador == null)
            return;

        NetworkPlayerSetup setup =
            jugador.GetComponent<NetworkPlayerSetup>();

        if (setup == null || setup.EsElian)
        {
            gameObject.SetActive(false);
            return;
        }

        objetivo = jugador.transform;
        persecucionActiva = true;

        Debug.Log("VIGILIA: Persiguiendo a Lía.");
    }

    // =====================================
    // PERSECUCION
    // =====================================

    private void FixedUpdate()
    {
        if (!persecucionActiva || objetivo == null)
            return;

        float diferenciaX =
            objetivo.position.x - cuerpo.position.x;

        if (Mathf.Abs(diferenciaX) < 0.05f)
            return;

        float direccion = Mathf.Sign(diferenciaX);

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
            "VIGILIA: Entrando en puerta. Velocidad: " +
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
                "VIGILIA: Salió de la puerta. " +
                "Velocidad normal: " + velocidadPersecucion
            );
        }
    }

    // =====================================
    // DETECTAR CONTACTO CON LIA
    // =====================================

    
    private void OnTriggerStay2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null)
            return;

        // Solo procesar al jugador dueño de este personaje.
        if (!jugador.IsOwner)
            return;

        NetworkPlayerSetup setup =
            jugador.GetComponent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
            return;

        // La Vigilia solamente afecta a Lía.
        if (setup.EsElian)
            return;

        // Respetar intervalo entre golpes.
        if (Time.time < siguienteGolpePermitido)
            return;

        VidaJugador vida =
            jugador.GetComponent<VidaJugador>();

        if (vida == null)
        {
            Debug.LogError(
                "VIGILIA: Lía no tiene componente VidaJugador."
            );
            return;
        }

        siguienteGolpePermitido =
            Time.time + intervaloEntreGolpes;

        AplicarImpacto(jugador);

        Debug.Log(
            "VIGILIA: CONTACTO CONFIRMADO CON LÍA."
        );
    }


    // =====================================
    // APLICAR DANIO Y LENTITUD
    // =====================================

    private void AplicarImpacto(NetworkObject jugador)
    {
        VidaJugador vida =
            jugador.GetComponent<VidaJugador>();

        NetworkPlayerMovement movimiento =
            jugador.GetComponent<NetworkPlayerMovement>();

        if (vida != null)
        {
            vida.PerderVida();

            Debug.Log("VIGILIA: Lia ha perdido una vida.");
        }

        if (movimiento != null)
        {
            if (rutinaLentitud != null)
                StopCoroutine(rutinaLentitud);

            rutinaLentitud =
                StartCoroutine(AplicarLentitud(movimiento));
        }
    }

    // =====================================
    // RECUPERAR VELOCIDAD DE LIA
    // =====================================

    private IEnumerator AplicarLentitud(
        NetworkPlayerMovement movimiento)
    {
        movimiento.ConfigurarVelocidadNivel(
            velocidadGolpeadaLia
        );

        Debug.Log("VIGILIA: Lia ralentizada.");

        yield return new WaitForSeconds(duracionLentitud);

        if (movimiento != null &&
            movimiento.IsSpawned &&
            movimiento.IsOwner)
        {
            movimiento.ConfigurarVelocidadNivel(
                velocidadNormalLia
            );
        }

        Debug.Log("VIGILIA: Lia recupera su velocidad.");

        rutinaLentitud = null;
    }

    // =====================================
    // MODIFICAR VELOCIDADES
    // =====================================

    public void ModificarVelocidad(float nuevaVelocidad)
    {
        velocidadPersecucion = Mathf.Max(0f, nuevaVelocidad);
    }

    public float ObtenerVelocidad()
    {
        return velocidadPersecucion;
    }
}
