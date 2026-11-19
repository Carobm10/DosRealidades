
using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class P1ElUmbralController : NetworkBehaviour
{
    [Header("Paneles de ambos jugadores")]
    [SerializeField] private GameObject ventanaPanelElian;
    [SerializeField] private GameObject ventanaPanelLia;

    [Header("Interacciones")]
    [SerializeField] private ZonaInteraccion interaccionPanelElian;
    [SerializeField] private ZonaInteraccion interaccionPanelLia;

    [Header("Brillo de los objetivos")]
    [SerializeField] private BrilloObjetivo brilloPanelElian;
    [SerializeField] private BrilloObjetivo brilloPanelLia;

    [Header("Estado del puzzle")]
    [SerializeField] private bool trianguloEsCorrecto = true;

    [Header("Salida cooperativa")]
    [SerializeField] private ZonaSalidaCooperativa zonaSalida;

    [Header("Fragmentos de carta")]
    [SerializeField] private ObjetoInventario fragmentoElian;
    [SerializeField] private ObjetoInventario fragmentoLia;

    private NetworkVariable<bool> panelElianAbierto =
        new NetworkVariable<bool>(false);

    private NetworkVariable<bool> panelLiaAbierto =
        new NetworkVariable<bool>(false);

    private NetworkVariable<bool> puzzleResuelto =
        new NetworkVariable<bool>(false);

    // Estado local de cada cámara.
    private bool esperandoZoom;

    // Confirmaciones sincronizadas por el servidor.
    private bool zoomElianTerminado;
    private bool zoomLiaTerminado;

    // Estado de entrega y cierre de tarjetas.
    private bool fragmentosEntregados;
    private bool tarjetaElianCerrada;
    private bool tarjetaLiaCerrada;

    private bool secuenciaIniciada;

    private Coroutine rutinaSecuencia;

    public bool PuzzleResuelto => puzzleResuelto.Value;

    // =====================================
    // INICIO
    // =====================================

    public override void OnNetworkSpawn()
    {
        InventarioUI.TarjetaObjetoCerradaLocal +=
            AlCerrarTarjetaFragmento;

        CamaraJugadorLocal.ZoomCinematicoFinalizadoLocal +=
            AlTerminarZoomLocal;

        puzzleResuelto.OnValueChanged +=
            AlCambiarEstadoPuzzle;

        Debug.Log(
            "P1: Controlador iniciado. PuzzleResuelto = " +
            puzzleResuelto.Value
        );

        if (puzzleResuelto.Value)
            EjecutarSecuenciaResuelto();
    }

    public override void OnNetworkDespawn()
    {
        InventarioUI.TarjetaObjetoCerradaLocal -=
            AlCerrarTarjetaFragmento;

        CamaraJugadorLocal.ZoomCinematicoFinalizadoLocal -=
            AlTerminarZoomLocal;

        puzzleResuelto.OnValueChanged -=
            AlCambiarEstadoPuzzle;

        if (rutinaSecuencia != null)
            StopCoroutine(rutinaSecuencia);

        rutinaSecuencia = null;
    }

    // =====================================
    // REGISTRAR APERTURA DE PANELES
    // =====================================

    public void RegistrarPanelAbierto(bool esPanelElian)
    {
        if (!IsSpawned || puzzleResuelto.Value)
            return;

        RegistrarPanelAbiertoRpc(esPanelElian);
    }

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void RegistrarPanelAbiertoRpc(
        bool esPanelElian,
        RpcParams rpcParams = default)
    {
        if (!IsServer || puzzleResuelto.Value)
            return;

        ulong clienteId =
            rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients
            .TryGetValue(clienteId, out NetworkClient cliente))
            return;

        NetworkObject jugador = cliente.PlayerObject;

        if (jugador == null)
            return;

        NetworkPlayerSetup setup =
            jugador.GetComponent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
            return;

        if (setup.EsElian != esPanelElian)
        {
            Debug.LogWarning(
                "P1: Jugador intentando abrir panel ajeno."
            );

            return;
        }

        if (esPanelElian)
        {
            panelElianAbierto.Value = true;

            Debug.Log("P1: Panel de Elian abierto.");
        }
        else
        {
            panelLiaAbierto.Value = true;

            Debug.Log("P1: Panel de Lia abierto.");
        }
    }

    // =====================================
    // BOTONES DEL PANEL
    // =====================================

    public void SeleccionarCirculo()
    {
        EnviarSeleccion(0);
    }

    public void SeleccionarTriangulo()
    {
        EnviarSeleccion(1);
    }

    public void SeleccionarCuadrado()
    {
        EnviarSeleccion(2);
    }

    
    private void EnviarSeleccion(int simbolo)
    {
        Debug.Log("P1: BOTON PRESIONADO. Simbolo: " + simbolo);

        if (!IsSpawned)
        {
            Debug.LogError("P1: El controlador no está Spawned.");
            return;
        }

        if (puzzleResuelto.Value)
        {
            Debug.LogWarning("P1: El puzzle ya estaba resuelto.");
            return;
        }

        NetworkManager red = NetworkManager.Singleton;

        if (red == null || red.LocalClient == null ||
            red.LocalClient.PlayerObject == null)
        {
            Debug.LogError("P1: No se encontró el jugador local.");
            return;
        }

        NetworkPlayerSetup setup =
            red.LocalClient.PlayerObject.GetComponent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
        {
            Debug.LogError("P1: Identidad del jugador sin configurar.");
            return;
        }

        if (!setup.EsElian)
        {
            Debug.LogWarning("P1: Solo Elian puede resolver el puzzle.");
            return;
        }

        if (PanelSimbolosUI.Instancia != null)
        {
            PanelSimbolosUI.Instancia.RestablecerPanel();

            if (simbolo == 0)
                PanelSimbolosUI.Instancia.SeleccionarCirculo();
            else if (simbolo == 1)
                PanelSimbolosUI.Instancia.SeleccionarTriangulo();
            else if (simbolo == 2)
                PanelSimbolosUI.Instancia.SeleccionarCuadrado();
        }

        Debug.Log("P1: Enviando respuesta al servidor.");

        EnviarSeleccionServidorRpc(simbolo);
    }


    // =====================================
    // VALIDACION EN SERVIDOR
    // =====================================

    
    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void EnviarSeleccionServidorRpc(
        int simboloSeleccionado,
        RpcParams rpcParams = default)
    {
        Debug.Log(
            "P1 SERVIDOR: Respuesta recibida: " +
            simboloSeleccionado
        );

        if (!IsServer || puzzleResuelto.Value)
            return;

        ulong clienteId = rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients
            .TryGetValue(clienteId, out NetworkClient cliente))
        {
            Debug.LogError("P1: Cliente no encontrado.");
            return;
        }

        NetworkObject jugador = cliente.PlayerObject;

        if (jugador == null)
        {
            Debug.LogError("P1: Jugador sin NetworkObject.");
            return;
        }

        NetworkPlayerSetup setup =
            jugador.GetComponent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
        {
            Debug.LogError("P1: No se pudo identificar al jugador.");
            return;
        }

        if (!setup.EsElian)
        {
            Debug.LogWarning("P1: La respuesta no viene de Elian.");
            return;
        }

        bool correcto =
            trianguloEsCorrecto && simboloSeleccionado == 1;

        if (!correcto)
        {
            Debug.Log("P1: RESPUESTA INCORRECTA.");
            return;
        }

        Debug.Log("P1: TRIANGULO CORRECTO. RESOLVIENDO PUZZLE.");

        puzzleResuelto.Value = true;

        EjecutarSecuenciaResuelto();
    }


    // =====================================
    // SOLICITAR REINICIO
    // =====================================

    public void SolicitarReinicioPuzzle()
    {
        if (!IsSpawned || puzzleResuelto.Value)
            return;

        SolicitarReinicioServidorRpc();
    }

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void SolicitarReinicioServidorRpc()
    {
        if (!IsServer || puzzleResuelto.Value)
            return;

        panelElianAbierto.Value = false;
        panelLiaAbierto.Value = false;

        Debug.Log(
            "P1: Reiniciando apertura de paneles."
        );

        ReiniciarPuzzleClientRpc();
    }

    [Rpc(SendTo.Everyone)]
    private void ReiniciarPuzzleClientRpc()
    {
        if (puzzleResuelto.Value)
            return;

        if (ventanaPanelElian != null)
            ventanaPanelElian.SetActive(false);

        if (ventanaPanelLia != null)
            ventanaPanelLia.SetActive(false);

        PanelSimbolosUI.Instancia?.RestablecerPanel();
    }

    // =====================================
    // PUZZLE RESUELTO
    // =====================================

    private void AlCambiarEstadoPuzzle(
        bool valorAnterior,
        bool valorNuevo)
    {
        if (!valorNuevo)
            return;

        EjecutarSecuenciaResuelto();
    }

    
    private void EjecutarSecuenciaResuelto()
    {
        if (secuenciaIniciada)
            return;

        if (!puzzleResuelto.Value)
            return;

        secuenciaIniciada = true;

        Debug.Log(
            "P1: INICIANDO SECUENCIA DEL PUZZLE. " +
            "Panel Elian: " + panelElianAbierto.Value +
            " | Panel Lia: " + panelLiaAbierto.Value
        );

        rutinaSecuencia =
            StartCoroutine(SecuenciaPuzzleResuelto());
    }


    private IEnumerator SecuenciaPuzzleResuelto()
    {
        // Dar tiempo al mensaje CORRECTO.
        yield return new WaitForSeconds(0.5f);

        // Reiniciar confirmaciones.
        tarjetaElianCerrada = false;
        tarjetaLiaCerrada = false;

        if (IsServer)
        {
            zoomElianTerminado = false;
            zoomLiaTerminado = false;
            fragmentosEntregados = false;
        }

        // Cerrar los dos paneles.
        if (ventanaPanelElian != null)
            ventanaPanelElian.SetActive(false);

        if (ventanaPanelLia != null)
            ventanaPanelLia.SetActive(false);

        PanelSimbolosUI.Instancia?.RestablecerPanel();

        // Ocultar botones de interacción.
        if (HUDInteraccion.Instancia != null)
        {
            if (interaccionPanelElian != null)
                HUDInteraccion.Instancia.OcultarBoton(
                    interaccionPanelElian
                );

            if (interaccionPanelLia != null)
                HUDInteraccion.Instancia.OcultarBoton(
                    interaccionPanelLia
                );
        }

        // Desactivar las interacciones.
        if (interaccionPanelElian != null)
            interaccionPanelElian.enabled = false;

        if (interaccionPanelLia != null)
            interaccionPanelLia.enabled = false;

        // Completar los brillos.
        if (brilloPanelElian != null)
            brilloPanelElian.CompletarObjetivo();

        if (brilloPanelLia != null)
            brilloPanelLia.CompletarObjetivo();

        // Ocultar misión anterior.
        if (HUDMision.Instancia != null)
            HUDMision.Instancia.OcultarMision();

        // Preparar espera de las dos cámaras.
        esperandoZoom = true;

        // Iniciar cinematografía.
        if (IsServer)
        {
            if (zonaSalida != null)
            {
                zonaSalida.HabilitarSalida();

                Debug.Log(
                    "P1: Cinematografía iniciada. " +
                    "La salida permanece bloqueada."
                );
            }
            else
            {
                Debug.LogError(
                    "P1: Falta asignar PF_ZonaSalida."
                );
            }
        }

        Debug.Log(
            "P1: Esperando que ambas cámaras terminen el zoom."
        );

        rutinaSecuencia = null;
    }

    // =====================================
    // DETECTAR FIN DEL ZOOM LOCAL
    // =====================================

    private void AlTerminarZoomLocal(
        CamaraJugadorLocal camara)
    {
        if (!IsSpawned ||
            !IsClient ||
            !esperandoZoom ||
            camara == null ||
            !camara.IsOwner)
            return;

        esperandoZoom = false;

        Debug.Log(
            "P1: Zoom terminado en cámara local."
        );

        NotificarZoomTerminadoServidorRpc();
    }

    // =====================================
    // NOTIFICAR AL SERVIDOR
    // =====================================

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void NotificarZoomTerminadoServidorRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer ||
            !puzzleResuelto.Value ||
            fragmentosEntregados)
            return;

        ulong clienteId =
            rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients
            .TryGetValue(clienteId, out NetworkClient cliente))
            return;

        if (cliente.PlayerObject == null)
            return;

        NetworkPlayerSetup setup =
            cliente.PlayerObject
            .GetComponent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
            return;

        if (setup.EsElian)
        {
            zoomElianTerminado = true;

            Debug.Log("P1: Zoom de Elian terminado.");
        }
        else
        {
            zoomLiaTerminado = true;

            Debug.Log("P1: Zoom de Lia terminado.");
        }

        if (zoomElianTerminado && zoomLiaTerminado)
        {
            EntregarFragmentosServidor();
        }
    }

    // =====================================
    // ENTREGAR FRAGMENTOS A CADA JUGADOR
    // =====================================

    private void EntregarFragmentosServidor()
    {
        if (!IsServer || fragmentosEntregados)
            return;

        if (fragmentoElian == null ||
            fragmentoLia == null)
        {
            Debug.LogError(
                "P1: Asigna los dos ScriptableObjects " +
                "de fragmentos en el Inspector."
            );

            return;
        }

        NetworkManager red = NetworkManager.Singleton;

        if (red == null)
            return;

        NetworkObject jugadorElian = null;
        NetworkObject jugadorLia = null;

        foreach (NetworkClient cliente in red.ConnectedClientsList)
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
                "P1: No se encontraron ambos jugadores."
            );

            return;
        }

        InventarioJugador inventarioElian =
            jugadorElian.GetComponent<InventarioJugador>();

        InventarioJugador inventarioLia =
            jugadorLia.GetComponent<InventarioJugador>();

        if (inventarioElian == null ||
            inventarioLia == null)
        {
            Debug.LogError(
                "P1: Falta InventarioJugador."
            );

            return;
        }

        bool elianOK =
            inventarioElian.TieneObjeto(fragmentoElian.Id) ||
            inventarioElian.AgregarObjetoDesdeServidor(
                fragmentoElian.Id
            );

        bool liaOK =
            inventarioLia.TieneObjeto(fragmentoLia.Id) ||
            inventarioLia.AgregarObjetoDesdeServidor(
                fragmentoLia.Id
            );

        if (!elianOK || !liaOK)
        {
            Debug.LogError(
                "P1: No se pudieron entregar ambos fragmentos. " +
                "Elian: " + elianOK +
                " | Lia: " + liaOK
            );

            return;
        }

        // Marcar entrega antes de enviar las tarjetas.
        fragmentosEntregados = true;

        MostrarFragmentoRpc(
            fragmentoElian.Id,
            RpcTarget.Single(
                jugadorElian.OwnerClientId,
                RpcTargetUse.Temp
            )
        );

        MostrarFragmentoRpc(
            fragmentoLia.Id,
            RpcTarget.Single(
                jugadorLia.OwnerClientId,
                RpcTargetUse.Temp
            )
        );

        Debug.Log(
            "P1: LOS DOS FRAGMENTOS FUERON ENTREGADOS."
        );
    }

    // =====================================
    // MOSTRAR TARJETA EN CADA JUGADOR
    // =====================================

    
    [Rpc(SendTo.SpecifiedInParams)]
    private void MostrarFragmentoRpc(
        string idObjeto,
        RpcParams rpcParams = default)
    {
        // Registrar localmente que ya se entregó el fragmento.
        fragmentosEntregados = true;

        StartCoroutine(
            EsperarInventarioYMostrar(idObjeto)
        );
    }


    
    private IEnumerator EsperarInventarioYMostrar(
        string idObjeto)
    {
        float tiempoEspera = 0f;
        const float tiempoMaximo = 10f;

        while (tiempoEspera < tiempoMaximo)
        {
            InventarioUI inventarioUI =
                InventarioUI.Instancia;

            if (inventarioUI != null &&
                inventarioUI.PuedeMostrarTarjetaPorId(idObjeto))
            {
                inventarioUI.MostrarTarjetaPorId(idObjeto);

                Debug.Log(
                    "P1: Tarjeta mostrada correctamente: " +
                    idObjeto
                );

                yield break;
            }

            tiempoEspera += Time.unscaledDeltaTime;

            yield return null;
        }

        Debug.LogError(
            "P1: Tiempo agotado esperando inventario y objeto local: " +
            idObjeto
        );
    }


    // =====================================
    // DETECTAR CIERRE DE TARJETAS P1
    // =====================================

    
    private void AlCerrarTarjetaFragmento(string idObjeto)
    {
        if (!IsSpawned ||
            !IsClient ||
            !fragmentosEntregados)
            return;

        NetworkManager red = NetworkManager.Singleton;

        if (red == null ||
            red.LocalClient == null ||
            red.LocalClient.PlayerObject == null)
            return;

        NetworkPlayerSetup setup =
            red.LocalClient.PlayerObject
            .GetComponent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
            return;

        string idEsperado = setup.EsElian
            ? fragmentoElian.Id
            : fragmentoLia.Id;

        if (idObjeto != idEsperado)
            return;

        Debug.Log(
            "P1: Jugador cerró su fragmento: " + idObjeto
        );

        ConfirmarCierreTarjetaP1Rpc(idObjeto);
    }


    // =====================================
    // CONFIRMAR CIERRE EN SERVIDOR
    // =====================================

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void ConfirmarCierreTarjetaP1Rpc(
        string idObjeto,
        RpcParams rpcParams = default)
    {
        if (!IsServer ||
            !fragmentosEntregados ||
            !puzzleResuelto.Value)
            return;

        ulong clienteId =
            rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients
            .TryGetValue(clienteId, out NetworkClient cliente))
            return;

        if (cliente.PlayerObject == null)
            return;

        NetworkPlayerSetup setup =
            cliente.PlayerObject
            .GetComponent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
            return;

        // Validar que cada jugador cierre su propia tarjeta.
        string idEsperado = setup.EsElian
            ? fragmentoElian.Id
            : fragmentoLia.Id;

        if (idObjeto != idEsperado)
        {
            Debug.LogWarning(
                "P1: Se recibió un cierre de tarjeta incorrecto."
            );

            return;
        }

        // Registrar cierre individual.
        if (setup.EsElian)
        {
            tarjetaElianCerrada = true;
        }
        else
        {
            tarjetaLiaCerrada = true;
        }

        Debug.Log(
            "P1: TARJETAS CERRADAS | " +
            "Elian: " + tarjetaElianCerrada +
            " | Lia: " + tarjetaLiaCerrada
        );

        // La salida solo se habilita cuando ambos cerraron.
        if (tarjetaElianCerrada &&
            tarjetaLiaCerrada)
        {
            if (zonaSalida != null)
            {
                zonaSalida.HabilitarSalidaDespuesDeTarjetas();

                Debug.Log(
                    "P1: AMBOS CERRARON SUS TARJETAS. " +
                    "SALIDA HABILITADA."
                );
            }
            else
            {
                Debug.LogError(
                    "P1: No está asignada la zona de salida."
                );
            }
        }
    }

    public void RegistrarPanelAbierto(GameObject panelAbierto)
    {
        if (panelAbierto == null)
            return;

        if (panelAbierto == ventanaPanelElian)
        {
            RegistrarPanelAbierto(true);
        }
        else if (panelAbierto == ventanaPanelLia)
        {
            RegistrarPanelAbierto(false);
        }
        else
        {
            Debug.LogWarning(
                "P1: La ventana abierta no corresponde a ningún panel."
            );
        }
    }
}
