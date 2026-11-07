
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class SaltoJugador : NetworkBehaviour
{
    [Header("Controles")]
    [SerializeField] private InputActionReference accionSaltar;

    [Header("Visual")]
    [SerializeField] private Transform visualJugador;
    [SerializeField] private Animator animatorJugador;

    [Header("Salto general")]
    [SerializeField] private float alturaSalto = 0.5f;
    [SerializeField] private float duracionSalto = 0.45f;

    [Header("Salto P3 - Camino de madera")]
    [SerializeField] private float distanciaSaltoP3 = 1.2f;
    [SerializeField] private float duracionSaltoP3 = 0.65f;
    [SerializeField] private float alturaSaltoP3 = 0.6f;

    private Rigidbody2D cuerpo;
    private NetworkPlayerMovement movimiento;

    private bool saltando;
    private Vector3 posicionVisualInicial;

    private bool EsNivelP3 =>
        SceneManager.GetActiveScene().name == "P3_CaminoMadera";

    private void Awake()
    {
        cuerpo = GetComponent<Rigidbody2D>();
        movimiento = GetComponent<NetworkPlayerMovement>();

        if (visualJugador != null)
        {
            posicionVisualInicial = visualJugador.localPosition;

            if (animatorJugador == null)
                animatorJugador =
                    visualJugador.GetComponent<Animator>();
        }
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner || accionSaltar == null)
            return;

        accionSaltar.action.Enable();
        accionSaltar.action.performed += AlSaltar;
    }

    public override void OnNetworkDespawn()
    {
        if (!IsOwner || accionSaltar == null)
            return;

        accionSaltar.action.performed -= AlSaltar;
        accionSaltar.action.Disable();
    }

    private void AlSaltar(InputAction.CallbackContext contexto)
    {
        if (saltando || !IsOwner)
            return;

        if (EsNivelP3)
            StartCoroutine(SaltoCaminoMadera());
        else
            StartCoroutine(SaltoNormal());
    }

    private IEnumerator SaltoNormal()
    {
        saltando = true;

        if (animatorJugador != null)
            animatorJugador.SetBool("Saltando", true);

        float tiempo = 0f;

        while (tiempo < duracionSalto)
        {
            tiempo += Time.deltaTime;

            float progreso =
                Mathf.Clamp01(tiempo / duracionSalto);

            float altura =
                Mathf.Sin(progreso * Mathf.PI) * alturaSalto;

            visualJugador.localPosition =
                posicionVisualInicial + Vector3.up * altura;

            yield return null;
        }

        FinalizarSalto();
    }

    private IEnumerator SaltoCaminoMadera()
    {
        if (cuerpo == null || movimiento == null)
            yield break;

        saltando = true;

        // Obtener la ultima direccion horizontal.
        float direccionX = animatorJugador != null
            ? animatorJugador.GetFloat("DireccionX")
            : 0f;

        if (Mathf.Abs(direccionX) < 0.1f)
        {
            saltando = false;
            Debug.LogWarning(
                "Para saltar en P3 debes mirar hacia izquierda o derecha."
            );
            yield break;
        }

        Vector2 inicio = cuerpo.position;

        Vector2 destino = inicio +
            Vector2.right * Mathf.Sign(direccionX) *
            distanciaSaltoP3;

        movimiento.BloquearMovimiento(true);

        if (animatorJugador != null)
            animatorJugador.SetBool("Saltando", true);

        float tiempo = 0f;

        while (tiempo < duracionSaltoP3)
        {
            tiempo += Time.fixedDeltaTime;

            float progreso =
                Mathf.Clamp01(tiempo / duracionSaltoP3);

            Vector2 posicion =
                Vector2.Lerp(inicio, destino, progreso);

            cuerpo.MovePosition(posicion);

            float altura =
                Mathf.Sin(progreso * Mathf.PI) *
                alturaSaltoP3;

            visualJugador.localPosition =
                posicionVisualInicial +
                Vector3.up * altura;

            yield return new WaitForFixedUpdate();
        }

        cuerpo.MovePosition(destino);
        cuerpo.position = destino;

        FinalizarSalto();

        movimiento.BloquearMovimiento(false);

        Debug.Log("SALTO P3 COMPLETADO");
    }

    private void FinalizarSalto()
    {
        visualJugador.localPosition = posicionVisualInicial;

        if (animatorJugador != null)
            animatorJugador.SetBool("Saltando", false);

        saltando = false;
    }
}
