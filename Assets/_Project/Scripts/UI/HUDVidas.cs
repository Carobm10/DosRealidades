using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

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
    }

    private void ConfigurarVisualJugador()
    {
        bool esElian;

#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
        {
            esElian =
                RolPruebaJugador.Instancia.EsElian();
        }
        else
        {
            esElian =
                NetworkManager.Singleton == null ||
                NetworkManager.Singleton.IsHost;
        }
#else
        esElian =
            NetworkManager.Singleton != null &&
            NetworkManager.Singleton.IsHost;
#endif

        if (vidasElian != null)
            vidasElian.SetActive(esElian);

        if (vidasLia != null)
            vidasLia.SetActive(!esElian);
    }

    public void ActualizarVidas(int vidas)
    {
        // Actualizamos ambas filas aunque una esté oculta.
        // Así siempre quedan sincronizadas.

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
}