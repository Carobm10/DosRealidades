
using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class ZonaInteraccion : MonoBehaviour
{
    [Header("Interaccion")]
    [SerializeField] private string textoAccion = "INTERACTUAR";

    [Header("Punto del indicador UI")]
    [SerializeField] private Transform puntoIndicador;

    [Header("Ventana opcional")]
    [SerializeField] private GameObject ventanaAbrir;

    [Header("Nota guia reutilizable")]
    [SerializeField] private NotaGuiaInteractiva notaGuia;

    [Header("Reinicio cooperativo P1")]
    [SerializeField] private bool reiniciarPuzzleP1AlSalir;
    [SerializeField] private P1ElUmbralController controladorPuzzleP1;

    [Header("NPC opcional")]
    [SerializeField] private NPCDialogo npcDialogo;

    [Header("Audio de proximidad NPC")]
    [SerializeField] private AudioSource audioSourceNPC;
    [SerializeField] private AudioClip sonidoProximidadNPC;
    [SerializeField, Range(0f, 1f)] private float volumenSonidoNPC = 1f;

    [Header("Control visual NPC")]
    [SerializeField] private NPCVisualController visualNPC;

    [Header("Puerta P5")]
    [SerializeField] private PuertaPuzzleP5 puertaPuzzle;

    [Header("Objeto recolectable")]
    [SerializeField] private ObjetoRecolectable objetoRecolectable;

    [Header("Regreso P5")]
    [SerializeField] private RegresoPasilloP5 regresoPasillo;

    [Header("Brillo de objeto opcional")]
    [SerializeField] private SpriteRenderer objetoBrillo;
    [SerializeField] private Sprite spriteBrillo;

    [Header("Parpadeo automatico")]
    [SerializeField] private bool parpadeoAutomatico;
    [SerializeField] private float tiempoNormal = 0.7f;
    [SerializeField] private float tiempoBrillo = 0.7f;

    [Header("Boton cooperativo P3")]
    [SerializeField] private bool esBotonFinalP3;
    [SerializeField] private bool botonEsParaLia;
    [SerializeField] private ControlFinalP3 controlFinal;

    [Header("Puerta pasillo Elian")]
    [SerializeField] private Animator animatorPuertaElian;
    [SerializeField] private string parametroPuertaAbierta = "Abierta";

    [Header("Botones Runner P2")]
    [SerializeField] private bool esBotonPuertaP2;
    [SerializeField, Range(1, 3)]
    private int numeroPuertaP2 = 1;

    [Header("Animacion boton fisico P2")]
    [SerializeField] private Animator animatorBotonP2;
    [SerializeField] private string parametroBrilloP2 = "Brillo";
    [SerializeField] private string triggerPresionarP2 = "Presionar";

    private bool botonP2Presionado;

    private bool puertaElianAbierta;

    private Sprite spriteOriginal;
    private Coroutine rutinaParpadeo;
    private int contactosJugadorLocal;

    private bool puzzleEnCurso;
    private bool manteniendo;

    [Header("Dispositivos de llaves P8")]
    [SerializeField] private DispositivosLlavesP8 dispositivoLlavesP8;
    [SerializeField] private bool dispositivoEsElian;

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        if (npcDialogo == null)
            npcDialogo = GetComponent<NPCDialogo>();

        if (audioSourceNPC == null)
            audioSourceNPC = GetComponent<AudioSource>();

        if (visualNPC == null)
            visualNPC = GetComponent<NPCVisualController>();

        if (puertaPuzzle == null)
            puertaPuzzle = GetComponent<PuertaPuzzleP5>();

        if (regresoPasillo == null)
            regresoPasillo = GetComponent<RegresoPasilloP5>();

        if (notaGuia == null)
            notaGuia = GetComponentInParent<NotaGuiaInteractiva>();

        if (objetoBrillo != null)
            spriteOriginal = objetoBrillo.sprite;

        if (reiniciarPuzzleP1AlSalir &&
            controladorPuzzleP1 == null)
        {
            controladorPuzzleP1 =
                FindAnyObjectByType<P1ElUmbralController>();
        }

        if (esBotonFinalP3 && controlFinal == null)
        {
            controlFinal =
                FindFirstObjectByType<ControlFinalP3>(
                    FindObjectsInactive.Include
                );

            if (controlFinal == null)
            {
                Debug.LogWarning(
                    "P3: Este botón está configurado como botón final, " +
                    "pero no encuentra ControlFinalP3. Objeto: " +
                    gameObject.name
                );
            }
        }

        if (objetoRecolectable == null)
            objetoRecolectable =
                GetComponent<ObjetoRecolectable>();

        if (animatorBotonP2 == null && esBotonPuertaP2)
        {
            animatorBotonP2 = GetComponent<Animator>();
        }
    }

    private void OnEnable()
    {
        if (esBotonFinalP3)
            return;

        if (parpadeoAutomatico &&
            objetoBrillo != null &&
            spriteBrillo != null)
        {
            rutinaParpadeo = StartCoroutine(Parpadear());
        }
    }

    // =====================================
    // POSICION INDICADOR
    // =====================================

    public Vector3 ObtenerPosicionIndicador()
    {
        return puntoIndicador != null
            ? puntoIndicador.position
            : transform.position;
    }

    // =====================================
    // BRILLO
    // =====================================

    private IEnumerator Parpadear()
    {
        while (true)
        {
            objetoBrillo.sprite = spriteOriginal;

            yield return new WaitForSeconds(
                Mathf.Max(0.05f, tiempoNormal)
            );

            objetoBrillo.sprite = spriteBrillo;

            yield return new WaitForSeconds(
                Mathf.Max(0.05f, tiempoBrillo)
            );
        }
    }

    private void CambiarBrilloObjeto(bool activar)
    {
        if (objetoBrillo == null)
            return;

        objetoBrillo.sprite =
            activar && spriteBrillo != null
            ? spriteBrillo
            : spriteOriginal;
    }

    // =====================================
    // JUGADOR PERMITIDO
    // =====================================

    private bool EsJugadorPermitido(NetworkObject jugador)
    {
        if (jugador == null || !jugador.IsOwner)
            return false;

        if (notaGuia != null && !notaGuia.PuedeLeerla())
            return false;

        if (esBotonPuertaP2)
        {
            NetworkPlayerSetup setup =
                jugador.GetComponent<NetworkPlayerSetup>();

            return setup != null &&
                setup.RolConfigurado &&
                setup.EsElian;
        }

        if (!esBotonFinalP3)
            return true;

        bool esLia = IdentidadJugadorLocal.EsLia();

        return botonEsParaLia ? esLia : !esLia;
    }

    // =====================================
    // ENTRAR EN ZONA
    // =====================================

    private void OnTriggerEnter2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (!EsJugadorPermitido(jugador))
            return;

        contactosJugadorLocal++;

        // SONIDO DE PROXIMIDAD NPC
        // Solo se reproduce al entrar por primera vez en la zona.

        if (contactosJugadorLocal == 1 &&
            npcDialogo != null &&
            audioSourceNPC != null &&
            sonidoProximidadNPC != null)
        {
            audioSourceNPC.PlayOneShot(
                sonidoProximidadNPC,
                volumenSonidoNPC
            );
        }

        HUDInteraccion.Instancia?.MostrarBoton(
            textoAccion,
            this
        );

        if (esBotonFinalP3)
        {
            if (controlFinal == null)
            {
                controlFinal =
                    FindFirstObjectByType<ControlFinalP3>(
                        FindObjectsInactive.Include
                    );
            }

            if (controlFinal != null)
            {
                controlFinal.ActivarBotonLocal(
                    botonEsParaLia
                );
            }
            else
            {
                Debug.LogWarning(
                    "P3: No se encontró ControlFinalP3 para " +
                    gameObject.name
                );
            }

            return;
        }

        visualNPC?.CambiarBrillo(true);

        if (esBotonPuertaP2 && !botonP2Presionado &&
            animatorBotonP2 != null)
        {
            animatorBotonP2.SetBool(parametroBrilloP2, true);
        }

        if (!parpadeoAutomatico)
            CambiarBrilloObjeto(true);
    }

    // =====================================
    // SALIR DE ZONA
    // =====================================

    private void OnTriggerExit2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (!EsJugadorPermitido(jugador))
            return;

        contactosJugadorLocal =
            Mathf.Max(0, contactosJugadorLocal - 1);

        if (contactosJugadorLocal > 0)
            return;

        TerminarMantener();

        HUDInteraccion.Instancia?.OcultarBoton(this);

        if (esBotonFinalP3)
        {
            if (controlFinal != null)
            {
                controlFinal.PonerBotonNormalLocal(
                    botonEsParaLia
                );
            }

            return;
        }

        visualNPC?.CambiarBrillo(false);

        if (esBotonPuertaP2 && !botonP2Presionado &&
            animatorBotonP2 != null)
        {
            animatorBotonP2.SetBool(parametroBrilloP2, false);
        }

        if (!parpadeoAutomatico)
            CambiarBrilloObjeto(false);

        // Reinicio opcional exclusivo de P1.

        if (reiniciarPuzzleP1AlSalir)
        {
            if (controladorPuzzleP1 == null)
            {
                controladorPuzzleP1 =
                    FindAnyObjectByType<P1ElUmbralController>();
            }

            if (controladorPuzzleP1 != null)
            {
                controladorPuzzleP1.SolicitarReinicioPuzzle();
            }
        }
    }

    // =====================================
    // INTERACTUAR
    // =====================================

    public void Interactuar()
    {
        if (contactosJugadorLocal <= 0)
            return;

        // DISPOSITIVOS DE LLAVES P8

        if (dispositivoLlavesP8 != null)
        {
            dispositivoLlavesP8.SolicitarColocarLlave(
                dispositivoEsElian
            );

            return;
        }

        // =====================================
        // BOTONES RUNNER P2
        // =====================================

        if (esBotonPuertaP2)
        {
            if (botonP2Presionado)
                return;

            NetworkManager red = NetworkManager.Singleton;

            if (red == null ||
                red.LocalClient == null ||
                red.LocalClient.PlayerObject == null)
                return;

            ControlPuertasP2 control =
                red.LocalClient.PlayerObject
                .GetComponent<ControlPuertasP2>();

            if (control == null)
            {
                Debug.LogError(
                    "P2: No se encontró ControlPuertasP2."
                );
                return;
            }

            // Bloquear nuevas pulsaciones.
            botonP2Presionado = true;

            // Detener el brillo.
            if (animatorBotonP2 != null)
            {
                animatorBotonP2.SetBool(
                    parametroBrilloP2,
                    false
                );

                // Reproducir hundimiento.
                animatorBotonP2.ResetTrigger(
                    triggerPresionarP2
                );

                animatorBotonP2.SetTrigger(
                    triggerPresionarP2
                );
            }

            // Solicitar cierre de la puerta de Lía.
            control.SolicitarCerrarPuerta(numeroPuertaP2);

            Debug.Log(
                "P2: Botón " + numeroPuertaP2 +
                " presionado por Elian."
            );

            return;
        }
        
        // PUERTA PASILLO ELIAN

        if (animatorPuertaElian != null)
        {
            if (puertaElianAbierta)
                return;

            puertaElianAbierta = true;

            animatorPuertaElian.SetBool(
                parametroPuertaAbierta,
                true
            );

            Debug.Log("PUERTA ELIAN: Abierta.");

            return;
        }

        // NOTAS GUIA
        // Tiene prioridad sobre las ventanas normales.

        if (notaGuia != null)
        {
            notaGuia.AbrirNota();
            return;
        }

        // OBJETOS RECOLECTABLES

        if (objetoRecolectable != null)
        {
            Debug.Log("[ZONA] Ejecutando interacción con objeto recolectable.");
            objetoRecolectable.SolicitarRecoleccion();
            return;
        }

        // REGRESO P5

        if (regresoPasillo != null)
        {
            regresoPasillo.SolicitarRegreso();
            return;
        }

        // PUERTAS P5

        if (puertaPuzzle != null)
        {
            puertaPuzzle.IntentarAbrir();
            return;
        }

        // NPC

        if (npcDialogo != null)
        {
            npcDialogo.IniciarDialogo();
            return;
        }

        // VENTANAS NORMALES

        if (ventanaAbrir != null)
        {
            MantenerBrillo();
            ventanaAbrir.SetActive(true);

            if (controladorPuzzleP1 == null)
            {
                controladorPuzzleP1 =
                    FindAnyObjectByType<P1ElUmbralController>();
            }

            if (controladorPuzzleP1 != null)
            {
                controladorPuzzleP1.RegistrarPanelAbierto(
                    ventanaAbrir
                );
            }
        }
    }

    // =====================================
    // PULSACION MANTENIDA P3
    // =====================================

    public void ComenzarMantener()
    {
        if (contactosJugadorLocal <= 0 ||
            manteniendo ||
            !esBotonFinalP3)
            return;

        if (controlFinal == null)
        {
            controlFinal =
                FindAnyObjectByType<ControlFinalP3>();
        }

        if (controlFinal == null)
        {
            Debug.LogError(
                "P3: NO SE ENCONTRO CONTROL FINAL"
            );
            return;
        }

        manteniendo = true;
        controlFinal.ComenzarPresion();

        Debug.Log("P3: MANTENIENDO BOTON");
    }

    public void TerminarMantener()
    {
        if (!manteniendo)
            return;

        manteniendo = false;

        if (controlFinal != null)
            controlFinal.TerminarPresion();

        Debug.Log("P3: SE SOLTO BOTON");
    }

    // =====================================
    // BRILLO DE PUZZLES
    // =====================================

    public void MantenerBrillo()
    {
        puzzleEnCurso = true;

        if (rutinaParpadeo != null)
        {
            StopCoroutine(rutinaParpadeo);
            rutinaParpadeo = null;
        }

        CambiarBrilloObjeto(true);
    }

    public void ReanudarParpadeo()
    {
        if (esBotonFinalP3 ||
            !parpadeoAutomatico ||
            !isActiveAndEnabled)
            return;

        puzzleEnCurso = false;

        if (rutinaParpadeo == null)
            rutinaParpadeo = StartCoroutine(Parpadear());
    }

    private void Update()
    {
        if (!parpadeoAutomatico ||
            !puzzleEnCurso ||
            esBotonFinalP3)
            return;

        if (ventanaAbrir != null &&
            !ventanaAbrir.activeInHierarchy)
        {
            ReanudarParpadeo();
        }
    }

    // =====================================
    // DESACTIVACION
    // =====================================

    private void OnDisable()
    {
        TerminarMantener();

        contactosJugadorLocal = 0;

        HUDInteraccion.Instancia?.OcultarBoton(this);

        if (esBotonFinalP3)
        {
            if (controlFinal != null)
            {
                controlFinal.PonerBotonNormalLocal(
                    botonEsParaLia
                );
            }
        }
        else
        {
            visualNPC?.CambiarBrillo(false);
        }

        if (rutinaParpadeo != null)
        {
            StopCoroutine(rutinaParpadeo);
            rutinaParpadeo = null;
        }

        if (!esBotonFinalP3)
            CambiarBrilloObjeto(false);
    }
}
