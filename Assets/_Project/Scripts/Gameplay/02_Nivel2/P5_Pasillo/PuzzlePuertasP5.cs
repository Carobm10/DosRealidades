
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Collections;

public class PuzzlePuertasP5 : NetworkBehaviour
{
    [Header("Secuencia correcta")]
    [SerializeField] private int[] secuenciaCorrecta =
    {
        204, 202, 201
    };

    [Header("Errores")]
    [SerializeField] private int fallosParaVigilia = 3;
    [SerializeField] private bool reiniciarProgresoAlFallar = false;

    [Header("La Vigilia")]
    [SerializeField] private GameObject vigiliaVisual;
    [SerializeField] private float tiempoVigilia = 5f;

    [Header("Control de huellas")]
    [SerializeField] private ControlHuellasP5 controlHuellas;

    [Header("Cinematica")]
    [SerializeField] private float tiempoAntesDeCambiarEscena = 1.2f;
    [SerializeField] private float duracionEnfoque = 1.8f;

    [Header("Entrada cooperativa")]
[SerializeField] private float distanciaEntrada = 1.5f;

[SerializeField] private Transform entrada204Elian;
[SerializeField] private Transform entrada204Lia;

[SerializeField] private Transform entrada202Elian;
[SerializeField] private Transform entrada202Lia;

[SerializeField] private Transform entrada201Elian;
[SerializeField] private Transform entrada201Lia;

    [Header("Mision despues del puzzle")]
    [SerializeField] private string misionElian =
        "Busca el objeto que necesitas para continuar";

    [SerializeField] private string misionLia =
        "Ayuda a Elian";

    // Conserva el progreso entre escenas mientras
    // la aplicación siga ejecutándose.
    private static int progresoGuardado = 0;

    private NetworkVariable<int> pasoActual =
        new NetworkVariable<int>(0);

    private NetworkVariable<int> fallosActuales =
        new NetworkVariable<int>(0);

    private NetworkVariable<bool> puzzleCompletado =
        new NetworkVariable<bool>(false);

    private NetworkVariable<int> ultimaPuertaCorrecta =
        new NetworkVariable<int>(-1);

    private bool transicionEnCurso;

    private NetworkPlayerMovement movimientoLocal;
    private bool movimientoBloqueadoAntesCinematica;
    private Coroutine rutinaControlesCinematica;

    public bool PuzzleCompletado => puzzleCompletado.Value;

