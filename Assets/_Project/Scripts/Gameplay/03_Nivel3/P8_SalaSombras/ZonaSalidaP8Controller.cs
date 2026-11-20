
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(NetworkObject))]
[RequireComponent(typeof(BoxCollider2D))]
public class ZonaSalidaP8Controller : NetworkBehaviour
{
    [Header("Referencias")]
    [SerializeField] private DispositivosLlavesP8 dispositivosLlaves;
    [SerializeField]
    private HistorietaFinalP8Controller historietaFinal;

    // Jugadores presentes en la zona.
    private readonly HashSet<ulong> elianDentro =
        new HashSet<ulong>();

    private readonly HashSet<ulong> liaDentro =
        new HashSet<ulong>();

    // Control de colliders por jugador.
    private readonly Dictionary<Collider2D, ulong> propietarioCollider =
        new Dictionary<Collider2D, ulong>();

    private readonly Dictionary<ulong, HashSet<Collider2D>> collidersJugador =
        new Dictionary<ulong, HashSet<Collider2D>>();

    // Sincronización de la historieta.
    private NetworkVariable<bool> historietaMostrada =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    // =====================================
    // INICIO
    // =====================================

    public override void OnNetworkSpawn()
    {
        historietaMostrada.OnValueChanged += ActualizarHistorieta;

        if (IsServer)
            historietaMostrada.Value = false;

        AplicarEstadoHistorieta(historietaMostrada.Value);

        Debug.Log("P8 | Zona de salida cooperativa iniciada.");
    }

    public override void OnNetworkDespawn()
    {
        historietaMostrada.OnValueChanged -= ActualizarHistorieta;

        elianDentro.Clear();
        liaDentro.Clear();
        propietarioCollider.Clear();
        collidersJugador.Clear();
    }

    // =====================================
    // DETECTAR ENTRADA
    // =====================================

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsServer || historietaMostrada.Value)
            return;

        NetworkPlayerSetup setup =
            other.GetComponentInParent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
            return;

        NetworkObject jugador =
            setup.GetComponent<NetworkObject>();

        if (jugador == null)
            return;

        ulong clienteId = jugador.OwnerClientId;

        if (propietarioCollider.ContainsKey(other))
            return;

        propietarioCollider.Add(other, clienteId);

        if (!collidersJugador.ContainsKey(clienteId))
        {
            collidersJugador.Add(
                clienteId,
                new HashSet<Collider2D>()
            );
        }

        collidersJugador[clienteId].Add(other);

        if (setup.EsElian)
            elianDentro.Add(clienteId);
        else
            liaDentro.Add(clienteId);

        Debug.Log(
            "P8 | Jugador entró en salida: " +
            (setup.EsElian ? "Elian" : "Lía")
        );

        ComprobarSalida();
    }

    // =====================================
    // DETECTAR PERMANENCIA
    // =====================================

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!IsServer || historietaMostrada.Value)
            return;

        ComprobarSalida();
    }

    // =====================================
    // DETECTAR SALIDA
    // =====================================

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!IsServer)
            return;

        if (!propietarioCollider.TryGetValue(
            other, out ulong clienteId))
            return;

        propietarioCollider.Remove(other);

        if (!collidersJugador.TryGetValue(
            clienteId, out HashSet<Collider2D> colliders))
            return;

        colliders.Remove(other);

        // Si conserva otro collider dentro,
        // el jugador sigue presente.

        if (colliders.Count > 0)
            return;

        collidersJugador.Remove(clienteId);

        elianDentro.Remove(clienteId);
        liaDentro.Remove(clienteId);

        Debug.Log(
            "P8 | Jugador salió de la zona: " + clienteId
        );
    }

    // =====================================
    // COMPROBAR SALIDA COOPERATIVA
    // =====================================

    private void ComprobarSalida()
    {
        if (!IsServer || historietaMostrada.Value)
            return;

        if (dispositivosLlaves == null)
        {
            Debug.LogError(
                "P8 | Falta asignar DispositivosLlavesP8."
            );
            return;
        }

        // Ambas llaves deben estar colocadas.

        if (!dispositivosLlaves.AmbasLlavesColocadas)
            return;

        // Elian y Lía deben estar presentes.

        if (elianDentro.Count == 0 || liaDentro.Count == 0)
            return;

        // Activar una sola vez.

        historietaMostrada.Value = true;

        Debug.Log(
            "P8 | AMBOS JUGADORES LLEGARON. " +
            "MOSTRANDO HISTORIETA FINAL."
        );
    }

    // =====================================
    // SINCRONIZAR HISTORIETA
    // =====================================

    private void ActualizarHistorieta(
        bool anterior,
        bool nuevo)
    {
        AplicarEstadoHistorieta(nuevo);
    }

    private void AplicarEstadoHistorieta(bool mostrar)
    {
        if (historietaFinal == null)
        {
            Debug.LogError(
                "P8 | Falta asignar HistorietaFinalP8Controller."
            );
            return;
        }

        if (mostrar)
            historietaFinal.MostrarHistorietaFinal();
    }
}
