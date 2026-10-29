using UnityEngine;
using Unity.Netcode;

public class VisualRealidadP1 : MonoBehaviour
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
        // En prueba directa usamos el selector de ModoPrueba.
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
        // En multiplayer real:
        // Host = Elian / Client = Lia
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