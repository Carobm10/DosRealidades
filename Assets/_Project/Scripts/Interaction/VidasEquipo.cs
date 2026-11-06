
using UnityEngine;
using Unity.Netcode;
using System;

public class VidasEquipo : NetworkBehaviour
{
    public static VidasEquipo Instancia { get; private set; }

    [SerializeField] private int vidasIniciales = 3;

    private NetworkVariable<int> vidasActuales =
        new NetworkVariable<int>(3);

    public int VidasActuales => vidasActuales.Value;

    public event Action AlAgotarVidas;

    private void Awake()
    {
        Instancia = this;
    }

    public override void OnNetworkSpawn()
    {
        vidasActuales.OnValueChanged += AlCambiarVidas;

        if (IsServer)
            vidasActuales.Value = vidasIniciales;

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
        PerderVidaServidor();
    }

    
    public bool PerderVidaServidor()
    {
        if (!IsServer || vidasActuales.Value <= 0)
            return false;

        vidasActuales.Value--;

        Debug.Log("VIDAS RESTANTES: " + vidasActuales.Value);

        if (vidasActuales.Value == 0)
        {
            SolicitarReinicioRpc();
            return false;
        }

        return true;
    }


    [Rpc(SendTo.Everyone)]
    private void SolicitarReinicioRpc()
    {
        AlAgotarVidas?.Invoke();
    }

    public void RestaurarVidas()
    {
        if (IsServer)
            vidasActuales.Value = vidasIniciales;
    }

    private void AlCambiarVidas(int anterior, int nuevas)
    {
        ActualizarHUD(nuevas);
    }

    private void ActualizarHUD(int vidas)
    {
        HUDVidas.Instancia?.ActualizarVidas(vidas);
    }

    private void OnDestroy()
    {
        if (Instancia == this)
            Instancia = null;
    }
}
