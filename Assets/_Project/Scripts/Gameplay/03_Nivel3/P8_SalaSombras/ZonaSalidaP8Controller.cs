
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(NetworkObject))]
[RequireComponent(typeof(BoxCollider2D))]
public class ZonaSalidaP8Controller : NetworkBehaviour
{
    [Header("Referencias")]
    [SerializeField] private DispositivosLlavesP8 dispositivosLlaves;
    [SerializeField] private HistorietaFinalP8Controller historietaFinal;

    private readonly HashSet<ulong> elianDentro =
        new HashSet<ulong>();

    private readonly HashSet<ulong> liaDentro =
        new HashSet<ulong>();

    private readonly Dictionary<Collider2D, ulong> propietarioCollider =
        new Dictionary<Collider2D, ulong>();

    private readonly Dictionary<ulong, HashSet<Collider2D>> collidersJugador =
        new Dictionary<ulong, HashSet<Collider2D>>();

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

        Debug.Log("P8 | Zona de salida iniciada.");
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

        RegistrarJugador(other);
    }

    // =====================================
    // DETECTAR PERMANENCIA
    // =====================================

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!IsServer || historietaMostrada.Value)
            return;

        RegistrarJugador(other);
        ComprobarSalida();
    }

    // =====================================
    // REGISTRAR JUGADOR
    // =====================================

    private void RegistrarJugador(Collider2D other)
    {
        if (propietarioCollider.ContainsKey(other))
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
            "P8 | Entrada en salida: " +
            (setup.EsElian ? "Elian" : "Lia")
        );

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

        // ESPERAR FIN DE LA CINEMATICA

        if (!dispositivosLlaves.SalidaHabilitada)
            return;

        // COMPROBAR LLAVES

        if (!dispositivosLlaves.AmbasLlavesColocadas)
            return;

        // COMPROBAR AMBOS JUGADORES

        if (elianDentro.Count == 0 || liaDentro.Count == 0)
            return;

        // ACTIVAR HISTORIETA UNA SOLA VEZ

        historietaMostrada.Value = true;

        Debug.Log(
            "P8 | AMBOS JUGADORES EN SALIDA. " +
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
        if (!mostrar)
            return;

        if (historietaFinal == null)
        {
            Debug.LogError(
                "P8 | Falta asignar HistorietaFinalP8Controller."
            );
            return;
        }

        historietaFinal.MostrarHistorietaFinal();
    }
}
