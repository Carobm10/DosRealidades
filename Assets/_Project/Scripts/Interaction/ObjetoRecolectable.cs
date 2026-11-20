
using System;
using System.Collections;
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

    [Header("Tarjeta de recoleccion")]
    [SerializeField] private bool mostrarTarjetaInmediatamente;

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

        RecoleccionConfirmadaLocal?.Invoke(objeto);
    }

    // =====================================
    // SOLICITAR RECOLECCION
    // =====================================

    public void SolicitarRecoleccion()
    {
        if (!IsSpawned ||
            !IsClient ||
            recolectado.Value ||
            objetoInventario == null)
            return;

        SolicitarRecoleccionRpc();
    }

    // =====================================
    // VALIDACION EN SERVIDOR
    // =====================================

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void SolicitarRecoleccionRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer ||
            !IsSpawned ||
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
            return;

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
            return;

        bool agregado =
            inventario.AgregarObjetoDesdeServidor(
                objetoInventario.Id
            );

        if (!agregado)
            return;

        recolectado.Value = true;

        AplicarEstado();

        NotificarTarjetaRpc(
            RpcTarget.Single(
                clienteId,
                RpcTargetUse.Temp
            )
        );

        Debug.Log(
            "[RECOLECTABLE] RECOLECTADO: " +
            objetoInventario.Id +
            " | Jugador: " +
            (esElian ? "Elian" : "Lia")
        );
    }

    // =====================================
    // NOTIFICAR TARJETA
    // =====================================

    [Rpc(SendTo.SpecifiedInParams)]
    private void NotificarTarjetaRpc(
        RpcParams rpcParams = default)
    {
        if (mostrarTarjetaInmediatamente)
        {
            StartCoroutine(
                EsperarInventarioYMostrarTarjeta()
            );

            return;
        }

        NotificarRecoleccionLocal(objetoInventario);
    }

    private IEnumerator EsperarInventarioYMostrarTarjeta()
    {
        float tiempo = 0f;
        const float tiempoMaximo = 8f;

        while (tiempo < tiempoMaximo)
        {
            NetworkManager red = NetworkManager.Singleton;

            NetworkObject jugadorLocal = null;

            if (red != null && red.LocalClient != null)
                jugadorLocal = red.LocalClient.PlayerObject;

            InventarioJugador inventarioLocal =
                jugadorLocal != null
                    ? jugadorLocal.GetComponent<InventarioJugador>()
                    : null;

            InventarioUI ui = InventarioUI.Instancia;

            if (ui == null || !ui.isActiveAndEnabled)
                ui = FindFirstObjectByType<InventarioUI>();

            if (inventarioLocal != null &&
                ui != null &&
                objetoInventario != null &&
                inventarioLocal.TieneObjeto(objetoInventario.Id))
            {
                ui.MostrarTarjetaPorId(objetoInventario.Id);

                Debug.Log(
                    "[RECOLECTABLE] TARJETA MOSTRADA DIRECTAMENTE: " +
                    objetoInventario.Id
                );

                yield break;
            }

            tiempo += Time.unscaledDeltaTime;
            yield return null;
        }

        Debug.LogError(
            "[RECOLECTABLE] No se pudo mostrar la tarjeta. " +
            "Revisar InventarioUI y sincronizacion del inventario."
        );
    }

    // =====================================
    // CAMBIO DE ESTADO
    // =====================================

    private void AlCambiarRecolectado(
        bool estadoAnterior,
        bool estadoNuevo)
    {
        if (estadoNuevo)
            AplicarEstado();
    }

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
