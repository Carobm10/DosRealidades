
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class NetworkPlayerMovement : NetworkBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento = 4f;

    [Header("Controles")]
    [SerializeField] private InputActionReference accionMover;

    [SerializeField] private Animator animatorJugador;

    private Rigidbody2D cuerpo;
    private Vector2 direccionMovimiento;

    // Nuevo: bloqueo de movimiento durante dialogos.
    private bool movimientoBloqueado = false;

    private void Awake()
    {
        cuerpo = GetComponent<Rigidbody2D>();
    }

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            if (accionMover != null && accionMover.action != null)
                accionMover.action.Enable();

            cuerpo.simulated = true;
        }
        else
        {
            cuerpo.simulated = false;
        }
    }

    private void Update()
    {
        if (!IsOwner)
            return;

        if (movimientoBloqueado)
        {
            direccionMovimiento = Vector2.zero;
            ActualizarAnimacion(Vector2.zero);
            return;
        }

        if (accionMover != null && accionMover.action != null)
        {
            direccionMovimiento =
                accionMover.action.ReadValue<Vector2>();
        }

        direccionMovimiento =
            Vector2.ClampMagnitude(direccionMovimiento, 1f);

        ActualizarAnimacion(direccionMovimiento);
    }

    private void FixedUpdate()
    {
        if (!IsOwner || movimientoBloqueado)
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
        if (animatorJugador != null)
        {
            animatorJugador.SetFloat(
                "Velocidad",
                direccion.magnitude
            );
        }
    }

    // Se llamara desde la interfaz de dialogo.
    public void BloquearMovimiento(bool bloquear)
    {
        if (!IsOwner)
            return;

        movimientoBloqueado = bloquear;
        direccionMovimiento = Vector2.zero;

        if (bloquear)
            ActualizarAnimacion(Vector2.zero);
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
        direccionMovimiento = Vector2.zero;
    }
}
