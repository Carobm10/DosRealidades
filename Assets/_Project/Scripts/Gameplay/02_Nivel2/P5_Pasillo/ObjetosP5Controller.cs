using UnityEngine;
using Unity.Netcode;

public class ObjetosP5Controller : NetworkBehaviour
{
    public enum TipoObjetoP5
    {
        Fusible,
        SelloEco
    }

    [Header("Objetos visuales")]
    [SerializeField] private GameObject fusible;
    [SerializeField] private GameObject selloEco;

    private NetworkVariable<bool> fusibleRecogido =
        new NetworkVariable<bool>(false);

    private NetworkVariable<bool> selloRecogido =
        new NetworkVariable<bool>(false);

    public override void OnNetworkSpawn()
    {
        fusibleRecogido.OnValueChanged += AlCambiarFusible;
        selloRecogido.OnValueChanged += AlCambiarSello;

        ActualizarVisuales();
        RevisarObjetosCompletos();
    }

    public override void OnNetworkDespawn()
    {
        fusibleRecogido.OnValueChanged -= AlCambiarFusible;
        selloRecogido.OnValueChanged -= AlCambiarSello;
    }

    public void IntentarRecoger(TipoObjetoP5 tipo)
    {
        if (!IsSpawned)
            return;

        RecogerObjetoRpc((int)tipo);
    }

    [Rpc(SendTo.Server)]
    private void RecogerObjetoRpc(
        int tipo,
        RpcParams rpcParams = default)
    {
        ulong clientId =
            rpcParams.Receive.SenderClientId;

        bool esElian;

#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
        {
            esElian =
                RolPruebaJugador.Instancia.EsElian();
        }
        else
        {
            esElian =
                clientId ==
                NetworkManager.ServerClientId;
        }
#else
        esElian =
            clientId ==
            NetworkManager.ServerClientId;
#endif

        TipoObjetoP5 objeto =
            (TipoObjetoP5)tipo;

        if (objeto == TipoObjetoP5.Fusible)
        {
            if (!esElian)
                return;

            if (fusibleRecogido.Value)
                return;

            fusibleRecogido.Value = true;

            Debug.Log(
                "ELIAN recogio el FUSIBLE ✅"
            );
        }

        if (objeto == TipoObjetoP5.SelloEco)
        {
            if (esElian)
                return;

            if (selloRecogido.Value)
                return;

            selloRecogido.Value = true;

            Debug.Log(
                "LIA recogio el SELLO DE ECO ✅"
            );
        }

        RevisarObjetosCompletos();
    }

    private void AlCambiarFusible(
        bool anterior,
        bool nuevo)
    {
        ActualizarVisuales();
        RevisarObjetosCompletos();
    }

    private void AlCambiarSello(
        bool anterior,
        bool nuevo)
    {
        ActualizarVisuales();
        RevisarObjetosCompletos();
    }

    private void ActualizarVisuales()
    {
        if (fusible != null)
        {
            fusible.SetActive(
                !fusibleRecogido.Value
            );
        }

        if (selloEco != null)
        {
            selloEco.SetActive(
                !selloRecogido.Value
            );
        }
    }

    private void RevisarObjetosCompletos()
    {
        if (!fusibleRecogido.Value ||
            !selloRecogido.Value)
        {
            return;
        }

        if (HUDMision.Instancia != null)
        {
            HUDMision.Instancia.CambiarMision(
                "Activa el sistema de energía"
            );
        }

        Debug.Log(
            "P5: FUSIBLE + SELLO DE ECO CONSEGUIDOS ✅"
        );
    }
}