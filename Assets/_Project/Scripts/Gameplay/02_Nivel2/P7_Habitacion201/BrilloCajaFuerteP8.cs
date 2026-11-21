
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class BrilloCajaFuerteP8 : MonoBehaviour
{
    [Header("Objeto visual")]
    [SerializeField] private GameObject objetoBrillo;

    private readonly HashSet<Collider2D> collidersElian =
        new HashSet<Collider2D>();

    private void Awake()
    {
        if (objetoBrillo != null)
            objetoBrillo.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        NetworkPlayerSetup setup =
            jugador.GetComponent<NetworkPlayerSetup>();

        if (setup == null ||
            !setup.RolConfigurado ||
            !setup.EsElian)
            return;

        collidersElian.Add(otro);

        ActualizarBrillo();

        Debug.Log("P8 | Elian se acercó a la caja fuerte.");
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        if (!collidersElian.Contains(otro))
            return;

        collidersElian.Remove(otro);

        ActualizarBrillo();

        Debug.Log("P8 | Elian se alejó de la caja fuerte.");
    }

    private void ActualizarBrillo()
    {
        if (objetoBrillo != null)
            objetoBrillo.SetActive(collidersElian.Count > 0);
    }

    private void OnDisable()
    {
        collidersElian.Clear();

        if (objetoBrillo != null)
            objetoBrillo.SetActive(false);
    }
}
