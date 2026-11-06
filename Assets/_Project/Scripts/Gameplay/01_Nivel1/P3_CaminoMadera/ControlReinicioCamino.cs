
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

    private bool reinicioEnProceso;

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            if (controlCheckpoint == null)
                controlCheckpoint = GetComponent<ControlCheckpointCamino>();

            if (vidasEquipo == null)
                vidasEquipo = FindFirstObjectByType<VidasEquipo>();

            if (vidasEquipo != null)
                vidasEquipo.AlAgotarVidas += ReiniciarCamino;
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

        reinicioEnProceso = true;

        Debug.Log("REINICIANDO TODO EL CAMINO DE MADERA");

        // Restaurar todos los tablones.
        PlataformaCamino[] tablones =
            FindObjectsByType<PlataformaCamino>(
                FindObjectsSortMode.None
            );

        foreach (PlataformaCamino tablon in tablones)
        {
            tablon.RestablecerServidor();
        }

        // Borrar el checkpoint de Lia.
        if (controlCheckpoint != null)
        {
            foreach (ulong id in NetworkManager.Singleton.ConnectedClientsIds)
                controlCheckpoint.ReiniciarCheckpoint(id);
        }

        // Recuperar las tres vidas.
        vidasEquipo?.RestaurarVidas();

        // Devolver cada jugador a su spawn.
        foreach (ulong id in NetworkManager.Singleton.ConnectedClientsIds)
        {
            Vector3 posicion;

            if (id == NetworkManager.ServerClientId)
            {
                posicion = spawnElian.position;
            }
            else
            {
                posicion = spawnLia.position;
            }

            ReposicionarJugadorClientRpc(
                posicion,
                new ClientRpcParams
                {
                    Send = new ClientRpcSendParams
                    {
                        TargetClientIds = new[] { id }
                    }
                }
            );
        }

        reinicioEnProceso = false;
    }

    [ClientRpc]
    private void ReposicionarJugadorClientRpc(
        Vector3 posicion,
        ClientRpcParams rpcParams = default)
    {
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
        }

        jugador.transform.position = posicion;

        Debug.Log("JUGADOR REINICIADO EN EL INICIO");
    }
}
