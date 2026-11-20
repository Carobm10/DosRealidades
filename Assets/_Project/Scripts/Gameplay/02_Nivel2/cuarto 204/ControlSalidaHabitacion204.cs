
using UnityEngine;
using Unity.Netcode;

public class ControlSalidaHabitacion204 : MonoBehaviour
{
    [Header("Salida de la habitacion")]
    [SerializeField]
    private ZonaSalidaCooperativa zonaSalida;

    [Header("Objetos necesarios para salir")]
    [SerializeField]
    private ObjetoRecolectable[] objetosNecesarios;

    private bool salidaActivada;

    private void Update()
    {
        if (salidaActivada)
            return;

        NetworkManager red = NetworkManager.Singleton;

        if (red == null || !red.IsServer)
            return;

        if (zonaSalida == null ||
            !zonaSalida.IsSpawned)
            return;

        if (objetosNecesarios == null ||
            objetosNecesarios.Length == 0)
            return;

        foreach (ObjetoRecolectable objeto in objetosNecesarios)
        {
            if (objeto == null || !objeto.EstaRecolectado)
                return;
        }

        zonaSalida.HabilitarSalidaSinCinematica();

        if (zonaSalida.SalidaHabilitada)
        {
            salidaActivada = true;

            Debug.Log(
                "204: OBJETOS RECOLECTADOS. " +
                "SALIDA COOPERATIVA HABILITADA."
            );
        }
    }
}
