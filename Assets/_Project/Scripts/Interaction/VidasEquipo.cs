using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class VidasEquipo : NetworkBehaviour
{
    public static VidasEquipo Instancia { get; private set; }

    [SerializeField] private int vidasIniciales = 3;

    private NetworkVariable<int> vidasActuales =
        new NetworkVariable<int>(3);

    public int VidasActuales => vidasActuales.Value;

    private void Awake()
    {
        Instancia = this;
    }

    public override void OnNetworkSpawn()
    {
        vidasActuales.OnValueChanged += AlCambiarVidas;

        if (IsServer)
        {
            vidasActuales.Value = vidasIniciales;
        }

        ActualizarHUD(vidasActuales.Value);
    }

    public override void OnNetworkDespawn()
    {
        vidasActuales.OnValueChanged -= AlCambiarVidas;
    }

    public void PerderVida()
    {
        if (!IsSpawned)
            return;

        PerderVidaRpc();
    }

    [Rpc(SendTo.Server)]
    private void PerderVidaRpc()
    {
        if (vidasActuales.Value <= 0)
            return;

        vidasActuales.Value--;

        Debug.Log(
            "VIDA DE EQUIPO: " +
            vidasActuales.Value
        );
    }

    private void AlCambiarVidas(
        int anterior,
        int nuevas)
    {
        ActualizarHUD(nuevas);

        if (nuevas <= 0)
        {
            Debug.Log(
                "SIN VIDAS - luego definiremos qué ocurre."
            );
        }
    }

    private void ActualizarHUD(int vidas)
    {
        HUDVidas.Instancia?.ActualizarVidas(vidas);
    }

}