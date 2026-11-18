
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

    [Header("Audio ambiente por realidad")]
    [SerializeField] private AudioClip ambienteElian;
    [SerializeField] private AudioClip ambienteLia;

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

        // ACTIVAR LA REALIDAD CORRESPONDIENTE

        if (realidadElian != null)
            realidadElian.SetActive(esElian);

        if (realidadLia != null)
            realidadLia.SetActive(!esElian);

        // MOSTRAR UNICAMENTE EL RECOLECTABLE PROPIO

        if (recolectableElian != null)
            recolectableElian.ConfigurarVisibilidadLocal(esElian);

        if (recolectableLia != null)
            recolectableLia.ConfigurarVisibilidadLocal(!esElian);

        // CONFIGURAR AUDIO AMBIENTE LOCAL

        if (AudioManager.Instance != null)
        {
            AudioClip ambienteSeleccionado =
                esElian ? ambienteElian : ambienteLia;

            AudioManager.Instance.ReproducirAmbiente(
                ambienteSeleccionado
            );
        }
        else
        {
            Debug.LogError(
                "No se encontró AudioManager en esta instancia."
            );
        }

        // ACTUALIZAR MISION

        ActualizarMision(esElian);

        Debug.Log(
            "REALIDAD CONFIGURADA: " +
            (esElian ? "ELIAN" : "LIA")
        );

        Debug.Log(
            "AUDIO AMBIENTE: " +
            (esElian ? "AMBIENTE ELIAN" : "AMBIENTE LIA")
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
