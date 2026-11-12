
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Multiplayer;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Threading.Tasks;

public class GestorMultijugador : MonoBehaviour
{
    public static GestorMultijugador Instancia { get; private set; }

    [Header("Configuracion de reconexion")]
    [SerializeField] private float tiempoMaximoReconectar = 30f;
    [SerializeField] private float intervaloReintento = 2f;

    [Header("Escena principal")]
    [SerializeField] private string escenaMenuPrincipal = "01_MainMenu";

    public bool ServiciosListos { get; private set; }
    public ISession SesionActual => sesionActual;

    private ISession sesionActual;

    private HUDReconexionController hudReconexion;

    private Coroutine rutinaReconectarCliente;
    private Coroutine rutinaEsperaHost;

    private bool esInstanciaPrincipal;
    private bool callbacksRegistrados;

    private bool reconexionLocalActiva;
    private bool esperandoCliente;
    private bool salidaVoluntaria;

    // =====================================
    // INICIO Y PERSISTENCIA
    // =====================================

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        Instancia = this;
        esInstanciaPrincipal = true;

        DontDestroyOnLoad(gameObject);

        Debug.Log("GestorMultijugador persistente.");
    }

    private async void Start()
    {
        if (!esInstanciaPrincipal)
            return;

        if (NetworkManager.Singleton != null)
        {
            DontDestroyOnLoad(
                NetworkManager.Singleton.gameObject
            );
        }

        SceneManager.sceneLoaded += AlCargarEscena;

        RegistrarCallbacksRed();
        VincularHUD();

        await InicializarServicios();
    }

    private void OnDestroy()
    {
        if (Instancia != this)
            return;

        SceneManager.sceneLoaded -= AlCargarEscena;

        if (NetworkManager.Singleton != null &&
            callbacksRegistrados)
        {
            NetworkManager.Singleton.OnClientConnectedCallback -=
                AlConectarJugador;

            NetworkManager.Singleton.OnClientDisconnectCallback -=
                AlDesconectarJugador;
        }

        DesvincularHUD();

        Instancia = null;
    }

    // =====================================
    // UNITY SERVICES
    // =====================================

    private async Task InicializarServicios()
    {
        try
        {
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance
                    .SignInAnonymouslyAsync();
            }

            ServiciosListos = true;

            Debug.Log(
                "Unity Services listo. Jugador: " +
                AuthenticationService.Instance.PlayerId
            );
        }
        catch (Exception error)
        {
            ServiciosListos = false;

            Debug.LogError(
                "Error inicializando Unity Services: " +
                error.Message
            );
        }
    }

    // =====================================
    // CREAR PARTIDA
    // =====================================

    public async Task<string> CrearPartida()
    {
        if (!ServiciosListos)
        {
            Debug.LogWarning(
                "Unity Services todavía no está listo."
            );

            return null;
        }

        try
        {
            SessionOptions opciones = new SessionOptions
            {
                MaxPlayers = 2
            }
            .WithRelayNetwork();

            sesionActual =
                await MultiplayerService.Instance
                    .CreateSessionAsync(opciones);

            Debug.Log("Partida creada.");
            Debug.Log("Código: " + sesionActual.Code);
            Debug.Log("ID: " + sesionActual.Id);

            return sesionActual.Code;
        }
        catch (Exception error)
        {
            Debug.LogError(
                "No se pudo crear la partida: " +
                error.Message
            );

            return null;
        }
    }

    // =====================================
    // UNIRSE A PARTIDA
    // =====================================

    public async Task<bool> UnirsePartida(string codigo)
    {
        if (!ServiciosListos)
        {
            Debug.LogWarning(
                "Unity Services todavía no está listo."
            );

            return false;
        }

        try
        {
            sesionActual =
                await MultiplayerService.Instance
                    .JoinSessionByCodeAsync(codigo);

            Debug.Log(
                "Conectado a la partida: " +
                sesionActual.Id
            );

            return true;
        }
        catch (Exception error)
        {
            Debug.LogError(
                "No se pudo unir a la partida: " +
                error.Message
            );

            return false;
        }
    }

    // =====================================
    // REGISTRAR EVENTOS DE RED
    // =====================================

    private void RegistrarCallbacksRed()
    {
        if (NetworkManager.Singleton == null ||
            callbacksRegistrados)
            return;

        NetworkManager.Singleton.OnClientConnectedCallback +=
            AlConectarJugador;

        NetworkManager.Singleton.OnClientDisconnectCallback +=
            AlDesconectarJugador;

        callbacksRegistrados = true;

        Debug.Log("Gestor: callbacks de red registrados.");
    }

    // =====================================
    // DETECTAR CAMBIOS DE ESCENA
    // =====================================

    private void AlCargarEscena(
        Scene escena,
        LoadSceneMode modo)
    {
        StartCoroutine(VincularHUDDespuesDeCarga());
    }

    private IEnumerator VincularHUDDespuesDeCarga()
    {
        yield return null;

        VincularHUD();
    }

    // =====================================
    // CONECTAR CON EL HUD
    // =====================================

    private void VincularHUD()
    {
        HUDReconexionController nuevoHUD =
            FindAnyObjectByType<HUDReconexionController>();

        if (nuevoHUD == hudReconexion)
            return;

        DesvincularHUD();

        hudReconexion = nuevoHUD;

        if (hudReconexion == null)
        {
            Debug.LogWarning(
                "No se encontró HUDReconexionController."
            );

            return;
        }

        hudReconexion.ContinuarSolicitado +=
            AlSolicitarContinuar;

        hudReconexion.MenuPrincipalSolicitado +=
            AlSolicitarMenuPrincipal;

        Debug.Log("Gestor: HUD de reconexión vinculado.");
    }

    private void DesvincularHUD()
    {
        if (hudReconexion == null)
            return;

        hudReconexion.ContinuarSolicitado -=
            AlSolicitarContinuar;

        hudReconexion.MenuPrincipalSolicitado -=
            AlSolicitarMenuPrincipal;

        hudReconexion = null;
    }

    // =====================================
    // DETECTAR DESCONEXIONES
    // =====================================

    private void AlDesconectarJugador(ulong idCliente)
    {
        if (salidaVoluntaria || !EsEscenaDeJuego())
            return;

        NetworkManager red = NetworkManager.Singleton;

        if (red == null)
            return;

        Debug.Log(
            "GESTOR: jugador desconectado. ID: " +
            idCliente
        );

        // CASO 1: HOST PIERDE AL CLIENTE.

        if (red.IsHost)
        {
            if (idCliente == red.LocalClientId)
            {
                MostrarErrorDefinitivo(
                    "El Host perdió su conexión."
                );

                return;
            }

            EsperarReconexionCliente();

            return;
        }

        // CASO 2: CLIENTE PIERDE SU CONEXION.

        if (idCliente == red.LocalClientId)
        {
            IniciarReconexionCliente();
        }
    }

    // =====================================
    // HOST: ESPERAR AL CLIENTE
    // =====================================

    private void EsperarReconexionCliente()
    {
        if (esperandoCliente)
            return;

        esperandoCliente = true;

        BloquearMovimientoLocal(true);

        if (hudReconexion != null)
            hudReconexion.MostrarReconectando();

        Debug.Log(
            "HOST: esperando reconexión del segundo jugador."
        );

        rutinaEsperaHost =
            StartCoroutine(TemporizadorEsperaHost());
    }

    private IEnumerator TemporizadorEsperaHost()
    {
        yield return new WaitForSecondsRealtime(
            tiempoMaximoReconectar
        );

        if (!esperandoCliente)
            yield break;

        esperandoCliente = false;
        rutinaEsperaHost = null;

        MostrarErrorDefinitivo(
            "El otro jugador no pudo reconectarse."
        );
    }

    // =====================================
    // CLIENTE: INICIAR RECONEXION
    // =====================================

    private void IniciarReconexionCliente()
    {
        if (reconexionLocalActiva)
            return;

        reconexionLocalActiva = true;

        BloquearMovimientoLocal(true);

        if (hudReconexion != null)
            hudReconexion.MostrarReconectando();

        if (sesionActual == null)
        {
            MostrarErrorDefinitivo(
                "No se encontró la sesión anterior."
            );

            return;
        }

        rutinaReconectarCliente =
            StartCoroutine(ReintentarConexionCliente());

        Debug.Log("CLIENTE: iniciando reconexión.");
    }

    // =====================================
    // CLIENTE: INTENTOS AUTOMATICOS
    // =====================================

    private IEnumerator ReintentarConexionCliente()
    {
        float limite =
            Time.realtimeSinceStartup +
            tiempoMaximoReconectar;

        while (Time.realtimeSinceStartup < limite &&
               reconexionLocalActiva)
        {
            Debug.Log(
                "CLIENTE: intentando recuperar sesión..."
            );

            Task<ISession> solicitud =
                MultiplayerService.Instance
                    .ReconnectToSessionAsync(sesionActual.Id);

            // Esperar respuesta del servicio.

            while (!solicitud.IsCompleted &&
                   Time.realtimeSinceStartup < limite)
            {
                yield return null;
            }

            if (!solicitud.IsCompleted)
                break;

            if (solicitud.IsFaulted)
            {
                Debug.LogWarning(
                    "Fallo de reconexión: " +
                    solicitud.Exception?.GetBaseException().Message
                );
            }
            else if (solicitud.IsCanceled)
            {
                Debug.LogWarning(
                    "Solicitud de reconexión cancelada."
                );
            }
            else if (solicitud.Result != null)
            {
                sesionActual = solicitud.Result;

                Debug.Log(
                    "Sesión recuperada. Esperando conexión Netcode."
                );

                // La sesión recuperada no significa todavía
                // que el jugador ya esté conectado a Netcode.

                while (Time.realtimeSinceStartup < limite &&
                       reconexionLocalActiva)
                {
                    NetworkManager red = NetworkManager.Singleton;

                    if (red != null && red.IsConnectedClient)
                    {
                        CompletarReconexion();

                        yield break;
                    }

                    yield return null;
                }

                break;
            }

            yield return new WaitForSecondsRealtime(
                intervaloReintento
            );
        }

        if (reconexionLocalActiva)
        {
            reconexionLocalActiva = false;
            rutinaReconectarCliente = null;

            MostrarErrorDefinitivo(
                "No fue posible recuperar la conexión."
            );
        }
    }

    // =====================================
    // DETECTAR RECONEXION EXITOSA
    // =====================================

    private void AlConectarJugador(ulong idCliente)
    {
        Debug.Log(
            "GESTOR: jugador conectado. ID: " +
            idCliente
        );

        NetworkManager red = NetworkManager.Singleton;

        if (red == null)
            return;

        // Cliente local recuperó la conexión.

        if (!red.IsHost &&
            reconexionLocalActiva &&
            idCliente == red.LocalClientId)
        {
            CompletarReconexion();
            return;
        }

        // Host detectó que regresó el cliente.

        if (red.IsHost &&
            esperandoCliente &&
            idCliente != red.LocalClientId)
        {
            CompletarReconexion();
        }
    }

    private void CompletarReconexion()
    {
        Debug.Log(
            "GESTOR: conexión recuperada correctamente."
        );

        reconexionLocalActiva = false;
        esperandoCliente = false;

        if (rutinaReconectarCliente != null)
        {
            StopCoroutine(rutinaReconectarCliente);
            rutinaReconectarCliente = null;
        }

        if (rutinaEsperaHost != null)
        {
            StopCoroutine(rutinaEsperaHost);
            rutinaEsperaHost = null;
        }

        // Mantener bloqueado el movimiento hasta que
        // el jugador pulse Continuar.

        BloquearMovimientoLocal(true);

        if (hudReconexion != null)
            hudReconexion.MostrarReconectado();
    }

    // =====================================
    // BLOQUEAR MOVIMIENTO LOCAL
    // =====================================

    private void BloquearMovimientoLocal(bool bloquear)
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red == null ||
            red.LocalClient == null ||
            red.LocalClient.PlayerObject == null)
            return;

        NetworkPlayerMovement movimiento =
            red.LocalClient.PlayerObject
                .GetComponent<NetworkPlayerMovement>();

        if (movimiento != null)
        {
            movimiento.BloquearMovimiento(bloquear);
        }
    }

    // =====================================
    // CONTINUAR PARTIDA
    // =====================================

    private void AlSolicitarContinuar()
    {
        Debug.Log(
            "GESTOR: jugador solicitó continuar."
        );

        BloquearMovimientoLocal(false);
    }

    // =====================================
    // ERROR DE CONEXION
    // =====================================

    private void MostrarErrorDefinitivo(string motivo)
    {
        Debug.LogWarning(
            "GESTOR: " + motivo
        );

        reconexionLocalActiva = false;
        esperandoCliente = false;

        if (rutinaReconectarCliente != null)
        {
            StopCoroutine(rutinaReconectarCliente);
            rutinaReconectarCliente = null;
        }

        if (rutinaEsperaHost != null)
        {
            StopCoroutine(rutinaEsperaHost);
            rutinaEsperaHost = null;
        }

        if (hudReconexion != null)
            hudReconexion.MostrarErrorConexion();
    }

    // =====================================
    // REGRESAR AL MENU PRINCIPAL
    // =====================================

    private void AlSolicitarMenuPrincipal()
    {
        VolverAlMenuPrincipal();
    }

    public async void VolverAlMenuPrincipal()
    {
        salidaVoluntaria = true;

        BloquearMovimientoLocal(false);

        if (rutinaReconectarCliente != null)
            StopCoroutine(rutinaReconectarCliente);

        if (rutinaEsperaHost != null)
            StopCoroutine(rutinaEsperaHost);

        try
        {
            if (sesionActual != null)
            {
                await sesionActual.LeaveAsync();

                sesionActual = null;
            }
            else if (NetworkManager.Singleton != null &&
                     NetworkManager.Singleton.IsListening)
            {
                NetworkManager.Singleton.Shutdown();
            }
        }
        catch (Exception error)
        {
            Debug.LogWarning(
                "Error cerrando sesión: " +
                error.Message
            );

            if (NetworkManager.Singleton != null &&
                NetworkManager.Singleton.IsListening)
            {
                NetworkManager.Singleton.Shutdown();
            }
        }

        SceneManager.LoadScene(escenaMenuPrincipal);

        salidaVoluntaria = false;
    }

    // =====================================
    // IDENTIFICAR ESCENA DE JUEGO
    // =====================================

    private bool EsEscenaDeJuego()
    {
        return SceneManager.GetActiveScene().name !=
               escenaMenuPrincipal;
    }
}
