
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class NetworkPlayerMovement : NetworkBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento = 4f;
    [SerializeField] private float umbralMovimiento = 0.15f;

    [Header("Controles")]
    [SerializeField] private InputActionReference accionMover;

    [Header("Animaciones")]
    [SerializeField] private Animator animatorJugador;

    private Rigidbody2D cuerpo;

    private Vector2 direccionMovimiento;
    private Vector2 ultimaDireccion = Vector2.down;

    private bool movimientoBloqueado = false;

    private void Awake()
    {
        cuerpo = GetComponent<Rigidbody2D>();

        if (animatorJugador == null)
            animatorJugador = GetComponentInChildren<Animator>();
    }

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            if (accionMover != null && accionMover.action != null)
                accionMover.action.Enable();

            if (cuerpo != null)
                cuerpo.simulated = true;
        }
        else
        {
            if (cuerpo != null)
                cuerpo.simulated = false;
        }

        ActualizarDireccionAnimator(ultimaDireccion);
    }

    private void Update()
    {
        if (!IsOwner)
            return;

        if (movimientoBloqueado)
        {
            direccionMovimiento = Vector2.zero;
            ActualizarVelocidadAnimator(0f);
            return;
        }

        Vector2 entrada = Vector2.zero;

        if (accionMover != null && accionMover.action != null)
        {
            entrada = accionMover.action.ReadValue<Vector2>();
        }

        // Detectar si existe movimiento.
        if (entrada.magnitude < umbralMovimiento)
        {
            direccionMovimiento = Vector2.zero;
            ActualizarVelocidadAnimator(0f);
            return;
        }

        // Convertir el movimiento en cuatro direcciones.
        if (Mathf.Abs(entrada.x) > Mathf.Abs(entrada.y))
        {
            direccionMovimiento = new Vector2(
                Mathf.Sign(entrada.x), 0f
            );
        }
        else
        {
            direccionMovimiento = new Vector2(
                0f, Mathf.Sign(entrada.y)
            );
        }

        // Guardar la última dirección.
        ultimaDireccion = direccionMovimiento;

        ActualizarDireccionAnimator(ultimaDireccion);
        ActualizarVelocidadAnimator(1f);
    }

    private void FixedUpdate()
    {
        if (!IsOwner || movimientoBloqueado || cuerpo == null)
            return;

        Vector2 nuevaPosicion =
            cuerpo.position +
            direccionMovimiento *
            velocidadMovimiento *
            Time.fixedDeltaTime;

        cuerpo.MovePosition(nuevaPosicion);
    }

    private void ActualizarDireccionAnimator(Vector2 direccion)
    {
        if (animatorJugador == null)
            return;

        animatorJugador.SetFloat("DireccionX", direccion.x);
        animatorJugador.SetFloat("DireccionY", direccion.y);
    }

    private void ActualizarVelocidadAnimator(float velocidad)
    {
        if (animatorJugador == null)
            return;

        animatorJugador.SetFloat("Velocidad", velocidad);
    }

    public void BloquearMovimiento(bool bloquear)
    {
        if (!IsOwner)
            return;

        movimientoBloqueado = bloquear;
        direccionMovimiento = Vector2.zero;

        if (bloquear)
            ActualizarVelocidadAnimator(0f);
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
