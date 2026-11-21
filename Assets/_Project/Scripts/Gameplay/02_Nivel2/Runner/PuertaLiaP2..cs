
using System.Collections.Generic;
using UnityEngine;

public class PuertaLiaP2 : MonoBehaviour
{
    [Header("Identificacion")]
    [SerializeField] private int numeroPuerta = 1;

    [Header("Animacion")]
    [SerializeField] private Animator animatorPuerta;
    [SerializeField] private string parametroCerrar = "Cerrar";

    [Header("Zona de ralentizacion")]
    [SerializeField] private BoxCollider2D colliderBloqueo;

    private bool cerrada;

    private readonly HashSet<Collider2D> collidersVigilia =
        new HashSet<Collider2D>();

    public int NumeroPuerta => numeroPuerta;

    private void Awake()
    {
        if (animatorPuerta == null)
            animatorPuerta = GetComponent<Animator>();

        if (animatorPuerta == null)
        {
            Debug.LogError(
                "P2: Puerta " + numeroPuerta +
                " no tiene Animator asignado."
            );
        }

        if (colliderBloqueo != null)
        {
            colliderBloqueo.isTrigger = true;
            colliderBloqueo.enabled = false;
        }

        cerrada = false;
    }

    // =====================================
    // CERRAR PUERTA
    // =====================================

    public void CerrarVisualLocal()
    {
        if (cerrada)
            return;

        if (animatorPuerta == null)
        {
            Debug.LogError(
                "P2: No se puede cerrar puerta " +
                numeroPuerta + ". Falta Animator."
            );
            return;
        }

        if (!animatorPuerta.isActiveAndEnabled)
        {
            Debug.LogError(
                "P2: Animator de puerta " +
                numeroPuerta + " está desactivado."
            );
            return;
        }

        if (!TieneParametroCerrar())
        {
            Debug.LogError(
                "P2: No existe el parámetro Bool '" +
                parametroCerrar + "' en la puerta " +
                numeroPuerta
            );
            return;
        }

        cerrada = true;

        animatorPuerta.SetBool(parametroCerrar, true);

        Debug.Log(
            "P2: CIERRE EJECUTADO. Puerta " + numeroPuerta
        );
    }

    private bool TieneParametroCerrar()
    {
        foreach (AnimatorControllerParameter parametro
                 in animatorPuerta.parameters)
        {
            if (parametro.name == parametroCerrar &&
                parametro.type == AnimatorControllerParameterType.Bool)
                return true;
        }

        return false;
    }

    // =====================================
    // ACTIVAR ZONA AL TERMINAR ANIMACION
    // =====================================

    public void ActivarBloqueo()
    {
        if (!cerrada)
            return;

        if (colliderBloqueo == null)
        {
            Debug.LogWarning(
                "P2: Falta collider de bloqueo en puerta " +
                numeroPuerta
            );
            return;
        }

        colliderBloqueo.enabled = true;

        Debug.Log(
            "P2: Zona de ralentizacion activada. Puerta " +
            numeroPuerta
        );
    }

    // =====================================
    // ENTRADA DE LA VIGILIA
    // =====================================

    private void OnTriggerEnter2D(Collider2D otro)
    {
        PersecucionVigiliaP2 vigilia =
            otro.GetComponentInParent<PersecucionVigiliaP2>();

        if (vigilia == null)
            return;

        if (!collidersVigilia.Add(otro))
            return;

        vigilia.EntrarZonaPuerta();

        Debug.Log(
            "P2: Vigilia entra en puerta " + numeroPuerta
        );
    }

    // =====================================
    // SALIDA DE LA VIGILIA
    // =====================================

    private void OnTriggerExit2D(Collider2D otro)
    {
        PersecucionVigiliaP2 vigilia =
            otro.GetComponentInParent<PersecucionVigiliaP2>();

        if (vigilia == null)
            return;

        if (!collidersVigilia.Remove(otro))
            return;

        vigilia.SalirZonaPuerta();

        Debug.Log(
            "P2: Vigilia sale de puerta " + numeroPuerta
        );
    }

    // =====================================
    // LIMPIEZA
    // =====================================

    private void OnDisable()
    {
        foreach (Collider2D colision in collidersVigilia)
        {
            if (colision == null)
                continue;

            PersecucionVigiliaP2 vigilia =
                colision.GetComponentInParent<PersecucionVigiliaP2>();

            if (vigilia != null)
                vigilia.SalirZonaPuerta();
        }

        collidersVigilia.Clear();
    }
}
