using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;
using System.Collections;

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

    private readonly NetworkVariable<int> pasoActual = new NetworkVariable<int>(0);
    private readonly NetworkVariable<int> simboloSeleccionado = new NetworkVariable<int>(-1);
    // 0 = nada; 1 = incorrecto; 2 = correcto.
    private readonly NetworkVariable<int> resultadoSeleccion = new NetworkVariable<int>(0);
    private readonly NetworkVariable<bool> puzzleCompletado = new NetworkVariable<bool>(false);

    private bool procesandoSeleccion;
    private Coroutine corrutinaSeleccion;
    private Coroutine rutinaHabilitarSalida;
    private bool secuenciaCinematograficaIniciada;
    private Sprite spriteNormalMesaElian;
    private Sprite spriteNormalMesaLia;

    public bool EstaCompletado => puzzleCompletado.Value;

    private void Awake()
    {
        if (mesaElian != null) spriteNormalMesaElian = mesaElian.sprite;
        if (mesaLia != null) spriteNormalMesaLia = mesaLia.sprite;
    }

    public override void OnNetworkSpawn()
    {
        pasoActual.OnValueChanged += AlCambiarPaso;
        simboloSeleccionado.OnValueChanged += AlCambiarSeleccion;
        resultadoSeleccion.OnValueChanged += AlCambiarResultado;
        puzzleCompletado.OnValueChanged += AlCompletarPuzzle;

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

        if (corrutinaSeleccion != null) StopCoroutine(corrutinaSeleccion);
        if (rutinaHabilitarSalida != null) StopCoroutine(rutinaHabilitarSalida);
        corrutinaSeleccion = null;
        rutinaHabilitarSalida = null;
    }

    // Botones de la mesa de Elian.
    public void SeleccionarCirculo() => SolicitarSeleccion(SimboloRecepcion.Circulo);
    public void SeleccionarTriangulo() => SolicitarSeleccion(SimboloRecepcion.Triangulo);
    public void SeleccionarCuadrado() => SolicitarSeleccion(SimboloRecepcion.Cuadrado);
    public void SeleccionarRombo() => SolicitarSeleccion(SimboloRecepcion.Rombo);

    private void SolicitarSeleccion(SimboloRecepcion simbolo)
    {
        if (!IsSpawned || puzzleCompletado.Value) return;
        EnviarSeleccionRpc((int)simbolo);
    }

    [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
    private void EnviarSeleccionRpc(int simbolo, RpcParams rpcParams = default)
    {
        if (!IsServer || puzzleCompletado.Value || procesandoSeleccion) return;
        if (secuenciaCorrecta == null || secuenciaCorrecta.Length == 0)
        {
            Debug.LogWarning("Puzzle Recepcion: no hay secuencia configurada.");
            return;
        }
        if (pasoActual.Value >= secuenciaCorrecta.Length) return;
        if (simbolo < (int)SimboloRecepcion.Circulo || simbolo > (int)SimboloRecepcion.Rombo) return;

        // La mesa de botones pertenece a Elian (Host) en la asignacion actual.
        if (NetworkManager.Singleton == null ||
            rpcParams.Receive.SenderClientId != NetworkManager.ServerClientId)
            return;

        SimboloRecepcion elegido = (SimboloRecepcion)simbolo;
        bool correcto = elegido == secuenciaCorrecta[pasoActual.Value];
        corrutinaSeleccion = StartCoroutine(ProcesarSeleccionServidor(elegido, correcto));
    }

    private IEnumerator ProcesarSeleccionServidor(SimboloRecepcion seleccionado, bool correcto)
    {
        procesandoSeleccion = true;
        simboloSeleccionado.Value = (int)seleccionado;
        resultadoSeleccion.Value = correcto ? 2 : 1;

        yield return new WaitForSecondsRealtime(Mathf.Max(0f, tiempoFeedback));

        if (correcto)
        {
            int siguientePaso = pasoActual.Value + 1;
            if (siguientePaso >= secuenciaCorrecta.Length)
            {
                // Conservar progreso completo al iluminar el ultimo simbolo.
                pasoActual.Value = secuenciaCorrecta.Length;
                puzzleCompletado.Value = true;
            }
            else pasoActual.Value = siguientePaso;
        }

        simboloSeleccionado.Value = -1;
        resultadoSeleccion.Value = 0;
        procesandoSeleccion = false;
        corrutinaSeleccion = null;
    }

    private void AlCambiarPaso(int anterior, int nuevo)
    {
        if (puzzleCompletado.Value) return;
        ActualizarPistaLia(nuevo);
        ActualizarSeleccionElian(simboloSeleccionado.Value);
    }

    private void ActualizarPistaLia(int paso)
    {
        if (puzzleCompletado.Value) return;
        OcultarSimbolosLia();
        if (secuenciaCorrecta == null || paso < 0 || paso >= secuenciaCorrecta.Length) return;
        MostrarImagen(ObtenerImagenLia(secuenciaCorrecta[paso]), true);
    }

    private void AlCambiarSeleccion(int anterior, int nuevo)
    {
        if (puzzleCompletado.Value) return;
        ActualizarSeleccionElian(nuevo);
    }

    private void ActualizarSeleccionElian(int simbolo)
    {
        if (puzzleCompletado.Value) return;
        OcultarSimbolosElian();
        if (secuenciaCorrecta != null)
        {
            int completados = Mathf.Min(pasoActual.Value, secuenciaCorrecta.Length);
            for (int i = 0; i < completados; i++)
                MostrarImagen(ObtenerImagenElian(secuenciaCorrecta[i]), true);
        }
        if (simbolo >= 0 && simbolo <= (int)SimboloRecepcion.Rombo)
            MostrarImagen(ObtenerImagenElian((SimboloRecepcion)simbolo), true);
    }

    private void AlCambiarResultado(int anterior, int nuevo)
    {
        if (!puzzleCompletado.Value) ActualizarResultado(nuevo);
    }

    private void ActualizarResultado(int resultado)
    {
        if (textoResultadoElian == null) return;
        if (resultado == 0)
        {
            textoResultadoElian.gameObject.SetActive(false);
            return;
        }
        textoResultadoElian.gameObject.SetActive(true);
        if (ColorUtility.TryParseHtmlString("#F3E4C7", out Color crema))
            textoResultadoElian.color = crema;
        textoResultadoElian.text = resultado == 2 ? "CORRECTO" : "INCORRECTO";
    }

    private void AlCompletarPuzzle(bool anterior, bool nuevo)
    {
        if (nuevo) FinalizarPuzzleLocal();
    }

    private void FinalizarPuzzleLocal()
    {
        if (secuenciaCinematograficaIniciada) return;
        secuenciaCinematograficaIniciada = true;

        OcultarSimbolosLia();
        OcultarSimbolosElian();
        if (textoResultadoElian != null) textoResultadoElian.gameObject.SetActive(false);
        if (ventanaPuzzleElian != null) ventanaPuzzleElian.SetActive(false);
        if (ventanaPuzzleLia != null) ventanaPuzzleLia.SetActive(false);

        if (HUDInteraccion.Instancia != null)
        {
            if (interaccionElian != null) HUDInteraccion.Instancia.OcultarBoton(interaccionElian);
            if (interaccionLia != null) HUDInteraccion.Instancia.OcultarBoton(interaccionLia);
        }

        if (interaccionElian != null) interaccionElian.enabled = false;
        if (interaccionLia != null) interaccionLia.enabled = false;

        // Quitar el brillo y regresar a la imagen normal del escenario.
        if (mesaElian != null && spriteNormalMesaElian != null)
            mesaElian.sprite = spriteNormalMesaElian;
        if (mesaLia != null && spriteNormalMesaLia != null)
            mesaLia.sprite = spriteNormalMesaLia;

        if (!string.IsNullOrWhiteSpace(misionAlCompletar) && HUDMision.Instancia != null)
            HUDMision.Instancia.CambiarMision(misionAlCompletar);

        StartCoroutine(SecuenciaCinematograficaLocal());

        // El servidor habilita la zona compartida una sola vez.
        if (IsServer && rutinaHabilitarSalida == null)
            rutinaHabilitarSalida = StartCoroutine(HabilitarSalidaTrasCinematica());

        Debug.Log("Puzzle Recepcion completado. Iniciando cinematica.");
    }

    private IEnumerator SecuenciaCinematograficaLocal()
    {
        NetworkManager red = NetworkManager.Singleton;
        if (red == null || red.LocalClient == null || red.LocalClient.PlayerObject == null)
            yield break;

        bool esElian = red.IsHost;
        NetworkObject jugadorLocal = red.LocalClient.PlayerObject;
        NetworkPlayerMovement movimiento = jugadorLocal.GetComponent<NetworkPlayerMovement>();
        CamaraJugadorLocal camara = jugadorLocal.GetComponent<CamaraJugadorLocal>();
        Transform puntoCamara = esElian ? puntoCamaraElian : puntoCamaraLia;
        Animator animatorPuerta = esElian ? animatorPuertaElian : animatorPuertaLia;

        if (movimiento == null || camara == null || puntoCamara == null || animatorPuerta == null)
        {
            Debug.LogError("Puzzle Recepcion: faltan referencias para la cinematica local.");
            yield break;
        }

        movimiento.BloquearMovimiento(true);
        float duracionAnimacion = ObtenerDuracionPuerta(animatorPuerta);
        camara.EnfocarConZoom(puntoCamara.position, duracionAnimacion + 0.5f);
        yield return new WaitForSecondsRealtime(0.4f);

        animatorPuerta.enabled = true;
        animatorPuerta.Rebind();
        animatorPuerta.Update(0f);

        yield return new WaitForSecondsRealtime(duracionAnimacion);
        yield return new WaitForSecondsRealtime(0.8f);

        movimiento.BloquearMovimiento(false);
    }

    private IEnumerator HabilitarSalidaTrasCinematica()
    {
        // La camara utiliza: zoom de entrada + pausa + zoom de salida.
        // El tiempo es conservador respecto de la rutina local de puertas.
        float mayorDuracion = Mathf.Max(
            ObtenerDuracionPuerta(animatorPuertaElian),
            ObtenerDuracionPuerta(animatorPuertaLia));
        float espera = mayorDuracion + 1.2f +
                       Mathf.Max(0f, margenSeguridadSalida);
        yield return new WaitForSecondsRealtime(espera);

        if (IsSpawned && IsServer && puzzleCompletado.Value)
        {
            if (zonaSalidaCooperativa != null)
            {
                zonaSalidaCooperativa.HabilitarSalida();
                Debug.Log("Puzzle Recepcion: salida cooperativa habilitada.");
            }
            else
            {
                Debug.LogError("Puzzle Recepcion: asigna PF_ZonaSalida en el Inspector.");
            }
        }
        rutinaHabilitarSalida = null;
    }

    private float ObtenerDuracionPuerta(Animator animator)
    {
        if (animator == null || animator.runtimeAnimatorController == null) return 2f;
        float duracion = 0f;
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
            if (clip != null && clip.length > duracion) duracion = clip.length;
        return duracion > 0f ? duracion : 2f;
    }

    private void PrepararVisualInicial()
    {
        OcultarSimbolosLia();
        OcultarSimbolosElian();
        if (textoResultadoElian != null) textoResultadoElian.gameObject.SetActive(false);
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
            case SimboloRecepcion.Circulo: return circuloLia;
            case SimboloRecepcion.Triangulo: return trianguloLia;
            case SimboloRecepcion.Cuadrado: return cuadradoLia;
            case SimboloRecepcion.Rombo: return romboLia;
            default: return null;
        }
    }

    private Image ObtenerImagenElian(SimboloRecepcion simbolo)
    {
        switch (simbolo)
        {
            case SimboloRecepcion.Circulo: return circuloElian;
            case SimboloRecepcion.Triangulo: return trianguloElian;
            case SimboloRecepcion.Cuadrado: return cuadradoElian;
            case SimboloRecepcion.Rombo: return romboElian;
            default: return null;
        }
    }

    private void MostrarImagen(Image imagen, bool mostrar)
    {
        if (imagen == null) return;
        Color color = imagen.color;
        color.a = mostrar ? 1f : 0f;
        imagen.color = color;
    }

    public void SolicitarReinicio()
    {
        if (!IsSpawned || puzzleCompletado.Value) return;
        ReiniciarPuzzleRpc();
    }

    [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
    private void ReiniciarPuzzleRpc()
    {
        if (!IsServer || puzzleCompletado.Value) return;
        if (corrutinaSeleccion != null)
        {
            StopCoroutine(corrutinaSeleccion);
            corrutinaSeleccion = null;
        }
        procesandoSeleccion = false;
        pasoActual.Value = 0;
        simboloSeleccionado.Value = -1;
        resultadoSeleccion.Value = 0;
        // El puzzle completado solamente se reinicia al recargar la escena.
    }
}
