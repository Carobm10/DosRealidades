
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;

public class HUDDialogoNPC : MonoBehaviour
{
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

    private enum FaseDialogo
    {
        Ninguna,
        OpcionJugador,
        RespuestaNPC
    }

    private NPCDialogo npcActual;
    private NodoDialogo nodoActual;
    private OpcionDialogo opcionSeleccionada;

    private Coroutine rutinaEscritura;

    private bool escribiendo;
    private bool conversacionAbierta;

    private FaseDialogo faseActual = FaseDialogo.Ninguna;

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
                    () => SeleccionarOpcion(indice)
                );
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

    // =====================================
    // ABRIR CONVERSACION
    // =====================================

    public void AbrirDialogo(NPCDialogo npc)
    {
        if (npc == null || conversacionAbierta)
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

    // =====================================
    // MOSTRAR NODO DEL NPC
    // =====================================

    private void MostrarNodo(string id)
    {
        if (npcActual == null)
            return;

        DetenerEscritura();

        nodoActual = npcActual.BuscarNodo(id);

        if (nodoActual == null)
        {
            Debug.LogWarning("No se encontro el nodo: " + id);
            CerrarDialogo();
            return;
        }

        faseActual = FaseDialogo.Ninguna;
        opcionSeleccionada = null;

        if (contenedorOpciones != null)
            contenedorOpciones.SetActive(false);

        if (botonContinuar != null)
            botonContinuar.gameObject.SetActive(false);

        MostrarPersonaje(
            nodoActual.hablante == NodoDialogo.Hablante.NPC
        );

        if (botonSaltar != null)
            botonSaltar.gameObject.SetActive(true);

        rutinaEscritura = StartCoroutine(
            EscribirTexto(nodoActual.texto)
        );
    }

    // =====================================
    // ESCRITURA DEL TEXTO
    // =====================================

    private IEnumerator EscribirTexto(string contenido)
    {
        escribiendo = true;

        if (textoDialogo == null)
        {
            escribiendo = false;
            rutinaEscritura = null;
            yield break;
        }

        textoDialogo.text = contenido ?? "";
        textoDialogo.maxVisibleCharacters = 0;
        textoDialogo.ForceMeshUpdate();

        int total = textoDialogo.textInfo.characterCount;

        for (int i = 1; i <= total; i++)
        {
            textoDialogo.maxVisibleCharacters = i;

            yield return new WaitForSecondsRealtime(
                tiempoPorCaracter
            );
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

    // =====================================
    // FINALIZAR CADA TEXTO
    // =====================================

    private void FinalizarEscritura()
    {
        if (botonSaltar != null)
            botonSaltar.gameObject.SetActive(false);

        // Ya habló el jugador o el NPC respondió.
        // Ahora se permite continuar.

        if (faseActual == FaseDialogo.OpcionJugador ||
            faseActual == FaseDialogo.RespuestaNPC)
        {
            if (contenedorOpciones != null)
                contenedorOpciones.SetActive(false);

            if (botonContinuar != null)
                botonContinuar.gameObject.SetActive(true);

            return;
        }

        // Primera intervención del NPC:
        // mostrar las opciones del jugador.

        bool tieneOpciones =
            nodoActual != null &&
            nodoActual.opciones != null &&
            nodoActual.opciones.Length > 0;

        if (tieneOpciones)
        {
            MostrarPersonaje(false);

            ActualizarOpciones();

            if (contenedorOpciones != null)
                contenedorOpciones.SetActive(true);

            if (botonContinuar != null)
                botonContinuar.gameObject.SetActive(false);
        }
        else
        {
            if (contenedorOpciones != null)
                contenedorOpciones.SetActive(false);

            if (botonContinuar != null)
                botonContinuar.gameObject.SetActive(true);
        }
    }

    // =====================================
    // MOSTRAR PERSONAJE Y RETRATO
    // =====================================

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

    // =====================================
    // ACTUALIZAR OPCIONES
    // =====================================

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

    // =====================================
    // SELECCIONAR OPCION DEL JUGADOR
    // =====================================

    private void SeleccionarOpcion(int indice)
    {
        if (!conversacionAbierta || escribiendo)
            return;

        opcionSeleccionada = ObtenerOpcion(indice);

        if (opcionSeleccionada == null)
            return;

        if (contenedorOpciones != null)
            contenedorOpciones.SetActive(false);

        if (botonContinuar != null)
            botonContinuar.gameObject.SetActive(false);

        // Primero habla el jugador.

        faseActual = FaseDialogo.OpcionJugador;

        MostrarPersonaje(false);

        if (botonSaltar != null)
            botonSaltar.gameObject.SetActive(true);

        rutinaEscritura = StartCoroutine(
            EscribirTexto(opcionSeleccionada.texto)
        );
    }

    // =====================================
    // CONTINUAR CONVERSACION
    // =====================================

    public void Continuar()
    {
        if (!conversacionAbierta)
            return;

        if (escribiendo)
        {
            SaltarEscritura();
            return;
        }

        // El jugador ya eligió.
        // Ahora responde el NPC.

        if (faseActual == FaseDialogo.OpcionJugador)
        {
            MostrarRespuestaNPC();
            return;
        }

        // El NPC ya respondió.
        // Pasar al siguiente nodo.

        if (faseActual == FaseDialogo.RespuestaNPC)
        {
            if (opcionSeleccionada == null)
            {
                CerrarDialogo();
                return;
            }

            string siguiente =
                opcionSeleccionada.siguienteNodo;

            if (string.IsNullOrWhiteSpace(siguiente))
            {
                CerrarDialogo();
                return;
            }

            MostrarNodo(siguiente);
            return;
        }

        // Compatibilidad con nodos sin opciones.

        CerrarDialogo();
    }

    // =====================================
    // RESPUESTA DEL NPC A LA OPCION
    // =====================================

    private void MostrarRespuestaNPC()
    {
        if (opcionSeleccionada == null)
            return;

        faseActual = FaseDialogo.RespuestaNPC;

        if (contenedorOpciones != null)
            contenedorOpciones.SetActive(false);

        if (botonContinuar != null)
            botonContinuar.gameObject.SetActive(false);

        MostrarPersonaje(true);

        if (botonSaltar != null)
            botonSaltar.gameObject.SetActive(true);

        if (string.IsNullOrWhiteSpace(
            opcionSeleccionada.respuestaNPC))
        {
            Debug.LogWarning(
                "Falta la respuesta del NPC para esta opcion."
            );
        }

        rutinaEscritura = StartCoroutine(
            EscribirTexto(opcionSeleccionada.respuestaNPC)
        );
    }

    // =====================================
    // CERRAR CONVERSACION
    // =====================================

    public void CerrarDialogo()
    {
        DetenerEscritura();

        conversacionAbierta = false;

        nodoActual = null;
        npcActual = null;
        opcionSeleccionada = null;

        faseActual = FaseDialogo.Ninguna;

        if (textoDialogo != null)
        {
            textoDialogo.text = "";
            textoDialogo.maxVisibleCharacters = int.MaxValue;
        }

        if (contenedorOpciones != null)
            contenedorOpciones.SetActive(false);

        if (botonContinuar != null)
            botonContinuar.gameObject.SetActive(false);

        if (botonSaltar != null)
            botonSaltar.gameObject.SetActive(false);

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

    // =====================================
    // DETENER ESCRITURA
    // =====================================

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
