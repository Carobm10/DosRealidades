
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

    [Header("Brillo de objeto opcional")]
    [SerializeField] private SpriteRenderer objetoBrillo;
    [SerializeField] private Sprite spriteBrillo;

    [Header("Parpadeo automatico")]
    [SerializeField] private bool parpadeoAutomatico = false;
    [SerializeField] private float tiempoNormal = 0.7f;
    [SerializeField] private float tiempoBrillo = 0.7f;

    private Sprite spriteOriginal;
    private Coroutine rutinaParpadeo;
    private int contactosJugadorLocal = 0;
    private bool puzzleEnCurso = false;

    private void Awake()
    {
        if (npcDialogo == null)
            npcDialogo = GetComponent<NPCDialogo>();

        if (visualNPC == null)
            visualNPC = GetComponent<NPCVisualController>();

        if (objetoBrillo != null)
            spriteOriginal = objetoBrillo.sprite;
    }

    private void OnEnable()
    {
        if (parpadeoAutomatico &&
            objetoBrillo != null &&
            spriteBrillo != null)
        {
            rutinaParpadeo = StartCoroutine(Parpadear());
        }
    }

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

    private void OnTriggerEnter2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        contactosJugadorLocal++;

        HUDInteraccion.Instancia?.MostrarBoton(
            textoAccion, this);

        visualNPC?.CambiarBrillo(true);

        if (!parpadeoAutomatico)
            CambiarBrilloObjeto(true);
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        contactosJugadorLocal =
            Mathf.Max(0, contactosJugadorLocal - 1);

        if (contactosJugadorLocal > 0)
            return;

        HUDInteraccion.Instancia?.OcultarBoton(this);

        visualNPC?.CambiarBrillo(false);

        if (!parpadeoAutomatico)
            CambiarBrilloObjeto(false);
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

    private void OnDisable()
    {
        contactosJugadorLocal = 0;

        HUDInteraccion.Instancia?.OcultarBoton(this);

        visualNPC?.CambiarBrillo(false);

        if (rutinaParpadeo != null)
        {
            StopCoroutine(rutinaParpadeo);
            rutinaParpadeo = null;
        }

        // Siempre restaurar la imagen normal.
        CambiarBrilloObjeto(false);
    }

    public void Interactuar()
    {
        if (npcDialogo != null)
        {
            npcDialogo.IniciarDialogo();
            return;
        }

        if (ventanaAbrir != null)
        {
            MantenerBrillo();
            ventanaAbrir.SetActive(true);
        }
    }

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
        if (!parpadeoAutomatico || !isActiveAndEnabled)
            return;

        puzzleEnCurso = false;

        if (rutinaParpadeo == null)
            rutinaParpadeo = StartCoroutine(Parpadear());
    }

    private void Update()
    {
        if (!parpadeoAutomatico || !puzzleEnCurso)
            return;

        if (ventanaAbrir != null &&
            !ventanaAbrir.activeInHierarchy)
        {
            ReanudarParpadeo();
        }
    }
}
