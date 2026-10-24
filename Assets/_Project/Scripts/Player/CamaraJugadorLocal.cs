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

    private BoxCollider2D limitesCamara;
    private bool limitarCamara = false;

    private bool enfoqueActivo = false;
    private Vector3 puntoEnfoque;

    private Coroutine rutinaEnfoque;

    private void Awake()
    {
        if (camaraJugador == null)
        {
            camaraJugador = GetComponentInChildren<Camera>(true);
        }

        if (audioListenerJugador == null && camaraJugador != null)
        {
            audioListenerJugador =
                camaraJugador.GetComponent<AudioListener>();
        }
    }

    public override void OnNetworkSpawn()
    {
        SceneManager.sceneLoaded += AlCargarEscena;

        ActualizarCamara(SceneManager.GetActiveScene().name);
        BuscarLimitesCamara();
    }

    public override void OnNetworkDespawn()
    {
        SceneManager.sceneLoaded -= AlCargarEscena;
    }

    private void AlCargarEscena(
        Scene escena,
        LoadSceneMode modo
    )
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
        limitarCamara = false;
        limitesCamara = null;

        if (!IsOwner)
            return;

        GameObject objetoLimites =
            GameObject.Find("LimitesCamara");

        if (objetoLimites == null)
            return;

        limitesCamara =
            objetoLimites.GetComponent<BoxCollider2D>();

        if (limitesCamara == null)
            return;

        limitarCamara = true;
    }

    private void LateUpdate()
    {
        if (!IsOwner)
            return;

        if (camaraJugador == null)
            return;

        Vector3 posicionDeseada;

        if (enfoqueActivo)
        {
            posicionDeseada = puntoEnfoque;

            Vector3 posicionLimitada =
                ObtenerPosicionLimitada(posicionDeseada);

            posicionLimitada.z =
                camaraJugador.transform.position.z;

            camaraJugador.transform.position =
                Vector3.Lerp(
                    camaraJugador.transform.position,
                    posicionLimitada,
                    velocidadEnfoque * Time.deltaTime
                );
        }
        else
        {
            posicionDeseada = transform.position;

            Vector3 posicionLimitada =
                ObtenerPosicionLimitada(posicionDeseada);

            posicionLimitada.z =
                camaraJugador.transform.position.z;

            camaraJugador.transform.position =
                posicionLimitada;
        }
    }

    private Vector3 ObtenerPosicionLimitada(
        Vector3 posicionDeseada
    )
    {
        if (!limitarCamara || limitesCamara == null)
        {
            return posicionDeseada;
        }

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

        float x;
        float y;

        if (minimoX > maximoX)
            x = limites.center.x;
        else
            x = Mathf.Clamp(
                posicionDeseada.x,
                minimoX,
                maximoX
            );

        if (minimoY > maximoY)
            y = limites.center.y;
        else
            y = Mathf.Clamp(
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

    public void EnfocarTemporalmente(
        Vector3 posicion,
        float duracion = 2f
    )
    {
        if (!IsOwner)
            return;

        if (rutinaEnfoque != null)
        {
            StopCoroutine(rutinaEnfoque);
        }

        rutinaEnfoque =
            StartCoroutine(
                RutinaEnfoque(posicion, duracion)
            );
    }

    private IEnumerator RutinaEnfoque(
        Vector3 posicion,
        float duracion
    )
    {
        puntoEnfoque = posicion;
        enfoqueActivo = true;

        yield return new WaitForSeconds(duracion);

        enfoqueActivo = false;
        rutinaEnfoque = null;
    }
}
