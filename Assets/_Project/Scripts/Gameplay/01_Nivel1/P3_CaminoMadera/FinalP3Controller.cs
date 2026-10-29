using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class FinalP3Controller : NetworkBehaviour
{
    [Header("Indicadores")]
    [SerializeField] private SpriteRenderer indicadorElian;
    [SerializeField] private SpriteRenderer indicadorLia;

    [Header("Colores")]
    [SerializeField] private Color colorApagado = Color.gray;
    [SerializeField] private Color colorListo = Color.green;

    [Header("Cambio de escena")]
    [SerializeField] private string siguienteEscena;

    private NetworkVariable<bool> elianListo =
        new NetworkVariable<bool>(false);

    private NetworkVariable<bool> liaLista =
        new NetworkVariable<bool>(false);

    private bool cambiandoEscena = false;

    public override void OnNetworkSpawn()
    {
        elianListo.OnValueChanged += AlCambiarElian;
        liaLista.OnValueChanged += AlCambiarLia;

        ActualizarVisuales();

        if (IsServer)
        {
            RevisarFinalServidor();
        }
    }

    public override void OnNetworkDespawn()
    {
        elianListo.OnValueChanged -= AlCambiarElian;
        liaLista.OnValueChanged -= AlCambiarLia;
    }

    // ==============================
    // ELIAN
    // ==============================

    public void MarcarElian()
    {
        if (!IsSpawned)
            return;

        MarcarElianRpc();
    }

    [Rpc(SendTo.Server)]
    private void MarcarElianRpc()
    {
        if (cambiandoEscena)
            return;

        if (elianListo.Value)
            return;

        elianListo.Value = true;

        Debug.Log(
            "ELIAN LISTO ✅"
        );

        RevisarFinalServidor();
    }

    // ==============================
    // LIA
    // ==============================

    public void MarcarLia()
    {
        if (!IsSpawned)
            return;

        MarcarLiaRpc();
    }

    [Rpc(SendTo.Server)]
    private void MarcarLiaRpc()
    {
        if (cambiandoEscena)
            return;

        if (liaLista.Value)
            return;

        liaLista.Value = true;

        Debug.Log(
            "LIA LISTA ✅"
        );

        RevisarFinalServidor();
    }

    // ==============================
    // VISUALES
    // ==============================

    private void AlCambiarElian(
        bool anterior,
        bool nuevo)
    {
        ActualizarVisuales();
    }

    private void AlCambiarLia(
        bool anterior,
        bool nuevo)
    {
        ActualizarVisuales();
    }

    private void ActualizarVisuales()
    {
        if (indicadorElian != null)
        {
            indicadorElian.color =
                elianListo.Value
                ? colorListo
                : colorApagado;
        }

        if (indicadorLia != null)
        {
            indicadorLia.color =
                liaLista.Value
                ? colorListo
                : colorApagado;
        }
    }

    // ==============================
    // FINAL COOPERATIVO
    // ==============================

    private void RevisarFinalServidor()
    {
        if (!IsServer)
            return;

        if (cambiandoEscena)
            return;

        if (!elianListo.Value ||
            !liaLista.Value)
        {
            return;
        }

        Debug.Log(
            "P3 COMPLETADO: ambos jugadores estan listos."
        );

        CargarSiguienteEscena();
    }

    private void CargarSiguienteEscena()
    {
        if (string.IsNullOrWhiteSpace(
            siguienteEscena))
        {
            Debug.LogWarning(
                "FinalP3: falta configurar la siguiente escena."
            );

            return;
        }

        if (NetworkManager.Singleton == null)
            return;

        cambiandoEscena = true;

        NetworkManager.Singleton
            .SceneManager
            .LoadScene(
                siguienteEscena,
                LoadSceneMode.Single
            );
    }
}