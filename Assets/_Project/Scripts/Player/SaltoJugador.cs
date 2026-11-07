
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

    private bool saltando;
    private bool esperandoValidacion;

    private Vector3 posicionVisualInicial;

    private bool EsNivelP3 =>
        SceneManager.GetActiveScene().name == "P3_CaminoMadera";

    // =====================================
    // INICIALIZACION
    // =====================================

    private void Awake()
    {
        if (visualJugador != null)
        {
            posicionVisualInicial = visualJugador.localPosition;

            if (animatorJugador == null)
            {
                animatorJugador =
                    visualJugador.GetComponent<Animator>();
            }
        }
    }

    // =====================================
    // ACTIVAR CONTROLES
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
            "SALTO CONFIGURADO PARA: " +
            gameObject.name
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

        StopAllCoroutines();

        saltando = false;
        esperandoValidacion = false;

        RestaurarVisual();
    }

    // =====================================
    // DETECTAR SALTO
    // =====================================

    private void AlSaltar(
        InputAction.CallbackContext contexto)
    {
        if (!IsOwner ||
            saltando ||
            esperandoValidacion)
            return;

        // EN P3 EL SALTO QUEDA DESACTIVADO.
        // Los jugadores deben caminar hasta los botones.
        if (EsNivelP3)
        {
            Debug.Log(
                "P3: SALTO DESACTIVADO PARA ESTA PRUEBA."
            );

            return;
        }

        // En los demás niveles se conserva el salto normal.
        StartCoroutine(SaltoNormal());
    }

    // =====================================
    // SALTO NORMAL
    // =====================================

    private IEnumerator SaltoNormal()
    {
        saltando = true;

        if (animatorJugador != null)
        {
            animatorJugador.SetBool("Saltando", true);
        }

        float tiempo = 0f;

        while (tiempo < duracionSalto)
        {
            tiempo += Time.deltaTime;

            float progreso =
                Mathf.Clamp01(tiempo / duracionSalto);

            float altura =
                Mathf.Sin(progreso * Mathf.PI) *
                alturaSalto;

            if (visualJugador != null)
            {
                visualJugador.localPosition =
                    posicionVisualInicial +
                    Vector3.up * altura;
            }

            yield return null;
        }

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
            animatorJugador.SetBool("Saltando", false);
        }

        saltando = false;

        Debug.Log("SALTO NORMAL FINALIZADO.");
    }

    // =====================================
    // RESTAURAR POSICION VISUAL
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
            animatorJugador.SetBool("Saltando", false);
        }
    }

    // =====================================
    // COMPATIBILIDAD CON SCRIPTS ANTERIORES
    // =====================================

    public void ConfirmarValidacion()
    {
        esperandoValidacion = false;
        saltando = false;

        RestaurarVisual();

        Debug.Log(
            "VALIDACION DE SALTO FINALIZADA."
        );
    }
}
