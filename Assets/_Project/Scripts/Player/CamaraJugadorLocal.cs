
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Collections;

public class CamaraJugadorLocal : NetworkBehaviour
{
    [Header("Camara del jugador")]
    [SerializeField] private Camera camaraJugador;
    [SerializeField] private AudioListener audioListenerJugador;

    [Header("Enfoque cinematografico")]
    [SerializeField] private float velocidadEnfoque = 5f;
    [SerializeField] private float zoomObjetivo = 3f;
    [SerializeField] private float velocidadZoom = 3f;

    [Header("Camara fija en habitaciones")]
    [SerializeField] private float margenHabitacion = 1f;
    private Transform puntoCamaraFija;

    // =====================================
    // CONFIGURACION EXCLUSIVA RUNNER
    // =====================================

    [Header("Runner Vigilia - Camara horizontal")]
    [SerializeField] private float ajusteZoomRunner = 1f;

    private const string ESCENA_RUNNER = "Runner_Vigilia";

    private bool modoRunnerActivo;
    private float alturaFijaRunner;

    // =====================================
    // VARIABLES GENERALES
    // =====================================

    private bool camaraFijaActiva;
    private bool cinematicaActiva;

    private BoxCollider2D limitesCamara;
    private bool limitarCamara = false;

    private bool enfoqueActivo = false;
    private bool zoomEnCurso;

    private Vector3 puntoEnfoque;

    private float tamañoOriginal;
    private Coroutine rutinaEnfoque;

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        if (camaraJugador == null)
        {
            camaraJugador =
                GetComponentInChildren<Camera>(true);
        }

        if (audioListenerJugador == null &&
            camaraJugador != null)
        {
            audioListenerJugador =
                camaraJugador.GetComponent<AudioListener>();
        }

