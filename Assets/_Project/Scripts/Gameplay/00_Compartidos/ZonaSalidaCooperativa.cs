
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Collections;

public class ZonaSalidaCooperativa : NetworkBehaviour
{
    [Header("Escena de destino")]
    [SerializeField] private string escenaDestino;

    [Header("Zona de deteccion")]
    [SerializeField] private Collider2D zonaDeteccion;

    [Header("Visuales de salida")]
    [SerializeField] private GameObject visualBloqueado;
    [SerializeField] private GameObject visualHabilitado;

    [Header("Cinematica Elian")]
    [SerializeField] private Transform puntoCamaraElian;
    [SerializeField] private Animator animatorPuertaElian;

    [Header("Cinematica Lia")]
    [SerializeField] private Transform puntoCamaraLia;
    [SerializeField] private Animator animatorPuertaLia;

    [Header("Configuracion de puerta")]
    [SerializeField] private bool tienePuerta = true;
    [SerializeField] private string estadoApertura = "Abrir";

    [Header("Configuracion de camara")]
    [SerializeField] private bool usarZoom = true;

    [Header("Tiempos")]
    [SerializeField] private float esperaAntesDeAbrir = 0.4f;
    [SerializeField] private float duracionApertura = 1f;
    [SerializeField] private float esperaCambioEscena = 2f;

    private NetworkVariable<bool> puzzleResuelto =
        new NetworkVariable<bool>(false);

    private NetworkVariable<bool> salidaHabilitada =
        new NetworkVariable<bool>(false);

    private bool cambiandoEscena;

    private Coroutine rutinaPrepararSalida;
    private Coroutine rutinaCambioEscena;

    public bool SalidaHabilitada =>
        salidaHabilitada.Value;

