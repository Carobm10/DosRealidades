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

        StartCoroutine(
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

        // Mostramos lo que Elian acaba de tocar.
        simboloSeleccionado.Value =
            (int)seleccionado;

        resultadoSeleccion.Value =
            correcto ? 2 : 1;

        yield return new WaitForSeconds(
            tiempoFeedback
        );

        // Quitamos el feedback.
        simboloSeleccionado.Value = -1;
        resultadoSeleccion.Value = 0;

        if (correcto)
        {
            int siguientePaso =
                pasoActual.Value + 1;

            if (siguientePaso >=
                secuenciaCorrecta.Length)
            {
                puzzleCompletado.Value = true;
            }
            else
            {
                pasoActual.Value =
                    siguientePaso;
            }
        }

        procesandoSeleccion = false;
    }

    // ========================================
    // CAMBIO DE PASO
    // ========================================

    private void AlCambiarPaso(
        int anterior,
        int nuevo
    )
    {
        ActualizarPistaLia(nuevo);

        Debug.Log(
            "Puzzle Recepcion | Paso: " +
            (nuevo + 1)
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

    private void AlCambiarSeleccion(
        int anterior,
        int nuevo
    )
    {
        ActualizarSeleccionElian(nuevo);
    }

    private void ActualizarSeleccionElian(
        int simbolo
    )
    {
        OcultarSimbolosElian();

        if (simbolo < 0)
            return;

        Image imagen =
            ObtenerImagenElian(
                (SimboloRecepcion)simbolo
            );

        MostrarImagen(imagen, true);
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

    private void ActualizarResultado(
        int resultado
    )
    {
        if (textoResultadoElian == null)
            return;

        if (resultado == 0)
        {
            textoResultadoElian.gameObject.SetActive(false);
            return;
        }

        textoResultadoElian.gameObject.SetActive(true);

        if (resultado == 2)
        {
            textoResultadoElian.text =
                "CORRECTO";

            textoResultadoElian.color =
                Color.green;
        }
        else
        {
            textoResultadoElian.text =
                "INCORRECTO";

            textoResultadoElian.color =
                Color.red;
        }
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
        OcultarSimbolosLia();
        OcultarSimbolosElian();

        if (textoResultadoElian != null)
        {
            textoResultadoElian.gameObject.SetActive(false);
        }

        if (ventanaPuzzleElian != null)
        {
            ventanaPuzzleElian.SetActive(false);
        }

        if (ventanaPuzzleLia != null)
        {
            ventanaPuzzleLia.SetActive(false);
        }

        if (HUDInteraccion.Instancia != null)
        {
            if (interaccionElian != null)
            {
                HUDInteraccion.Instancia.OcultarBoton(
                    interaccionElian
                );
            }

            if (interaccionLia != null)
            {
                HUDInteraccion.Instancia.OcultarBoton(
                    interaccionLia
                );
            }
        }

        if (interaccionElian != null)
        {
            interaccionElian.enabled = false;
        }

        if (interaccionLia != null)
        {
            interaccionLia.enabled = false;
        }

        if (!string.IsNullOrWhiteSpace(
            misionAlCompletar
        ))
        {
            if (HUDMision.Instancia != null)
            {
                HUDMision.Instancia.CambiarMision(
                    misionAlCompletar
                );
            }
        }

        Debug.Log(
            "Puzzle de Recepcion completado."
        );
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
}