
using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class ZonaInteraccion : MonoBehaviour
{
    [Header("Interaccion")]
    [SerializeField] private string textoAccion = "INTERACTUAR";

    [Header("Ventana opcional")]
    [SerializeField] private GameObject ventanaAbrir;

    [Header("NPC opcional")]
    [SerializeField] private NPCDialogo npcDialogo;

    [Header("Control visual NPC")]
    [SerializeField] private NPCVisualController visualNPC;
    [Header("Puerta P5")]
    [SerializeField] private PuertaPuzzleP5 puertaPuzzle;

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

    [Header("Regreso P5")]
    [SerializeField] private RegresoPasilloP5 regresoPasillo;

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
        if (npcDialogo == null)
            npcDialogo = GetComponent<NPCDialogo>();

        if (visualNPC == null)
            visualNPC = GetComponent<NPCVisualController>();

        if (objetoBrillo != null)
            spriteOriginal = objetoBrillo.sprite;

        if (esBotonFinalP3 && controlFinal == null)
        {
            controlFinal =
                FindAnyObjectByType<ControlFinalP3>();
        }
        if (puertaPuzzle == null)
            puertaPuzzle = GetComponent<PuertaPuzzleP5>();

        if (regresoPasillo == null)
            regresoPasillo = GetComponent<RegresoPasilloP5>();
    }

    private void OnEnable()
    {
        // Los botones P3 utilizan Animator.
        // No deben tener parpadeo por cambio de Sprite.
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
    // PARPADEO DE OBJETOS NORMALES
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

        HUDInteraccion.Instancia?.MostrarBoton(
            textoAccion,
            this
        );

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

            Debug.Log(
                "P3: JUGADOR ENTRO EN ZONA DEL BOTON"
            );

            return;
        }

        visualNPC?.CambiarBrillo(true);

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

            Debug.Log(
                "P3: JUGADOR SALIO DE ZONA DEL BOTON"
            );

            return;
        }

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
    // INTERACCIONES NORMALES
    // =====================================

    public void Interactuar()
    {
        if (regresoPasillo != null)
        {
            regresoPasillo.SolicitarRegreso();
            return;
        }
        // PUERTAS DEL NIVEL P5
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

        // VENTANAS
        if (ventanaAbrir != null)
        {
            MantenerBrillo();
            ventanaAbrir.SetActive(true);
        }
    }

    // =====================================
    // PULSACION MANTENIDA
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

        Debug.Log("P3: SE SOLTO EL BOTON");
    }

    // =====================================
    // BRILLO DE OBJETOS Y PUZZLES
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
