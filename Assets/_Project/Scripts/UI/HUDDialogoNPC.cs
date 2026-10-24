using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class HUDDialogoNPC : MonoBehaviour
{
    public static HUDDialogoNPC Instancia { get; private set; }

    [Header("Interfaz")]
    [SerializeField] private GameObject canvasDialogo;
    [SerializeField] private GameObject hudJuego;

    [Header("Datos del NPC")]
    [SerializeField] private Image retratoNPC;
    [SerializeField] private TMP_Text nombreNPC;
    [SerializeField] private TMP_Text textoDialogo;

    [Header("Opciones")]
    [SerializeField] private GameObject contenedorOpciones;

    [SerializeField] private Button opcion1;
    [SerializeField] private TMP_Text textoOpcion1;

    [SerializeField] private Button opcion2;
    [SerializeField] private TMP_Text textoOpcion2;

    [SerializeField] private Button opcion3;
    [SerializeField] private TMP_Text textoOpcion3;

    [Header("Continuar")]
    [SerializeField] private Button botonContinuar;

    private NPCDialogo npcActual;

    private NetworkPlayerMovement movimientoJugador;
    private SaltoJugador saltoJugador;

    private bool mostrandoRespuesta = false;

    private void Awake()
    {
        Instancia = this;

        opcion1.onClick.AddListener(() => ElegirOpcion(0));
        opcion2.onClick.AddListener(() => ElegirOpcion(1));
        opcion3.onClick.AddListener(() => ElegirOpcion(2));

        botonContinuar.onClick.AddListener(Continuar);

        canvasDialogo.SetActive(false);
    }

    public void AbrirDialogo(NPCDialogo npc)
    {
        npcActual = npc;
        mostrandoRespuesta = false;

        canvasDialogo.SetActive(true);

        // Ocultamos TODO el HUD normal.
        if (hudJuego != null)
            hudJuego.SetActive(false);

        BloquearJugador();

        nombreNPC.text = npc.NombreNPC;
        textoDialogo.text = npc.TextoInicial;

        if (retratoNPC != null)
            retratoNPC.sprite = npc.RetratoNPC;

        MostrarOpciones();

        botonContinuar.gameObject.SetActive(false);
    }

    private void MostrarOpciones()
    {
        contenedorOpciones.SetActive(true);

        ConfigurarOpcion(
            opcion1,
            textoOpcion1,
            npcActual.Opcion1
        );

        ConfigurarOpcion(
            opcion2,
            textoOpcion2,
            npcActual.Opcion2
        );

        ConfigurarOpcion(
            opcion3,
            textoOpcion3,
            npcActual.Opcion3
        );
    }

    private void ConfigurarOpcion(
        Button boton,
        TMP_Text texto,
        string contenido)
    {
        bool mostrar =
            !string.IsNullOrWhiteSpace(contenido);

        boton.gameObject.SetActive(mostrar);

        if (mostrar)
            texto.text = contenido;
    }

    private void ElegirOpcion(int opcion)
    {
        if (npcActual == null)
            return;

        string respuesta = "";

        switch (opcion)
        {
            case 0:
                respuesta = npcActual.Respuesta1;
                break;

            case 1:
                respuesta = npcActual.Respuesta2;
                break;

            case 2:
                respuesta = npcActual.Respuesta3;
                break;
        }

        contenedorOpciones.SetActive(false);

        textoDialogo.text = respuesta;

        mostrandoRespuesta = true;

        botonContinuar.gameObject.SetActive(true);
    }

    private void Continuar()
    {
        if (!mostrandoRespuesta)
            return;

        CerrarDialogo();
    }

    public void CerrarDialogo()
    {
        canvasDialogo.SetActive(false);

        if (hudJuego != null)
            hudJuego.SetActive(true);

        DesbloquearJugador();

        npcActual = null;
        mostrandoRespuesta = false;
    }

    private void BloquearJugador()
    {
        NetworkObject[] objetos =
            FindObjectsByType<NetworkObject>(
                FindObjectsSortMode.None
            );

        foreach (NetworkObject objeto in objetos)
        {
            if (!objeto.IsOwner)
                continue;

            movimientoJugador =
                objeto.GetComponent<NetworkPlayerMovement>();

            saltoJugador =
                objeto.GetComponent<SaltoJugador>();

            if (movimientoJugador != null)
                movimientoJugador.enabled = false;

            if (saltoJugador != null)
                saltoJugador.enabled = false;

            Rigidbody2D rb =
                objeto.GetComponent<Rigidbody2D>();

            if (rb != null)
                rb.linearVelocity = Vector2.zero;

            break;
        }
    }

    private void DesbloquearJugador()
    {
        if (movimientoJugador != null)
            movimientoJugador.enabled = true;

        if (saltoJugador != null)
            saltoJugador.enabled = true;
    }
}