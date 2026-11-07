
using UnityEngine;
using Unity.Netcode;

public class ControlReinicioCamino : NetworkBehaviour
{
    [Header("Puntos iniciales")]
    [SerializeField] private Transform spawnElian;
    [SerializeField] private Transform spawnLia;

    [Header("Sistemas")]
    [SerializeField] private ControlCheckpointCamino controlCheckpoint;
    [SerializeField] private VidasEquipo vidasEquipo;
    [SerializeField] private ControlSaltosPuente controlSaltos;

    private bool reinicioEnProceso;

    public override void OnNetworkSpawn()
    {
        if (!IsServer)
            return;

        // Buscar componentes en SistemaCamino.
        if (controlCheckpoint == null)
            controlCheckpoint =
                GetComponent<ControlCheckpointCamino>();

        if (vidasEquipo == null)
            vidasEquipo =
                GetComponent<VidasEquipo>();

        if (controlSaltos == null)
            controlSaltos =
                GetComponent<ControlSaltosPuente>();

        // Búsqueda alternativa si no están en el mismo objeto.
        if (controlCheckpoint == null)
            controlCheckpoint =
                FindAnyObjectByType<ControlCheckpointCamino>();

        if (vidasEquipo == null)
            vidasEquipo =
                FindAnyObjectByType<VidasEquipo>();

        if (controlSaltos == null)
            controlSaltos =
                FindAnyObjectByType<ControlSaltosPuente>();

        if (vidasEquipo != null)
        {
            vidasEquipo.AlAgotarVidas += ReiniciarCamino;
        }
        else
        {
            Debug.LogError(
                "ControlReinicioCamino: no se encontró VidasEquipo."
            );
        }

        if (spawnElian == null || spawnLia == null)
        {
            Debug.LogError(
                "Asigna Spawn Elian y Spawn Lia en el Inspector."
            );
        }
    }

    public override void OnNetworkDespawn()
    {
        if (vidasEquipo != null)
            vidasEquipo.AlAgotarVidas -= ReiniciarCamino;
    }

    private void ReiniciarCamino()
    {
        if (!IsServer || reinicioEnProceso)
            return;

        if (NetworkManager.Singleton == null)
            return;

        reinicioEnProceso = true;

        Debug.Log(
            "REINICIANDO COMPLETAMENTE EL CAMINO DE MADERA."
        );

        // 1. Restaurar todos los tablones.
        PlataformaCamino[] tablones =
            FindObjectsByType<PlataformaCamino>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None
            );

        foreach (PlataformaCamino tablon in tablones)
        {
            if (tablon != null && tablon.IsSpawned)
                tablon.RestablecerServidor();
        }

        // 2. Reiniciar el progreso del puente.
        if (controlSaltos != null)
        {
            controlSaltos.ReiniciarRuta();
        }

        // 3. Borrar los checkpoints de todos.
        if (controlCheckpoint != null)
        {
            foreach (ulong id in
                NetworkManager.Singleton.ConnectedClientsIds)
            {
                controlCheckpoint.ReiniciarCheckpoint(id);
            }
        }

        // 4. Restaurar las tres vidas.
        if (vidasEquipo != null)
            vidasEquipo.RestaurarVidas();

        // 5. Devolver a cada jugador a su spawn.
        foreach (ulong id in
            NetworkManager.Singleton.ConnectedClientsIds)
        {
            Transform spawn =
                id == NetworkManager.ServerClientId
                ? spawnElian
                : spawnLia;

            if (spawn == null)
            {
                Debug.LogError(
                    "No se encontró el spawn del jugador: " + id
                );

                continue;
            }

            ReposicionarJugadorClientRpc(
                spawn.position,
                new ClientRpcParams
                {
                    Send = new ClientRpcSendParams
                    {
                        TargetClientIds = new[] { id }
                    }
                }
            );
        }

        Debug.Log(
            "CAMINO REINICIADO. VIDAS RESTAURADAS."
        );

        reinicioEnProceso = false;
    }

    [ClientRpc]
    private void ReposicionarJugadorClientRpc(
        Vector3 posicion,
        ClientRpcParams rpcParams = default)
    {
        if (NetworkManager.Singleton == null)
            return;

        NetworkObject jugador =
            NetworkManager.Singleton.SpawnManager
            .GetLocalPlayerObject();

        if (jugador == null || !jugador.IsOwner)
            return;

        Rigidbody2D cuerpo =
            jugador.GetComponent<Rigidbody2D>();

        if (cuerpo != null)
        {
            cuerpo.linearVelocity = Vector2.zero;
            cuerpo.angularVelocity = 0f;
            cuerpo.position = posicion;
            cuerpo.rotation = 0f;
        }

        jugador.transform.position = posicion;

        Physics2D.SyncTransforms();

        Debug.Log(
            "JUGADOR DEVUELTO A SU SPAWN: " + posicion
        );
    }
}
