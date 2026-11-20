
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public enum SimboloRecepcion
{
    Circulo = 0,
    Triangulo = 1,
    Cuadrado = 2,
    Rombo = 3
}

public class PuzzleRecepcionController : NetworkBehaviour
{
    [Header("Secuencia correcta")]
    [SerializeField] private SimboloRecepcion[] secuenciaCorrecta;

    [Header("Simbolos iluminados - Lia")]
    [SerializeField] private Image circuloLia;
    [SerializeField] private Image trianguloLia;
    [SerializeField] private Image cuadradoLia;
    [SerializeField] private Image romboLia;

    [Header("Simbolos iluminados - Elian")]
    [SerializeField] private Image circuloElian;
    [SerializeField] private Image trianguloElian;
    [SerializeField] private Image cuadradoElian;
    [SerializeField] private Image romboElian;

    [Header("Ventanas")]
    [SerializeField] private GameObject ventanaPuzzleElian;
    [SerializeField] private GameObject ventanaPuzzleLia;

    [Header("Iluminacion de las mesas")]
    [SerializeField] private SpriteRenderer mesaElian;
    [SerializeField] private SpriteRenderer mesaLia;
    [SerializeField] private Sprite mesaElianBrillo;
    [SerializeField] private Sprite mesaLiaBrillo;

    [Header("Animaciones de puertas")]
    [SerializeField] private Animator animatorPuertaElian;
    [SerializeField] private Animator animatorPuertaLia;

    [Header("Puntos de enfoque de camara")]
    [SerializeField] private Transform puntoCamaraElian;
    [SerializeField] private Transform puntoCamaraLia;

    [Header("Interacciones")]
    [SerializeField] private ZonaInteraccion interaccionElian;
    [SerializeField] private ZonaInteraccion interaccionLia;

    [Header("Resultado opcional")]
    [SerializeField] private TMP_Text textoResultadoElian;

    [Header("Tiempos")]
    [SerializeField] private float tiempoFeedback = 0.6f;

    [Header("Mision al terminar")]
    [SerializeField] private string misionAlCompletar = "";

    [Header("Salida cooperativa hacia habitaciones")]
    [SerializeField] private ZonaSalidaCooperativa zonaSalidaCooperativa;
    [SerializeField, Min(0f)] private float margenSeguridadSalida = 0.5f;

    [Header("Fragmento de la carta")]
    [SerializeField] private ObjetoInventario fragmentoCartaP2Elian;
    [SerializeField] private ObjetoInventario fragmentoCartaP2Lia;

    private readonly NetworkVariable<int> pasoActual =
        new NetworkVariable<int>(0);

    private readonly NetworkVariable<int> simboloSeleccionado =
        new NetworkVariable<int>(-1);

    // 0 = nada; 1 = incorrecto; 2 = correcto.
    private readonly NetworkVariable<int> resultadoSeleccion =
        new NetworkVariable<int>(0);

    private readonly NetworkVariable<bool> puzzleCompletado =
        new NetworkVariable<bool>(false);

    private readonly NetworkVariable<bool> fragmentoEntregado =
        new NetworkVariable<bool>(false);

    private bool procesandoSeleccion;
    private Coroutine corrutinaSeleccion;
    private bool secuenciaCinematograficaIniciada;
    private Sprite spriteNormalMesaElian;
    private Sprite spriteNormalMesaLia;

    private bool cinematicaLocalTerminada;

    private NetworkPlayerMovement movimientoLocal;
    private bool movimientoEstabaBloqueado;

    private readonly HashSet<ulong> jugadoresCinematicaTerminada =
        new HashSet<ulong>();

    public bool EstaCompletado => puzzleCompletado.Value;

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        if (mesaElian != null)
            spriteNormalMesaElian = mesaElian.sprite;

