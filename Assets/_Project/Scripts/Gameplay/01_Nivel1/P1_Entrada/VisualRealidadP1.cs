
using UnityEngine;
using Unity.Netcode;

public class VisualRealidadP1 : MonoBehaviour
{
    [Header("Realidades")]
    [SerializeField] private GameObject realidadElian;
    [SerializeField] private GameObject realidadLia;

    [Header("Objetos recolectables")]
    [SerializeField] private ObjetoRecolectable recolectableElian;
    [SerializeField] private ObjetoRecolectable recolectableLia;

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

        // Activar la realidad correspondiente.
        if (realidadElian != null)
            realidadElian.SetActive(esElian);

        if (realidadLia != null)
            realidadLia.SetActive(!esElian);

        // Mostrar únicamente el recolectable propio.
        if (recolectableElian != null)
            recolectableElian.ConfigurarVisibilidadLocal(esElian);

        if (recolectableLia != null)
            recolectableLia.ConfigurarVisibilidadLocal(!esElian);

        ActualizarMision(esElian);

        Debug.Log(
            "REALIDAD CONFIGURADA: " +
            (esElian ? "ELIAN" : "LIA")
        );
    }

    private void ActualizarMision(bool esElian)
    {
        if (HUDMision.Instancia == null)
            return;

        if (esElian)
        {
            HUDMision.Instancia.CambiarMision(
                "Selecciona la figura correcta para abrir la puerta"
            );
        }
        else
        {
            HUDMision.Instancia.CambiarMision(
                "Ayuda a Elian a identificar el símbolo correcto"
            );
        }
    }
}