    public bool PuzzleResuelto =>
        puzzleResuelto.Value;

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        if (zonaDeteccion == null)
        {
            Transform zona =
                transform.Find("ZonaDeteccion");

            if (zona != null)
                zonaDeteccion =
                    zona.GetComponent<Collider2D>();
        }
    }

    public override void OnNetworkSpawn()
    {
        salidaHabilitada.OnValueChanged +=
            AlCambiarEstadoSalida;

        ActualizarVisuales(
            salidaHabilitada.Value
        );
    }

    public override void OnNetworkDespawn()
    {
        salidaHabilitada.OnValueChanged -=
            AlCambiarEstadoSalida;

        if (rutinaPrepararSalida != null)
            StopCoroutine(rutinaPrepararSalida);

        if (rutinaCambioEscena != null)
            StopCoroutine(rutinaCambioEscena);
    }

    // =====================================
    // DETECCION DE AMBOS JUGADORES
    // =====================================

    private void Update()
    {
        if (!IsSpawned ||
            !IsServer ||
            cambiandoEscena ||
            !salidaHabilitada.Value)
            return;

        if (!AmbosJugadoresDentro())
            return;

        if (string.IsNullOrWhiteSpace(escenaDestino))
        {
            Debug.LogError(
                "P5: falta configurar la escena destino."
            );
            return;
        }

        cambiandoEscena = true;

        rutinaCambioEscena =
            StartCoroutine(CambiarEscena());
    }

    private bool AmbosJugadoresDentro()
    {
        if (NetworkManager.Singleton == null ||
            zonaDeteccion == null)
            return false;

        var jugadores =
            NetworkManager.Singleton.ConnectedClientsList;

        if (jugadores.Count != 2)
            return false;

        foreach (var cliente in jugadores)
        {
            if (cliente.PlayerObject == null)
                return false;

            if (!JugadorDentro(cliente.PlayerObject))
                return false;
        }

        return true;
    }

    private bool JugadorDentro(NetworkObject jugador)
    {
        Collider2D[] colliders =
            jugador.GetComponentsInChildren<Collider2D>();

        foreach (Collider2D col in colliders)
        {
            if (col == null ||
                !col.enabled ||
                col.isTrigger ||
                !col.gameObject.activeInHierarchy)
                continue;

            if (zonaDeteccion.bounds.Intersects(col.bounds))
                return true;
        }

        return false;
    }

    // =====================================
    // FINALIZACION DEL PUZZLE
    // =====================================

    // IMPORTANTE:
    // Este metodo debe llamarse desde el servidor
    // cuando el puzzle del nivel este completado.

    public void HabilitarSalida()
    {
        if (!IsSpawned ||
            !IsServer ||
            puzzleResuelto.Value)
            return;

        puzzleResuelto.Value = true;

        Debug.Log(
            "PUZZLE COMPLETADO: iniciando cinematica de salida."
        );

        // Cada jugador reproduce su propia puerta
        // y enfoca su propia camara.

        IniciarCinematicaRpc();

        rutinaPrepararSalida =
            StartCoroutine(PrepararSalida());
    }

    private IEnumerator PrepararSalida()
    {
        yield return new WaitForSecondsRealtime(
            Mathf.Max(0f, esperaAntesDeAbrir)
        );

        // Esperar la apertura de la puerta.
        if (tienePuerta)
        {
            yield return new WaitForSecondsRealtime(
                Mathf.Max(0f, duracionApertura)
            );
        }

        if (!IsSpawned || !IsServer)
            yield break;

        salidaHabilitada.Value = true;

        Debug.Log(
            "SALIDA HABILITADA: ambos jugadores pueden avanzar."
        );

        rutinaPrepararSalida = null;
    }

    // =====================================
    // BLOQUEAR SALIDA
    // =====================================

    public void BloquearSalida()
    {
        if (!IsSpawned ||
            !IsServer ||
            cambiandoEscena)
            return;

        if (rutinaPrepararSalida != null)
        {
            StopCoroutine(rutinaPrepararSalida);
            rutinaPrepararSalida = null;
        }

        puzzleResuelto.Value = false;
        salidaHabilitada.Value = false;

        ActualizarVisuales(false);

        Debug.Log("SALIDA BLOQUEADA.");
    }

    // =====================================
    // CINEMATICA PARA AMBAS REALIDADES
    // =====================================

    [Rpc(SendTo.Everyone)]
    private void IniciarCinematicaRpc()
    {
        bool esLia =
            IdentidadJugadorLocal.EsLia();

        Transform puntoCamara =
            esLia
            ? puntoCamaraLia
            : puntoCamaraElian;

        Animator animatorPuerta =
            esLia
            ? animatorPuertaLia
            : animatorPuertaElian;

        // Enfocar camara local.

        if (puntoCamara != null)
        {
            CamaraJugadorLocal[] camaras =
                FindObjectsByType<CamaraJugadorLocal>(
                    FindObjectsSortMode.None
                );

            foreach (CamaraJugadorLocal camara in camaras)
            {
                if (!camara.IsOwner)
                    continue;

                float duracionEnfoque =
                    esperaAntesDeAbrir +
                    (tienePuerta ? duracionApertura : 0f);

                if (usarZoom)
                {
                    camara.EnfocarConZoom(
                        puntoCamara.position,
                        duracionEnfoque
                    );
                }
                else
                {
                    camara.EnfocarTemporalmente(
                        puntoCamara.position,
                        duracionEnfoque
                    );
                }
            }
        }

        // Reproducir la animacion de la puerta
        // correspondiente a la realidad local.

        if (tienePuerta)
        {
            StartCoroutine(
                AbrirPuertaLocal(animatorPuerta)
            );
        }
    }

    private IEnumerator AbrirPuertaLocal(
        Animator animatorPuerta)
    {
        yield return new WaitForSecondsRealtime(
            Mathf.Max(0f, esperaAntesDeAbrir)
        );

        if (animatorPuerta == null)
        {
            Debug.LogWarning(
                "ZonaSalida: falta el Animator de la realidad local."
            );

            yield break;
        }

        if (!animatorPuerta.gameObject.activeInHierarchy)
        {
            Debug.LogWarning(
                "ZonaSalida: la puerta local no esta activa."
            );

            yield break;
        }

        animatorPuerta.enabled = true;

        animatorPuerta.Play(
            estadoApertura,
            0,
            0f
        );

        animatorPuerta.Update(0f);

        Debug.Log(
            "ZonaSalida: puerta local abierta."
        );
    }

    // =====================================
    // VISUALES
    // =====================================

    private void AlCambiarEstadoSalida(
        bool anterior,
        bool nuevo)
    {
        ActualizarVisuales(nuevo);
    }

    private void ActualizarVisuales(bool habilitada)
    {
        if (visualBloqueado != null)
            visualBloqueado.SetActive(!habilitada);

        if (visualHabilitado != null)
            visualHabilitado.SetActive(habilitada);
    }

    // =====================================
    // CAMBIO DE ESCENA
    // =====================================

    private IEnumerator CambiarEscena()
    {
        Debug.Log(
            "Ambos jugadores llegaron a la salida."
        );

        yield return new WaitForSecondsRealtime(
            Mathf.Max(0f, esperaCambioEscena)
        );

        // Comprobar nuevamente que los dos
        // siguen dentro de la zona.

        if (!IsServer || !AmbosJugadoresDentro())
        {
            cambiandoEscena = false;
            rutinaCambioEscena = null;
            yield break;
        }

        if (NetworkManager.Singleton == null ||
            NetworkManager.Singleton.SceneManager == null)
        {
            cambiandoEscena = false;
            rutinaCambioEscena = null;
            yield break;
        }

        var resultado =
            NetworkManager.Singleton.SceneManager.LoadScene(
                escenaDestino,
                LoadSceneMode.Single
            );

        if (resultado != SceneEventProgressStatus.Started)
        {
            Debug.LogError(
                "Error al cambiar escena: " + resultado
            );

            cambiandoEscena = false;
        }

        rutinaCambioEscena = null;
    }
}
