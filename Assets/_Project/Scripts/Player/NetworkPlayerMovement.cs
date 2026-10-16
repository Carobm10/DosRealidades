using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class NetworkPlayerMovement : NetworkBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento = 4f;

    [Header("Controles")]
    [SerializeField] private InputActionReference accionMover;

    private Rigidbody2D cuerpo;
    private Vector2 direccionMovimiento;

    private void Awake()
    {
        cuerpo = GetComponent<Rigidbody2D>();
    }

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
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

        direccionMovimiento =
            accionMover.action.ReadValue<Vector2>();

        // Evita que moverse en diagonal sea más rápido.
        direccionMovimiento =
            Vector2.ClampMagnitude(direccionMovimiento, 1f);
    }

    private void FixedUpdate()
    {
        if (!IsOwner)
            return;

        Vector2 nuevaPosicion =
            cuerpo.position +
            direccionMovimiento *
            velocidadMovimiento *
            Time.fixedDeltaTime;

        cuerpo.MovePosition(nuevaPosicion);
    }

    public override void OnNetworkDespawn()
    {
        if (IsOwner)
        {
            accionMover.action.Disable();
        }
    }
}