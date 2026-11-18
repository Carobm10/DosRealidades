
using UnityEngine;
using Unity.Netcode;

public class VisualRealidadP3 : MonoBehaviour
{
    [Header("Realidades")]
    [SerializeField] private GameObject realidadElian;
    [SerializeField] private GameObject realidadLia;

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

        // Activar la realidad correspondiente
        if (realidadElian != null)
            realidadElian.SetActive(esElian);

        if (realidadLia != null)
            realidadLia.SetActive(!esElian);

        // Seleccionar y reproducir el ambiente local
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
                "P3: No se encontró AudioManager."
            );
        }

        // Actualizar misión
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
