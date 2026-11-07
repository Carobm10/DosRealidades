
using UnityEngine;
using Unity.Netcode;
using System;

public class VidasEquipo : NetworkBehaviour
{
    public static VidasEquipo Instancia { get; private set; }

    [Header("Configuración")]
    [SerializeField] private int vidasIniciales = 3;

    private NetworkVariable<int> vidasActuales =
        new NetworkVariable<int>(
            3,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    public int VidasActuales => vidasActuales.Value;

    public event Action AlAgotarVidas;

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            Debug.LogError("Hay más de un VidasEquipo en la escena.");
            return;
        }

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

        if (Instancia == this)
            Instancia = null;
    }

    // Solicitud para perder una vida.
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

    // Únicamente el servidor descuenta las vidas.
    public bool PerderVidaServidor()
    {
        if (!IsServer || vidasActuales.Value <= 0)
            return false;

        vidasActuales.Value--;

        Debug.Log(
            "VIDAS RESTANTES: " + vidasActuales.Value
        );

        if (vidasActuales.Value <= 0)
        {
            Debug.Log("EQUIPO SIN VIDAS. REINICIANDO CAMINO.");

            AlAgotarVidas?.Invoke();

            return false;
        }

        return true;
    }

    // Restaurar las vidas al reiniciar el camino.
    public void RestaurarVidas()
    {
        if (!IsServer)
            return;

        vidasActuales.Value = vidasIniciales;

        ActualizarHUD(vidasActuales.Value);

        Debug.Log("VIDAS RESTAURADAS: " + vidasIniciales);
    }

    private void AlCambiarVidas(int anterior, int nuevas)
    {
        ActualizarHUD(nuevas);
    }

    private void ActualizarHUD(int vidas)
    {
        HUDVidas.Instancia?.ActualizarVidas(vidas);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();

        if (Instancia == this)
            Instancia = null;
    }
}
