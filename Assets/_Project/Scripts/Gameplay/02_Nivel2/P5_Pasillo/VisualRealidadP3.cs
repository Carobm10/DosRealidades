using UnityEngine;
using Unity.Netcode;

public class VisualRealidadP3 : MonoBehaviour
{
    [SerializeField] private GameObject realidadElian;
    [SerializeField] private GameObject realidadLia;

    private void Start()
    {
        AplicarRealidad();
    }

    private void AplicarRealidad()
    {
        bool esElian;

#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
        {
            esElian = RolPruebaJugador.Instancia.EsElian();
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

        realidadElian.SetActive(esElian);
        realidadLia.SetActive(!esElian);

        if (HUDMision.Instancia == null)
            return;

        if (esElian)
        {
            HUDMision.Instancia.CambiarMision(
                "Guía a Lía por el camino seguro"
            );
        }
        else
        {
            HUDMision.Instancia.CambiarMision(
                "Cruza siguiendo las indicaciones de Elian"
            );
        }
    }
}