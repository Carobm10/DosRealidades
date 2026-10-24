using UnityEngine;
using Unity.Netcode;

public class ZonaInteraccion : MonoBehaviour
{
    [Header("Texto que vera el jugador")]
    [SerializeField] private string textoAccion = "INTERACTUAR";

    [Header("Accion")]
    [SerializeField] private GameObject ventanaAbrir;

    private void OnTriggerEnter2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null)
            return;

        if (!jugador.IsOwner)
            return;

        if (HUDInteraccion.Instancia != null)
        {
            HUDInteraccion.Instancia.MostrarBoton(
                textoAccion,
                this
            );
        }
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null)
            return;

        if (!jugador.IsOwner)
            return;

        if (HUDInteraccion.Instancia != null)
        {
            HUDInteraccion.Instancia.OcultarBoton(this);
        }
    }

    public void Interactuar()
    {
        if (ventanaAbrir != null)
        {
            ventanaAbrir.SetActive(true);
        }
    }
}