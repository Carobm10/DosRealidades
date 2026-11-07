
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Collections;

public class PuzzlePuertasP5 : NetworkBehaviour
{
    [Header("Secuencia correcta")]
    [SerializeField] private int[] secuenciaCorrecta =
    {
        204, 201, 203
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
    [SerializeField] private float duracionEnfoque = 5f;

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
            ProcesarError(numeroPuerta);
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

        StartCoroutine(
            CargarHabitacion(puerta.EscenaDestino)
        );
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

        puerta.AbrirVisualLocal();

        CamaraJugadorLocal[] camaras =
            FindObjectsByType<CamaraJugadorLocal>(
                FindObjectsSortMode.None
            );

        foreach (CamaraJugadorLocal camara in camaras)
        {
            if (camara.IsOwner)
            {
                camara.EnfocarConZoom(
                    puerta.PuntoEnfoque.position,
                    duracion
                );
            }
        }
    }

    [Rpc(SendTo.Everyone)]
    private void ActualizarProgresoClientesRpc(int progreso)
    {
        progresoGuardado = progreso;
    }

    // =====================================
    // CAMBIO DE ESCENA SINCRONIZADO
    // =====================================

    private IEnumerator CargarHabitacion(string nombreEscena)
    {
        yield return new WaitForSeconds(
            tiempoAntesDeCambiarEscena
        );

        if (!IsServer)
            yield break;

        if (NetworkManager.Singleton == null ||
            NetworkManager.Singleton.SceneManager == null)
        {
            Debug.LogError(
                "P5: No se encontro el SceneManager de Netcode."
            );

            transicionEnCurso = false;
            yield break;
        }

        Debug.Log(
            "P5: Cargando habitacion " + nombreEscena
        );

        NetworkManager.Singleton.SceneManager.LoadScene(
            nombreEscena,
            LoadSceneMode.Single
        );
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
                controlHuellas.DetenerRecorrido();
                break;

            case 2:
                controlHuellas.ActivarCamino(203);
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
}
