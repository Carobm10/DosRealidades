
using UnityEngine;
using Unity.Netcode;

public class VisualRealidadP2 : MonoBehaviour
{
    [Header("Realidades")]
    [SerializeField] private GameObject realidadElian;
    [SerializeField] private GameObject realidadLia;

    [Header("Botones de pausa")]
    [SerializeField] private GameObject botonPausaElian;
    [SerializeField] private GameObject botonPausaLia;

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

        // ACTIVAR REALIDAD CORRESPONDIENTE

        if (realidadElian != null)
            realidadElian.SetActive(esElian);

        if (realidadLia != null)
            realidadLia.SetActive(!esElian);

        // BOTON DE PAUSA POR JUGADOR

        if (botonPausaElian != null)
            botonPausaElian.SetActive(esElian);

        if (botonPausaLia != null)
            botonPausaLia.SetActive(!esElian);

        // AUDIO AMBIENTE

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
            "REALIDAD: " +
            (esElian ? "ELIAN" : "LIA") +
            " | BOTON PAUSA: " +
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
