
using UnityEngine;
using TMPro;
using System.Collections;
using System.Threading.Tasks;
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

    // Evita solicitudes duplicadas mientras se crea o cierra una sala.
    private bool cerrandoConexion = false;
    private bool creandoPartida = false;
    private bool uniendosePartida = false;
    private int versionOperacion = 0;
    private Task<string> tareaCrear;
    private Task<bool> tareaUnirse;

    // Recordar desde qué pantalla se abrieron las opciones
    private GameObject panelAnteriorAOpciones;
    private bool tituloEstabaActivoAntesDeOpciones;

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
        AbrirPanelOpciones(menuPrincipal);
    }

    public void AbrirOpcionesDesdeNuevaPartida()
    {
        AbrirPanelOpciones(panelNuevaPartida);
    }

    private void AbrirPanelOpciones(GameObject panelOrigen)
    {
        if (panelOpciones == null)
        {
            Debug.LogError("Panel_Opciones no está asignado.");
            return;
        }

        panelAnteriorAOpciones = panelOrigen;

        tituloEstabaActivoAntesDeOpciones =
            tituloDosRealidades != null &&
            tituloDosRealidades.activeSelf;

        if (panelOrigen != null)
            panelOrigen.SetActive(false);

        if (tituloDosRealidades != null)
            tituloDosRealidades.SetActive(false);

        // Ocultar también cualquier otro panel principal.
        if (menuPrincipal != null)
            menuPrincipal.SetActive(false);

        if (panelNuevaPartida != null)
            panelNuevaPartida.SetActive(false);

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
        if (cerrandoConexion || creandoPartida || uniendosePartida)
            return;

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

    public async void CerrarVentanaUnirse()
    {
        if (cerrandoConexion)
            return;

        // No ocultar la ventana hasta cerrar efectivamente la sesión.
        bool cerrado = await CerrarConexionMultijugador();
        if (this == null || !cerrado)
            return;

        if (fondoOscuroUnirse != null)
            fondoOscuroUnirse.SetActive(false);

        if (panelNuevaPartida != null)
            panelNuevaPartida.SetActive(true);

        if (campoCodigoPartida != null)
            campoCodigoPartida.text = "";

        if (textoEstadoUnirse != null)
            textoEstadoUnirse.text = "";
    }

    public async void EntrarPartida()
    {
        if (cerrandoConexion || creandoPartida || uniendosePartida)
            return;

        if (campoCodigoPartida == null ||
            gestorMultijugador == null ||
            textoEstadoUnirse == null)
        {
            Debug.LogError("Faltan referencias en la ventana Unirse.");
            return;
        }

        string codigo = campoCodigoPartida.text.Trim().ToUpper();

        if (codigo == "")
        {
            textoEstadoUnirse.text = "Ingresa un código.";
            return;
        }

        uniendosePartida = true;
        int operacion = versionOperacion;
        textoEstadoUnirse.text = "Conectando...";

        try
        {
            tareaUnirse = gestorMultijugador.UnirsePartida(codigo);
            bool conectado = await tareaUnirse;

            // Si el usuario cerró durante la conexión, no mostrar
            // mensajes nuevos ni reactivar paneles.
            if (this == null || operacion != versionOperacion)
                return;

            if (!conectado)
            {
                textoEstadoUnirse.text =
                    "Código incorrecto o partida no disponible.";
                return;
            }

            textoEstadoUnirse.text =
                "Conectado\nEsperando que el Host inicie partida...";
        }
        catch (System.Exception error)
        {
            Debug.LogError("UNIRSE: " + error.Message);
            if (this != null && operacion == versionOperacion &&
                textoEstadoUnirse != null)
                textoEstadoUnirse.text =
                    "Código incorrecto o partida no disponible.";
        }
        finally
        {
            if (this != null)
                uniendosePartida = false;
        }
    }


    // --------------------------------------------------
    // VENTANA CREAR PARTIDA
    // --------------------------------------------------

    public async void AbrirVentanaCrear()
    {
        if (cerrandoConexion || creandoPartida || uniendosePartida)
            return;

        if (gestorMultijugador == null)
        {
            Debug.LogError("No está asignado GestorMultijugador.");
            return;
        }

        creandoPartida = true;
        int operacion = versionOperacion;

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

        try
        {
            tareaCrear = gestorMultijugador.CrearPartida();
            string codigo = await tareaCrear;

            if (this == null || operacion != versionOperacion)
                return;

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

            // Si el segundo jugador se conectó muy rápido, no
            // reemplazar "Jugador conectado" por la animación.
            NetworkManager red = NetworkManager.Singleton;
            if (red != null && red.IsHost &&
                red.ConnectedClientsIds.Count >= 2)
                JugadorConectado();
            else
                animacionEspera = StartCoroutine(AnimarTextoEspera());
        }
        catch (System.Exception error)
        {
            Debug.LogError("CREAR: " + error.Message);
            if (this != null && operacion == versionOperacion &&
                textoEsperandoJugador != null)
                textoEsperandoJugador.text =
                    "No se pudo crear la partida.";
        }
        finally
        {
            if (this != null)
                creandoPartida = false;
        }
    }

    public async void CerrarVentanaCrear()
    {
        if (cerrandoConexion)
            return;

        if (animacionEspera != null)
        {
            StopCoroutine(animacionEspera);
            animacionEspera = null;
        }

        if (botonEmpezarPartida != null)
            botonEmpezarPartida.SetActive(false);

        bool cerrado = await CerrarConexionMultijugador();
        if (this == null || !cerrado)
            return;

        if (fondoOscuroCrear != null)
            fondoOscuroCrear.SetActive(false);

        if (panelNuevaPartida != null)
            panelNuevaPartida.SetActive(true);

        if (textoEsperandoJugador != null)
            textoEsperandoJugador.text = "Esperando jugador";

        if (textoCodigoGenerado != null)
            textoCodigoGenerado.text = "------";
    }


    // --------------------------------------------------
    // CERRAR CONEXION DE RED
    // --------------------------------------------------

    private async Task<bool> CerrarConexionMultijugador()
    {
        if (cerrandoConexion)
            return false;

        cerrandoConexion = true;
        versionOperacion++;

        // La interfaz permanece visible mientras se cierra la sala.
        if (fondoOscuroCrear != null && fondoOscuroCrear.activeSelf &&
            textoEsperandoJugador != null)
            textoEsperandoJugador.text = "Cerrando partida...";

        if (fondoOscuroUnirse != null && fondoOscuroUnirse.activeSelf &&
            textoEstadoUnirse != null)
            textoEstadoUnirse.text = "Desconectando...";

        try
        {
            // Esperamos una creación/unión en curso; de lo contrario
            // la operación tardía podría reabrir la sesión ya cerrada.
            if (tareaCrear != null && !tareaCrear.IsCompleted)
            {
                try { await tareaCrear; }
                catch (System.Exception error)
                { Debug.LogWarning("CIERRE/CREAR: " + error.Message); }
            }

            if (tareaUnirse != null && !tareaUnirse.IsCompleted)
            {
                try { await tareaUnirse; }
                catch (System.Exception error)
                { Debug.LogWarning("CIERRE/UNIRSE: " + error.Message); }
            }

            if (this == null)
                return false;

            GestorMultijugador gestor = gestorMultijugador != null
                ? gestorMultijugador : GestorMultijugador.Instancia;

            if (gestor == null)
            {
                Debug.LogError("MENU: falta GestorMultijugador.");
                MostrarErrorAlCerrar();
                return false;
            }

            bool cerrado = await gestor.CerrarSesionActual();
            if (this == null)
                return false;

            if (!cerrado)
            {
                MostrarErrorAlCerrar();
                return false;
            }

            tareaCrear = null;
            tareaUnirse = null;
            creandoPartida = false;
            uniendosePartida = false;
            Debug.Log("MENU: sesion cerrada correctamente.");
            return true;
        }
        catch (System.Exception error)
        {
            Debug.LogError("MENU: error cerrando sesion: " + error.Message);
            if (this != null)
                MostrarErrorAlCerrar();
            return false;
        }
        finally
        {
            if (this != null)
                cerrandoConexion = false;
        }
    }

    private void MostrarErrorAlCerrar()
    {
        if (fondoOscuroCrear != null && fondoOscuroCrear.activeSelf &&
            textoEsperandoJugador != null)
            textoEsperandoJugador.text = "Error al cerrar la partida.";

        if (fondoOscuroUnirse != null && fondoOscuroUnirse.activeSelf &&
            textoEstadoUnirse != null)
            textoEstadoUnirse.text = "Error al desconectar.";
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
            textoEsperandoJugador.text = "Jugador conectado";

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

        if (cerrandoConexion || NetworkManager.Singleton == null)
            return;

        if (NetworkManager.Singleton.IsHost)
        {
            if (NetworkManager.Singleton.ConnectedClientsIds.Count >= 2)
                JugadorConectado();
        }
        else if (NetworkManager.Singleton.IsClient)
        {
            if (textoEstadoUnirse != null)
                textoEstadoUnirse.text =
                    "Conectado\nEsperando que el Host inicie...";
        }
    }

    private void AlDesconectarJugador(ulong idCliente)
    {
        Debug.Log("Jugador desconectado. ID: " + idCliente);

        if (cerrandoConexion || NetworkManager.Singleton == null)
            return;

        if (NetworkManager.Singleton.IsHost &&
            fondoOscuroCrear != null &&
            fondoOscuroCrear.activeSelf &&
            NetworkManager.Singleton.ConnectedClientsIds.Count < 2)
        {
            if (botonEmpezarPartida != null)
                botonEmpezarPartida.SetActive(false);

            if (animacionEspera != null)
            {
                StopCoroutine(animacionEspera);
                animacionEspera = null;
            }

            if (textoEsperandoJugador != null)
                textoEsperandoJugador.text = "Esperando jugador";

            animacionEspera = StartCoroutine(AnimarTextoEspera());
        }
    }


    // --------------------------------------------------
    // EMPEZAR PARTIDA
    // --------------------------------------------------

    public void EmpezarPartida()
    {
        if (cerrandoConexion || creandoPartida)
            return;

        NetworkManager red = NetworkManager.Singleton;
        if (red == null)
        {
            Debug.LogWarning("No existe un NetworkManager.");
            return;
        }

        if (!red.IsHost)
        {
            Debug.LogWarning("Solo el Host puede iniciar la partida.");
            return;
        }

        if (red.ConnectedClientsIds.Count != 2)
        {
            Debug.LogWarning("Se necesitan 2 jugadores para empezar.");
            return;
        }

        red.SceneManager.LoadScene("P1_Entrada", LoadSceneMode.Single);
    }

    public void CerrarOpciones()
    {
        if (panelOpciones != null)
            panelOpciones.SetActive(false);

        if (panelAnteriorAOpciones != null)
            panelAnteriorAOpciones.SetActive(true);

        if (tituloDosRealidades != null)
            tituloDosRealidades.SetActive(
                tituloEstabaActivoAntesDeOpciones
            );

        panelAnteriorAOpciones = null;
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
