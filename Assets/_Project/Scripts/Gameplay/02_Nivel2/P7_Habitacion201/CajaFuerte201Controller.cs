
using UnityEngine;
using Unity.Netcode;
using System.Collections.Generic;

public class CajaFuerte201Controller : NetworkBehaviour
{
    [Header("Panel de codigo de Elian")]
    [SerializeField]
    private GameObject panelTecladoElian;

    [Header("Salida cooperativa")]
    [SerializeField]
    private ZonaSalidaCooperativa salidaCooperativa;

    [Header("IDs de las llaves")]
    [SerializeField]
    private string idLlaveElian = "Llave_Elian";

    [SerializeField]
    private string idLlaveLia = "Llave_lia";

    private bool codigoProcesado;

    private HashSet<ulong> jugadoresCerraronTarjeta =
        new HashSet<ulong>();

    // =====================================
    // CODIGO CORRECTO
    // =====================================

    public void AbrirDesdeCodigo()
    {
        if (!IsSpawned)
        {
            Debug.LogError(
                "CAJA 201: Controlador no Spawned."
            );
            return;
        }

        if (!IsServer)
        {
            Debug.LogWarning(
                "CAJA 201: Solo el servidor puede iniciar la apertura."
            );
            return;
        }

        if (codigoProcesado)
        {
            Debug.LogWarning(
                "CAJA 201: El código ya fue procesado."
            );
            return;
        }

        if (salidaCooperativa == null)
        {
            Debug.LogError(
                "CAJA 201: Falta asignar ZonaSalidaCooperativa."
            );
            return;
        }

        // Entregar primero las dos llaves.
        if (!EntregarLlaves())
        {
            Debug.LogError(
                "CAJA 201: No se pudieron entregar las dos llaves. " +
                "La salida permanece bloqueada."
            );
            return;
        }

        codigoProcesado = true;

        // Cerrar teclado de Elian.
        if (panelTecladoElian != null)
            panelTecladoElian.SetActive(false);

        Debug.Log(
            "CAJA 201: Código correcto. " +
            "Ambas llaves entregadas."
        );

        Debug.Log(
            "CAJA 201: Esperando que ambos jugadores cierren la tarjeta."
        );
    }

    // =====================================
    // ENTREGAR LLAVES A LOS DOS JUGADORES
    // =====================================

    private bool EntregarLlaves()
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red == null || !IsServer)
            return false;

        NetworkObject jugadorElian = null;
        NetworkObject jugadorLia = null;

        // Identificar los dos NetworkPlayer.
        foreach (var cliente in red.ConnectedClientsList)
        {
            NetworkObject jugador = cliente.PlayerObject;

            if (jugador == null || !jugador.IsSpawned)
                continue;

            NetworkPlayerSetup setup =
                jugador.GetComponent<NetworkPlayerSetup>();

            if (setup == null || !setup.RolConfigurado)
                continue;

            if (setup.EsElian)
                jugadorElian = jugador;
            else
                jugadorLia = jugador;
        }

        if (jugadorElian == null || jugadorLia == null)
        {
            Debug.LogError(
                "CAJA 201: No se encontraron Elian y Lía."
            );
            return false;
        }

        // Obtener inventarios individuales.
        InventarioJugador inventarioElian =
            jugadorElian.GetComponent<InventarioJugador>();

        InventarioJugador inventarioLia =
            jugadorLia.GetComponent<InventarioJugador>();

        if (inventarioElian == null || inventarioLia == null)
        {
            Debug.LogError(
                "CAJA 201: Falta InventarioJugador en uno de los jugadores."
            );
            return false;
        }

        // Comprobar que ambas definiciones existan.
        ObjetoInventario llaveElian =
            inventarioElian.ObtenerObjetoPorId(idLlaveElian);

        ObjetoInventario llaveLia =
            inventarioLia.ObtenerObjetoPorId(idLlaveLia);

        if (llaveElian == null || llaveLia == null)
        {
            Debug.LogError(
                "CAJA 201: No se encontraron las llaves en los catálogos. " +
                "Elian: " + (llaveElian != null) +
                " | Lia: " + (llaveLia != null)
            );
            return false;
        }

        // Agregar cada llave al inventario correspondiente.
        bool elianOK =
            inventarioElian.TieneObjeto(idLlaveElian) ||
            inventarioElian.AgregarObjetoDesdeServidor(idLlaveElian);

        bool liaOK =
            inventarioLia.TieneObjeto(idLlaveLia) ||
            inventarioLia.AgregarObjetoDesdeServidor(idLlaveLia);

        if (!elianOK || !liaOK)
        {
            Debug.LogError(
                "CAJA 201: Falló la entrega de una o ambas llaves."
            );
            return false;
        }

        // Enviar la tarjeta correspondiente a cada jugador.
        EnviarTarjetaLlaveRpc(
            idLlaveElian,
            RpcTarget.Single(
                jugadorElian.OwnerClientId,
                RpcTargetUse.Temp
            )
        );

        EnviarTarjetaLlaveRpc(
            idLlaveLia,
            RpcTarget.Single(
                jugadorLia.OwnerClientId,
                RpcTargetUse.Temp
            )
        );

        Debug.Log(
            "CAJA 201: Entrega completada. " +
            "Elian recibió " + idLlaveElian +
            " | Lía recibió " + idLlaveLia
        );

        return true;
    }

    // =====================================
    // MOSTRAR TARJETA AL JUGADOR CORRECTO
    // =====================================

    [Rpc(SendTo.SpecifiedInParams)]
    private void EnviarTarjetaLlaveRpc(
        string idObjeto,
        RpcParams rpcParams = default)
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red == null ||
            red.LocalClient == null ||
            red.LocalClient.PlayerObject == null)
        {
            Debug.LogError(
                "CAJA 201: No se encontró el jugador local."
            );
            return;
        }

        InventarioJugador inventario =
            red.LocalClient.PlayerObject
            .GetComponent<InventarioJugador>();

        if (inventario == null)
        {
            Debug.LogError(
                "CAJA 201: El jugador local no tiene inventario."
            );
            return;
        }

        // Recuperar la definición del objeto de su inventario.
        ObjetoInventario objeto =
            inventario.ObtenerObjetoPorId(idObjeto);

        if (objeto == null)
        {
            Debug.LogError(
                "CAJA 201: No se encontró la definición de " +
                idObjeto
            );
            return;
        }

        // Utilizar el evento compartido de las tarjetas.
        ObjetoRecolectable.NotificarRecoleccionLocal(
            objeto
        );

        Debug.Log(
            "CAJA 201: Tarjeta de llave enviada al jugador local: " +
            idObjeto
        );
    }


    public void ConfirmarCierreTarjetaLlave()
    {
        if (!IsSpawned || !IsClient)
            return;

        ConfirmarCierreTarjetaRpc();
    }

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void ConfirmarCierreTarjetaRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer || !codigoProcesado)
            return;

        ulong jugadorId = rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients.ContainsKey(jugadorId))
            return;

        jugadoresCerraronTarjeta.Add(jugadorId);

        Debug.Log(
            "CAJA 201: Jugadores que cerraron tarjeta: " +
            jugadoresCerraronTarjeta.Count + "/2"
        );

        if (jugadoresCerraronTarjeta.Count < 2)
            return;

        if (salidaCooperativa != null)
        {
            Debug.Log("CAJA 201: Ambos cerraron. Habilitando salida.");

            salidaCooperativa.HabilitarSalida();
        }
    }

}
