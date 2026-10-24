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

    [Header("Salto")]
    [SerializeField] private float alturaSalto = 0.5f;
    [SerializeField] private float duracionSalto = 0.45f;

    private bool saltando;
    private Vector3 posicionVisualInicial;

    private void Awake()
    {
        if (visualJugador != null)
        {
            posicionVisualInicial = visualJugador.localPosition;

            if (animatorJugador == null)
            {
                animatorJugador = visualJugador.GetComponent<Animator>();
            }
        }
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
            return;

        accionSaltar.action.Enable();
        accionSaltar.action.performed += AlSaltar;
    }

    public override void OnNetworkDespawn()
    {
        if (!IsOwner)
            return;

        accionSaltar.action.performed -= AlSaltar;
        accionSaltar.action.Disable();
    }

    private void AlSaltar(InputAction.CallbackContext contexto)
    {
        if (saltando)
            return;

        StartCoroutine(RealizarSalto());
    }

    private IEnumerator RealizarSalto()
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

            visualJugador.localPosition =
                posicionVisualInicial +
                Vector3.up * altura;

            yield return null;
        }

        visualJugador.localPosition =
            posicionVisualInicial;

        if (animatorJugador != null)
        {
            animatorJugador.SetBool("Saltando", false);
        }

        saltando = false;
    }
}