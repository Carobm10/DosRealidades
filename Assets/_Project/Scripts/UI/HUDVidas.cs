
using UnityEngine;
using UnityEngine.UI;

public class HUDVidas : MonoBehaviour
{
    public static HUDVidas Instancia { get; private set; }

    [Header("Contenedores")]
    [SerializeField] private GameObject vidasElian;
    [SerializeField] private GameObject vidasLia;

    [Header("Corazones Elian")]
    [SerializeField] private Image[] corazonesElian;

    [Header("Sprites Elian")]
    [SerializeField] private Sprite corazonElianConVida;
    [SerializeField] private Sprite corazonElianSinVida;

    [Header("Corazones Lia")]
    [SerializeField] private Image[] corazonesLia;

    [Header("Sprites Lia")]
    [SerializeField] private Sprite corazonLiaConVida;
    [SerializeField] private Sprite corazonLiaSinVida;

    private void Awake()
    {
        Instancia = this;
    }

    private void Start()
    {
        ConfigurarVisualJugador();
        StartCoroutine(InicializarVidasHUD());
    }

    private System.Collections.IEnumerator InicializarVidasHUD()
    {
        // Esperar hasta que el sistema de vidas
        // exista y esté conectado a la red.
        while (VidasEquipo.Instancia == null ||
            !VidasEquipo.Instancia.IsSpawned)
        {
            yield return null;
        }

        // Mostrar las vidas reales del equipo.
        ActualizarVidas(VidasEquipo.Instancia.VidasActuales);
    }

    private void ConfigurarVisualJugador()
    {
        bool esElian = IdentidadJugadorLocal.EsElian();

        if (vidasElian != null)
            vidasElian.SetActive(esElian);

        if (vidasLia != null)
            vidasLia.SetActive(!esElian);
    }

    public void ActualizarVidas(int vidas)
    {
        // Actualizar ambas filas aunque una esté oculta.

        for (int i = 0; i < corazonesElian.Length; i++)
        {
            if (corazonesElian[i] == null)
                continue;

            corazonesElian[i].sprite =
                i < vidas
                ? corazonElianConVida
                : corazonElianSinVida;
        }

        for (int i = 0; i < corazonesLia.Length; i++)
        {
            if (corazonesLia[i] == null)
                continue;

            corazonesLia[i].sprite =
                i < vidas
                ? corazonLiaConVida
                : corazonLiaSinVida;
        }
    }

    private void OnDestroy()
    {
        if (Instancia == this)
            Instancia = null;
    }
}
