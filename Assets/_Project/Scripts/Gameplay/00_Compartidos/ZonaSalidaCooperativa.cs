
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Collections;

public class ZonaSalidaCooperativa : NetworkBehaviour
{
    [Header("Escena de destino")]
    [SerializeField] private string escenaDestino = "P2_Recepcion";

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
    [SerializeField] private float duracionApertura = 0.67f;
    [SerializeField] private float margenTransicionesZoom = 0.75f;
    [SerializeField] private float esperaCambioEscena = 2f;
    
    [Header("Salida inmediata Runner Vigilia")]
    [SerializeField] private bool activarSalidaAlIniciar = false;
    [SerializeField] private bool bastaUnJugador = false;

    private readonly NetworkVariable<bool> puzzleResuelto =
        new NetworkVariable<bool>(false);

    private readonly NetworkVariable<bool> salidaHabilitada =
        new NetworkVariable<bool>(false);

    private bool cambiandoEscena;

    private Coroutine rutinaCambioEscena;
    private Coroutine rutinaPuertaLocal;

    public bool SalidaHabilitada => salidaHabilitada.Value;
    public bool PuzzleResuelto => puzzleResuelto.Value;

    private void Awake()
    {
        if (zonaDeteccion == null)
        {
            Transform zona = transform.Find("ZonaDeteccion");

            if (zona != null)
                zonaDeteccion = zona.GetComponent<Collider2D>();
        }
    }

    public override void OnNetworkSpawn()
    {
        cambiandoEscena = false;

        salidaHabilitada.OnValueChanged += AlCambiarEstadoSalida;

        ActualizarVisuales(salidaHabilitada.Value);

        if (IsServer && activarSalidaAlIniciar)
        {
            puzzleResuelto.Value = true;
            salidaHabilitada.Value = true;
            ActualizarVisuales(true);
        }
    }

    public override void OnNetworkDespawn()
    {
        salidaHabilitada.OnValueChanged -= AlCambiarEstadoSalida;

        if (rutinaCambioEscena != null)
            StopCoroutine(rutinaCambioEscena);

        if (rutinaPuertaLocal != null)
            StopCoroutine(rutinaPuertaLocal);
    }

    // =====================================
    // DETECTAR AMBOS JUGADORES
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
                "SALIDA: falta configurar la escena destino."
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
            zonaDeteccion == null ||
            !zonaDeteccion.enabled)
            return false;

        var jugadores =
            NetworkManager.Singleton.ConnectedClientsList;

        if (bastaUnJugador)
        {
            foreach (var cliente in jugadores)
            {
                if (cliente.PlayerObject != null &&
                    JugadorDentro(cliente.PlayerObject))
                    return true;
            }

            return false;
        }

        if (jugadores.Count != 2)
            return false;

        foreach (var cliente in jugadores)
        {
            if (cliente.PlayerObject == null ||
                !JugadorDentro(cliente.PlayerObject))
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
    // INICIAR CINEMATICA
    // =====================================

    public void HabilitarSalida()
    {
        if (!IsSpawned ||
            !IsServer ||
            puzzleResuelto.Value ||
            cambiandoEscena)
            return;

        // Registrar que el puzzle fue completado.
        puzzleResuelto.Value = true;

        // IMPORTANTE:
        // Esto NO habilita todavía la zona de salida.
        salidaHabilitada.Value = false;

        ActualizarVisuales(false);

        Debug.Log(
            "P1: Puzzle completado. Iniciando cinematica. " +
            "Salida todavía bloqueada."
        );

        IniciarCinematicaRpc();
    }

    // =====================================
    // HABILITAR SALIDA DESPUES DE LAS TARJETAS
    // =====================================

    public void HabilitarSalidaDespuesDeTarjetas()
    {
        if (!IsSpawned ||
            !IsServer ||
            !puzzleResuelto.Value ||
            cambiandoEscena ||
            salidaHabilitada.Value)
            return;

        salidaHabilitada.Value = true;

        ActualizarVisuales(true);

        Debug.Log(
            "P1: AMBAS TARJETAS CERRADAS. " +
            "ZONA DE SALIDA HABILITADA."
        );
    }

    // =====================================
    // COMPATIBILIDAD CON P2 Y OTROS NIVELES
    // =====================================

    public void HabilitarSalidaSinCinematica()
    {
        if (!IsSpawned ||
            !IsServer ||
            cambiandoEscena)
            return;

        puzzleResuelto.Value = true;
        salidaHabilitada.Value = true;

        ActualizarVisuales(true);

        Debug.Log(
            "SALIDA HABILITADA SIN REPETIR CINEMATICA."
        );
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

        puzzleResuelto.Value = false;
        salidaHabilitada.Value = false;

        ActualizarVisuales(false);

        Debug.Log("SALIDA BLOQUEADA.");
    }

    // =====================================
    // CINEMATICA LOCAL DE CADA JUGADOR
    // =====================================

    [Rpc(SendTo.Everyone)]
    private void IniciarCinematicaRpc()
    {
        bool esLia = IdentidadJugadorLocal.EsLia();

        Transform puntoCamara =
            esLia ? puntoCamaraLia : puntoCamaraElian;

        Animator animatorPuerta =
            esLia ? animatorPuertaLia : animatorPuertaElian;

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
                    Mathf.Max(0f, esperaAntesDeAbrir) +
                    (tienePuerta
                        ? Mathf.Max(0f, duracionApertura)
                        : 0f);

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

                break;
            }
        }

        if (tienePuerta)
        {
            if (rutinaPuertaLocal != null)
                StopCoroutine(rutinaPuertaLocal);

            rutinaPuertaLocal =
                StartCoroutine(AbrirPuertaLocal(animatorPuerta));
        }
    }

    private IEnumerator AbrirPuertaLocal(
        Animator animatorPuerta)
    {
        yield return new WaitForSecondsRealtime(
            Mathf.Max(0f, esperaAntesDeAbrir)
        );

        if (animatorPuerta == null ||
            !animatorPuerta.gameObject.activeInHierarchy)
        {
            Debug.LogError(
                "P1: No se encontró el Animator de la puerta local."
            );

            yield break;
        }

        animatorPuerta.enabled = true;

        animatorPuerta.ResetTrigger(estadoApertura);
        animatorPuerta.SetTrigger(estadoApertura);

        Debug.Log(
            "P1: Animación de apertura activada."
        );

        rutinaPuertaLocal = null;
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
            "SALIDA: ambos jugadores llegaron a la zona."
        );

        yield return new WaitForSecondsRealtime(
            Mathf.Max(0f, esperaCambioEscena)
        );

        if (!IsSpawned ||
            !IsServer ||
            !AmbosJugadoresDentro())
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
                "SALIDA: no se pudo cargar escena: " + resultado
            );

            cambiandoEscena = false;
        }

        rutinaCambioEscena = null;
    }
}
