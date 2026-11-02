
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;

public class HUDDialogoNPC : MonoBehaviour
{
    // Compatibilidad con NPC antiguos
    public static HUDDialogoNPC Instancia { get; private set; }

    [Header("Panel de conversacion")]
    [SerializeField] private GameObject panelDialogo;

    [Header("Personajes")]
    [SerializeField] private TMP_Text textoNombre;
    [SerializeField] private TMP_Text textoDialogo;
    [SerializeField] private Image imagenRetrato;

    [Header("Opciones de respuesta")]
    [SerializeField] private GameObject contenedorOpciones;
    [SerializeField] private Button[] botonesOpciones = new Button[3];
    [SerializeField] private TMP_Text[] textosOpciones = new TMP_Text[3];

    [Header("Botones de control")]
    [SerializeField] private Button botonContinuar;
    [SerializeField] private Button botonSaltar;
    [SerializeField] private Button botonCerrar;

    [Header("HUD del juego")]
    [SerializeField] private HUDModoDialogo modoDialogo;

    [Header("Efecto de escritura")]
    [SerializeField, Range(0.01f, 0.15f)]
    private float tiempoPorCaracter = 0.035f;

    private NPCDialogo npcActual;
    private NodoDialogo nodoActual;
    private Coroutine rutinaEscritura;

    private bool escribiendo;
    private bool conversacionAbierta;
    private NetworkPlayerMovement jugadorEnDialogo;

    private void Awake()
    {
        if (Instancia == null)
            Instancia = this;

        for (int i = 0; i < botonesOpciones.Length && i < 3; i++)
        {
            int indice = i;

            if (botonesOpciones[i] != null)
            {
                botonesOpciones[i].onClick.AddListener(
                    () => SeleccionarOpcion(indice));
            }
        }

        if (botonContinuar != null)
            botonContinuar.onClick.AddListener(Continuar);

        if (botonSaltar != null)
            botonSaltar.onClick.AddListener(SaltarEscritura);

        if (botonCerrar != null)
            botonCerrar.onClick.AddListener(CerrarDialogo);

        if (contenedorOpciones != null)
            contenedorOpciones.SetActive(false);

        if (panelDialogo != null)
            panelDialogo.SetActive(false);
    }

    private void OnDestroy()
    {
        if (Instancia == this)
            Instancia = null;
    }

    public void AbrirDialogo(NPCDialogo npc)
    {
        if (npc == null)
            return;

        // Evita reiniciar una conversacion ya abierta.
        if (conversacionAbierta)
            return;

        npcActual = npc;
        conversacionAbierta = true;

        jugadorEnDialogo = null;

        if (NetworkManager.Singleton != null &&
            NetworkManager.Singleton.LocalClient != null &&
            NetworkManager.Singleton.LocalClient.PlayerObject != null)
        {
            jugadorEnDialogo =
                NetworkManager.Singleton.LocalClient.PlayerObject
                .GetComponent<NetworkPlayerMovement>();
        }

        if (jugadorEnDialogo != null)
            jugadorEnDialogo.BloquearMovimiento(true);
        if (modoDialogo != null)
            modoDialogo.OcultarHUD();

        if (panelDialogo != null)
            panelDialogo.SetActive(true);

        MostrarNodo(npcActual.NodoInicial);
    }

    private void MostrarNodo(string id)
    {
        if (npcActual == null)
            return;

        DetenerEscritura();

        nodoActual = npcActual.BuscarNodo(id);

        if (nodoActual == null)
        {
            Debug.LogWarning(
                "No se encontro el nodo: " + id);
            CerrarDialogo();
            return;
        }

        if (contenedorOpciones != null)
            contenedorOpciones.SetActive(false);

        MostrarPersonaje(
            nodoActual.hablante ==
            NodoDialogo.Hablante.NPC);

        if (botonContinuar != null)
            botonContinuar.gameObject.SetActive(false);

        if (botonSaltar != null)
            botonSaltar.gameObject.SetActive(true);

        rutinaEscritura = StartCoroutine(
            EscribirTexto(nodoActual.texto));
    }

    private IEnumerator EscribirTexto(string contenido)
    {
        escribiendo = true;

        textoDialogo.text = contenido ?? "";
        textoDialogo.maxVisibleCharacters = 0;
        textoDialogo.ForceMeshUpdate();

        int total = textoDialogo.textInfo.characterCount;

        for (int i = 1; i <= total; i++)
        {
            textoDialogo.maxVisibleCharacters = i;

            yield return new WaitForSecondsRealtime(
                tiempoPorCaracter);
        }

        rutinaEscritura = null;
        escribiendo = false;

        FinalizarEscritura();
    }

