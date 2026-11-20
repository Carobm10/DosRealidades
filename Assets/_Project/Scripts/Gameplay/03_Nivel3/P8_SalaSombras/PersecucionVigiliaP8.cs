
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

    private Vector2 ultimaDireccion = Vector2.down;

    private void Awake()
    {
        cuerpo = GetComponent<Rigidbody2D>();

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        StartCoroutine(IdentificarJugadorLocal());
    }

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
            setup != null && setup.RolConfigurado);

        bool correspondeAlJugador =
            setup.EsElian == persigueAElian;

        if (!correspondeAlJugador)
        {
            gameObject.SetActive(false);
            yield break;
        }

        objetivo = jugadorObjetivo.transform;
        persecucionActiva = true;

        Debug.Log(
            "P8 | Vigilia activada para " +
            (persigueAElian ? "Elian" : "Lia")
        );
    }

    private void FixedUpdate()
    {
        if (!persecucionActiva || objetivo == null)
            return;

        Vector2 diferencia =
            (Vector2)objetivo.position - cuerpo.position;

        if (diferencia.sqrMagnitude < 0.0025f)
            return;

        Vector2 direccion = diferencia.normalized;

        ultimaDireccion = direccion;

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

    private void OnTriggerStay2D(Collider2D otro)
    {
        if (!persecucionActiva)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null ||
            jugador != jugadorObjetivo ||
            !jugador.IsOwner)
            return;

        if (Time.time < siguienteGolpePermitido)
            return;

        VidasEquipo vidas = VidasEquipo.Instancia;

        if (vidas == null || !vidas.IsSpawned ||
            vidas.VidasActuales <= 0)
            return;

        siguienteGolpePermitido =
            Time.time + intervaloEntreGolpes;

        vidas.PerderVida();

        Debug.Log(
            "P8 | Vigilia golpeó a " +
            (persigueAElian ? "Elian" : "Lia")
        );
    }

    public void ModificarVelocidad(float velocidad)
    {
        velocidadPersecucion = Mathf.Max(0, velocidad);
    }
}
