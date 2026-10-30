
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb2D;
    private Vector2 movementInput;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movementInput = Vector2.zero;

        Keyboard teclado = Keyboard.current;

        if (teclado == null)
            return;

        // Movimiento horizontal
        if (teclado.aKey.isPressed ||
            teclado.leftArrowKey.isPressed)
        {
            movementInput.x -= 1f;
        }

        if (teclado.dKey.isPressed ||
            teclado.rightArrowKey.isPressed)
        {
            movementInput.x += 1f;
        }

        // Movimiento vertical
        if (teclado.wKey.isPressed ||
            teclado.upArrowKey.isPressed)
        {
            movementInput.y += 1f;
        }

        if (teclado.sKey.isPressed ||
            teclado.downArrowKey.isPressed)
        {
            movementInput.y -= 1f;
        }

        // Evitar que las diagonales sean más rápidas.
        movementInput = movementInput.normalized;
    }

    private void FixedUpdate()
    {
        if (rb2D == null)
            return;

        rb2D.linearVelocity = movementInput * speed;
    }
}
