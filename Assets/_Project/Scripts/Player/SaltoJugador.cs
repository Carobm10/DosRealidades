
using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;
using System.Collections;

public class SaltoJugador : NetworkBehaviour
{
    [Header("Controles")]
    [SerializeField] private InputActionReference accionSaltar;

    [Header("Visual")]
    [SerializeField] private Transform visualJugador;
    [SerializeField] private Animator animatorJugador;

    [Header("Salto general")]
    [SerializeField] private float alturaSalto = 0.6f;
    [SerializeField] private float duracionSalto = 0.45f;
    [SerializeField] private float distanciaSalto = 1f;

    private Rigidbody2D cuerpo;
    private NetworkPlayerMovement movimiento;

    private bool saltando;

    private Vector3 posicionVisualInicial;

    private Coroutine rutinaSalto;

    private void Awake()
    {
        cuerpo = GetComponent<Rigidbody2D>();

        movimiento =
            GetComponent<NetworkPlayerMovement>();

        if (visualJugador != null)
        {
            posicionVisualInicial =
                visualJugador.localPosition;

            if (animatorJugador == null)
            {
                animatorJugador =
                    visualJugador.GetComponent<Animator>();
            }
        }
    }

    // =====================================
    // INICIALIZACION
    // =====================================

    public override void OnNetworkSpawn()
    {
        if (!IsOwner ||
            accionSaltar == null ||
            accionSaltar.action == null)
            return;

        accionSaltar.action.Enable();

        accionSaltar.action.performed += AlSaltar;

        Debug.Log(
            "SALTO CONFIGURADO PARA: " + gameObject.name
        );
    }

    // =====================================
    // DESACTIVAR CONTROLES
    // =====================================

    public override void OnNetworkDespawn()
    {
        if (IsOwner &&
            accionSaltar != null &&
            accionSaltar.action != null)
        {
            accionSaltar.action.performed -= AlSaltar;
            accionSaltar.action.Disable();
        }

        if (rutinaSalto != null)
        {
            StopCoroutine(rutinaSalto);
            rutinaSalto = null;
        }

        saltando = false;

        RestaurarVisual();

        movimiento?.BloquearMovimiento(false);
    }

    // =====================================
    // DETECTAR SALTO
    // =====================================

    private void AlSaltar(
        InputAction.CallbackContext contexto)
    {
        if (!IsOwner || saltando)
            return;

        if (cuerpo == null || movimiento == null)
        {
            Debug.LogError(
                "SALTO: Faltan Rigidbody2D o NetworkPlayerMovement."
            );

            return;
        }

        if (movimiento.MovimientoBloqueado)
            return;

        StartCoroutine(SaltoGeneral());
    }

    // =====================================
    // SALTO GENERAL CON DESPLAZAMIENTO
    // =====================================

    private IEnumerator SaltoGeneral()
    {
        saltando = true;

        Vector2 inicio = cuerpo.position;

        // Utilizar la ultima direccion del joystick.
        Vector2 direccion =
            movimiento.UltimaDireccion;

        if (direccion.sqrMagnitude < 0.01f)
            direccion = Vector2.down;

        direccion.Normalize();

        // Calcular destino horizontal y vertical.
        Vector2 destino =
            inicio + direccion * distanciaSalto;

        // Bloquear movimiento normal.
        movimiento.BloquearMovimiento(true);

        // Configurar animacion.
        if (animatorJugador != null)
        {
            animatorJugador.SetFloat(
                "Velocidad", 0f
            );

            animatorJugador.SetFloat(
                "DireccionX", direccion.x
            );

            animatorJugador.SetFloat(
                "DireccionY", direccion.y
            );

            animatorJugador.SetBool(
                "Saltando", true
            );
        }

        Debug.Log(
            "SALTO INICIADO | DIRECCION: " + direccion
        );

        float tiempo = 0f;

        // Movimiento fisico del personaje.
        while (tiempo < duracionSalto)
        {
            float progreso =
                Mathf.Clamp01(tiempo / duracionSalto);

            // Desplazamiento hacia adelante.
            Vector2 nuevaPosicion =
                Vector2.Lerp(
                    inicio,
                    destino,
                    progreso
                );

            cuerpo.MovePosition(nuevaPosicion);

            // Arco visual del salto.
            float altura =
                Mathf.Sin(progreso * Mathf.PI) *
                alturaSalto;

            if (visualJugador != null)
            {
                visualJugador.localPosition =
                    posicionVisualInicial +
                    Vector3.up * altura;
            }

            tiempo += Time.fixedDeltaTime;

            yield return new WaitForFixedUpdate();
        }

        // Completar desplazamiento.
        cuerpo.MovePosition(destino);

        yield return new WaitForFixedUpdate();

        FinalizarSalto();
    }

    // =====================================
    // FINALIZAR SALTO
    // =====================================

    private void FinalizarSalto()
    {
        RestaurarVisual();

        if (animatorJugador != null)
        {
            animatorJugador.SetBool(
                "Saltando", false
            );
        }

        movimiento?.BloquearMovimiento(false);

        saltando = false;

        rutinaSalto = null;

        Debug.Log(
            "SALTO FINALIZADO | POSICION: " + cuerpo.position
        );
    }

    // =====================================
    // RESTAURAR VISUAL
    // =====================================

    private void RestaurarVisual()
    {
        if (visualJugador != null)
        {
            visualJugador.localPosition =
                posicionVisualInicial;
        }

        if (animatorJugador != null)
        {
            animatorJugador.SetBool(
                "Saltando", false
            );
        }
    }

    // =====================================
    // COMPATIBILIDAD CON VALIDACIONES ANTERIORES
    // =====================================

    public void ConfirmarValidacion()
    {
        if (rutinaSalto != null)
        {
            StopCoroutine(rutinaSalto);
            rutinaSalto = null;
        }

        FinalizarSalto();

        Debug.Log(
            "VALIDACION DE SALTO FINALIZADA."
        );
    }
}
