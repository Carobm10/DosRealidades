
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

        if (jugador == null || !jugador.IsOwner)
            return;

        NetworkPlayerSetup setup =
            jugador.GetComponent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
            return;

        if (setup.EsElian)
            return;

        VidasEquipo vidas = VidasEquipo.Instancia;

        if (vidas == null || !vidas.IsSpawned)
        {
            Debug.LogError(
                "VIGILIA: No se encontró VidasEquipo activo."
            );
            return;
        }

        if (vidas.VidasActuales <= 0)
            return;

        if (Time.time < siguienteGolpePermitido)
            return;

        siguienteGolpePermitido =
            Time.time + intervaloEntreGolpes;

        AplicarImpacto(jugador);

        Debug.Log(
            "VIGILIA: IMPACTO CONFIRMADO CON LIA."
        );
    }

    // =====================================
    // APLICAR DANIO
    // =====================================

    private void AplicarImpacto(NetworkObject jugador)
    {
        VidasEquipo vidas = VidasEquipo.Instancia;

        if (vidas == null)
            return;

        // Descontar del contador compartido.
        // El servidor actualiza automáticamente ambos HUD.
        vidas.PerderVida();

        Debug.Log(
            "VIGILIA: Solicitud de perdida de vida enviada."
        );

        // Aplicar ralentización local a Lía.
        NetworkPlayerMovement movimiento =
            jugador.GetComponent<NetworkPlayerMovement>();

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
        velocidadPersecucion =
            Mathf.Max(0f, nuevaVelocidad);
    }

    public float ObtenerVelocidad()
    {
        return velocidadPersecucion;
    }
}
