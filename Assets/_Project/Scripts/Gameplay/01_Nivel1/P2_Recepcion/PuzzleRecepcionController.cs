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
    [SerializeField]
    private SimboloRecepcion[] secuenciaCorrecta;

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

    private NetworkVariable<int> pasoActual =
        new NetworkVariable<int>(0);

    private NetworkVariable<int> simboloSeleccionado =
        new NetworkVariable<int>(-1);

    // 0 = nada
    // 1 = incorrecto
    // 2 = correcto
    private NetworkVariable<int> resultadoSeleccion =
        new NetworkVariable<int>(0);

    private NetworkVariable<bool> puzzleCompletado =
        new NetworkVariable<bool>(false);

    private bool procesandoSeleccion = false;
    private Coroutine corrutinaSeleccion;
    private bool secuenciaCinematograficaIniciada = false;

    public override void OnNetworkSpawn()
    {
        pasoActual.OnValueChanged += AlCambiarPaso;
        simboloSeleccionado.OnValueChanged += AlCambiarSeleccion;
        resultadoSeleccion.OnValueChanged += AlCambiarResultado;
        puzzleCompletado.OnValueChanged += AlCompletarPuzzle;

        PrepararVisualInicial();

        if (puzzleCompletado.Value)
        {
            FinalizarPuzzleLocal();
            return;
        }

        ActualizarPistaLia(pasoActual.Value);
        ActualizarSeleccionElian(
            simboloSeleccionado.Value
        );

        ActualizarResultado(
            resultadoSeleccion.Value
        );
    }

    public override void OnNetworkDespawn()
    {
        pasoActual.OnValueChanged -= AlCambiarPaso;
        simboloSeleccionado.OnValueChanged -= AlCambiarSeleccion;
        resultadoSeleccion.OnValueChanged -= AlCambiarResultado;
        puzzleCompletado.OnValueChanged -= AlCompletarPuzzle;
    }

    // ========================================
    // BOTONES DE ELIAN
    // ========================================

    public void SeleccionarCirculo()
    {
        EnviarSeleccionRpc(
            (int)SimboloRecepcion.Circulo
        );
    }

    public void SeleccionarTriangulo()
    {
        EnviarSeleccionRpc(
            (int)SimboloRecepcion.Triangulo
        );
    }

    public void SeleccionarCuadrado()
    {
        EnviarSeleccionRpc(
            (int)SimboloRecepcion.Cuadrado
        );
    }

    public void SeleccionarRombo()
    {
        EnviarSeleccionRpc(
            (int)SimboloRecepcion.Rombo
        );
    }

    // ========================================
    // VALIDACION EN SERVIDOR
    // ========================================

    [Rpc(SendTo.Server)]
    private void EnviarSeleccionRpc(
        int simbolo
    )
    {
        if (puzzleCompletado.Value)
            return;

        if (procesandoSeleccion)
            return;

        if (secuenciaCorrecta == null ||
            secuenciaCorrecta.Length == 0)
        {
            Debug.LogWarning(
                "Puzzle Recepcion: no hay secuencia configurada."
            );

            return;
        }

        if (pasoActual.Value >=
            secuenciaCorrecta.Length)
        {
            return;
        }

        SimboloRecepcion seleccionado =
            (SimboloRecepcion)simbolo;

        SimboloRecepcion correcto =
            secuenciaCorrecta[pasoActual.Value];

        bool acerto =
            seleccionado == correcto;

        corrutinaSeleccion = StartCoroutine(
            ProcesarSeleccionServidor(
                seleccionado,
                acerto
            )
        );
    }

    
    private IEnumerator ProcesarSeleccionServidor(
        SimboloRecepcion seleccionado,
        bool correcto
    )
    {
        procesandoSeleccion = true;

        // Mostrar la figura seleccionada.
        simboloSeleccionado.Value = (int)seleccionado;

        resultadoSeleccion.Value = correcto ? 2 : 1;

        yield return new WaitForSeconds(tiempoFeedback);

        if (correcto)
        {
            int siguientePaso = pasoActual.Value + 1;

            // IMPORTANTE:
            // Primero avanzamos el paso para conservar
            // iluminada la figura que acaba de acertar.
            if (siguientePaso >= secuenciaCorrecta.Length)
            {
                puzzleCompletado.Value = true;
            }
            else
            {
                pasoActual.Value = siguientePaso;
            }
        }

        // Ahora limpiamos únicamente el feedback.
        // Las figuras acertadas permanecen iluminadas.
        simboloSeleccionado.Value = -1;
        resultadoSeleccion.Value = 0;

        procesandoSeleccion = false;
    }


    // ========================================
    // CAMBIO DE PASO
    // ========================================

    private void AlCambiarPaso(int anterior, int nuevo)
    {
        ActualizarPistaLia(nuevo);

        // Actualizar las figuras acumuladas de Elian.
        ActualizarSeleccionElian(simboloSeleccionado.Value);

        Debug.Log(
            "Puzzle Recepcion | Paso: " + (nuevo + 1)
        );
    }

    private void ActualizarPistaLia(
        int paso
    )
    {
        OcultarSimbolosLia();

        if (secuenciaCorrecta == null)
            return;

        if (paso < 0 ||
            paso >= secuenciaCorrecta.Length)
        {
            return;
        }

        SimboloRecepcion pista =
            secuenciaCorrecta[paso];

        Image imagen =
            ObtenerImagenLia(pista);

        MostrarImagen(imagen, true);
    }

    // ========================================
    // VISUAL DE ELIAN
    // ========================================

    private void AlCambiarSeleccion(int anterior, int nuevo)
    {
        ActualizarSeleccionElian(nuevo);
    }
    
    private void ActualizarSeleccionElian(int simbolo)
    {
        // Limpiar la visualización anterior.
        OcultarSimbolosElian();

        // Mantener iluminadas las figuras ya acertadas.
        if (secuenciaCorrecta != null)
        {
            int pasosCompletados = Mathf.Min(
                pasoActual.Value,
                secuenciaCorrecta.Length
            );

            for (int i = 0; i < pasosCompletados; i++)
            {
                Image figuraCorrecta =
                    ObtenerImagenElian(secuenciaCorrecta[i]);

                MostrarImagen(figuraCorrecta, true);
            }
        }

        // Mostrar temporalmente la selección actual.
        if (simbolo >= 0 &&
            simbolo <= (int)SimboloRecepcion.Rombo)
        {
            Image figuraActual =
                ObtenerImagenElian((SimboloRecepcion)simbolo);

            MostrarImagen(figuraActual, true);
        }
    }


    // ========================================
    // CORRECTO / INCORRECTO
    // ========================================

    private void AlCambiarResultado(
        int anterior,
        int nuevo
    )
    {
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

        // Color crema para ambos resultados.
        Color colorCrema;
        ColorUtility.TryParseHtmlString("#F3E4C7", out colorCrema);

        textoResultadoElian.color = colorCrema;

        textoResultadoElian.text =
            resultado == 2 ? "CORRECTO" : "INCORRECTO";
    }


    // ========================================
    // PUZZLE COMPLETADO
    // ========================================

    private void AlCompletarPuzzle(
        bool anterior,
        bool nuevo
    )
    {
        if (!nuevo)
            return;

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

        if (!string.IsNullOrWhiteSpace(misionAlCompletar))
        {
            if (HUDMision.Instancia != null)
                HUDMision.Instancia.CambiarMision(misionAlCompletar);
        }

        StartCoroutine(SecuenciaCinematograficaLocal());

        Debug.Log("Puzzle completado. Iniciando secuencia cinematografica.");
    }

    
    private IEnumerator SecuenciaCinematograficaLocal()
    {
        if (NetworkManager.Singleton == null |
            NetworkManager.Singleton.LocalClient == null)
            yield break;

        // Identificar el jugador local.
        bool esElian = NetworkManager.Singleton.IsHost;

        NetworkObject jugadorLocal =
            NetworkManager.Singleton.LocalClient.PlayerObject;

        if (jugadorLocal == null)
        {
            Debug.LogError("No se encontro el jugador local.");
            yield break;
        }

        NetworkPlayerMovement movimiento =
            jugadorLocal.GetComponent<NetworkPlayerMovement>();

        CamaraJugadorLocal camara =
            jugadorLocal.GetComponent<CamaraJugadorLocal>();

        Transform puntoCamara =
            esElian ? puntoCamaraElian : puntoCamaraLia;

        Animator animatorPuerta =
            esElian ? animatorPuertaElian : animatorPuertaLia;

        if (movimiento == null ||
            camara == null ||
            puntoCamara == null ||
            animatorPuerta == null)
        {
            Debug.LogError(
                "Falta una referencia para la secuencia cinematografica."
            );

            yield break;
        }

        // 1. Bloquear movimiento local.
        movimiento.BloquearMovimiento(true);

        // 2. Obtener duracion de la animacion.
        float duracionAnimacion = ObtenerDuracionPuerta(animatorPuerta);

        // 3. Iniciar zoom hacia la puerta.
        camara.EnfocarConZoom(
            puntoCamara.position,
            duracionAnimacion + 0.5f
        );

        // Esperar a que la camara se acerque.
        yield return new WaitForSeconds(0.4f);

        // 4. Activar la animacion de apertura.
        animatorPuerta.enabled = true;
        animatorPuerta.Rebind();
        animatorPuerta.Update(0f);

        Debug.Log(
            "Abriendo puerta de " + (esElian ? "Elian" : "Lia")
        );

        // 5. Esperar a que termine la animacion.
        yield return new WaitForSeconds(duracionAnimacion);

        // 6. Esperar el regreso de la camara.
        yield return new WaitForSeconds(0.8f);

        // 7. Liberar movimiento.
        movimiento.BloquearMovimiento(false);

        Debug.Log(
            "Secuencia cinematografica terminada para " +
            (esElian ? "Elian" : "Lia")
        );
    }

    private float ObtenerDuracionPuerta(Animator animator)
    {
        if (animator == null ||
            animator.runtimeAnimatorController == null)
            return 2f;

        float duracion = 0f;

        AnimationClip[] clips =
            animator.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            if (clip != null && clip.length > duracion)
                duracion = clip.length;
        }

        return duracion > 0f ? duracion : 2f;
    }




    // ========================================
    // UTILIDADES VISUALES
    // ========================================

    private void PrepararVisualInicial()
    {
        OcultarSimbolosLia();
        OcultarSimbolosElian();

        if (textoResultadoElian != null)
        {
            textoResultadoElian.gameObject.SetActive(false);
        }
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

    private Image ObtenerImagenLia(
        SimboloRecepcion simbolo
    )
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
        }

        return null;
    }

    private Image ObtenerImagenElian(
        SimboloRecepcion simbolo
    )
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
        }

        return null;
    }

    private void MostrarImagen(
        Image imagen,
        bool mostrar
    )
    {
        if (imagen == null)
            return;

        Color color = imagen.color;

        color.a =
            mostrar ? 1f : 0f;

        imagen.color = color;
    }

    // ========================================
    // REINICIAR PUZZLE AL CERRAR
    // ========================================

    public void SolicitarReinicio()
    {
        ReiniciarPuzzleRpc();
    }

    [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
    private void ReiniciarPuzzleRpc()
    {
        // Si el puzzle ya fue completado, no permitir reiniciarlo.
        if (puzzleCompletado.Value)
            return;
        // Detener cualquier selección que esté procesándose.
        if (corrutinaSeleccion != null)
        {
            StopCoroutine(corrutinaSeleccion);
            corrutinaSeleccion = null;
        }

        procesandoSeleccion = false;

        // Restablecer todos los valores del puzzle.
        pasoActual.Value = 0;
        simboloSeleccionado.Value = -1;
        resultadoSeleccion.Value = 0;
        puzzleCompletado.Value = false;

        Debug.Log("Puzzle Recepción reiniciado.");
    }


}