        if (mesaLia != null)
            spriteNormalMesaLia = mesaLia.sprite;
    }

    public override void OnNetworkSpawn()
    {
        pasoActual.OnValueChanged += AlCambiarPaso;
        simboloSeleccionado.OnValueChanged += AlCambiarSeleccion;
        resultadoSeleccion.OnValueChanged += AlCambiarResultado;
        puzzleCompletado.OnValueChanged += AlCompletarPuzzle;

        CamaraJugadorLocal.ZoomCinematicoFinalizadoLocal +=
            AlFinalizarZoomLocal;

        secuenciaCinematograficaIniciada = false;
        procesandoSeleccion = false;

        PrepararVisualInicial();

        if (puzzleCompletado.Value)
        {
            FinalizarPuzzleLocal();
            return;
        }

        ActualizarPistaLia(pasoActual.Value);
        ActualizarSeleccionElian(simboloSeleccionado.Value);
        ActualizarResultado(resultadoSeleccion.Value);
    }

    public override void OnNetworkDespawn()
    {
        pasoActual.OnValueChanged -= AlCambiarPaso;
        simboloSeleccionado.OnValueChanged -= AlCambiarSeleccion;
        resultadoSeleccion.OnValueChanged -= AlCambiarResultado;
        puzzleCompletado.OnValueChanged -= AlCompletarPuzzle;

        CamaraJugadorLocal.ZoomCinematicoFinalizadoLocal -=
            AlFinalizarZoomLocal;

        if (corrutinaSeleccion != null)
            StopCoroutine(corrutinaSeleccion);

        corrutinaSeleccion = null;

        if (movimientoLocal != null &&
            movimientoLocal.IsSpawned &&
            movimientoLocal.IsOwner)
        {
            movimientoLocal.BloquearMovimiento(
                movimientoEstabaBloqueado
            );
        }
    }

    // =====================================
    // BOTONES DE ELIAN
    // =====================================

    public void SeleccionarCirculo()
    {
        SolicitarSeleccion(SimboloRecepcion.Circulo);
    }

    public void SeleccionarTriangulo()
    {
        SolicitarSeleccion(SimboloRecepcion.Triangulo);
    }

    public void SeleccionarCuadrado()
    {
        SolicitarSeleccion(SimboloRecepcion.Cuadrado);
    }

    public void SeleccionarRombo()
    {
        SolicitarSeleccion(SimboloRecepcion.Rombo);
    }

    private void SolicitarSeleccion(SimboloRecepcion simbolo)
    {
        if (!IsSpawned || puzzleCompletado.Value)
            return;

        EnviarSeleccionRpc((int)simbolo);
    }

    // =====================================
    // VALIDACION EN SERVIDOR
    // =====================================

    [Rpc(
        SendTo.Server,
        InvokePermission = RpcInvokePermission.Everyone
    )]
    private void EnviarSeleccionRpc(
        int simbolo,
        RpcParams rpcParams = default)
    {
        if (!IsServer ||
            puzzleCompletado.Value ||
            procesandoSeleccion)
            return;

        if (secuenciaCorrecta == null ||
            secuenciaCorrecta.Length == 0)
        {
            Debug.LogWarning(
                "P2: No hay secuencia configurada."
            );
            return;
        }

        if (pasoActual.Value >= secuenciaCorrecta.Length)
            return;

        if (simbolo < 0 || simbolo > 3)
            return;

        // Solo Elian puede introducir la secuencia.
        if (NetworkManager.Singleton == null ||
            rpcParams.Receive.SenderClientId !=
            NetworkManager.ServerClientId)
            return;

        SimboloRecepcion elegido =
            (SimboloRecepcion)simbolo;

        bool correcto =
            elegido == secuenciaCorrecta[pasoActual.Value];

        corrutinaSeleccion =
            StartCoroutine(
                ProcesarSeleccionServidor(elegido, correcto)
            );
    }

    private IEnumerator ProcesarSeleccionServidor(
        SimboloRecepcion seleccionado,
        bool correcto)
    {
        procesandoSeleccion = true;

        simboloSeleccionado.Value = (int)seleccionado;

        resultadoSeleccion.Value = correcto ? 2 : 1;

        yield return new WaitForSecondsRealtime(
            Mathf.Max(0f, tiempoFeedback)
        );

        if (correcto)
        {
            int siguientePaso = pasoActual.Value + 1;

            if (siguientePaso >= secuenciaCorrecta.Length)
            {
                pasoActual.Value = secuenciaCorrecta.Length;
                puzzleCompletado.Value = true;
            }
            else
            {
                pasoActual.Value = siguientePaso;
            }
        }

        simboloSeleccionado.Value = -1;
        resultadoSeleccion.Value = 0;

        procesandoSeleccion = false;
        corrutinaSeleccion = null;
    }

    // =====================================
    // ACTUALIZAR PISTAS DE LIA
    // =====================================

    private void AlCambiarPaso(int anterior, int nuevo)
    {
        if (puzzleCompletado.Value)
            return;

        ActualizarPistaLia(nuevo);
        ActualizarSeleccionElian(simboloSeleccionado.Value);
    }

    private void ActualizarPistaLia(int paso)
    {
        if (puzzleCompletado.Value)
            return;

        OcultarSimbolosLia();

        if (secuenciaCorrecta == null ||
            paso < 0 ||
            paso >= secuenciaCorrecta.Length)
            return;

        MostrarImagen(
            ObtenerImagenLia(secuenciaCorrecta[paso]),
            true
        );
    }

    // =====================================
    // ACTUALIZAR SELECCION DE ELIAN
    // =====================================

    private void AlCambiarSeleccion(int anterior, int nuevo)
    {
        if (!puzzleCompletado.Value)
            ActualizarSeleccionElian(nuevo);
    }

    private void ActualizarSeleccionElian(int simbolo)
    {
        if (puzzleCompletado.Value)
            return;

        OcultarSimbolosElian();

        if (secuenciaCorrecta != null)
        {
            int completados = Mathf.Min(
                pasoActual.Value,
                secuenciaCorrecta.Length
            );

            for (int i = 0; i < completados; i++)
            {
                MostrarImagen(
                    ObtenerImagenElian(secuenciaCorrecta[i]),
                    true
                );
            }
        }

        if (simbolo >= 0 && simbolo <= 3)
        {
            MostrarImagen(
                ObtenerImagenElian(
                    (SimboloRecepcion)simbolo
                ),
                true
            );
        }
    }

    // =====================================
    // RESULTADOS
    // =====================================

    private void AlCambiarResultado(int anterior, int nuevo)
    {
        if (!puzzleCompletado.Value)
            ActualizarResultado(nuevo);
    }

    private void ActualizarResultado(int resultado)
    {
        if (textoResultadoElian == null)
            return;

        if (resultado == 0)
        {
            textoResultadoElian.gameObject.SetActive(false);
            return;
        }

        textoResultadoElian.gameObject.SetActive(true);

        if (ColorUtility.TryParseHtmlString(
            "#F3E4C7",
            out Color crema))
        {
            textoResultadoElian.color = crema;
        }

        textoResultadoElian.text =
            resultado == 2 ? "CORRECTO" : "INCORRECTO";
    }

    // =====================================
    // PUZZLE COMPLETADO
    // =====================================

    private void AlCompletarPuzzle(bool anterior, bool nuevo)
    {
        if (nuevo)
            FinalizarPuzzleLocal();
    }

    private void FinalizarPuzzleLocal()
    {
        if (secuenciaCinematograficaIniciada)
            return;

        secuenciaCinematograficaIniciada = true;

        OcultarSimbolosLia();
        OcultarSimbolosElian();

        if (textoResultadoElian != null)
            textoResultadoElian.gameObject.SetActive(false);

        if (ventanaPuzzleElian != null)
            ventanaPuzzleElian.SetActive(false);

        if (ventanaPuzzleLia != null)
            ventanaPuzzleLia.SetActive(false);

        if (HUDInteraccion.Instancia != null)
        {
            if (interaccionElian != null)
                HUDInteraccion.Instancia.OcultarBoton(interaccionElian);

            if (interaccionLia != null)
                HUDInteraccion.Instancia.OcultarBoton(interaccionLia);
        }

        if (interaccionElian != null)
            interaccionElian.enabled = false;

        if (interaccionLia != null)
            interaccionLia.enabled = false;

        // Restaurar aspecto de las mesas.
        if (mesaElian != null && spriteNormalMesaElian != null)
            mesaElian.sprite = spriteNormalMesaElian;

        if (mesaLia != null && spriteNormalMesaLia != null)
            mesaLia.sprite = spriteNormalMesaLia;

        if (!string.IsNullOrWhiteSpace(misionAlCompletar) &&
            HUDMision.Instancia != null)
        {
            HUDMision.Instancia.CambiarMision(
                misionAlCompletar
            );
        }

        // Cada cliente ejecuta su propia cinematica.
        StartCoroutine(SecuenciaCinematograficaLocal());

        Debug.Log(
            "P2: Puzzle completado. Cinematica iniciada."
        );
    }

    // =====================================
    // CINEMATICA LOCAL
    // =====================================

    private IEnumerator SecuenciaCinematograficaLocal()
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red == null ||
            red.LocalClient == null ||
            red.LocalClient.PlayerObject == null)
        {
            Debug.LogError(
                "P2: No se encontro el jugador local."
            );
            yield break;
        }

        bool esElian = red.IsHost;

