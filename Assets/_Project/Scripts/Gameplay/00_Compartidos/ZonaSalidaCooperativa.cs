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
    [Tooltip("Margen para que termine el acercamiento y regreso del zoom. Con velocidadZoom 3, se requieren aproximadamente 0.67 segundos adicionales.")]
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

    private void Update()
    {
        if (!IsSpawned || !IsServer || cambiandoEscena || !salidaHabilitada.Value)
            return;

        if (!AmbosJugadoresDentro())
            return;

        if (string.IsNullOrWhiteSpace(escenaDestino))
        {
            Debug.LogError("SALIDA: falta configurar la escena destino.");
            return;
        }

        cambiandoEscena = true;
        rutinaCambioEscena = StartCoroutine(CambiarEscena());
    }

    private bool AmbosJugadoresDentro()
    {
        if (NetworkManager.Singleton == null || zonaDeteccion == null || !zonaDeteccion.enabled)
            return false;

        var jugadores = NetworkManager.Singleton.ConnectedClientsList;
        if (jugadores.Count != 2)
            return false;

        foreach (var cliente in jugadores)
        {
            if (cliente.PlayerObject == null || !JugadorDentro(cliente.PlayerObject))
                return false;
        }
        return true;
    }

    private bool JugadorDentro(NetworkObject jugador)
    {
        Collider2D[] colliders = jugador.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            if (col == null || !col.enabled || col.isTrigger || !col.gameObject.activeInHierarchy)
                continue;

            if (zonaDeteccion.bounds.Intersects(col.bounds))
                return true;
        }
        return false;
    }

    // Llamar desde el servidor cuando termine el puzzle.
    public void HabilitarSalida()
    {
        if (!IsSpawned || !IsServer || puzzleResuelto.Value || cambiandoEscena)
            return;

        puzzleResuelto.Value = true;
        Debug.Log("PUZZLE COMPLETADO: iniciando cinematica de salida.");
        IniciarCinematicaRpc();
        rutinaPrepararSalida = StartCoroutine(PrepararSalida());
    }

    private IEnumerator PrepararSalida()
    {
        // Los jugadores ven primero el enfoque, despues la apertura,
        // y al final se deja terminar el regreso del zoom.
        float esperaTotal = Mathf.Max(0f, esperaAntesDeAbrir);
        if (tienePuerta)
            esperaTotal += Mathf.Max(0f, duracionApertura);
        if (usarZoom)
            esperaTotal += Mathf.Max(0f, margenTransicionesZoom);

        yield return new WaitForSecondsRealtime(esperaTotal);

        if (!IsSpawned || !IsServer || !puzzleResuelto.Value)
            yield break;

        salidaHabilitada.Value = true;
        rutinaPrepararSalida = null;
        Debug.Log("SALIDA HABILITADA: cinematica terminada.");
    }

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

    [Rpc(SendTo.Everyone)]
    private void IniciarCinematicaRpc()
    {
        bool esLia = IdentidadJugadorLocal.EsLia();
        Transform puntoCamara = esLia ? puntoCamaraLia : puntoCamaraElian;
        Animator animatorPuerta = esLia ? animatorPuertaLia : animatorPuertaElian;

        if (puntoCamara != null)
        {
            CamaraJugadorLocal[] camaras = FindObjectsByType<CamaraJugadorLocal>(
                FindObjectsSortMode.None);

            foreach (CamaraJugadorLocal camara in camaras)
            {
                if (!camara.IsOwner)
                    continue;

                float duracionEnfoque = Mathf.Max(0f, esperaAntesDeAbrir) +
                    (tienePuerta ? Mathf.Max(0f, duracionApertura) : 0f);

                if (usarZoom)
                    camara.EnfocarConZoom(puntoCamara.position, duracionEnfoque);
                else
                    camara.EnfocarTemporalmente(puntoCamara.position, duracionEnfoque);

                break;
            }
        }

        if (tienePuerta)
        {
            if (rutinaPuertaLocal != null)
                StopCoroutine(rutinaPuertaLocal);
            rutinaPuertaLocal = StartCoroutine(AbrirPuertaLocal(animatorPuerta));
        }
    }

    private IEnumerator AbrirPuertaLocal(Animator animatorPuerta)
    {
        yield return new WaitForSecondsRealtime(Mathf.Max(0f, esperaAntesDeAbrir));

        if (animatorPuerta == null)
        {
            Debug.LogWarning("SALIDA: falta Animator de puerta local.");
            rutinaPuertaLocal = null;
            yield break;
        }

        if (!animatorPuerta.gameObject.activeInHierarchy)
        {
            Debug.LogWarning("SALIDA: la puerta local no esta activa.");
            rutinaPuertaLocal = null;
            yield break;
        }

        animatorPuerta.enabled = true;
        animatorPuerta.ResetTrigger(estadoApertura);
        animatorPuerta.SetTrigger(estadoApertura);
        rutinaPuertaLocal = null;
        Debug.Log("SALIDA: trigger de apertura activado.");
    }

    private void AlCambiarEstadoSalida(bool anterior, bool nuevo)
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

    private IEnumerator CambiarEscena()
    {
        Debug.Log("SALIDA: ambos jugadores llegaron a la salida.");
        yield return new WaitForSecondsRealtime(Mathf.Max(0f, esperaCambioEscena));

        if (!IsSpawned || !IsServer || !AmbosJugadoresDentro())
        {
            cambiandoEscena = false;
            rutinaCambioEscena = null;
            yield break;
        }

        if (NetworkManager.Singleton == null || NetworkManager.Singleton.SceneManager == null)
        {
            cambiandoEscena = false;
            rutinaCambioEscena = null;
            yield break;
        }

        var resultado = NetworkManager.Singleton.SceneManager.LoadScene(
            escenaDestino, LoadSceneMode.Single);

        if (resultado != SceneEventProgressStatus.Started)
        {
            Debug.LogError("SALIDA: no se pudo cargar la escena: " + resultado);
            cambiandoEscena = false;
        }

        rutinaCambioEscena = null;
    }
}
