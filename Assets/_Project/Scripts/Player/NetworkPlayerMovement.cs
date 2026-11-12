
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class NetworkPlayerMovement : NetworkBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento = 4f;

    [Header("Controles")]
    [SerializeField] private InputActionReference accionMover;

    [Header("Animacion")]
    [SerializeField] private Animator animatorJugador;

    private Rigidbody2D cuerpo;

    private Vector2 direccionMovimiento;
    private Vector2 ultimaDireccion = Vector2.down;

    private float ultimaDireccionHorizontal = 0f;

    private bool movimientoBloqueado;
    private bool modoPuente;

    // =====================================
    // ANIMACIONES SINCRONIZADAS
    // =====================================

    private NetworkVariable<float> velocidadReplicada =
        new NetworkVariable<float>(
            0f,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Owner
        );

    private NetworkVariable<float> direccionXReplicada =
        new NetworkVariable<float>(
            0f,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Owner
        );

    private NetworkVariable<float> direccionYReplicada =
        new NetworkVariable<float>(
            -1f,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Owner
        );

    // =====================================
    // PROPIEDADES
    // =====================================

    public float UltimaDireccionHorizontal =>
        ultimaDireccionHorizontal;

    public Vector2 UltimaDireccion =>
        ultimaDireccion;

    public bool MovimientoBloqueado =>
        movimientoBloqueado;

    public bool ModoPuente =>
        modoPuente;

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        cuerpo = GetComponent<Rigidbody2D>();
    }

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            if (accionMover != null &&
                accionMover.action != null)
            {
                accionMover.action.Enable();
            }

            if (cuerpo != null)
                cuerpo.simulated = true;

            // Inicializar direccion hacia abajo.
            ActualizarAnimacion(Vector2.zero);
        }
        else
        {
            if (cuerpo != null)
                cuerpo.simulated = false;

            // Aplicar animacion recibida.
            AplicarAnimacionReplicada();
        }
    }

    // =====================================
    // ACTUALIZACION
    // =====================================

    private void Update()
    {
        if (!IsSpawned)
            return;

        // Los jugadores remotos reciben
        // las animaciones del propietario.

        if (!IsOwner)
        {
            AplicarAnimacionReplicada();
            return;
        }

        if (accionMover == null ||
            accionMover.action == null)
            return;

        Vector2 entrada =
            accionMover.action.ReadValue<Vector2>();

        // Recordar ultima direccion.

        if (entrada.sqrMagnitude > 0.01f)
        {
            ultimaDireccion = entrada.normalized;

            if (Mathf.Abs(entrada.x) > 0.1f)
            {
                ultimaDireccionHorizontal =
                    Mathf.Sign(entrada.x);
            }
        }

        // Movimiento bloqueado o puente.

        if (movimientoBloqueado || modoPuente)
        {
            direccionMovimiento = Vector2.zero;

            ActualizarAnimacion(Vector2.zero);

            return;
        }

        direccionMovimiento =
            Vector2.ClampMagnitude(entrada, 1f);

        ActualizarAnimacion(direccionMovimiento);
    }

    // =====================================
    // MOVIMIENTO FISICO
    // =====================================

    private void FixedUpdate()
    {
        if (!IsOwner ||
            movimientoBloqueado ||
            modoPuente ||
            cuerpo == null)
            return;

        Vector2 nuevaPosicion =
            cuerpo.position +
            direccionMovimiento *
            velocidadMovimiento *
            Time.fixedDeltaTime;

        cuerpo.MovePosition(nuevaPosicion);
    }

    // =====================================
    // ACTUALIZAR ANIMACION LOCAL
    // =====================================

    private void ActualizarAnimacion(Vector2 direccion)
    {
        float velocidad = direccion.magnitude;

        Vector2 direccionAnimacion =
            direccion.sqrMagnitude > 0.01f
            ? direccion.normalized
            : ultimaDireccion;

        // Actualizar Animator local.

        if (animatorJugador != null)
        {
            animatorJugador.SetFloat(
                "Velocidad",
                velocidad
            );

            animatorJugador.SetFloat(
                "DireccionX",
                direccionAnimacion.x
            );

            animatorJugador.SetFloat(
                "DireccionY",
                direccionAnimacion.y
            );
        }

        // Sincronizar parametros por red.

        if (IsSpawned && IsOwner)
        {
            velocidadReplicada.Value = velocidad;

            direccionXReplicada.Value =
                direccionAnimacion.x;

            direccionYReplicada.Value =
                direccionAnimacion.y;
        }
    }

    // =====================================
    // APLICAR ANIMACION EN JUGADORES REMOTOS
    // =====================================

    private void AplicarAnimacionReplicada()
    {
        if (animatorJugador == null)
            return;

        animatorJugador.SetFloat(
            "Velocidad",
            velocidadReplicada.Value
        );

        animatorJugador.SetFloat(
            "DireccionX",
            direccionXReplicada.Value
        );

        animatorJugador.SetFloat(
            "DireccionY",
            direccionYReplicada.Value
        );
    }

    // =====================================
    // MODO PUENTE
    // =====================================

    public void ActivarModoPuente(bool activar)
    {
        if (!IsOwner)
            return;

        modoPuente = activar;

        direccionMovimiento = Vector2.zero;

        ActualizarAnimacion(Vector2.zero);

        Debug.Log("MODO PUENTE: " + activar);
    }

    // =====================================
    // BLOQUEAR MOVIMIENTO
    // =====================================

    public void BloquearMovimiento(bool bloquear)
    {
        if (!IsOwner)
            return;

        movimientoBloqueado = bloquear;

        direccionMovimiento = Vector2.zero;

        ActualizarAnimacion(Vector2.zero);
    }

    // =====================================
    // DESCONEXION
    // =====================================

    public override void OnNetworkDespawn()
    {
        if (IsOwner &&
            accionMover != null &&
            accionMover.action != null)
        {
            accionMover.action.Disable();
        }

        movimientoBloqueado = false;
        modoPuente = false;

        direccionMovimiento = Vector2.zero;
    }
}
