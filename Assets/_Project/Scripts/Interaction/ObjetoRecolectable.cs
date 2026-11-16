
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
    private bool visiblePorRealidad = true;

    private NetworkVariable<bool> recolectado =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    // Evento compartido para mostrar la tarjeta local.
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
    // EVENTO COMPARTIDO DE TARJETAS
    // =====================================

    public static void NotificarRecoleccionLocal(
        ObjetoInventario objeto)
    {
        if (objeto == null)
        {
            Debug.LogError(
                "[RECOLECTABLE] No se puede mostrar una tarjeta sin objeto."
            );
            return;
        }

        Debug.Log(
            "[RECOLECTABLE] Mostrando tarjeta: " + objeto.Nombre
        );

        RecoleccionConfirmadaLocal?.Invoke(objeto);
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
                "[RECOLECTABLE] El NetworkObject no está Spawned."
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

        float distancia = Vector2.Distance(
            jugador.transform.position,
            transform.position
        );

        if (distancia > distanciaMaxima)
        {
            Debug.LogWarning(
                "[RECOLECTABLE] Jugador demasiado lejos."
            );
            return;
        }

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

        InventarioJugador inventario =
            jugador.GetComponent<InventarioJugador>();

        if (inventario == null)
        {
            Debug.LogError(
                "[RECOLECTABLE] Jugador sin inventario."
            );
            return;
        }

        bool agregado =
            inventario.AgregarObjetoDesdeServidor(
                objetoInventario.Id
            );

        if (!agregado)
        {
            Debug.LogWarning(
                "[RECOLECTABLE] No se pudo agregar el objeto: " +
                objetoInventario.Id
            );
            return;
        }

        // El servidor registra la recolección.
        recolectado.Value = true;

        AplicarEstado();

        // Notificar únicamente al jugador que recogió el objeto.
        NotificarTarjetaRpc(
            RpcTarget.Single(
                clienteId,
                RpcTargetUse.Temp
            )
        );

        Debug.Log(
            "[RECOLECTABLE] OBJETO RECOLECTADO: " +
            objetoInventario.Nombre +
            " | Personaje: " +
            (esElian ? "Elian" : "Lia")
        );
    }

    // =====================================
    // NOTIFICAR TARJETA AL JUGADOR
    // =====================================

    [Rpc(SendTo.SpecifiedInParams)]
    private void NotificarTarjetaRpc(
        RpcParams rpcParams = default)
    {
        NotificarRecoleccionLocal(objetoInventario);
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
    }

    // =====================================
    // OCULTAR OBJETO EN TODOS LOS CLIENTES
    // =====================================

    private void AplicarEstado()
    {
        bool mostrar =
            visiblePorRealidad && !recolectado.Value;

        foreach (SpriteRenderer sprite in sprites)
        {
            if (sprite != null)
                sprite.enabled = mostrar;
        }

        foreach (Collider2D colisionador in colisionadores)
        {
            if (colisionador != null)
                colisionador.enabled = mostrar;
        }

        if (!mostrar && HUDInteraccion.Instancia != null)
        {
            HUDInteraccion.Instancia.OcultarBoton(
                zonaInteraccion
            );
        }
    }

    public void ConfigurarVisibilidadLocal(bool visible)
    {
        visiblePorRealidad = visible;
        AplicarEstado();
    }
}
