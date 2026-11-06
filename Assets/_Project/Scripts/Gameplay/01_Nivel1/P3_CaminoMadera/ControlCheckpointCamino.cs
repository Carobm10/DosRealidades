
using UnityEngine;
using Unity.Netcode;
using System.Collections.Generic;

public class ControlCheckpointCamino : NetworkBehaviour
{
    [Header("Punto inicial")]
    [SerializeField] private Transform inicioCamino;

    private Vector3 posicionInicio;

    private Dictionary<ulong, Vector3> puntosSeguros =
        new Dictionary<ulong, Vector3>();

    public override void OnNetworkSpawn()
    {
        if (inicioCamino != null)
            posicionInicio = inicioCamino.position;

        if (IsServer)
            puntosSeguros.Clear();
    }

    public void RegistrarCheckpointServidor(
        ulong jugadorId,
        Vector3 posicion)
    {
        if (!IsServer)
            return;

        puntosSeguros[jugadorId] = posicion;
    }

    // Recuperacion en un punto asignado manualmente.
    public void RecuperarJugador(
        ulong jugadorId,
        Vector3 posicion)
    {
        if (!IsServer)
            return;

        EnviarRespawn(jugadorId, posicion);
    }

    // Recuperacion automatica si no hay punto asignado.
    public void RecuperarJugador(ulong jugadorId)
    {
        if (!IsServer)
            return;

        Vector3 posicion = posicionInicio;

        if (puntosSeguros.TryGetValue(
            jugadorId, out Vector3 guardada))
        {
            posicion = guardada;
        }

        EnviarRespawn(jugadorId, posicion);
    }

    private void EnviarRespawn(
        ulong jugadorId,
        Vector3 posicion)
    {
        RecuperarJugadorClientRpc(
            posicion,
            new ClientRpcParams
            {
                Send = new ClientRpcSendParams
                {
                    TargetClientIds = new[] { jugadorId }
                }
            }
        );
    }

    [ClientRpc]
    private void RecuperarJugadorClientRpc(
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
        }

        jugador.transform.position = posicion;

        Debug.Log("LIA RECUPERADA EN: " + posicion);
    }

    public void ReiniciarCheckpoint(ulong jugadorId)
    {
        if (!IsServer)
            return;

        puntosSeguros.Remove(jugadorId);
    }

    public Vector3 ObtenerInicio()
    {
        return inicioCamino != null
            ? inicioCamino.position
            : posicionInicio;
    }
}
