
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class RegresoPasilloP5 : NetworkBehaviour
{
    [Header("Fragmentos necesarios")]
    [SerializeField] private ObjetoRecolectable fragmentoElian;
    [SerializeField] private ObjetoRecolectable fragmentoLia;

    [Header("Zona de salida")]
    [SerializeField] private Collider2D zonaSalida;

    [Header("Configuracion de salida")]
    [SerializeField] private string escenaDestino = "P5_Pasillo";
    [SerializeField] private string misionSalida =
        "Ya puedes salir de la habitación";

    [Header("Transicion")]
    [SerializeField] private bool salidaAutomatica = true;

    private NetworkVariable<bool> salidaHabilitada =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private bool regresoEnCurso;
    private bool misionAplicada;

    public bool SalidaHabilitada => salidaHabilitada.Value;

    private void Awake()
    {
        if (zonaSalida == null)
            zonaSalida = GetComponent<Collider2D>();
    }

    public override void OnNetworkSpawn()
    {
        salidaHabilitada.OnValueChanged +=
            AlCambiarSalidaHabilitada;

        regresoEnCurso = false;
        misionAplicada = false;

        if (IsServer)
            salidaHabilitada.Value = false;
    }

    public override void OnNetworkDespawn()
    {
        salidaHabilitada.OnValueChanged -=
            AlCambiarSalidaHabilitada;
    }

    private void Update()
    {
        if (!IsSpawned)
            return;

        // El servidor comprueba los dos fragmentos.
        if (IsServer &&
            !salidaHabilitada.Value &&
            AmbosFragmentosRecolectados())
        {
            salidaHabilitada.Value = true;

            Debug.Log(
                "HABITACION 204: Ambos fragmentos recolectados."
            );
        }

        // Actualizar la misión en cada jugador.
        if (salidaHabilitada.Value)
            AplicarMisionLocal();

        // Salida automática cuando ambos están dentro.
        if (IsServer &&
            salidaAutomatica &&
            salidaHabilitada.Value &&
            !regresoEnCurso)
        {
            if (AmbosJugadoresDentro())
                CargarPasillo();
        }
    }

    // =====================================
    // COMPROBAR RECOLECCION
    // =====================================

    private bool AmbosFragmentosRecolectados()
    {
        if (fragmentoElian == null ||
            fragmentoLia == null)
            return false;

        if (!fragmentoElian.IsSpawned ||
            !fragmentoLia.IsSpawned)
            return false;

        return fragmentoElian.EstaRecolectado &&
               fragmentoLia.EstaRecolectado;
    }

    // =====================================
    // ACTUALIZAR MISION
    // =====================================

    private void AlCambiarSalidaHabilitada(
        bool anterior,
        bool nuevo)
    {
        if (nuevo)
            AplicarMisionLocal();
    }

    private void AplicarMisionLocal()
    {
        if (misionAplicada)
            return;

        if (HUDMision.Instancia == null)
            return;

        HUDMision.Instancia.CambiarMision(
            misionSalida
        );

        misionAplicada = true;

        Debug.Log("P5: Misión de salida activada.");
    }

    // =====================================
    // DETECTAR A LOS DOS JUGADORES
    // =====================================

    private bool AmbosJugadoresDentro()
    {
        if (NetworkManager.Singleton == null ||
            zonaSalida == null ||
            !zonaSalida.enabled)
            return false;

        var jugadores =
            NetworkManager.Singleton.ConnectedClientsList;

        if (jugadores.Count != 2)
            return false;

        foreach (var cliente in jugadores)
        {
            if (cliente.PlayerObject == null ||
                !cliente.PlayerObject.IsSpawned)
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

            if (zonaSalida.bounds.Intersects(col.bounds))
                return true;
        }

        return false;
    }

    // =====================================
    // SOLICITUD MANUAL DE REGRESO
    // =====================================

    public void SolicitarRegreso()
    {
        if (!IsSpawned || !IsClient)
            return;

        SolicitarRegresoRpc();
    }

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void SolicitarRegresoRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer ||
            !salidaHabilitada.Value ||
            regresoEnCurso)
            return;

        if (!AmbosJugadoresDentro())
        {
            Debug.Log(
                "P5: Esperando que ambos jugadores lleguen a la salida."
            );
            return;
        }

        CargarPasillo();
    }

    // =====================================
    // CAMBIAR ESCENA
    // =====================================

    private void CargarPasillo()
    {
        if (!IsServer || regresoEnCurso)
            return;

        if (NetworkManager.Singleton == null ||
            NetworkManager.Singleton.SceneManager == null)
            return;

        regresoEnCurso = true;

        Debug.Log(
            "P5: Ambos jugadores llegaron. Regresando al pasillo."
        );

        var resultado =
            NetworkManager.Singleton.SceneManager.LoadScene(
                escenaDestino,
                LoadSceneMode.Single
            );

        if (resultado != SceneEventProgressStatus.Started)
        {
            Debug.LogError(
                "P5: Error al regresar al pasillo: " +
                resultado
            );

            regresoEnCurso = false;
        }
    }
}