        if (camaraJugador != null)
        {
            tamañoOriginal =
                camaraJugador.orthographicSize;
        }
    }

    // =====================================
    // NETWORK SPAWN
    // =====================================

    public override void OnNetworkSpawn()
    {
        SceneManager.sceneLoaded += AlCargarEscena;

        ActualizarCamara(
            SceneManager.GetActiveScene().name
        );

        BuscarLimitesCamara();
    }

    public override void OnNetworkDespawn()
    {
        SceneManager.sceneLoaded -= AlCargarEscena;

        if (rutinaEnfoque != null)
        {
            StopCoroutine(rutinaEnfoque);
            rutinaEnfoque = null;
        }
    }

    // =====================================
    // CAMBIO DE ESCENA
    // =====================================

    private void AlCargarEscena(
        Scene escena,
        LoadSceneMode modo)
    {
        ActualizarCamara(escena.name);
        BuscarLimitesCamara();
    }

    private void ActualizarCamara(string nombreEscena)
    {
        if (camaraJugador == null)
            return;

        bool escenaJugable =
            nombreEscena != "01_MainMenu";

        bool activar =
            IsOwner && escenaJugable;

        camaraJugador.gameObject.SetActive(activar);

        if (audioListenerJugador != null)
        {
            audioListenerJugador.enabled = activar;
        }
    }

    // =====================================
    // BUSCAR LIMITES DE CAMARA
    // =====================================

    private void BuscarLimitesCamara()
    {
        puntoCamaraFija = null;
        limitarCamara = false;
        limitesCamara = null;
        camaraFijaActiva = false;

        modoRunnerActivo =
            SceneManager.GetActiveScene().name == ESCENA_RUNNER;

        if (!IsOwner)
            return;

        if (camaraJugador != null)
        {
            camaraJugador.ResetAspect();
        }

        GameObject puntoFijo =
            GameObject.Find("PuntoCamaraFija");

        if (puntoFijo != null)
        {
            puntoCamaraFija = puntoFijo.transform;
        }

        DetenerEnfoqueAnterior();

        GameObject objetoLimites =
            GameObject.Find("LimitesCamara");

        if (objetoLimites == null)
        {
            if (modoRunnerActivo)
            {
                Debug.LogError(
                    "RUNNER: No se encontró LimitesCamara."
                );
            }

            return;
        }

        limitesCamara =
            objetoLimites.GetComponent<BoxCollider2D>();

        limitarCamara = limitesCamara != null;

        camaraFijaActiva =
            GameObject.Find("PuntoCamaraFija") != null &&
            limitesCamara != null;

        // =====================================
        // CONFIGURACION EXCLUSIVA RUNNER
        // =====================================

        if (modoRunnerActivo)
        {
            ConfigurarCamaraRunner();
        }
    }

    // =====================================
    // CONFIGURAR CAMARA RUNNER
    // =====================================

    private void ConfigurarCamaraRunner()
    {
        if (camaraJugador == null)
            return;

        camaraJugador.orthographic = true;

        if (limitesCamara != null)
        {
            Bounds limites = limitesCamara.bounds;

            // La camara permanece a la altura
            // central del escenario.

            alturaFijaRunner = limites.center.y;

            // Ajustar zoom para cubrir
            // la altura completa del escenario.

            camaraJugador.orthographicSize =
                Mathf.Max(
                    0.1f,
                    limites.extents.y * ajusteZoomRunner
                );
        }
        else
        {
            alturaFijaRunner =
                camaraJugador.transform.position.y;
        }

        Debug.Log(
            "RUNNER: Camara horizontal configurada. " +
            "Zoom: " + camaraJugador.orthographicSize +
            " | Altura fija: " + alturaFijaRunner
        );
    }

    // =====================================
    // ACTUALIZACION DE CAMARA
    // =====================================

    private void LateUpdate()
    {
        if (!IsOwner || camaraJugador == null)
            return;

        // Durante el zoom, la corrutina
        // controla la camara.

        if (zoomEnCurso)
            return;

        // Enfoque temporal.

        if (enfoqueActivo)
        {
            Vector3 posicionLimitada =
                ObtenerPosicionLimitada(puntoEnfoque);

            posicionLimitada.z =
                camaraJugador.transform.position.z;

            camaraJugador.transform.position =
                Vector3.Lerp(
                    camaraJugador.transform.position,
                    posicionLimitada,
                    velocidadEnfoque * Time.deltaTime
                );

            return;
        }

        // =====================================
        // RUNNER: SEGUIMIENTO HORIZONTAL
        // =====================================

        if (modoRunnerActivo)
        {
            SeguirJugadorHorizontal();
            return;
        }

        // =====================================
        // COMPORTAMIENTO ORIGINAL
        // DEMAS NIVELES
        // =====================================

        if (puntoCamaraFija != null &&
            limitesCamara != null)
        {
            Bounds limites = limitesCamara.bounds;

            Vector3 posicion = limites.center;

            posicion.z =
                camaraJugador.transform.position.z;

            camaraJugador.transform.position = posicion;

            camaraJugador.orthographic = true;

            camaraJugador.orthographicSize =
                limites.size.y / 2f;

            camaraJugador.aspect =
                limites.size.x / limites.size.y;

            return;
        }

        if (camaraFijaActiva &&
            limitesCamara != null)
        {
            AjustarCamaraHabitacion();
            return;
        }

        Vector3 posicionDeseada = transform.position;

        Vector3 posicionFinal =
            ObtenerPosicionLimitada(posicionDeseada);

        posicionFinal.z =
            camaraJugador.transform.position.z;

        camaraJugador.transform.position = posicionFinal;
    }

    // =====================================
    // SEGUIMIENTO HORIZONTAL RUNNER
    // =====================================

    private void SeguirJugadorHorizontal()
    {
        if (camaraJugador == null)
            return;

        float posicionX = transform.position.x;

        float posicionY = alturaFijaRunner;

        if (limitesCamara != null)
        {
            Bounds limites = limitesCamara.bounds;

            float anchoCamara =
                camaraJugador.orthographicSize *
                camaraJugador.aspect;

            float minimoX =
                limites.min.x + anchoCamara;

            float maximoX =
                limites.max.x - anchoCamara;

            // Evitar salir del escenario
            // por los extremos horizontales.

            if (minimoX > maximoX)
            {
                posicionX = limites.center.x;
            }
            else
            {
                posicionX = Mathf.Clamp(
                    posicionX,
                    minimoX,
                    maximoX
                );
            }
        }

        Vector3 posicionFinal = new Vector3(
            posicionX,
            posicionY,
            camaraJugador.transform.position.z
        );

        camaraJugador.transform.position =
            posicionFinal;
    }

    // =====================================
    // LIMITES GENERALES
    // =====================================

    private Vector3 ObtenerPosicionLimitada(
        Vector3 posicionDeseada)
    {
        if (!limitarCamara || limitesCamara == null)
            return posicionDeseada;

        Bounds limites = limitesCamara.bounds;

        float altoCamara =
            camaraJugador.orthographicSize;

        float anchoCamara =
            altoCamara * camaraJugador.aspect;

        float minimoX =
            limites.min.x + anchoCamara;

        float maximoX =
            limites.max.x - anchoCamara;

        float minimoY =
            limites.min.y + altoCamara;

        float maximoY =
            limites.max.y - altoCamara;

        float x =
            minimoX > maximoX
            ? limites.center.x
            : Mathf.Clamp(
                posicionDeseada.x,
                minimoX,
                maximoX
            );

        float y =
            minimoY > maximoY
            ? limites.center.y
            : Mathf.Clamp(
                posicionDeseada.y,
                minimoY,
                maximoY
            );

        return new Vector3(
            x,
            y,
            posicionDeseada.z
        );
    }

    // =====================================
    // ENFOQUE TEMPORAL SIN ZOOM
    // =====================================

    public void EnfocarTemporalmente(
        Vector3 posicion,
        float duracion = 2f)
    {
        if (!IsOwner || camaraJugador == null)
            return;

        DetenerEnfoqueAnterior();

        rutinaEnfoque =
            StartCoroutine(
                RutinaEnfoque(posicion, duracion)
            );
    }

    private IEnumerator RutinaEnfoque(
        Vector3 posicion,
        float duracion)
    {
        puntoEnfoque = posicion;
        enfoqueActivo = true;

        yield return new WaitForSeconds(duracion);

        enfoqueActivo = false;
        rutinaEnfoque = null;
    }

    // =====================================
    // ENFOQUE CINEMATOGRAFICO CON ZOOM
    // =====================================

    public void EnfocarConZoom(
        Vector3 posicion,
        float duracion)
    {
        if (!IsOwner || camaraJugador == null)
            return;

        DetenerEnfoqueAnterior();

        rutinaEnfoque =
            StartCoroutine(
                RutinaZoom(posicion, duracion)
            );
    }

    private IEnumerator RutinaZoom(
        Vector3 posicion,
        float duracion)
    {
        Vector3 posicionInicial =
            camaraJugador.transform.position;

        float tamañoInicial =
            camaraJugador.orthographicSize;

        Vector3 posicionZoom = new Vector3(
            posicion.x,
            posicion.y,
            posicionInicial.z
        );

        enfoqueActivo = true;
        zoomEnCurso = true;

        // ACERCAMIENTO

        float tiempo = 0f;

        while (tiempo < 1f)
        {
            tiempo += Time.deltaTime * velocidadZoom;

            float t = Mathf.Clamp01(tiempo);

            camaraJugador.orthographicSize =
                Mathf.Lerp(
                    tamañoInicial,
                    zoomObjetivo,
                    t
                );

            Vector3 posicionDeseada =
                Vector3.Lerp(
                    posicionInicial,
                    posicionZoom,
                    t
                );

            Vector3 posicionLimitada =
                ObtenerPosicionLimitada(posicionDeseada);

            posicionLimitada.z = posicionInicial.z;

            camaraJugador.transform.position =
                posicionLimitada;

            yield return null;
        }

        camaraJugador.orthographicSize = zoomObjetivo;

        camaraJugador.transform.position =
            ObtenerPosicionLimitada(posicionZoom);

        // MANTENER ENFOQUE

        yield return new WaitForSeconds(duracion);

        // REGRESAR A LA POSICION ORIGINAL

        tiempo = 0f;

        while (tiempo < 1f)
        {
            tiempo += Time.deltaTime * velocidadZoom;

            float t = Mathf.Clamp01(tiempo);

            camaraJugador.orthographicSize =
                Mathf.Lerp(
                    zoomObjetivo,
                    tamañoInicial,
                    t
                );

            Vector3 posicionDeseada =
                Vector3.Lerp(
                    posicionZoom,
                    posicionInicial,
                    t
                );

            Vector3 posicionLimitada =
                ObtenerPosicionLimitada(posicionDeseada);

            posicionLimitada.z = posicionInicial.z;

            camaraJugador.transform.position =
                posicionLimitada;

            yield return null;
        }

        camaraJugador.orthographicSize = tamañoInicial;

        camaraJugador.transform.position =
            ObtenerPosicionLimitada(posicionInicial);

        enfoqueActivo = false;
        zoomEnCurso = false;
        rutinaEnfoque = null;
    }

    // =====================================
    // DETENER ENFOQUE ANTERIOR
    // =====================================

    private void DetenerEnfoqueAnterior()
    {
        if (rutinaEnfoque != null)
        {
            StopCoroutine(rutinaEnfoque);
            rutinaEnfoque = null;
        }

        cinematicaActiva = false;
        enfoqueActivo = false;
        zoomEnCurso = false;

        if (camaraJugador == null)
            return;

        if (puntoCamaraFija != null &&
            limitesCamara != null)
        {
            Bounds limites = limitesCamara.bounds;

            Vector3 posicion = limites.center;

            posicion.z =
                camaraJugador.transform.position.z;

            camaraJugador.transform.position = posicion;

            camaraJugador.orthographicSize =
                limites.size.y / 2f;

            camaraJugador.aspect =
                limites.size.x / limites.size.y;
        }
    }

    // =====================================
    // AJUSTAR CAMARA DE HABITACION
    // =====================================

    private void AjustarCamaraHabitacion()
    {
        Bounds limites = limitesCamara.bounds;

        float alto = limites.size.y;
        float ancho = limites.size.x;

        float tamañoVertical = alto / 2f;

        float tamañoHorizontal =
            ancho / (2f * camaraJugador.aspect);

        camaraJugador.orthographicSize =
            Mathf.Max(
                tamañoVertical,
                tamañoHorizontal
            ) * Mathf.Max(1f, margenHabitacion);

        Vector3 posicion = limites.center;

        posicion.z =
            camaraJugador.transform.position.z;

        camaraJugador.transform.position = posicion;
    }
}
