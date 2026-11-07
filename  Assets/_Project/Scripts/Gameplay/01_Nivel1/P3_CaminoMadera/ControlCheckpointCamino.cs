
using UnityEngine;
using Unity.Netcode;
using System.Collections.Generic;

public class ControlCheckpointCamino : NetworkBehaviour
{
    [Header("Punto inicial")]
    [SerializeField] private Transform inicioCamino;

    private struct DatosCheckpoint
    {
        public Vector3 posicion;
        public int fila;

        public DatosCheckpoint(Vector3 posicion, int fila)
        {
            this.posicion = posicion;
            this.fila = fila;
        }
    }

    private Vector3 posicionInicio;

    private Dictionary<ulong, DatosCheckpoint> checkpoints =
        new Dictionary<ulong, DatosCheckpoint>();

    private ControlSaltosPuente controlSaltos;

    public override void OnNetworkSpawn()
    {
        if (inicioCamino != null)
            posicionInicio = inicioCamino.position;

        controlSaltos =
            FindFirstObjectByType<ControlSaltosPuente>();

        if (IsServer)
            checkpoints.Clear();
    }

    public void RegistrarCheckpointServidor(
        ulong jugadorId,
        Vector3 posicion,
        int fila)
    {
        if (!IsServer)
            return;

        checkpoints[jugadorId] =
            new DatosCheckpoint(posicion, fila);

        Debug.Log(
            "CHECKPOINT GUARDADO: FILA " + fila
        );
    }

    public void RecuperarJugador(ulong jugadorId)
    {
        if (!IsServer)
            return;

        Vector3 posicion = posicionInicio;
        int fila = -1;

        if (checkpoints.TryGetValue(
            jugadorId, out DatosCheckpoint datos))
        {
            posicion = datos.posicion;
            fila = datos.fila;
        }

        if (controlSaltos == null)
            controlSaltos =
                FindFirstObjectByType<ControlSaltosPuente>();

        if (controlSaltos != null)
            controlSaltos.EstablecerFilaServidor(fila);

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

        Debug.Log("RECUPERANDO EN: " + posicion);
    }

    public void ReiniciarCheckpoint(ulong jugadorId)
    {
        if (!IsServer)
            return;

        checkpoints.Remove(jugadorId);
    }

    public Vector3 ObtenerInicio()
    {
        return inicioCamino != null
            ? inicioCamino.position
            : posicionInicio;
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

        Physics2D.SyncTransforms();

        Debug.Log("JUGADOR RECUPERADO: " + posicion);
    }
}
