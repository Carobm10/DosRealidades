
using UnityEngine;
using Unity.Netcode;

public class VisualRealidadP2 : MonoBehaviour
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

        // ACTIVAR REALIDAD CORRESPONDIENTE

        if (realidadElian != null)
            realidadElian.SetActive(esElian);

        if (realidadLia != null)
            realidadLia.SetActive(!esElian);

        // CONFIGURAR AUDIO AMBIENTE

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
                "P2: No se encontró AudioManager."
            );
        }

        // ACTUALIZAR MISION

        ActualizarMision(esElian);

        Debug.Log(
            "P2 - REALIDAD CONFIGURADA: " +
            (esElian ? "ELIAN" : "LIA")
        );

        Debug.Log(
            "P2 - AUDIO: " +
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
