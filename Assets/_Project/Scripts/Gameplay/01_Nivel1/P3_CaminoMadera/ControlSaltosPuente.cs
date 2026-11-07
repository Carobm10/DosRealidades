
using UnityEngine;
using Unity.Netcode;
using System.Collections.Generic;

public class ControlSaltosPuente : NetworkBehaviour
{
    [System.Serializable]
    public class FilaSalto
    {
        public Transform tablonIzquierdo;
        public Transform tablonDerecho;
    }

    [Header("Inicio")]
    [SerializeField] private Transform puntoInicio;

    [Header("Siete filas")]
    [SerializeField] private FilaSalto[] filas = new FilaSalto[7];

    // true = derecha, false = izquierda.
    private readonly bool[] rutaCorrecta =
    {
        true, false, false, true, false, true, true
    };

    private NetworkVariable<int> filaActual =
        new NetworkVariable<int>(
            -1,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private HashSet<ulong> solicitudesProcesadas =
        new HashSet<ulong>();

    private ControlCheckpointCamino checkpoint;
    private ControlFinalP3 controlFinal;

    public int FilaActual => filaActual.Value;
    public Transform PuntoInicio => puntoInicio;
    public bool RutaCompletada => filaActual.Value >= 6;

    public override void OnNetworkSpawn()
    {
        checkpoint =
            FindAnyObjectByType<ControlCheckpointCamino>();

        controlFinal =
            FindAnyObjectByType<ControlFinalP3>();
    }

    public Transform ObtenerDestino(bool derecha)
    {
        int siguiente = filaActual.Value + 1;

        if (filas == null ||
            siguiente < 0 ||
            siguiente >= filas.Length ||
            filas[siguiente] == null)
            return null;

        return derecha
            ? filas[siguiente].tablonDerecho
            : filas[siguiente].tablonIzquierdo;
    }

    public void SolicitarValidacionAterrizaje(
        Transform destino,
        bool derecha)
    {
        if (!IsSpawned || destino == null)
            return;

        NetworkObject plataforma =
            destino.GetComponentInParent<NetworkObject>();

        if (plataforma == null)
        {
            Debug.LogError(
                "El tablón no tiene NetworkObject."
            );
            return;
        }

        ValidarAterrizajeRpc(
            new NetworkObjectReference(plataforma),
            derecha
        );
    }

    [Rpc(
        SendTo.Server,
        InvokePermission = RpcInvokePermission.Everyone
    )]
    private void ValidarAterrizajeRpc(
        NetworkObjectReference referencia,
        bool derecha,
        RpcParams rpcParams = default)
    {
        if (!IsServer)
            return;

        ulong jugadorId =
            rpcParams.Receive.SenderClientId;

        Debug.Log(
            "VALIDANDO SALTO. JUGADOR: " + jugadorId
        );

        if (!solicitudesProcesadas.Add(jugadorId))
            return;

        try
        {
            ProcesarValidacion(
                jugadorId,
                referencia,
                derecha
            );
        }
        finally
        {
            solicitudesProcesadas.Remove(jugadorId);

            // Desbloquear el salto del jugador que lo solicitó.
            ConfirmarValidacionClientRpc(
                new ClientRpcParams
                {
                    Send = new ClientRpcSendParams
                    {
                        TargetClientIds = new[] { jugadorId }
                    }
                }
            );
        }
    }

    private void ProcesarValidacion(
        ulong jugadorId,
        NetworkObjectReference referencia,
        bool derecha)
    {
        if (RutaCompletada)
            return;

        if (filas == null || filas.Length == 0)
            return;

        if (!referencia.TryGet(out NetworkObject plataforma))
        {
            Debug.LogError("No se encontró el tablón aterrizado.");
            return;
        }

        int fila = filaActual.Value + 1;

        if (fila < 0 || fila >= filas.Length ||
            filas[fila] == null)
            return;

        Transform destinoEsperado = derecha
            ? filas[fila].tablonDerecho
            : filas[fila].tablonIzquierdo;

        if (destinoEsperado == null)
            return;

        NetworkObject plataformaEsperada =
            destinoEsperado.GetComponentInParent<NetworkObject>();

        PlataformaCamino componente =
            plataforma.GetComponentInParent<PlataformaCamino>();

        if (plataformaEsperada == null || componente == null)
        {
            Debug.LogError(
                "Falta NetworkObject o PlataformaCamino."
            );
            return;
        }

        if (componente.EstaDestruida)
            return;

        bool ladoCorrecto =
            derecha == rutaCorrecta[fila];

        bool destinoCorrecto =
            plataforma == plataformaEsperada;

        bool esSeguro =
            componente.EsSeguro;

        Debug.Log(
            "RESULTADO: Fila " + fila +
            " | Lado: " + ladoCorrecto +
            " | Destino: " + destinoCorrecto +
            " | Seguro: " + esSeguro
        );

        if (ladoCorrecto && destinoCorrecto && esSeguro)
        {
            ProcesarSaltoCorrecto(
                jugadorId,
                destinoEsperado,
                fila
            );
        }
        else
        {
            ProcesarSaltoIncorrecto(
                jugadorId,
                componente
            );
        }
    }

    private void ProcesarSaltoCorrecto(
        ulong jugadorId,
        Transform destino,
        int fila)
    {
        filaActual.Value = fila;

        Debug.Log(
            "SALTO CORRECTO. FILA: " + fila
        );

        if (checkpoint == null)
        {
            checkpoint =
                FindAnyObjectByType<ControlCheckpointCamino>();
        }

        if (checkpoint != null)
        {
            checkpoint.RegistrarCheckpointServidor(
                jugadorId,
                destino.position,
                fila
            );
        }
        else
        {
            Debug.LogError(
                "No se encontró ControlCheckpointCamino."
            );
        }

        if (fila == filas.Length - 1)
        {
            Debug.Log("PUENTE COMPLETADO.");

            if (controlFinal == null)
            {
                controlFinal =
                    FindAnyObjectByType<ControlFinalP3>();
            }

            if (controlFinal != null)
                controlFinal.ActivarBotonesServidor();
            else
                Debug.LogError("No se encontró ControlFinalP3.");
        }
    }

    private void ProcesarSaltoIncorrecto(
        ulong jugadorId,
        PlataformaCamino plataforma)
    {
        Debug.LogWarning("SALTO INCORRECTO.");

        // El tablón incorrecto desaparece.
        plataforma.DestruirServidor();

        VidasEquipo vidas = VidasEquipo.Instancia;

        if (vidas == null)
        {
            Debug.LogError("No se encontró VidasEquipo.");
            return;
        }

        bool quedanVidas =
            vidas.PerderVidaServidor();

        if (quedanVidas)
        {
            if (checkpoint == null)
            {
                checkpoint =
                    FindAnyObjectByType<ControlCheckpointCamino>();
            }

            if (checkpoint != null)
            {
                checkpoint.RecuperarJugador(jugadorId);
            }
            else
            {
                Debug.LogError(
                    "No se encontró el checkpoint para recuperar a Lía."
                );
            }
        }
    }

    [ClientRpc]
    private void ConfirmarValidacionClientRpc(
        ClientRpcParams rpcParams = default)
    {
        NetworkObject jugador =
            NetworkManager.Singleton.SpawnManager
            .GetLocalPlayerObject();

        if (jugador == null || !jugador.IsOwner)
            return;

        SaltoJugador salto =
            jugador.GetComponent<SaltoJugador>();

        salto?.ConfirmarValidacion();

        Debug.Log("CONFIRMACIÓN DE SALTO RECIBIDA.");
    }

    public void EstablecerFilaServidor(int fila)
    {
        if (!IsServer)
            return;

        filaActual.Value =
            Mathf.Clamp(fila, -1, filas.Length - 1);
    }

    public void ReiniciarRuta()
    {
        if (!IsServer)
            return;

        filaActual.Value = -1;
        solicitudesProcesadas.Clear();

        Debug.Log("RUTA REINICIADA.");
    }
}
