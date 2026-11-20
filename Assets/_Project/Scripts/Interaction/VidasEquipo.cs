
using UnityEngine;
using Unity.Netcode;
using System;
using UnityEngine.SceneManagement;

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
            AlAgotarVidas += SolicitarReinicioPorVidas;
        }

        ActualizarHUD(vidasActuales.Value);
    }

    public override void OnNetworkDespawn()
    {
        vidasActuales.OnValueChanged -= AlCambiarVidas;

        if (IsServer)
            AlAgotarVidas -= SolicitarReinicioPorVidas;

        if (Instancia == this)
            Instancia = null;
    }

    // =====================================
    // SOLICITAR PERDIDA DE VIDA
    // =====================================
    
    public void PerderVida()
    {
        if (!IsSpawned)
            return;

        if (EsEscenaP8())
        {
            if (IsServer)
                RegistrarAtrapamientoP8Servidor();
            else
                PerderVidaRpc();

            return;
        }

        if (IsServer)
            PerderVidaServidor();
        else
            PerderVidaRpc();
    }


    
    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void PerderVidaRpc(RpcParams rpcParams = default)
    {
        if (!IsServer)
            return;

        ulong clienteId = rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients.TryGetValue(
            clienteId, out NetworkClient cliente))
            return;

        if (cliente.PlayerObject == null)
            return;

        NetworkPlayerSetup setup =
            cliente.PlayerObject.GetComponent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
            return;

        if (EsEscenaP8())
        {
            RegistrarAtrapamientoP8Servidor();
            return;
        }

        // Se conserva la regla anterior fuera de P8.
        if (setup.EsElian)
            return;

        PerderVidaServidor();
    }


    private bool EsEscenaP8()
    {
        return SceneManager.GetActiveScene().name ==
            "P8_SalaSombras";
    }

    private void RegistrarAtrapamientoP8Servidor()
    {
        if (!IsServer)
            return;

        SupervivenciaP8Controller controlador =
            FindFirstObjectByType<SupervivenciaP8Controller>();

        if (controlador == null || !controlador.IsSpawned)
        {
            Debug.LogError(
                "P8 | No se encontró SupervivenciaP8Controller."
            );
            return;
        }

        controlador.RegistrarAtrapamientoServidor();
    }


    // =====================================
    // DESCONTAR VIDA EN SERVIDOR
    // =====================================

    public bool PerderVidaServidor()
    {
        if (!IsServer || vidasActuales.Value <= 0)
            return false;

        vidasActuales.Value--;

        Debug.Log(
            "RUNNER P2 | VIDAS RESTANTES: " + vidasActuales.Value
        );

        if (vidasActuales.Value <= 0)
        {
            Debug.Log(
                "RUNNER P2 | SIN VIDAS. REINICIANDO NIVEL COMPLETO."
            );

            AlAgotarVidas?.Invoke();

            return false;
        }

        return true;
    }

    // =====================================
    // REINICIO AUTOMATICO
    // =====================================

    private void SolicitarReinicioPorVidas()
    {
        if (!IsServer)
            return;

        ReinicioNivelCooperativo reinicio =
            ReinicioNivelCooperativo.Instancia;

        if (reinicio == null || !reinicio.IsSpawned)
        {
            Debug.LogError(
                "No se encontró ReinicioNivelCooperativo activo."
            );
            return;
        }

        Debug.Log(
            "P8 | VIDAS AGOTADAS. REINICIANDO NIVEL COMPLETO."
        );

        reinicio.ReiniciarDesdeServidor();
    }

    // =====================================
    // RESTAURAR VIDAS
    // =====================================

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
