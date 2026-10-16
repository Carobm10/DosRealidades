using UnityEngine;
using TMPro;
using System.Collections;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class MenuPrincipalUI : MonoBehaviour
{
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


    // --------------------------------------------------
    // INICIO
    // --------------------------------------------------

    private void Start()
    {
        // Aseguramos que las ventanas empiecen cerradas.
        fondoOscuroUnirse.SetActive(false);
        fondoOscuroCrear.SetActive(false);

        // El botón Empezar no aparece hasta que llegue el segundo jugador.
        botonEmpezarPartida.SetActive(false);

        RegistrarCallbacks();
    }


    // --------------------------------------------------
    // CALLBACKS DE RED
    // --------------------------------------------------

    private void RegistrarCallbacks()
    {
        if (NetworkManager.Singleton == null || callbacksRegistrados)
            return;

        NetworkManager.Singleton.OnClientConnectedCallback += AlConectarJugador;
        NetworkManager.Singleton.OnClientDisconnectCallback += AlDesconectarJugador;

        callbacksRegistrados = true;
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton == null || !callbacksRegistrados)
            return;

        NetworkManager.Singleton.OnClientConnectedCallback -= AlConectarJugador;
        NetworkManager.Singleton.OnClientDisconnectCallback -= AlDesconectarJugador;

        callbacksRegistrados = false;
    }


    // --------------------------------------------------
    // VENTANA UNIRSE A PARTIDA
    // --------------------------------------------------

    public void AbrirVentanaUnirse()
    {
        fondoOscuroCrear.SetActive(false);
        fondoOscuroUnirse.SetActive(true);

        campoCodigoPartida.text = "";
        textoEstadoUnirse.text = "";

        campoCodigoPartida.Select();
        campoCodigoPartida.ActivateInputField();
    }

    public void CerrarVentanaUnirse()
    {
        fondoOscuroUnirse.SetActive(false);

        campoCodigoPartida.text = "";
        textoEstadoUnirse.text = "";

        if (NetworkManager.Singleton != null &&
            NetworkManager.Singleton.IsListening)
        {
            NetworkManager.Singleton.Shutdown();
        }
    }

    public async void EntrarPartida()
    {
        string codigo =
            campoCodigoPartida.text.Trim().ToUpper();

        if (codigo == "")
        {
            textoEstadoUnirse.text =
                "Ingresa un código.";

            return;
        }

        textoEstadoUnirse.text =
            "Conectando...";

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
        fondoOscuroUnirse.SetActive(false);
        fondoOscuroCrear.SetActive(true);

        botonEmpezarPartida.SetActive(false);
        textoEsperandoJugador.text = "Creando partida...";

        string codigo =
            await gestorMultijugador.CrearPartida();

        if (string.IsNullOrEmpty(codigo))
        {
            textoEsperandoJugador.text =
                "No se pudo crear la partida.";

            return;
        }

        textoCodigoGenerado.text = codigo;

        textoEsperandoJugador.text =
            "Esperando jugador";

        if (animacionEspera != null)
        {
            StopCoroutine(animacionEspera);
        }

        animacionEspera =
            StartCoroutine(AnimarTextoEspera());
    }

    public void CerrarVentanaCrear()
    {
        fondoOscuroCrear.SetActive(false);

        if (animacionEspera != null)
        {
            StopCoroutine(animacionEspera);
            animacionEspera = null;
        }

        botonEmpezarPartida.SetActive(false);
        textoEsperandoJugador.text = "Esperando jugador";
        textoCodigoGenerado.text = "------";

        if (NetworkManager.Singleton != null &&
            NetworkManager.Singleton.IsListening)
        {
            NetworkManager.Singleton.Shutdown();
        }
    }


    // --------------------------------------------------
    // ANIMACIÓN "ESPERANDO JUGADOR..."
    // --------------------------------------------------

    private IEnumerator AnimarTextoEspera()
    {
        while (true)
        {
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
    // SEGUNDO JUGADOR CONECTADO
    // --------------------------------------------------

    private void JugadorConectado()
    {
        if (animacionEspera != null)
        {
            StopCoroutine(animacionEspera);
            animacionEspera = null;
        }

        textoEsperandoJugador.text = "Jugador conectado ✓";

        botonEmpezarPartida.SetActive(true);
    }

    private void AlConectarJugador(ulong idCliente)
    {
        Debug.Log("Jugador conectado. ID: " + idCliente);

        // Si somos el Host, esperamos tener dos jugadores:
        // Host + Client.
        if (NetworkManager.Singleton.IsHost)
        {
            if (NetworkManager.Singleton.ConnectedClientsIds.Count >= 2)
            {
                JugadorConectado();
            }
        }

        // Si somos el Client, significa que logramos entrar.
        else if (NetworkManager.Singleton.IsClient)
        {
            textoEstadoUnirse.text =
                "Conectado ✓\nEsperando que el Host inicie...";
        }
    }

    private void AlDesconectarJugador(ulong idCliente)
    {
        Debug.Log("Jugador desconectado. ID: " + idCliente);

        if (NetworkManager.Singleton == null)
            return;

        // Solo hacemos esto si el Host todavía tiene
        // abierta la ventana de Crear Partida.
        if (NetworkManager.Singleton.IsHost &&
            fondoOscuroCrear.activeSelf &&
            NetworkManager.Singleton.ConnectedClientsIds.Count < 2)
        {
            botonEmpezarPartida.SetActive(false);

            textoEsperandoJugador.text = "Esperando jugador";

            if (animacionEspera != null)
            {
                StopCoroutine(animacionEspera);
            }

            animacionEspera = StartCoroutine(AnimarTextoEspera());
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
            Debug.LogWarning("Solo el Host puede iniciar la partida.");
            return;
        }

        NetworkManager.Singleton.SceneManager.LoadScene(
            "Level_01_Lobby",
            LoadSceneMode.Single
        );
    }

    // --------------------------------------------------
    // OPCIONES
    // --------------------------------------------------

    public void AbrirOpciones()
    {
        Debug.Log("Opciones todavía no implementadas.");
    }


    // --------------------------------------------------
    // SALIR
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