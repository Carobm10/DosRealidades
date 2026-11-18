
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

        cerrada = true;

        if (animatorPuerta != null)
        {
            animatorPuerta.SetBool(parametroCerrar, true);
        }

        Debug.Log(
            "P2: Cerrando puerta de Lia " + numeroPuerta
        );
    }

    // =====================================
    // ACTIVAR ZONA AL TERMINAR ANIMACION
    // =====================================

    public void ActivarBloqueo()
    {
        if (!cerrada)
            return;

        if (colliderBloqueo != null)
        {
            colliderBloqueo.enabled = true;

            Debug.Log(
                "P2: Zona de ralentizacion activada. Puerta " +
                numeroPuerta
            );
        }
        else
        {
            Debug.LogWarning(
                "P2: Falta asignar el collider de puerta " +
                numeroPuerta
            );
        }
    }

    // =====================================
    // LA VIGILIA ENTRA EN LA PUERTA
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
            "P2: La Vigilia entra en zona de puerta " +
            numeroPuerta
        );
    }

    // =====================================
    // LA VIGILIA SALE DE LA PUERTA
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
            "P2: La Vigilia sale de zona de puerta " +
            numeroPuerta
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