    public void SaltarEscritura()
    {
        if (!escribiendo)
            return;

        DetenerEscritura();

        if (textoDialogo != null)
            textoDialogo.maxVisibleCharacters = int.MaxValue;

        FinalizarEscritura();
    }

    private void FinalizarEscritura()
    {
        if (botonSaltar != null)
            botonSaltar.gameObject.SetActive(false);

        bool tieneOpciones =
            nodoActual != null &&
            nodoActual.opciones != null &&
            nodoActual.opciones.Length > 0;

        if (tieneOpciones)
        {
            // Es el turno de responder del jugador.
            MostrarPersonaje(false);
            ActualizarOpciones();

            if (contenedorOpciones != null)
                contenedorOpciones.SetActive(true);

            if (botonContinuar != null)
                botonContinuar.gameObject.SetActive(false);
        }
        else
        {
            // Nodo de despedida.
            if (contenedorOpciones != null)
                contenedorOpciones.SetActive(false);

            if (botonContinuar != null)
                botonContinuar.gameObject.SetActive(true);
        }
    }

    private void MostrarPersonaje(bool esNPC)
    {
        if (npcActual == null)
            return;

        if (textoNombre != null)
        {
            textoNombre.text = esNPC
                ? npcActual.NombreNPC
                : npcActual.NombreJugador;
        }

        if (imagenRetrato != null)
        {
            Sprite retrato = esNPC
                ? npcActual.RetratoNPC
                : npcActual.RetratoJugador;

            imagenRetrato.sprite = retrato;
            imagenRetrato.enabled = retrato != null;
        }
    }

    private void ActualizarOpciones()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i >= botonesOpciones.Length)
                break;

            Button boton = botonesOpciones[i];

            if (boton == null)
                continue;

            OpcionDialogo opcion = ObtenerOpcion(i);

            bool disponible =
                opcion != null &&
                !string.IsNullOrWhiteSpace(opcion.texto);

            boton.gameObject.SetActive(disponible);

            if (disponible &&
                i < textosOpciones.Length &&
                textosOpciones[i] != null)
            {
                textosOpciones[i].text = opcion.texto;
            }
        }
    }

    private OpcionDialogo ObtenerOpcion(int indice)
    {
        if (nodoActual == null ||
            nodoActual.opciones == null ||
            indice < 0 ||
            indice >= nodoActual.opciones.Length)
        {
            return null;
        }

        return nodoActual.opciones[indice];
    }

    private void SeleccionarOpcion(int indice)
    {
        if (!conversacionAbierta || escribiendo)
            return;

        OpcionDialogo opcion = ObtenerOpcion(indice);

        if (opcion == null)
            return;

        if (string.IsNullOrWhiteSpace(
            opcion.siguienteNodo))
        {
            CerrarDialogo();
            return;
        }

        MostrarNodo(opcion.siguienteNodo);
    }

    public void Continuar()
    {
        if (!conversacionAbierta)
            return;

        if (escribiendo)
        {
            SaltarEscritura();
            return;
        }

        bool tieneOpciones =
            nodoActual != null &&
            nodoActual.opciones != null &&
            nodoActual.opciones.Length > 0;

        if (!tieneOpciones)
            CerrarDialogo();
    }

    public void CerrarDialogo()
    {
        DetenerEscritura();

        conversacionAbierta = false;
        nodoActual = null;
        npcActual = null;

        if (textoDialogo != null)
        {
            textoDialogo.text = "";
            textoDialogo.maxVisibleCharacters = int.MaxValue;
        }

        if (contenedorOpciones != null)
            contenedorOpciones.SetActive(false);

        if (panelDialogo != null)
            panelDialogo.SetActive(false);
        
        if (modoDialogo != null)
            modoDialogo.RestaurarHUD();

        if (jugadorEnDialogo != null)
        {
            jugadorEnDialogo.BloquearMovimiento(false);
            jugadorEnDialogo = null;
        }
    }

    private void DetenerEscritura()
    {
        if (rutinaEscritura != null)
        {
            StopCoroutine(rutinaEscritura);
            rutinaEscritura = null;
        }

        escribiendo = false;
    }
}
