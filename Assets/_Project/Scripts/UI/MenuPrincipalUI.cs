
using UnityEngine;
using TMPro;
using System.Collections;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class MenuPrincipalUI : MonoBehaviour
{
    [Header("Menu principal")]
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject tituloDosRealidades;
    [SerializeField] private GameObject fondoHotel;

    [Header("Ventanas")]
    [SerializeField] private GameObject panelNuevaPartida;
    [SerializeField] private GameObject panelOpciones;

    [Header("Multijugador")]
    [SerializeField] private GestorMultijugador gestorMultijugador;

    [Header("Ventana Unirse")]
    [SerializeField] private GameObject fondoOscuroUnirse;
    [SerializeField] private TMP_InputField campoCodigoPartida;
    [SerializeField] private TMP_Text textoEstadoUnirse;

    [Header("Ventana Crear")]
    [SerializeField] private GameObject fondoOscuroCrear;
    [SerializeField] private TMP_Text textoCodigoGenerado;
    [SerializeField] private TMP_Text textoEsperandoJugador;
    [SerializeField] private GameObject botonEmpezarPartida;

    private Coroutine animacionEspera;
    private bool callbacksRegistrados = false;

    // Recuerda desde donde se abrieron las opciones.
    private bool volverANuevaPartida = false;


    // --------------------------------------------------
    // INICIO
    // --------------------------------------------------

    private void Start()
    {
        // El fondo permanece visible.
        if (fondoHotel != null)
            fondoHotel.SetActive(true);

        // Estado inicial: menu principal.
        if (menuPrincipal != null)
            menuPrincipal.SetActive(true);

        if (tituloDosRealidades != null)
            tituloDosRealidades.SetActive(true);

        if (panelNuevaPartida != null)
            panelNuevaPartida.SetActive(false);

        if (panelOpciones != null)
            panelOpciones.SetActive(false);

        if (fondoOscuroUnirse != null)
            fondoOscuroUnirse.SetActive(false);

        if (fondoOscuroCrear != null)
            fondoOscuroCrear.SetActive(false);

        if (botonEmpezarPartida != null)
            botonEmpezarPartida.SetActive(false);

        RegistrarCallbacks();
    }


    // --------------------------------------------------
    // MOSTRAR U OCULTAR ELEMENTOS PRINCIPALES
    // --------------------------------------------------

    private void OcultarMenuPrincipal()
    {
        if (menuPrincipal != null)
            menuPrincipal.SetActive(false);

        if (tituloDosRealidades != null)
            tituloDosRealidades.SetActive(false);

        // No ocultamos el fondo.
        if (fondoHotel != null)
            fondoHotel.SetActive(true);
    }

    private void MostrarMenuPrincipal()
    {
        if (panelNuevaPartida != null)
            panelNuevaPartida.SetActive(false);

        if (panelOpciones != null)
            panelOpciones.SetActive(false);

        if (fondoOscuroUnirse != null)
            fondoOscuroUnirse.SetActive(false);

        if (fondoOscuroCrear != null)
            fondoOscuroCrear.SetActive(false);

        if (fondoHotel != null)
            fondoHotel.SetActive(true);

        if (tituloDosRealidades != null)
            tituloDosRealidades.SetActive(true);

        if (menuPrincipal != null)
            menuPrincipal.SetActive(true);
    }


    // --------------------------------------------------
    // NUEVA PARTIDA
    // --------------------------------------------------

    public void AbrirNuevaPartida()
    {
        OcultarMenuPrincipal();

        if (panelOpciones != null)
            panelOpciones.SetActive(false);

        if (fondoOscuroUnirse != null)
            fondoOscuroUnirse.SetActive(false);

        if (fondoOscuroCrear != null)
            fondoOscuroCrear.SetActive(false);

        if (panelNuevaPartida != null)
            panelNuevaPartida.SetActive(true);
    }

    public void VolverMenuPrincipal()
    {
        // Este es el botón Volver de Nueva Partida.
        MostrarMenuPrincipal();
    }


    // --------------------------------------------------
    // CONFIGURACION
    // --------------------------------------------------

    public void AbrirOpciones()
    {
        // Guardamos el origen ANTES de ocultar las ventanas.
        volverANuevaPartida =
            panelNuevaPartida != null &&
            panelNuevaPartida.activeSelf;

        // Ocultamos todas las ventanas anteriores.
        if (menuPrincipal != null)
            menuPrincipal.SetActive(false);

        if (tituloDosRealidades != null)
            tituloDosRealidades.SetActive(false);

        if (panelNuevaPartida != null)
            panelNuevaPartida.SetActive(false);

        if (fondoOscuroUnirse != null)
            fondoOscuroUnirse.SetActive(false);

        if (fondoOscuroCrear != null)
            fondoOscuroCrear.SetActive(false);

        // El fondo permanece visible.
        if (fondoHotel != null)
            fondoHotel.SetActive(true);

        // Mostramos únicamente Configuración.
        if (panelOpciones != null)
            panelOpciones.SetActive(true);
    }

    public void ListoOpciones()
    {
        // Cerramos Configuración.
        if (panelOpciones != null)
            panelOpciones.SetActive(false);

        if (fondoHotel != null)
            fondoHotel.SetActive(true);

        if (volverANuevaPartida)
        {
            // Volvemos a Nueva Partida.
            OcultarMenuPrincipal();

            if (panelNuevaPartida != null)
                panelNuevaPartida.SetActive(true);
        }
        else
        {
            // Volvemos al menú principal.
            MostrarMenuPrincipal();
        }
    }


    // --------------------------------------------------
    // VENTANA UNIRSE A PARTIDA
    // --------------------------------------------------

    public void AbrirVentanaUnirse()
    {
        if (panelNuevaPartida != null)
            panelNuevaPartida.SetActive(false);

        if (fondoOscuroCrear != null)
            fondoOscuroCrear.SetActive(false);

        if (fondoOscuroUnirse != null)
            fondoOscuroUnirse.SetActive(true);

        if (campoCodigoPartida != null)
        {
            campoCodigoPartida.text = "";
            campoCodigoPartida.Select();
            campoCodigoPartida.ActivateInputField();
        }

        if (textoEstadoUnirse != null)
            textoEstadoUnirse.text = "";
    }

    public void CerrarVentanaUnirse()
    {
        if (fondoOscuroUnirse != null)
            fondoOscuroUnirse.SetActive(false);

        if (panelNuevaPartida != null)
            panelNuevaPartida.SetActive(true);

        if (campoCodigoPartida != null)
            campoCodigoPartida.text = "";

        if (textoEstadoUnirse != null)
            textoEstadoUnirse.text = "";

        CerrarConexionMultijugador();
    }

    public async void EntrarPartida()
    {
        if (campoCodigoPartida == null ||
            gestorMultijugador == null ||
            textoEstadoUnirse == null)
        {
            Debug.LogError(
                "Faltan referencias en la ventana Unirse."
            );
            return;
        }

        string codigo =
            campoCodigoPartida.text.Trim().ToUpper();

        if (codigo == "")
        {
            textoEstadoUnirse.text = "Ingresa un código.";
            return;
        }

        textoEstadoUnirse.text = "Conectando...";

        bool conectado =
            await gestorMultijugador.UnirsePartida(codigo);

        if (!conectado)
        {
            textoEstadoUnirse.text =
                "Código incorrecto o partida no disponible.";
            return;
        }

        textoEstadoUnirse.text =
            "Conectado ✓\nEsperando que el Host inicie...";
    }


    // --------------------------------------------------
    // VENTANA CREAR PARTIDA
    // --------------------------------------------------

    public async void AbrirVentanaCrear()
    {
        if (panelNuevaPartida != null)
            panelNuevaPartida.SetActive(false);

        if (fondoOscuroUnirse != null)
            fondoOscuroUnirse.SetActive(false);

        if (fondoOscuroCrear != null)
            fondoOscuroCrear.SetActive(true);

        if (botonEmpezarPartida != null)
            botonEmpezarPartida.SetActive(false);

        if (textoEsperandoJugador != null)
            textoEsperandoJugador.text = "Creando partida...";

        if (gestorMultijugador == null)
        {
            Debug.LogError(
                "No está asignado GestorMultijugador."
            );
            return;
        }

        string codigo =
            await gestorMultijugador.CrearPartida();

        if (string.IsNullOrEmpty(codigo))
        {
            if (textoEsperandoJugador != null)
                textoEsperandoJugador.text =
                    "No se pudo crear la partida.";

            return;
        }

        if (textoCodigoGenerado != null)
            textoCodigoGenerado.text = codigo;

        if (textoEsperandoJugador != null)
            textoEsperandoJugador.text = "Esperando jugador";

        if (animacionEspera != null)
            StopCoroutine(animacionEspera);

        animacionEspera =
            StartCoroutine(AnimarTextoEspera());
    }

    public void CerrarVentanaCrear()
    {
        if (fondoOscuroCrear != null)
            fondoOscuroCrear.SetActive(false);

        if (panelNuevaPartida != null)
            panelNuevaPartida.SetActive(true);

        if (animacionEspera != null)
        {
            StopCoroutine(animacionEspera);
            animacionEspera = null;
        }

        if (botonEmpezarPartida != null)
            botonEmpezarPartida.SetActive(false);

        if (textoEsperandoJugador != null)
            textoEsperandoJugador.text = "Esperando jugador";

        if (textoCodigoGenerado != null)
            textoCodigoGenerado.text = "------";

        CerrarConexionMultijugador();
    }


    // --------------------------------------------------
    // CERRAR CONEXION DE RED
    // --------------------------------------------------

    private void CerrarConexionMultijugador()
    {
        if (NetworkManager.Singleton != null &&
            NetworkManager.Singleton.IsListening)
        {
            NetworkManager.Singleton.Shutdown();
        }
    }


    // --------------------------------------------------
    // ANIMACION DE ESPERA
    // --------------------------------------------------

    private IEnumerator AnimarTextoEspera()
    {
        while (true)
        {
            if (textoEsperandoJugador == null)
                yield break;

            textoEsperandoJugador.text = "Esperando jugador.";
            yield return new WaitForSeconds(0.5f);

            textoEsperandoJugador.text = "Esperando jugador..";
            yield return new WaitForSeconds(0.5f);

            textoEsperandoJugador.text = "Esperando jugador...";
            yield return new WaitForSeconds(0.5f);

            textoEsperandoJugador.text = "Esperando jugador";
            yield return new WaitForSeconds(0.5f);
        }
    }


    // --------------------------------------------------
    // JUGADORES CONECTADOS
    // --------------------------------------------------

    private void JugadorConectado()
    {
        if (animacionEspera != null)
        {
            StopCoroutine(animacionEspera);
            animacionEspera = null;
        }

        if (textoEsperandoJugador != null)
            textoEsperandoJugador.text = "Jugador conectado ✓";

        if (botonEmpezarPartida != null)
            botonEmpezarPartida.SetActive(true);
    }

    private void RegistrarCallbacks()
    {
        if (NetworkManager.Singleton == null ||
            callbacksRegistrados)
            return;

        NetworkManager.Singleton.OnClientConnectedCallback +=
            AlConectarJugador;

        NetworkManager.Singleton.OnClientDisconnectCallback +=
            AlDesconectarJugador;

        callbacksRegistrados = true;
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton == null ||
            !callbacksRegistrados)
            return;

        NetworkManager.Singleton.OnClientConnectedCallback -=
            AlConectarJugador;

        NetworkManager.Singleton.OnClientDisconnectCallback -=
            AlDesconectarJugador;

        callbacksRegistrados = false;
    }

    private void AlConectarJugador(ulong idCliente)
    {
        Debug.Log("Jugador conectado. ID: " + idCliente);

        if (NetworkManager.Singleton == null)
            return;

        if (NetworkManager.Singleton.IsHost)
        {
            if (NetworkManager.Singleton.ConnectedClientsIds.Count >= 2)
                JugadorConectado();
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            if (textoEstadoUnirse != null)
            {
                textoEstadoUnirse.text =
                    "Conectado ✓\nEsperando que el Host inicie...";
            }
        }
    }

    private void AlDesconectarJugador(ulong idCliente)
    {
        Debug.Log("Jugador desconectado. ID: " + idCliente);

        if (NetworkManager.Singleton == null)
            return;

        if (NetworkManager.Singleton.IsHost &&
            fondoOscuroCrear != null &&
            fondoOscuroCrear.activeSelf &&
            NetworkManager.Singleton.ConnectedClientsIds.Count < 2)
        {
            if (botonEmpezarPartida != null)
                botonEmpezarPartida.SetActive(false);

            if (animacionEspera != null)
                StopCoroutine(animacionEspera);

            if (textoEsperandoJugador != null)
                textoEsperandoJugador.text = "Esperando jugador";

            animacionEspera =
                StartCoroutine(AnimarTextoEspera());
        }
    }


    // --------------------------------------------------
    // EMPEZAR PARTIDA
    // --------------------------------------------------

    public void EmpezarPartida()
    {
        if (NetworkManager.Singleton == null)
        {
            Debug.LogWarning("No existe un NetworkManager.");
            return;
        }

        if (!NetworkManager.Singleton.IsHost)
        {
            Debug.LogWarning(
                "Solo el Host puede iniciar la partida."
            );
            return;
        }

        NetworkManager.Singleton.SceneManager.LoadScene(
            "P1_Entrada",
            LoadSceneMode.Single
        );
    }


    // --------------------------------------------------
    // SALIR DEL JUEGO
    // --------------------------------------------------

    public void SalirJuego()
    {
        Debug.Log("Salir del juego.");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
