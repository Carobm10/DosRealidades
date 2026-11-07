
using UnityEngine;
using Unity.Netcode;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class ZonaPuente : MonoBehaviour
{
    private HashSet<Collider2D> contactos =
        new HashSet<Collider2D>();

    private NetworkPlayerMovement movimientoLocal;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        if (!IdentidadJugadorLocal.EsLia())
            return;

        NetworkPlayerMovement movimiento =
            jugador.GetComponent<NetworkPlayerMovement>();

        if (movimiento == null)
            return;

        contactos.Add(otro);

        movimientoLocal = movimiento;

        movimientoLocal.ActivarModoPuente(true);
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        if (!contactos.Remove(otro))
            return;

        if (contactos.Count > 0)
            return;

        movimientoLocal?.ActivarModoPuente(false);

        movimientoLocal = null;
    }

    private void OnDisable()
    {
        contactos.Clear();

        movimientoLocal?.ActivarModoPuente(false);

        movimientoLocal = null;
    }
}
