using UnityEngine;
using Unity.Netcode;

public class VidaJugador : NetworkBehaviour
{
    [SerializeField] private int vidasIniciales = 3;

    private NetworkVariable<int> vidas =
        new NetworkVariable<int>(3);

    public int VidasActuales => vidas.Value;

    public override void OnNetworkSpawn()
    {
        vidas.OnValueChanged += AlCambiarVidas;

        if (IsServer)
        {
            vidas.Value = vidasIniciales;
        }
    }

    public override void OnNetworkDespawn()
    {
        vidas.OnValueChanged -= AlCambiarVidas;
    }

    public void PerderVida()
    {
        if (!IsOwner)
            return;

        PerderVidaRpc();
    }

    [Rpc(SendTo.Server)]
    private void PerderVidaRpc()
    {
        if (vidas.Value <= 0)
            return;

        vidas.Value--;

        Debug.Log(
            "Jugador " +
            OwnerClientId +
            " | Vidas: " +
            vidas.Value
        );
    }

    private void AlCambiarVidas(
        int anterior,
        int nuevas)
    {
        Debug.Log(
            "Vidas: " +
            anterior +
            " → " +
            nuevas
        );

        // Luego conectaremos aquí
        // los corazones del HUD.
    }
}