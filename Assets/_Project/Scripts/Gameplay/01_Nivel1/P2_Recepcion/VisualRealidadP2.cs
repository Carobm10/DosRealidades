using UnityEngine;
using Unity.Netcode;

public class VisualRealidadP2 : MonoBehaviour
{
    [Header("Realidades")]
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
        // Si abrimos P2 directamente,
        // usamos el selector de ModoPrueba.
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
        // Multiplayer real:
        // Host = Elian
        // Client = Lia
        esElian =
            NetworkManager.Singleton != null &&
            NetworkManager.Singleton.IsHost;
#endif

        realidadElian.SetActive(esElian);
        realidadLia.SetActive(!esElian);
        ActualizarMision(esElian);
    }

    private void ActualizarMision(bool esElian)
    {
        if (HUDMision.Instancia == null)
            return;

        if (esElian)
        {
            HUDMision.Instancia.CambiarMision(
                "Investiga el mostrador de recepción"
            );
        }
        else
        {
            HUDMision.Instancia.CambiarMision(
                "Busca una pista que Elian no pueda ver"
            );
        }
    }
}