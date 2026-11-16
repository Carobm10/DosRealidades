
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

    private bool camaraFijaActiva;

    private BoxCollider2D limitesCamara;
    private bool limitarCamara = false;

    private bool enfoqueActivo = false;
    private Vector3 puntoEnfoque;

    private float tamañoOriginal;
    private Coroutine rutinaEnfoque;

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

    private void BuscarLimitesCamara()
    {
        puntoCamaraFija = null;
        limitarCamara = false;
        limitesCamara = null;
        camaraFijaActiva = false;

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

        DetenerEnfoqueAnterior();

        GameObject objetoLimites =
            GameObject.Find("LimitesCamara");

        if (objetoLimites == null)
            return;

        limitesCamara =
            objetoLimites.GetComponent<BoxCollider2D>();

        limitarCamara = limitesCamara != null;

        camaraFijaActiva =
            GameObject.Find("PuntoCamaraFija") != null &&
            limitesCamara != null;
    }

    private void LateUpdate()
    {
        if (!IsOwner || camaraJugador == null)
            return;

        if (puntoCamaraFija != null && limitesCamara != null)
        {
            Bounds limites = limitesCamara.bounds;

            Vector3 posicion = limites.center;
            posicion.z = camaraJugador.transform.position.z;

            camaraJugador.transform.position = posicion;

            camaraJugador.orthographic = true;

            camaraJugador.orthographicSize =
                limites.size.y / 2f;

            camaraJugador.aspect =
                limites.size.x / limites.size.y;

            return;
        }
        if (camaraFijaActiva && limitesCamara != null)
        {
            AjustarCamaraHabitacion();
            return;
        }

        Vector3 posicionDeseada =
            enfoqueActivo
            ? puntoEnfoque
            : transform.position;

        Vector3 posicionLimitada =
            ObtenerPosicionLimitada(posicionDeseada);

        posicionLimitada.z =
            camaraJugador.transform.position.z;

        if (enfoqueActivo)
        {
            camaraJugador.transform.position =
                Vector3.Lerp(
                    camaraJugador.transform.position,
                    posicionLimitada,
                    velocidadEnfoque * Time.deltaTime
                );
        }
        else
        {
            camaraJugador.transform.position =
                posicionLimitada;
        }
    }

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

    // ENFOQUE TEMPORAL SIN ZOOM
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

    // ENFOQUE CINEMATOGRAFICO CON ZOOM
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
        float tamañoInicial =
            camaraJugador.orthographicSize;

        puntoEnfoque = posicion;
        enfoqueActivo = true;

        // Acercamiento
        float tiempo = 0f;

        while (tiempo < 1f)
        {
            tiempo += Time.deltaTime * velocidadZoom;

            camaraJugador.orthographicSize =
                Mathf.Lerp(
                    tamañoInicial,
                    zoomObjetivo,
                    Mathf.Clamp01(tiempo)
                );

            yield return null;
        }

        camaraJugador.orthographicSize =
            zoomObjetivo;

        // Mantener el enfoque
        yield return new WaitForSeconds(duracion);

        // Regresar el zoom
        tiempo = 0f;

        while (tiempo < 1f)
        {
            tiempo += Time.deltaTime * velocidadZoom;

            camaraJugador.orthographicSize =
                Mathf.Lerp(
                    zoomObjetivo,
                    tamañoOriginal,
                    Mathf.Clamp01(tiempo)
                );

            yield return null;
        }

        camaraJugador.orthographicSize =
            tamañoOriginal;

        enfoqueActivo = false;
        rutinaEnfoque = null;
    }

    private void DetenerEnfoqueAnterior()
    {
        if (rutinaEnfoque != null)
        {
            StopCoroutine(rutinaEnfoque);
            rutinaEnfoque = null;
        }

        if (camaraJugador != null)
        {
            camaraJugador.orthographicSize =
                tamañoOriginal;
        }

        enfoqueActivo = false;
    }

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
