
using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class ZonaInteraccion : MonoBehaviour
{
    // =====================================
    // INTERACCION
    // =====================================

    [Header("Interaccion")]
    [SerializeField] private string textoAccion = "INTERACTUAR";

    [Header("Punto del indicador UI")]
    [SerializeField] private Transform puntoIndicador;

    [Header("Ventana opcional")]
    [SerializeField] private GameObject ventanaAbrir;

    // =====================================
    // NPC
    // =====================================

    [Header("NPC opcional")]
    [SerializeField] private NPCDialogo npcDialogo;

    [Header("Control visual NPC")]
    [SerializeField] private NPCVisualController visualNPC;

    // =====================================
    // PUERTAS P5
    // =====================================

    [Header("Puerta P5")]
    [SerializeField] private PuertaPuzzleP5 puertaPuzzle;

    [Header("Regreso P5")]
    [SerializeField] private RegresoPasilloP5 regresoPasillo;

    // =====================================
    // BRILLO
    // =====================================

    [Header("Brillo de objeto opcional")]
    [SerializeField] private SpriteRenderer objetoBrillo;
    [SerializeField] private Sprite spriteBrillo;

    [Header("Parpadeo automatico")]
    [SerializeField] private bool parpadeoAutomatico;
    [SerializeField] private float tiempoNormal = 0.7f;
    [SerializeField] private float tiempoBrillo = 0.7f;

    // =====================================
    // BOTONES COOPERATIVOS P3
    // =====================================

    [Header("Boton cooperativo P3")]
    [SerializeField] private bool esBotonFinalP3;
    [SerializeField] private bool botonEsParaLia;

    [SerializeField] private ControlFinalP3 controlFinal;

    // =====================================
    // VARIABLES INTERNAS
    // =====================================

    private Sprite spriteOriginal;

    private Coroutine rutinaParpadeo;

    private int contactosJugadorLocal;

    private bool puzzleEnCurso;
    private bool manteniendo;

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        // Buscar componentes automaticamente.

        if (npcDialogo == null)
            npcDialogo = GetComponent<NPCDialogo>();

        if (visualNPC == null)
            visualNPC = GetComponent<NPCVisualController>();

        if (puertaPuzzle == null)
            puertaPuzzle = GetComponent<PuertaPuzzleP5>();

        if (regresoPasillo == null)
            regresoPasillo = GetComponent<RegresoPasilloP5>();

        if (objetoBrillo != null)
            spriteOriginal = objetoBrillo.sprite;

        // Buscar collider para posicion alternativa
        // del indicador cuando no exista un Empty.

        // Buscar controlador de botones P3.

        if (esBotonFinalP3 && controlFinal == null)
        {
            controlFinal =
                FindAnyObjectByType<ControlFinalP3>();
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
    // POSICION DEL INDICADOR
    // =====================================

    public Vector3 ObtenerPosicionIndicador()
    {
        if (puntoIndicador != null)
            return puntoIndicador.position;

        return transform.position;
    }

    // =====================================
    // PARPADEO DE OBJETOS
    // =====================================

    private IEnumerator Parpadear()
    {
        while (true)
        {
            objetoBrillo.sprite = spriteOriginal;

            yield return new WaitForSeconds(tiempoNormal);

            objetoBrillo.sprite = spriteBrillo;

            yield return new WaitForSeconds(tiempoBrillo);
        }
    }

    // =====================================
    // VALIDAR JUGADOR
    // =====================================

    private bool EsJugadorPermitido(NetworkObject jugador)
    {
        if (jugador == null || !jugador.IsOwner)
            return false;

        if (!esBotonFinalP3)
            return true;

        bool esLia = IdentidadJugadorLocal.EsLia();

        return botonEsParaLia ? esLia : !esLia;
    }

    // =====================================
    // ENTRADA A ZONA
    // =====================================

    private void OnTriggerEnter2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (!EsJugadorPermitido(jugador))
            return;

        contactosJugadorLocal++;

        // Mostrar indicador contextual.

        HUDInteraccion.Instancia?.MostrarBoton(
            textoAccion,
            this
        );

        // BOTONES COOPERATIVOS P3.

        if (esBotonFinalP3)
        {
            if (controlFinal == null)
            {
                controlFinal =
                    FindAnyObjectByType<ControlFinalP3>();
            }

            if (controlFinal != null)
            {
                controlFinal.ActivarBotonLocal(
                    botonEsParaLia
                );
            }
            else
            {
                Debug.LogError(
                    "P3: NO SE ENCONTRO CONTROL FINAL"
                );
            }

            return;
        }

        // BRILLO NPC.

        visualNPC?.CambiarBrillo(true);

        // BRILLO DE OBJETOS.

        if (!parpadeoAutomatico)
            CambiarBrilloObjeto(true);
    }

    // =====================================
    // SALIDA DE ZONA
    // =====================================

    private void OnTriggerExit2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (!EsJugadorPermitido(jugador))
            return;

        contactosJugadorLocal =
            Mathf.Max(0, contactosJugadorLocal - 1);

        // Todavia quedan colliders del jugador dentro.

        if (contactosJugadorLocal > 0)
            return;

        TerminarMantener();

        // Ocultar indicador.

        HUDInteraccion.Instancia?.OcultarBoton(this);

        // BOTONES P3.

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

        // Retirar brillo.

        visualNPC?.CambiarBrillo(false);

        if (!parpadeoAutomatico)
            CambiarBrilloObjeto(false);
    }

    // =====================================
    // CAMBIAR BRILLO
    // =====================================

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
    // EJECUTAR INTERACCION
    // =====================================

    public void Interactuar()
    {
        // REGRESO P5.

        if (regresoPasillo != null)
        {
            regresoPasillo.SolicitarRegreso();
            return;
        }

        // PUERTAS P5.

        if (puertaPuzzle != null)
        {
            puertaPuzzle.IntentarAbrir();
            return;
        }

        // NPC.

        if (npcDialogo != null)
        {
            npcDialogo.IniciarDialogo();
            return;
        }

        // VENTANAS Y PUZZLES.

        if (ventanaAbrir != null)
        {
            MantenerBrillo();

            ventanaAbrir.SetActive(true);
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
