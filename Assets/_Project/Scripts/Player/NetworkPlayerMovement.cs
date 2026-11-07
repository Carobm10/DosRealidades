
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

    public float UltimaDireccionHorizontal =>
        ultimaDireccionHorizontal;

    public bool MovimientoBloqueado =>
        movimientoBloqueado;

    public bool ModoPuente =>
        modoPuente;

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
        }
        else
        {
            if (cuerpo != null)
                cuerpo.simulated = false;
        }
    }

    private void Update()
    {
        if (!IsOwner)
            return;

        if (accionMover == null ||
            accionMover.action == null)
            return;

        // Leer siempre el joystick.
        Vector2 entrada =
            accionMover.action.ReadValue<Vector2>();

        // Guardar la última dirección seleccionada.
        if (entrada.sqrMagnitude > 0.01f)
        {
            ultimaDireccion = entrada.normalized;

            if (Mathf.Abs(entrada.x) > 0.1f)
            {
                ultimaDireccionHorizontal =
                    Mathf.Sign(entrada.x);
            }
        }

        // Bloquear el desplazamiento normal
        // mientras Lía está dentro del puente.
        if (movimientoBloqueado || modoPuente)
        {
            direccionMovimiento = Vector2.zero;

            if (animatorJugador != null)
                animatorJugador.SetFloat("Velocidad", 0f);

            return;
        }

        direccionMovimiento =
            Vector2.ClampMagnitude(entrada, 1f);

        ActualizarAnimacion(direccionMovimiento);
    }

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

    private void ActualizarAnimacion(Vector2 direccion)
    {
        if (animatorJugador == null)
            return;

        animatorJugador.SetFloat(
            "Velocidad",
            direccion.magnitude
        );

        Vector2 direccionAnimacion =
            direccion.sqrMagnitude > 0.01f
            ? direccion.normalized
            : ultimaDireccion;

        animatorJugador.SetFloat(
            "DireccionX",
            direccionAnimacion.x
        );

        animatorJugador.SetFloat(
            "DireccionY",
            direccionAnimacion.y
        );
    }

    // ACTIVAR O DESACTIVAR EL MODO PUENTE.
    public void ActivarModoPuente(bool activar)
    {
        if (!IsOwner)
            return;

        modoPuente = activar;
        direccionMovimiento = Vector2.zero;

        if (activar && animatorJugador != null)
            animatorJugador.SetFloat("Velocidad", 0f);

        Debug.Log("MODO PUENTE: " + activar);
    }

    // BLOQUEAR MOVIMIENTO DURANTE EL SALTO.
    public void BloquearMovimiento(bool bloquear)
    {
        if (!IsOwner)
            return;

        movimientoBloqueado = bloquear;
        direccionMovimiento = Vector2.zero;

        if (bloquear && animatorJugador != null)
            animatorJugador.SetFloat("Velocidad", 0f);
    }

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
