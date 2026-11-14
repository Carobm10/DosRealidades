
using System;
using UnityEngine;
using Unity.Netcode;

public class ObjetoRecolectable : NetworkBehaviour
{
    public enum PersonajePermitido
    {
        Ambos,
        SoloElian,
        SoloLia
    }

    [Header("Objeto que se recolecta")]
    [SerializeField] private ObjetoInventario objetoInventario;

    [Header("Personaje autorizado")]
    [SerializeField]
    private PersonajePermitido personajePermitido =
        PersonajePermitido.Ambos;

    [Header("Validacion de distancia")]
    [SerializeField] private float distanciaMaxima = 3f;

    private SpriteRenderer[] sprites;
    private Collider2D[] colisionadores;
    private ZonaInteraccion zonaInteraccion;

    private NetworkVariable<bool> recolectado =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private NetworkVariable<ulong> recolectadoPor =
        new NetworkVariable<ulong>(
            ulong.MaxValue,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    // Evento para mostrar la tarjeta de objeto recolectado.
    public static event Action<ObjetoInventario>
        RecoleccionConfirmadaLocal;

    public bool EstaRecolectado => recolectado.Value;

    private void Awake()
    {
        sprites =
            GetComponentsInChildren<SpriteRenderer>(true);

        colisionadores =
            GetComponentsInChildren<Collider2D>(true);

        zonaInteraccion =
            GetComponent<ZonaInteraccion>();
    }

    public override void OnNetworkSpawn()
    {
        recolectado.OnValueChanged += AlCambiarRecolectado;

        AplicarEstado();
    }

    public override void OnNetworkDespawn()
    {
        recolectado.OnValueChanged -= AlCambiarRecolectado;
    }

    // =====================================
    // SOLICITAR RECOLECCION
    // =====================================

    
    public void SolicitarRecoleccion()
    {
        Debug.Log(
            "[RECOLECTABLE] Solicitud recibida. " +
            "IsSpawned: " + IsSpawned +
            " | IsClient: " + IsClient +
            " | Recolectado: " + recolectado.Value
        );

        if (!IsSpawned)
        {
            Debug.LogError(
                "[RECOLECTABLE] ERROR: El NetworkObject no está Spawned."
            );
            return;
        }

        if (!IsClient)
        {
            Debug.LogWarning(
                "[RECOLECTABLE] Este jugador no es cliente."
            );
            return;
        }

        if (recolectado.Value)
        {
            Debug.LogWarning(
                "[RECOLECTABLE] El objeto ya fue recolectado."
            );
            return;
        }

        if (objetoInventario == null)
        {
            Debug.LogError(
                "[RECOLECTABLE] Falta asignar ObjetoInventario."
            );
            return;
        }

        Debug.Log(
            "[RECOLECTABLE] Enviando solicitud al servidor..."
        );

        SolicitarRecoleccionRpc();
    }


    // =====================================
    // VALIDACION EN SERVIDOR
    // =====================================

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void SolicitarRecoleccionRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer || !IsSpawned ||
            recolectado.Value ||
            objetoInventario == null)
            return;

        ulong clienteId =
            rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients
            .TryGetValue(clienteId, out NetworkClient cliente))
            return;

        NetworkObject jugador = cliente.PlayerObject;

        if (jugador == null || !jugador.IsSpawned)
            return;

        // Validar distancia.
        float distancia = Vector2.Distance(
            jugador.transform.position,
            transform.position
        );

        if (distancia > distanciaMaxima)
        {
            Debug.LogWarning(
                "RECOLECTABLE: Jugador demasiado lejos."
            );
            return;
        }

        // Identificar personaje.
        NetworkPlayerSetup setup =
            jugador.GetComponent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
            return;

        bool esElian = setup.EsElian;

        if (personajePermitido ==
            PersonajePermitido.SoloElian && !esElian)
            return;

        if (personajePermitido ==
            PersonajePermitido.SoloLia && esElian)
            return;

        // Obtener inventario del jugador correcto.
        InventarioJugador inventario =
            jugador.GetComponent<InventarioJugador>();

        if (inventario == null)
        {
            Debug.LogError(
                "RECOLECTABLE: Jugador sin inventario."
            );
            return;
        }

        // Agregar objeto al inventario.
        bool agregado =
            inventario.AgregarObjetoDesdeServidor(
                objetoInventario.Id
            );

        if (!agregado)
            return;

        // Registrar quién lo recogió.
        recolectadoPor.Value = clienteId;

        // Avisar a todos los clientes.
        recolectado.Value = true;

        AplicarEstado();

        Debug.Log(
            "OBJETO RECOLECTADO: " +
            objetoInventario.Nombre +
            " | Personaje: " +
            (esElian ? "Elian" : "Lia")
        );
    }

    // =====================================
    // CAMBIO DE ESTADO
    // =====================================

    private void AlCambiarRecolectado(
        bool estadoAnterior,
        bool estadoNuevo)
    {
        if (!estadoNuevo)
            return;

        AplicarEstado();

        // Mostrar recompensa únicamente
        // al jugador que realizó la recolección.
        if (NetworkManager.Singleton != null &&
            NetworkManager.Singleton.IsClient &&
            NetworkManager.Singleton.LocalClientId ==
            recolectadoPor.Value)
        {
            RecoleccionConfirmadaLocal?.Invoke(
                objetoInventario
            );
        }
    }

    // =====================================
    // OCULTAR OBJETO EN TODOS LOS CLIENTES
    // =====================================

    private void AplicarEstado()
    {
        if (!recolectado.Value)
            return;

        foreach (SpriteRenderer sprite in sprites)
        {
            if (sprite != null)
                sprite.enabled = false;
        }

        foreach (Collider2D colisionador in colisionadores)
        {
            if (colisionador != null)
                colisionador.enabled = false;
        }

        if (HUDInteraccion.Instancia != null)
        {
            HUDInteraccion.Instancia.OcultarBoton(
                zonaInteraccion
            );
        }
    }
}
