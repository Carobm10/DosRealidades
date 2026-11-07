
using UnityEngine;
using Unity.Netcode;

public class ZonaSalidaP3 : MonoBehaviour
{
    public enum Personaje
    {
        Elian,
        Lia
    }

    [Header("Configuracion")]
    [SerializeField] private Personaje personajePermitido;

    [SerializeField] private ControlFinalP3 controlFinal;

    private bool salidaRegistrada;

    private void Awake()
    {
        if (controlFinal == null)
            controlFinal = FindAnyObjectByType<ControlFinalP3>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (salidaRegistrada)
            return;

        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        bool esLia = IdentidadJugadorLocal.EsLia();

        bool esPersonajeCorrecto =
            personajePermitido == Personaje.Lia
            ? esLia
            : !esLia;

        if (!esPersonajeCorrecto)
            return;

        if (controlFinal == null)
            controlFinal = FindAnyObjectByType<ControlFinalP3>();

        if (controlFinal == null)
            return;

        salidaRegistrada = true;

        controlFinal.RegistrarSalida();

        Debug.Log(
            "P3: " + personajePermitido +
            " ATRAVESO SU PUERTA."
        );
    }
}
