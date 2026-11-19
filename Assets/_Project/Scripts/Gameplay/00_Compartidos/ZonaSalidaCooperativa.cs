
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Collections;

public class ZonaSalidaCooperativa : NetworkBehaviour
{
    [Header("Escena de destino")]
    [SerializeField] private string escenaDestino = "P8_SalaSombras";

    [Header("Zona de deteccion")]
    [SerializeField] private Collider2D zonaDeteccion;

    [Header("Objetos necesarios para salir")]
    [SerializeField] private ObjetoRecolectable fragmentoElian;
    [SerializeField] private ObjetoRecolectable fragmentoLia;
    [SerializeField] private bool requiereObjetosRecolectables = true;

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

    private readonly NetworkVariable<bool> puzzleResuelto =
        new NetworkVariable<bool>(false);

    private readonly NetworkVariable<bool> salidaHabilitada =
        new NetworkVariable<bool>(false);

    private bool cambiandoEscena;

    private Coroutine rutinaPrepararSalida;
    private Coroutine rutinaCambioEscena;
    private Coroutine rutinaPuertaLocal;

    public bool SalidaHabilitada => salidaHabilitada.Value;
    public bool PuzzleResuelto => puzzleResuelto.Value;

    // =====================================
    // PREPARACION
    // =====================================

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
    }

    public override void OnNetworkDespawn()
    {
        salidaHabilitada.OnValueChanged -= AlCambiarEstadoSalida;

        DetenerRutinas();
    }

    private void DetenerRutinas()
    {
        if (rutinaPrepararSalida != null)
            StopCoroutine(rutinaPrepararSalida);

        if (rutinaCambioEscena != null)
            StopCoroutine(rutinaCambioEscena);

        if (rutinaPuertaLocal != null)
            StopCoroutine(rutinaPuertaLocal);

        rutinaPrepararSalida = null;
        rutinaCambioEscena = null;
        rutinaPuertaLocal = null;
    }

    // =====================================
    // CONTROL PRINCIPAL DE SALIDA
    // =====================================

    private void Update()
    {
        if (!IsServer || !IsSpawned)
            return;

        // Activación automática únicamente
        // cuando esta salida requiere objetos.
        if (requiereObjetosRecolectables &&
            !puzzleResuelto.Value)
        {
            if (AmbosObjetosRecolectados())
            {
                Debug.Log(
                    "SALIDA: Ambos objetos recolectados. " +
                    "Iniciando cinematica."
                );

                HabilitarSalida();
            }
        }

        // 2. Esperar a que termine la cinematica.
        if (!salidaHabilitada.Value)
            return;

        // 3. Esperar a que ambos jugadores lleguen.
        if (!AmbosJugadoresDentro())
            return;

        if (string.IsNullOrWhiteSpace(escenaDestino))
        {
            Debug.LogError(
                "SALIDA: Falta configurar la escena destino."
            );
            return;
        }

        // 4. Cambiar de escena.
        cambiandoEscena = true;

        rutinaCambioEscena = StartCoroutine(CambiarEscena());
    }

    private bool AmbosObjetosRecolectados()
    {
        Debug.Log(
            "========== DIAGNOSTICO SALIDA =========="
        );

        Debug.Log(
            "Requiere objetos: " + requiereObjetosRecolectables
        );

        Debug.Log(
            "Fragmento Elian asignado: " + (fragmentoElian != null)
        );

        Debug.Log(
            "Fragmento Lia asignado: " + (fragmentoLia != null)
        );

        if (!requiereObjetosRecolectables)
        {
            Debug.LogError(
                "SALIDA: Se habilita porque NO requiere objetos."
            );

            return true;
        }

        if (fragmentoElian == null || fragmentoLia == null)
        {
            Debug.LogError(
                "SALIDA: Faltan referencias de objetos."
            );

            return false;
        }

        Debug.Log(
            "Elian IsSpawned: " + fragmentoElian.IsSpawned
        );

        Debug.Log(
            "Lia IsSpawned: " + fragmentoLia.IsSpawned
        );

        if (!fragmentoElian.IsSpawned ||
            !fragmentoLia.IsSpawned)
            return false;

        Debug.Log(
            "Elian recolectado: " + fragmentoElian.EstaRecolectado
        );

        Debug.Log(
            "Lia recolectado: " + fragmentoLia.EstaRecolectado
        );

        bool resultado =
            fragmentoElian.EstaRecolectado &&
            fragmentoLia.EstaRecolectado;

        Debug.Log(
            "RESULTADO FINAL: " + resultado
        );

        Debug.Log(
            "========================================"
        );

        return resultado;
    }

    // =====================================
    // DETECTAR A LIA EN LA SALIDA
    // =====================================

    private bool LiaDentroDeZona()
    {
        if (NetworkManager.Singleton == null ||
            zonaDeteccion == null ||
            !zonaDeteccion.enabled)
        {
            return false;
        }

        var jugadores =
            NetworkManager.Singleton.ConnectedClientsList;

        foreach (var cliente in jugadores)
        {
            if (cliente.PlayerObject == null)
                continue;

            NetworkPlayerSetup setup =
                cliente.PlayerObject.GetComponent<NetworkPlayerSetup>();

            if (setup == null ||
                !setup.RolConfigurado ||
                setup.EsElian)
            {
                continue;
            }

            if (JugadorDentro(cliente.PlayerObject))
                return true;
        }

        return false;
    }

    // =====================================
    // DETECTAR A AMBOS JUGADORES
    // =====================================

    private bool AmbosJugadoresDentro()
    {
        if (NetworkManager.Singleton == null ||
            zonaDeteccion == null ||
            !zonaDeteccion.enabled)
        {
            return false;
        }

        var jugadores =
            NetworkManager.Singleton.ConnectedClientsList;

        if (jugadores.Count != 2)
            return false;

        bool elianDentro = false;
        bool liaDentro = false;

        foreach (var cliente in jugadores)
        {
            if (cliente.PlayerObject == null)
                return false;

            NetworkPlayerSetup setup =
                cliente.PlayerObject.GetComponent<NetworkPlayerSetup>();

            if (setup == null || !setup.RolConfigurado)
                return false;

            if (!JugadorDentro(cliente.PlayerObject))
                return false;

            if (setup.EsElian)
                elianDentro = true;
            else
                liaDentro = true;
        }

        return elianDentro && liaDentro;
    }

    // =====================================
    // COMPROBAR POSICION DEL JUGADOR
    // =====================================

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
            {
                continue;
            }

            if (zonaDeteccion.bounds.Intersects(col.bounds))
                return true;
        }

        return false;
    }

    // =====================================
    // HABILITAR SALIDA
    // =====================================

    public void HabilitarSalida()
    {
        Debug.LogError(
            "HABILITAR SALIDA FUE LLAMADO. " +
            "PUZZLE RESUELTO = " + puzzleResuelto.Value +
            " | STACK = " + System.Environment.StackTrace
        );
        if (!IsSpawned || !IsServer || puzzleResuelto.Value || cambiandoEscena)
        {
            return;
        }

        puzzleResuelto.Value = true;

        Debug.Log(
            "PUZZLE COMPLETADO: iniciando cinematica de salida."
        );

        IniciarCinematicaRpc();

        rutinaPrepararSalida =
            StartCoroutine(PrepararSalida());
    }

    // =====================================
    // HABILITAR SALIDA SIN CINEMATICA
    // =====================================

    public void HabilitarSalidaSinCinematica()
    {
        if (!IsSpawned ||
            !IsServer ||
            puzzleResuelto.Value ||
            cambiandoEscena)
        {
            return;
        }

        puzzleResuelto.Value = true;
        salidaHabilitada.Value = true;

        ActualizarVisuales(true);

        Debug.Log(
            "P2: SALIDA HABILITADA POR LLEGADA DE LIA."
        );
    }

    // =====================================
    // PREPARAR SALIDA
    // =====================================

    private IEnumerator PrepararSalida()
    {
        float esperaTotal =
            Mathf.Max(0f, esperaAntesDeAbrir);

        if (tienePuerta)
            esperaTotal += Mathf.Max(0f, duracionApertura);

        if (usarZoom)
            esperaTotal += Mathf.Max(0f, margenTransicionesZoom);

        yield return new WaitForSecondsRealtime(esperaTotal);

        if (!IsSpawned ||
            !IsServer ||
            !puzzleResuelto.Value)
        {
            yield break;
        }

        salidaHabilitada.Value = true;

        rutinaPrepararSalida = null;

        Debug.Log("SALIDA HABILITADA: cinematica terminada.");
    }

    // =====================================
    // BLOQUEAR SALIDA
    // =====================================

    public void BloquearSalida()
    {
        if (!IsSpawned || !IsServer || cambiandoEscena)
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
    // INICIAR CINEMATICA
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
            Debug.LogWarning("No se encontró la puerta local.");
            yield break;
        }

        animatorPuerta.enabled = true;

        animatorPuerta.ResetTrigger(estadoApertura);
        animatorPuerta.SetTrigger(estadoApertura);

        Debug.Log("PUERTA: Animación de apertura activada.");

        rutinaPuertaLocal = null;
    }

    // =====================================
    // ACTUALIZAR VISUALES
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
    // CAMBIAR ESCENA
    // =====================================

    private IEnumerator CambiarEscena()
    {
        Debug.Log(
            "P2: Ambos jugadores llegaron a la salida."
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
                "SALIDA: no se pudo cargar la escena: " +
                resultado
            );

            cambiandoEscena = false;
        }

        rutinaCambioEscena = null;
    }
}