#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
        {
            esElian = RolPruebaJugador.Instancia.EsElian();
        }
#endif

        NetworkObject jugadorLocal =
            red.LocalClient.PlayerObject;

        movimientoLocal =
            jugadorLocal.GetComponent<NetworkPlayerMovement>();

        CamaraJugadorLocal camara =
            jugadorLocal.GetComponent<CamaraJugadorLocal>();

        Transform puntoCamara =
            esElian ? puntoCamaraElian : puntoCamaraLia;

        Animator animatorPuerta =
            esElian ? animatorPuertaElian : animatorPuertaLia;

        if (movimientoLocal == null ||
            camara == null ||
            puntoCamara == null ||
            animatorPuerta == null)
        {
            Debug.LogError(
                "P2: Faltan referencias para la cinematica local. " +
                "Movimiento: " + (movimientoLocal != null) +
                " | Camara: " + (camara != null) +
                " | Punto: " + (puntoCamara != null) +
                " | Puerta: " + (animatorPuerta != null)
            );

            yield break;
        }

        cinematicaLocalTerminada = false;

        // Bloquear movimiento durante la cinematica.
        movimientoEstabaBloqueado =
            movimientoLocal.MovimientoBloqueado;

        movimientoLocal.BloquearMovimiento(true);

        // Obtener duracion de la animacion.
        float duracionAnimacion =
            ObtenerDuracionPuerta(animatorPuerta);

        // Calcular cuanto debe permanecer el zoom.
        float transicion =
            camara.DuracionTransicionZoom;

        float tiempoMantenerZoom = Mathf.Max(
            0f,
            duracionAnimacion - (transicion * 2f)
        );

        // Activar animacion de puerta.
        animatorPuerta.enabled = true;
        animatorPuerta.Rebind();
        animatorPuerta.Update(0f);

        // Iniciar zoom simultaneamente.
        camara.EnfocarConZoom(
            puntoCamara.position,
            tiempoMantenerZoom
        );

        Debug.Log(
            "P2: Cinematica iniciada | Jugador: " +
            (esElian ? "Elian" : "Lia") +
            " | Duracion puerta: " + duracionAnimacion +
            " | Permanencia zoom: " + tiempoMantenerZoom
        );

        // Esperar al evento real de finalizacion de camara.
        while (!cinematicaLocalTerminada)
        {
            yield return null;
        }

        // La camara ya regreso.
        // Liberar el movimiento antes de mostrar la tarjeta.
        movimientoLocal.BloquearMovimiento(
            movimientoEstabaBloqueado
        );

        movimientoLocal = null;

        Debug.Log(
            "P2: Cinematica terminada. " +
            "Confirmando al servidor."
        );

        // Informar al servidor que este jugador termino.
        ConfirmarCinematicaFinalizadaRpc();
    }

    // =====================================
    // EVENTO DE CAMARA
    // =====================================

    private void AlFinalizarZoomLocal(
        CamaraJugadorLocal camara)
    {
        if (!cinematicaLocalTerminada &&
            camara != null &&
            camara.IsOwner &&
            secuenciaCinematograficaIniciada)
        {
            cinematicaLocalTerminada = true;

            Debug.Log(
                "P2: Evento de zoom recibido. Camara restaurada."
            );
        }
    }

    // =====================================
    // CONFIRMACION AL SERVIDOR
    // =====================================

    [Rpc(
        SendTo.Server,
        InvokePermission = RpcInvokePermission.Everyone
    )]
    private void ConfirmarCinematicaFinalizadaRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer || !puzzleCompletado.Value)
            return;

        ulong clienteId =
            rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients
            .ContainsKey(clienteId))
            return;

        jugadoresCinematicaTerminada.Add(clienteId);

        Debug.Log(
            "P2: Cinematicas terminadas: " +
            jugadoresCinematicaTerminada.Count + "/2"
        );

        if (jugadoresCinematicaTerminada.Count < 2)
            return;

        if (fragmentoEntregado.Value)
            return;

        // Entregar el fragmento a ambos jugadores.
        if (!EntregarFragmentoAmbosJugadores())
            return;

        fragmentoEntregado.Value = true;

        // Habilitar salida sin repetir otra cinematica.
        if (zonaSalidaCooperativa != null)
        {
            zonaSalidaCooperativa.HabilitarSalidaSinCinematica();

            Debug.Log(
                "P2: Salida cooperativa habilitada."
            );
        }
        else
        {
            Debug.LogError(
                "P2: Falta asignar ZonaSalidaCooperativa."
            );
        }
    }

    // =====================================
    // ENTREGA DEL FRAGMENTO A AMBOS
    // =====================================

    
    private bool EntregarFragmentoAmbosJugadores()
    {
        if (!IsServer ||
            fragmentoCartaP2Elian == null ||
            fragmentoCartaP2Lia == null ||
            NetworkManager.Singleton == null)
        {
            Debug.LogError(
                "P2: Faltan los fragmentos de carta de Elian o Lia."
            );

            return false;
        }

        if (fragmentoCartaP2Elian.Id ==
            fragmentoCartaP2Lia.Id)
        {
            Debug.LogError(
                "P2: Los dos fragmentos tienen el mismo ID. " +
                "Deben ser objetos diferentes."
            );

            return false;
        }

        NetworkObject jugadorElian = null;
        NetworkObject jugadorLia = null;

        foreach (NetworkClient cliente in
            NetworkManager.Singleton.ConnectedClientsList)
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
                "P2: No se encontraron ambos jugadores."
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
                "P2: Falta InventarioJugador en uno de los jugadores."
            );

            return false;
        }

        string idElian = fragmentoCartaP2Elian.Id;
        string idLia = fragmentoCartaP2Lia.Id;

        // Verificar que cada jugador tenga registrado
        // su propio fragmento en el catalogo.

        if (inventarioElian.ObtenerObjetoPorId(idElian) == null ||
            inventarioLia.ObtenerObjetoPorId(idLia) == null)
        {
            Debug.LogError(
                "P2: No se encontraron los fragmentos " +
                "correspondientes en los catalogos."
            );

            return false;
        }

        // Entregar fragmento exclusivo de Elian.

        bool elianOK =
            inventarioElian.TieneObjeto(idElian) ||
            inventarioElian.AgregarObjetoDesdeServidor(idElian);

        // Entregar fragmento exclusivo de Lia.

        bool liaOK =
            inventarioLia.TieneObjeto(idLia) ||
            inventarioLia.AgregarObjetoDesdeServidor(idLia);

        if (!elianOK || !liaOK)
        {
            Debug.LogError(
                "P2: Error entregando fragmentos. " +
                "Elian: " + elianOK +
                " | Lia: " + liaOK
            );

            return false;
        }

        // Mostrar a cada jugador SU fragmento.

        MostrarTarjetaFragmentoRpc(
            idElian,
            RpcTarget.Single(
                jugadorElian.OwnerClientId,
                RpcTargetUse.Temp
            )
        );

        MostrarTarjetaFragmentoRpc(
            idLia,
            RpcTarget.Single(
                jugadorLia.OwnerClientId,
                RpcTargetUse.Temp
            )
        );

        Debug.Log(
            "P2: FRAGMENTOS DIFERENTES ENTREGADOS. " +
            "Elian: " + idElian +
            " | Lia: " + idLia
        );

        return true;
    }


    // =====================================
    // MOSTRAR TARJETA INDIVIDUAL
    // =====================================
    
    [Rpc(SendTo.SpecifiedInParams)]
    private void MostrarTarjetaFragmentoRpc(
        string idObjeto,
        RpcParams rpcParams = default)
    {
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
                    "P2: TARJETA MOSTRADA CORRECTAMENTE: " +
                    idObjeto
                );

                yield break;
            }

            tiempoEspera += Time.unscaledDeltaTime;

            yield return null;
        }

        Debug.LogError(
            "P2: Tiempo agotado esperando inventario y objeto: " +
            idObjeto
        );
    }

    // =====================================
    // DURACION DE LA PUERTA
    // =====================================

    private float ObtenerDuracionPuerta(Animator animator)
    {
        if (animator == null ||
            animator.runtimeAnimatorController == null)
            return 2f;

        float duracion = 0f;

        foreach (AnimationClip clip in
            animator.runtimeAnimatorController.animationClips)
        {
            if (clip != null)
                duracion = Mathf.Max(duracion, clip.length);
        }

        return duracion > 0f ? duracion : 2f;
    }

    // =====================================
    // VISUALES INICIALES
    // =====================================

    private void PrepararVisualInicial()
    {
        OcultarSimbolosLia();
        OcultarSimbolosElian();

        if (textoResultadoElian != null)
            textoResultadoElian.gameObject.SetActive(false);
    }

    private void OcultarSimbolosLia()
    {
        MostrarImagen(circuloLia, false);
        MostrarImagen(trianguloLia, false);
        MostrarImagen(cuadradoLia, false);
        MostrarImagen(romboLia, false);
    }

    private void OcultarSimbolosElian()
    {
        MostrarImagen(circuloElian, false);
        MostrarImagen(trianguloElian, false);
        MostrarImagen(cuadradoElian, false);
        MostrarImagen(romboElian, false);
    }

    private Image ObtenerImagenLia(SimboloRecepcion simbolo)
    {
        switch (simbolo)
        {
            case SimboloRecepcion.Circulo:
                return circuloLia;

            case SimboloRecepcion.Triangulo:
                return trianguloLia;

            case SimboloRecepcion.Cuadrado:
                return cuadradoLia;

            case SimboloRecepcion.Rombo:
                return romboLia;

            default:
                return null;
        }
    }

    private Image ObtenerImagenElian(SimboloRecepcion simbolo)
    {
        switch (simbolo)
        {
            case SimboloRecepcion.Circulo:
                return circuloElian;

            case SimboloRecepcion.Triangulo:
                return trianguloElian;

            case SimboloRecepcion.Cuadrado:
                return cuadradoElian;

            case SimboloRecepcion.Rombo:
                return romboElian;

            default:
                return null;
        }
    }

    private void MostrarImagen(Image imagen, bool mostrar)
    {
        if (imagen == null)
            return;

        Color color = imagen.color;
        color.a = mostrar ? 1f : 0f;
        imagen.color = color;
    }

    // =====================================
    // REINICIAR PUZZLE
    // =====================================

    public void SolicitarReinicio()
    {
        if (!IsSpawned || puzzleCompletado.Value)
            return;

        ReiniciarPuzzleRpc();
    }

    [Rpc(
        SendTo.Server,
        InvokePermission = RpcInvokePermission.Everyone
    )]
    private void ReiniciarPuzzleRpc()
    {
        if (!IsServer || puzzleCompletado.Value)
            return;

        if (corrutinaSeleccion != null)
        {
            StopCoroutine(corrutinaSeleccion);
            corrutinaSeleccion = null;
        }

        procesandoSeleccion = false;

        pasoActual.Value = 0;
        simboloSeleccionado.Value = -1;
        resultadoSeleccion.Value = 0;
    }
}
