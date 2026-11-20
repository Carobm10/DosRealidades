
using UnityEngine;
using Unity.Netcode;
using System.Collections;
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

    [Header("Pistas de codigo de Lia")]
    [SerializeField]
    private string idPistaLia90 = "fragmento_codigo_lia";

    [SerializeField]
    private string idPistaLia15 = "fragmento_carta_lia";

    [Header("Tiempo de apertura")]
    [SerializeField]
    private float esperaDespuesDeApertura = 1.2f;

    private bool codigoProcesado;
    private bool llavesEntregadas;

    private Coroutine rutinaEntrega;

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

        if (codigoProcesado)
            return;

        if (IsServer)
        {
            ProcesarCodigoCorrectoServidor();
        }
        else
        {
            SolicitarAperturaCajaRpc();
        }
    }

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void SolicitarAperturaCajaRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer || codigoProcesado)
            return;

        ulong clienteId =
            rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients
            .TryGetValue(clienteId, out var cliente))
            return;

        if (cliente.PlayerObject == null)
            return;

        NetworkPlayerSetup setup =
            cliente.PlayerObject.GetComponent<NetworkPlayerSetup>();

        if (setup == null ||
            !setup.RolConfigurado ||
            !setup.EsElian)
            return;

        ProcesarCodigoCorrectoServidor();
    }

    private void ProcesarCodigoCorrectoServidor()
    {
        if (!IsServer || codigoProcesado)
            return;

        if (salidaCooperativa == null)
        {
            Debug.LogError(
                "CAJA 201: Falta ZonaSalidaCooperativa."
            );
            return;
        }

        codigoProcesado = true;
        llavesEntregadas = false;

        jugadoresCerraronTarjeta.Clear();

        // =================================
        // PRIMERO: ELIMINAR PISTAS DE LIA
        // INMEDIATAMENTE AL ACEPTAR CODIGO
        // =================================

        EliminarPistasCodigoLiaInmediatamente();

        Debug.Log(
            "CAJA 201: Codigo correcto. " +
            "Pistas anteriores de Lia eliminadas."
        );

        // Cerrar teclado de Elian.
        if (panelTecladoElian != null)
            panelTecladoElian.SetActive(false);

        // =================================
        // SEGUNDO: INICIAR CINEMATICA
        // =================================

        Debug.Log(
            "CAJA 201: Iniciando apertura de puertas."
        );

        salidaCooperativa.HabilitarSalida();

        // =================================
        // TERCERO: ESPERAR APERTURA
        // =================================

        rutinaEntrega =
            StartCoroutine(EntregarLlavesDespuesDeApertura());
    }

    // =====================================
    // ELIMINAR PISTAS DE LIA
    // =====================================

    private void EliminarPistasCodigoLiaInmediatamente()
    {
        if (!IsServer ||
            NetworkManager.Singleton == null)
            return;

        foreach (var cliente in
            NetworkManager.Singleton.ConnectedClientsList)
        {
            NetworkObject jugador = cliente.PlayerObject;

            if (jugador == null || !jugador.IsSpawned)
                continue;

            NetworkPlayerSetup setup =
                jugador.GetComponent<NetworkPlayerSetup>();

            if (setup == null ||
                !setup.RolConfigurado ||
                setup.EsElian)
                continue;

            InventarioJugador inventarioLia =
                jugador.GetComponent<InventarioJugador>();

            if (inventarioLia == null)
            {
                Debug.LogError(
                    "CAJA 201: Lia no tiene InventarioJugador."
                );
                return;
            }

            EliminarPistasCodigoLia(inventarioLia);

            return;
        }

        Debug.LogError(
            "CAJA 201: No se encontro el jugador Lia."
        );
    }

    private void EliminarPistasCodigoLia(
        InventarioJugador inventarioLia)
    {
        if (!IsServer || inventarioLia == null)
            return;

        if (inventarioLia.TieneObjeto(idPistaLia90))
        {
            inventarioLia.EliminarObjetoDesdeServidor(
                idPistaLia90
            );

            Debug.Log(
                "CAJA 201: Eliminada pista 90 de Lia."
            );
        }

        if (inventarioLia.TieneObjeto(idPistaLia15))
        {
            inventarioLia.EliminarObjetoDesdeServidor(
                idPistaLia15
            );

            Debug.Log(
                "CAJA 201: Eliminada pista 15 de Lia."
            );
        }
    }

    // =====================================
    // ESPERAR APERTURA DE PUERTA
    // =====================================

    private IEnumerator EntregarLlavesDespuesDeApertura()
    {
        yield return new WaitForSecondsRealtime(
            Mathf.Max(0f, esperaDespuesDeApertura)
        );

        if (!IsServer || !IsSpawned)
            yield break;

        if (!EntregarLlaves())
        {
            Debug.LogError(
                "CAJA 201: No se pudieron entregar las llaves."
            );

            rutinaEntrega = null;
            yield break;
        }

        llavesEntregadas = true;

        Debug.Log(
            "CAJA 201: Ambas llaves entregadas. " +
            "Esperando cierre de tarjetas."
        );

        rutinaEntrega = null;
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
                "CAJA 201: No se encontraron ambos jugadores."
            );
            return false;
        }

        InventarioJugador inventarioElian =
            jugadorElian.GetComponent<InventarioJugador>();

        InventarioJugador inventarioLia =
            jugadorLia.GetComponent<InventarioJugador>();

        if (inventarioElian == null ||
            inventarioLia == null)
        {
            Debug.LogError(
                "CAJA 201: Falta InventarioJugador."
            );
            return false;
        }

        // Comprobar definiciones.
        ObjetoInventario llaveElian =
            inventarioElian.ObtenerObjetoPorId(idLlaveElian);

        ObjetoInventario llaveLia =
            inventarioLia.ObtenerObjetoPorId(idLlaveLia);

        if (llaveElian == null || llaveLia == null)
        {
            Debug.LogError(
                "CAJA 201: No se encontraron las definiciones. " +
                "Elian: " + (llaveElian != null) +
                " | Lia: " + (llaveLia != null)
            );
            return false;
        }

        // Agregar sin duplicar.
        bool elianOK =
            inventarioElian.TieneObjeto(idLlaveElian) ||
            inventarioElian.AgregarObjetoDesdeServidor(
                idLlaveElian
            );

        bool liaOK =
            inventarioLia.TieneObjeto(idLlaveLia) ||
            inventarioLia.AgregarObjetoDesdeServidor(
                idLlaveLia
            );

        if (!elianOK || !liaOK)
        {
            Debug.LogError(
                "CAJA 201: Error agregando las llaves. " +
                "Elian: " + elianOK +
                " | Lia: " + liaOK
            );
            return false;
        }

        // Enviar cada tarjeta a su jugador.
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
            "CAJA 201: LLAVES ENTREGADAS A AMBOS."
        );

        return true;
    }

    // =====================================
    // MOSTRAR TARJETAS INDIVIDUALES
    // ESPERANDO SINCRONIZACION
    // =====================================

    [Rpc(SendTo.SpecifiedInParams)]
    private void EnviarTarjetaLlaveRpc(
        string idObjeto,
        RpcParams rpcParams = default)
    {
        Debug.Log(
            "CAJA 201: Solicitud de tarjeta recibida: " +
            idObjeto
        );

        StartCoroutine(
            EsperarInventarioYMostrarTarjeta(idObjeto)
        );
    }

    private IEnumerator EsperarInventarioYMostrarTarjeta(
        string idObjeto)
    {
        float tiempoEspera = 0f;
        const float tiempoMaximo = 10f;

        while (tiempoEspera < tiempoMaximo)
        {
            InventarioUI inventarioUI =
                InventarioUI.Instancia;

            if (inventarioUI == null)
            {
                inventarioUI =
                    FindFirstObjectByType<InventarioUI>();
            }

            if (inventarioUI != null &&
                inventarioUI.PuedeMostrarTarjetaPorId(idObjeto))
            {
                inventarioUI.MostrarTarjetaPorId(idObjeto);

                Debug.Log(
                    "CAJA 201: TARJETA MOSTRADA CORRECTAMENTE: " +
                    idObjeto
                );

                yield break;
            }

            tiempoEspera += Time.unscaledDeltaTime;

            yield return null;
        }

        Debug.LogError(
            "CAJA 201: TIEMPO AGOTADO ESPERANDO TARJETA: " +
            idObjeto
        );
    }

    // =====================================
    // CERRAR TARJETAS
    // =====================================

    public void ConfirmarCierreTarjetaLlave(string idObjeto)
    {
        if (!IsSpawned || !IsClient)
            return;

        if (idObjeto != idLlaveElian &&
            idObjeto != idLlaveLia)
            return;

        ConfirmarCierreTarjetaRpc(idObjeto);
    }

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void ConfirmarCierreTarjetaRpc(
        string idObjeto,
        RpcParams rpcParams = default)
    {
        if (!IsServer ||
            !codigoProcesado ||
            !llavesEntregadas ||
            salidaCooperativa == null)
            return;

        ulong jugadorId =
            rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients
            .TryGetValue(jugadorId, out var cliente))
            return;

        if (cliente.PlayerObject == null)
            return;

        NetworkPlayerSetup setup =
            cliente.PlayerObject.GetComponent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
            return;

        // Cada jugador debe cerrar su propia llave.
        bool llaveCorrecta = setup.EsElian
            ? idObjeto == idLlaveElian
            : idObjeto == idLlaveLia;

        if (!llaveCorrecta)
            return;

        if (!jugadoresCerraronTarjeta.Add(jugadorId))
            return;

        Debug.Log(
            "CAJA 201: " +
            (setup.EsElian ? "Elian" : "Lia") +
            " cerro su tarjeta. " +
            jugadoresCerraronTarjeta.Count + "/2"
        );

        if (jugadoresCerraronTarjeta.Count < 2)
            return;

        // SOLO AHORA se habilita la salida.
        salidaCooperativa.HabilitarSalidaDespuesDeTarjetas();

        Debug.Log(
            "CAJA 201: AMBAS TARJETAS CERRADAS. " +
            "SALIDA HABILITADA."
        );
    }

    // =====================================
    // LIMPIEZA
    // =====================================

    public override void OnNetworkDespawn()
    {
        if (rutinaEntrega != null)
        {
            StopCoroutine(rutinaEntrega);
            rutinaEntrega = null;
        }
    }
}
