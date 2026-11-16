
using UnityEngine;
using Unity.Netcode;

public class ZoomPuerta201Local : MonoBehaviour
{
    [Header("Puntos de enfoque")]
    [SerializeField] private Transform puntoElian;
    [SerializeField] private Transform puntoLia;

    [Header("Duracion")]
    [SerializeField] private float tiempoPermanencia = 1.5f;

    public void EnfocarElian()
    {
        Enfocar(puntoElian);
    }

    public void EnfocarLia()
    {
        Enfocar(puntoLia);
    }

    private void Enfocar(Transform punto)
    {
        if (punto == null)
        {
            Debug.LogError("ZOOM 201: Falta asignar el punto de enfoque.");
            return;
        }

        if (NetworkManager.Singleton == null ||
            NetworkManager.Singleton.LocalClient == null)
            return;

        NetworkObject jugador =
            NetworkManager.Singleton.LocalClient.PlayerObject;

        if (jugador == null)
            return;

        CamaraJugadorLocal camara =
            jugador.GetComponent<CamaraJugadorLocal>();

        if (camara == null)
        {
            Debug.LogError("ZOOM 201: No se encontró CamaraJugadorLocal.");
            return;
        }

        camara.EnfocarConZoom(
            punto.position,
            tiempoPermanencia
        );

        Debug.Log("ZOOM 201: Enfocando puerta local.");
    }
}
