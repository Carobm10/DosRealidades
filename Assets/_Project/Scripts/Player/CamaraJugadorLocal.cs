using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class CamaraJugadorLocal : NetworkBehaviour
{
    [Header("Camara del jugador")]
    [SerializeField] private Camera camaraJugador;
    [SerializeField] private AudioListener audioListenerJugador;

    private BoxCollider2D limitesCamara;
    private bool limitarCamara = false;

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

    private void AlCargarEscena(Scene escena, LoadSceneMode modo)
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
        {
            Debug.LogWarning(
                "No se encontro el objeto LimitesCamara."
            );

            return;
        }

        limitesCamara =
            objetoLimites.GetComponent<BoxCollider2D>();

        if (limitesCamara == null)
        {
            Debug.LogWarning(
                "LimitesCamara no tiene BoxCollider2D."
            );

            return;
        }

        limitarCamara = true;
    }

    private void LateUpdate()
    {
        if (!IsOwner)
            return;

        if (!limitarCamara)
            return;

        if (camaraJugador == null || limitesCamara == null)
            return;

        LimitarPosicionCamara();
    }

    private void LimitarPosicionCamara()
    {
        Bounds limites = limitesCamara.bounds;

        float altoCamara = camaraJugador.orthographicSize;
        float anchoCamara =
            altoCamara * camaraJugador.aspect;

        float minimoX = limites.min.x + anchoCamara;
        float maximoX = limites.max.x - anchoCamara;

        float minimoY = limites.min.y + altoCamara;
        float maximoY = limites.max.y - altoCamara;

        Vector3 posicionDeseada = transform.position;

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

        camaraJugador.transform.position =
            new Vector3(
                x,
                y,
                camaraJugador.transform.position.z
            );
    }
}