
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;
using System;
using System.Collections;

public class HUDReconexionController : MonoBehaviour
{
    public static HUDReconexionController Instancia { get; private set; }

    [Header("Panel principal")]
    [SerializeField] private GameObject panelReconectando;

    [Header("Titulos y mensajes")]
    [SerializeField] private TMP_Text tituloReconectando;
    [SerializeField] private TMP_Text textoInformativo;
    [SerializeField] private TMP_Text textoInformativo2;
    [SerializeField] private TMP_Text textoInformativo3;

    [Header("Botones")]
    [SerializeField] private Button botonCerrar;
    [SerializeField] private Button botonContinuar;
    [SerializeField] private Button botonMenuPrincipal;

    [Header("Animacion")]
    [SerializeField] private float intervaloPuntos = 0.4f;

    private Coroutine animacionPuntos;

    // Eventos para conectar con GestorMultijugador.
    public event Action ContinuarSolicitado;
    public event Action MenuPrincipalSolicitado;

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            Destroy(this);
            return;
        }

        Instancia = this;

        if (botonContinuar != null)
            botonContinuar.onClick.AddListener(Continuar);

        if (botonMenuPrincipal != null)
            botonMenuPrincipal.onClick.AddListener(SalirMenuPrincipal);
    }

    private void Start()
    {
        OcultarPanel();
    }

    private void OnDestroy()
    {
        if (botonContinuar != null)
            botonContinuar.onClick.RemoveListener(Continuar);

        if (botonMenuPrincipal != null)
            botonMenuPrincipal.onClick.RemoveListener(SalirMenuPrincipal);

        if (Instancia == this)
            Instancia = null;
    }

    // =====================================
    // PREPARAR HUD PARA RECONECTAR
    // =====================================

    private void PrepararHUD()
    {
        // Cerrar pausa y ocultar controles.
        if (HUDPausaController.Instancia != null)
        {
            HUDPausaController.Instancia
                .CerrarPausaPorReconectar();
        }
    }

    // =====================================
    // ESTADO 1: RECONECTANDO
    // =====================================

    public void MostrarReconectando()
    {
        if (panelReconectando == null)
            return;

        PrepararHUD();

        panelReconectando.SetActive(true);

        DetenerAnimacion();

        if (tituloReconectando != null)
            tituloReconectando.text = "Reconectando";

        if (textoInformativo != null)
            textoInformativo.text =
                "Se ha interrumpido la conexión con el otro jugador.";

        if (textoInformativo2 != null)
            textoInformativo2.text =
                "Esperando a que vuelva a conectarse.";

        if (textoInformativo3 != null)
            textoInformativo3.text =
                "Intentando restablecer conexión...";

        MostrarBotones(false, false);

        animacionPuntos = StartCoroutine(AnimarPuntos());

        Debug.Log("HUD: RECONECTANDO");
    }

    // =====================================
    // ANIMACION DE LOS TRES PUNTOS
    // =====================================

    private IEnumerator AnimarPuntos()
    {
        int puntos = 0;

        while (true)
        {
            string sufijo = new string('.', puntos);

            if (tituloReconectando != null)
            {
                tituloReconectando.text =
                    "Reconectando" + sufijo;
            }

            puntos = (puntos + 1) % 4;

            yield return new WaitForSecondsRealtime(
                intervaloPuntos
            );
        }
    }

    // =====================================
    // ESTADO 2: RECONECTADO
    // =====================================

    public void MostrarReconectado()
    {
        DetenerAnimacion();

        PrepararHUD();

        if (panelReconectando != null)
            panelReconectando.SetActive(true);

        if (tituloReconectando != null)
            tituloReconectando.text = "¡Reconectado!";

        if (textoInformativo != null)
            textoInformativo.text =
                "Se ha restablecido la conexión con el otro jugador.";

        if (textoInformativo2 != null)
            textoInformativo2.text =
                "Tu compañero está nuevamente en la partida.";

        if (textoInformativo3 != null)
            textoInformativo3.text =
                "Pulsa Continuar para volver al juego.";

        MostrarBotones(true, false);

        Debug.Log("HUD: CONEXION RESTABLECIDA");
    }

    // =====================================
    // ESTADO 3: ERROR DE CONEXION
    // =====================================

    public void MostrarErrorConexion()
    {
        DetenerAnimacion();

        PrepararHUD();

        if (panelReconectando != null)
            panelReconectando.SetActive(true);

        if (tituloReconectando != null)
            tituloReconectando.text = "No se pudo conectar";

        if (textoInformativo != null)
            textoInformativo.text =
                "Se agotó el tiempo de espera.";

        if (textoInformativo2 != null)
            textoInformativo2.text =
                "No fue posible recuperar la conexión.";

        if (textoInformativo3 != null)
            textoInformativo3.text =
                "Puedes regresar al menú principal.";

        MostrarBotones(false, true);

        Debug.LogWarning("HUD: NO SE PUDO RECONECTAR");
    }

    // =====================================
    // MOSTRAR BOTONES SEGUN ESTADO
    // =====================================

    private void MostrarBotones(
        bool mostrarContinuar,
        bool mostrarMenuPrincipal)
    {
        if (botonCerrar != null)
            botonCerrar.gameObject.SetActive(false);

        if (botonContinuar != null)
            botonContinuar.gameObject.SetActive(mostrarContinuar);

        if (botonMenuPrincipal != null)
            botonMenuPrincipal.gameObject.SetActive(mostrarMenuPrincipal);
    }

    // =====================================
    // CONTINUAR PARTIDA
    // =====================================

    private void Continuar()
    {
        Debug.Log("HUD: CONTINUAR SOLICITADO");

        OcultarPanel();

        // Recuperar controles del jugador.
        if (HUDPausaController.Instancia != null)
        {
            HUDPausaController.Instancia
                .RestaurarControlesJuego();
        }

        // Recuperar movimiento local.
        DesbloquearMovimientoLocal();

        // Avisar al gestor de red.
        ContinuarSolicitado?.Invoke();
    }

    private void DesbloquearMovimientoLocal()
    {
        if (NetworkManager.Singleton == null ||
            NetworkManager.Singleton.LocalClient == null ||
            NetworkManager.Singleton.LocalClient.PlayerObject == null)
        {
            return;
        }

        NetworkPlayerMovement movimiento =
            NetworkManager.Singleton.LocalClient.PlayerObject
                .GetComponent<NetworkPlayerMovement>();

        if (movimiento != null)
            movimiento.BloquearMovimiento(false);
    }

    // =====================================
    // SALIR AL MENU PRINCIPAL
    // =====================================

    private void SalirMenuPrincipal()
    {
        Debug.Log("HUD: SALIR AL MENU PRINCIPAL SOLICITADO");

        MenuPrincipalSolicitado?.Invoke();
    }

    // =====================================
    // OCULTAR PANEL
    // =====================================

    public void OcultarPanel()
    {
        DetenerAnimacion();

        if (panelReconectando != null)
            panelReconectando.SetActive(false);
    }

    // =====================================
    // DETENER ANIMACION
    // =====================================

    private void DetenerAnimacion()
    {
        if (animacionPuntos != null)
        {
            StopCoroutine(animacionPuntos);
            animacionPuntos = null;
        }
    }
}
