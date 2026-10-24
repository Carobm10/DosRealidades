using UnityEngine;
using Unity.Netcode;

public class PuntoFinalJugador : MonoBehaviour
{
    public enum PersonajeObjetivo
    {
        Elian,
        Lia
    }

    [SerializeField] private PersonajeObjetivo personajeObjetivo;
    [SerializeField] private FinalP3Controller finalP3;

    private void OnTriggerEnter2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null)
            return;

        if (!jugador.IsOwner)
            return;

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
                jugador.OwnerClientId ==
                NetworkManager.ServerClientId;
        }
#else
        esElian =
            jugador.OwnerClientId ==
            NetworkManager.ServerClientId;
#endif

        if (personajeObjetivo == PersonajeObjetivo.Elian &&
            esElian)
        {
            finalP3.MarcarElian();
        }

        if (personajeObjetivo == PersonajeObjetivo.Lia &&
            !esElian)
        {
            finalP3.MarcarLia();
        }
    }
}