using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class NetworkPlayerMovement : NetworkBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float moveSpeed = 4f;

    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;

    public override void OnNetworkSpawn()
    {
        // Solo el dueño de este personaje puede leer controles.
        if (IsOwner)
        {
            moveAction.action.Enable();
        }
    }

    private void Update()
    {
        // Si este NetworkPlayer no me pertenece, no hago nada.
        if (!IsOwner)
            return;

        Vector2 input = moveAction.action.ReadValue<Vector2>();

        Vector3 movement = new Vector3(
            input.x,
            input.y,
            0f
        );

        transform.position += movement * moveSpeed * Time.deltaTime;
    }

    public override void OnNetworkDespawn()
    {
        if (IsOwner)
        {
            moveAction.action.Disable();
        }
    }
}