    [RuntimeInitializeOnLoadMethod(
        RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ReiniciarProgresoAlIniciarAplicacion()
    {
        progresoGuardado = 0;
    }

    public override void OnNetworkSpawn()
    {
        puzzleCompletado.OnValueChanged +=
            AlCambiarPuzzleCompletado;

        pasoActual.OnValueChanged += AlCambiarPasoActual;

        if (vigiliaVisual != null)
            vigiliaVisual.SetActive(false);

        if (IsServer)
        {
            pasoActual.Value = Mathf.Clamp(
                progresoGuardado, 0, secuenciaCorrecta.Length
            );

            puzzleCompletado.Value =
                pasoActual.Value >= secuenciaCorrecta.Length;
        }

        ActualizarHuellas(pasoActual.Value);

        if (puzzleCompletado.Value)
            FinalizarPuzzleLocal();
    }

    public override void OnNetworkDespawn()
    {
        puzzleCompletado.OnValueChanged -=
            AlCambiarPuzzleCompletado;

        pasoActual.OnValueChanged -= AlCambiarPasoActual;
    }

    // =====================================
    // SOLICITAR APERTURA
    // =====================================

    public void IntentarPuerta(int numeroPuerta)
    {
        if (!IsSpawned || transicionEnCurso)
            return;

        IntentarPuertaRpc(numeroPuerta);
    }

    [Rpc(SendTo.Server)]
    private void IntentarPuertaRpc(
        int numeroPuerta,
        RpcParams rpcParams = default)
    {
        // Solo Elian (Host) puede resolver el recorrido.
        if (rpcParams.Receive.SenderClientId !=
            NetworkManager.ServerClientId)
            return;

        if (puzzleCompletado.Value || transicionEnCurso)
            return;

        if (secuenciaCorrecta == null ||
            secuenciaCorrecta.Length == 0)
            return;

        if (pasoActual.Value >= secuenciaCorrecta.Length)
            return;

        int puertaEsperada =
            secuenciaCorrecta[pasoActual.Value];

        if (numeroPuerta == ultimaPuertaCorrecta.Value &&
            numeroPuerta != puertaEsperada)
            return;

        if (numeroPuerta != puertaEsperada)
        {
            // Ruta guiada: ninguna penalizacion ni aparicion de La Vigilia.
            Debug.Log("P5: Esta puerta no corresponde al siguiente paso.");
            return;
        }

        ProcesarAcierto(numeroPuerta);
    }

    // =====================================
    // PUERTA CORRECTA
    // =====================================

    private void ProcesarAcierto(int numeroPuerta)
    {
        PuertaPuzzleP5 puerta = BuscarPuerta(numeroPuerta);

        if (puerta == null)
        {
            Debug.LogError(
                "P5: No se encontro la puerta " + numeroPuerta
            );
            return;
        }

        if (string.IsNullOrWhiteSpace(puerta.EscenaDestino))
        {
            Debug.LogError(
                "P5: La puerta " + numeroPuerta +
                " no tiene escena de destino."
            );
            return;
        }

        ultimaPuertaCorrecta.Value = numeroPuerta;
        pasoActual.Value++;

        progresoGuardado = pasoActual.Value;

        Debug.Log(
            "P5 | PUERTA CORRECTA: " + numeroPuerta +
            " | Progreso: " + pasoActual.Value +
            "/" + secuenciaCorrecta.Length
        );

        transicionEnCurso = true;

        // Actualiza el progreso local de cada jugador.
        ActualizarProgresoClientesRpc(progresoGuardado);

        // Abre la puerta y enfoca la cámara en ambos jugadores.
        AbrirPuertaYCentrarCamaraRpc(
            numeroPuerta,
            duracionEnfoque
        );

        if (pasoActual.Value >= secuenciaCorrecta.Length)
            puzzleCompletado.Value = true;

        // Esperar a que concluyan tanto el zoom como la animacion de apertura.
        float esperaSegura = Mathf.Max(
            tiempoAntesDeCambiarEscena,
            duracionEnfoque + 0.8f,
            puerta.DuracionApertura + 0.5f
        );

        StartCoroutine(CargarHabitacion(numeroPuerta, puerta.EscenaDestino, esperaSegura));
    }

    private PuertaPuzzleP5 BuscarPuerta(int numero)
    {
        PuertaPuzzleP5[] puertas =
            FindObjectsByType<PuertaPuzzleP5>(
                FindObjectsSortMode.None
            );

        foreach (PuertaPuzzleP5 puerta in puertas)
        {
            if (puerta.NumeroPuerta == numero)
                return puerta;
        }

        return null;
    }

    // =====================================
    // APERTURA Y CAMARA EN TODOS LOS CLIENTES
    // =====================================

    
    [Rpc(SendTo.Everyone)]
    private void AbrirPuertaYCentrarCamaraRpc(
        int numeroPuerta,
        float duracion)
    {
        PuertaPuzzleP5 puerta = BuscarPuerta(numeroPuerta);

        if (puerta == null)
            return;

        // Obtener el jugador local.
        NetworkManager red = NetworkManager.Singleton;

        if (red != null &&
            red.LocalClient != null &&
            red.LocalClient.PlayerObject != null)
        {
            movimientoLocal =
                red.LocalClient.PlayerObject
                .GetComponent<NetworkPlayerMovement>();

            if (movimientoLocal != null)
            {
                movimientoBloqueadoAntesCinematica =
                    movimientoLocal.MovimientoBloqueado;

                movimientoLocal.BloquearMovimiento(true);
            }
        }

        // Abrir puerta de la realidad correspondiente.
        puerta.AbrirVisualLocal();

        // Enfocar cámara local.
        CamaraJugadorLocal[] camaras =
            FindObjectsByType<CamaraJugadorLocal>(
                FindObjectsSortMode.None
            );

        foreach (CamaraJugadorLocal camara in camaras)
        {
            if (camara.IsOwner)
            {
                camara.EnfocarConZoom(
                    puerta.PuntoEnfoqueLocal.position,
                    duracion
                );
            }
        }

        // Esperar a que termine la cinemática.
        if (rutinaControlesCinematica != null)
            StopCoroutine(rutinaControlesCinematica);

        float duracionTotal = Mathf.Max(
            duracion,
            puerta.DuracionApertura
        );

        rutinaControlesCinematica =
            StartCoroutine(
                RestaurarMovimientoAlTerminar(duracionTotal)
            );
    }

    private IEnumerator RestaurarMovimientoAlTerminar(
        float duracion)
    {
        yield return new WaitForSecondsRealtime(
            duracion + 0.2f
        );

        if (movimientoLocal != null &&
            movimientoLocal.IsSpawned &&
            movimientoLocal.IsOwner)
        {
            movimientoLocal.BloquearMovimiento(
                movimientoBloqueadoAntesCinematica
            );
        }

        movimientoLocal = null;
        rutinaControlesCinematica = null;

        Debug.Log(
            "P5: Cinemática terminada. Controles restaurados."
        );
    }


    [Rpc(SendTo.Everyone)]
    private void ActualizarProgresoClientesRpc(int progreso)
    {
        progresoGuardado = progreso;
    }

    // =====================================
    // CAMBIO DE ESCENA SINCRONIZADO
    // =====================================

    
    private IEnumerator CargarHabitacion(
        int numeroPuerta,
        string nombreEscena,
        float esperaSegura)
    {
        // Esperar a que termine la cinematica.
        yield return new WaitForSecondsRealtime(
            Mathf.Max(0f, esperaSegura)
        );

        if (!IsServer)
            yield break;

        // Esperar a que ambos jugadores lleguen.
        while (!AmbosEnLaPuerta(numeroPuerta))
        {
            yield return new WaitForSecondsRealtime(0.2f);
        }

        if (NetworkManager.Singleton == null ||
            NetworkManager.Singleton.SceneManager == null)
        {
            Debug.LogError("P5: No se encontro SceneManager.");
            transicionEnCurso = false;
            yield break;
        }

        Debug.Log(
            "P5: Ambos jugadores llegaron a la puerta " +
            numeroPuerta
        );

        var resultado =
            NetworkManager.Singleton.SceneManager.LoadScene(
                nombreEscena,
                LoadSceneMode.Single
            );

        if (resultado != SceneEventProgressStatus.Started)
        {
            Debug.LogError(
                "P5: Error al cargar escena: " + resultado
            );

            transicionEnCurso = false;
        }
    }

    private bool AmbosEnLaPuerta(int numeroPuerta)
    {
        if (!IsServer || NetworkManager.Singleton == null)
            return false;

        Transform puntoElian = null;
        Transform puntoLia = null;

        switch (numeroPuerta)
        {
            case 204:
                puntoElian = entrada204Elian;
                puntoLia = entrada204Lia;
                break;

            case 202:
                puntoElian = entrada202Elian;
                puntoLia = entrada202Lia;
                break;

            case 201:
                puntoElian = entrada201Elian;
                puntoLia = entrada201Lia;
                break;
        }

        if (puntoElian == null || puntoLia == null)
            return false;

        if (NetworkManager.Singleton.ConnectedClients.Count != 2)
            return false;

        bool elianPresente = false;
        bool liaPresente = false;

        foreach (var cliente in
            NetworkManager.Singleton.ConnectedClientsList)
        {
            NetworkObject jugador = cliente.PlayerObject;

            if (jugador == null)
                continue;

            bool esElian =
                cliente.ClientId == NetworkManager.ServerClientId;

            Transform puntoDestino =
                esElian ? puntoElian : puntoLia;

            float distancia = Vector2.Distance(
                jugador.transform.position,
                puntoDestino.position
            );

            if (distancia <= distanciaEntrada)
            {
                if (esElian)
                    elianPresente = true;
                else
                    liaPresente = true;
            }
        }

        return elianPresente && liaPresente;
    }


    // =====================================
    // ERRORES
    // =====================================

    private void ProcesarError(int numeroPuerta)
    {
        fallosActuales.Value++;

        Debug.Log(
            "P5 | PUERTA INCORRECTA: " + numeroPuerta +
            " | Fallos: " + fallosActuales.Value +
            "/" + fallosParaVigilia
        );

        if (reiniciarProgresoAlFallar)
        {
            pasoActual.Value = 0;
            progresoGuardado = 0;
            ultimaPuertaCorrecta.Value = -1;

            ActualizarProgresoClientesRpc(0);
        }

        if (fallosActuales.Value >= fallosParaVigilia)
        {
            fallosActuales.Value = 0;
            MostrarVigiliaRpc();
        }
    }

    [Rpc(SendTo.Everyone)]
    private void MostrarVigiliaRpc()
    {
        if (vigiliaVisual == null)
            return;

        StopCoroutine(nameof(RutinaVigilia));
        StartCoroutine(RutinaVigilia());
    }

    private IEnumerator RutinaVigilia()
    {
        vigiliaVisual.SetActive(true);

        yield return new WaitForSeconds(tiempoVigilia);

        vigiliaVisual.SetActive(false);
    }

    // =====================================
    // HUELLAS
    // =====================================

    private void AlCambiarPasoActual(int anterior, int nuevo)
    {
        ActualizarHuellas(nuevo);
    }

    private void ActualizarHuellas(int paso)
    {
        if (controlHuellas == null ||
            !controlHuellas.gameObject.activeInHierarchy)
            return;

        switch (paso)
        {
            case 0:
                controlHuellas.ActivarCamino(204);
                break;

            case 1:
                controlHuellas.ActivarCamino(202);
                break;

            case 2:
                controlHuellas.ActivarCamino(201);
                break;

            default:
                controlHuellas.DetenerRecorrido();
                break;
        }
    }

    // =====================================
    // FINALIZAR
    // =====================================

    private void AlCambiarPuzzleCompletado(
        bool anterior,
        bool nuevo)
    {
        if (nuevo)
            FinalizarPuzzleLocal();
    }

    private void FinalizarPuzzleLocal()
    {
        Debug.Log("P5: SECUENCIA DE PUERTAS COMPLETADA");

        if (controlHuellas != null &&
            controlHuellas.gameObject.activeInHierarchy)
        {
            controlHuellas.DetenerRecorrido();
        }

        bool esElian = NetworkManager.Singleton != null &&
                       NetworkManager.Singleton.IsHost;

#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
            esElian = RolPruebaJugador.Instancia.EsElian();
#endif

        if (HUDMision.Instancia != null)
        {
            HUDMision.Instancia.CambiarMision(
                esElian ? misionElian : misionLia
            );
        }
    }


    public static void ReiniciarProgresoParaNuevoIntento()
    {
        progresoGuardado = 0;

        PuzzlePuertasP5 puzzle =
            FindAnyObjectByType<PuzzlePuertasP5>();

        if (puzzle == null || !puzzle.IsSpawned || !puzzle.IsServer)
            return;

        puzzle.pasoActual.Value = 0;
        puzzle.fallosActuales.Value = 0;
        puzzle.puzzleCompletado.Value = false;
        puzzle.ultimaPuertaCorrecta.Value = -1;

        puzzle.transicionEnCurso = false;

        if (puzzle.vigiliaVisual != null)
            puzzle.vigiliaVisual.SetActive(false);

        puzzle.ActualizarHuellas(0);

        Debug.Log("P5: PROGRESO COMPLETAMENTE REINICIADO.");
    }

}
