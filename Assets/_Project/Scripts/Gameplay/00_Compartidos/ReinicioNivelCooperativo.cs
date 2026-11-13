
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(NetworkObject))]
public class ReinicioNivelCooperativo : NetworkBehaviour
{
    public static ReinicioNivelCooperativo Instancia
        { get; private set; }

    [Header("Configuracion")]
    [SerializeField] private float esperaAntesDeRecargar = 0.3f;

    private bool reiniciando;

    private void Awake()
    {
        Instancia = this;
    }

    public override void OnNetworkSpawn()
    {
        reiniciando = false;
    }

    // Lo puede solicitar Host o Client.
    public void SolicitarReinicio()
    {
        if (!IsSpawned || reiniciando)
            return;

        SolicitarReinicioRpc();
    }

    [Rpc(
        SendTo.Server,
        RequireOwnership = false
    )]
    private void SolicitarReinicioRpc()
    {
        if (!IsServer || reiniciando)
            return;

        reiniciando = true;

        Debug.Log(
            "REINICIO: preparando reinicio cooperativo."
        );

        PrepararJugadoresRpc();

        StartCoroutine(RecargarNivel());
    }

    // Ejecutar en Host y Client.
    [Rpc(SendTo.Everyone)]
    private void PrepararJugadoresRpc()
    {
        if (HUDPausaController.Instancia != null)
        {
            HUDPausaController.Instancia
                .PrepararParaReinicio();
        }

        HUDInteraccion.Instancia?.OcultarBotonActual();

        NetworkManager red = NetworkManager.Singleton;

        if (red == null ||
            red.LocalClient == null ||
            red.LocalClient.PlayerObject == null)
        {
            return;
        }

        NetworkPlayerMovement movimiento =
            red.LocalClient.PlayerObject
                .GetComponent<NetworkPlayerMovement>();

        if (movimiento != null)
        {
            movimiento.ActivarModoPuente(false);
            movimiento.BloquearMovimiento(false);
        }

        Debug.Log(
            "REINICIO: controles locales preparados."
        );
    }

    private IEnumerator RecargarNivel()
    {
        yield return new WaitForSecondsRealtime(
            Mathf.Max(0.1f, esperaAntesDeRecargar)
        );

        if (!IsServer ||
            NetworkManager.Singleton == null ||
            NetworkManager.Singleton.SceneManager == null)
        {
            reiniciando = false;
            yield break;
        }

        string escenaActual =
            SceneManager.GetActiveScene().name;

        var resultado =
            NetworkManager.Singleton.SceneManager.LoadScene(
                escenaActual,
                LoadSceneMode.Single
            );

        if (resultado != SceneEventProgressStatus.Started)
        {
            Debug.LogError(
                "REINICIO: no se pudo cargar la escena. " +
                resultado
            );

            reiniciando = false;
        }
        else
        {
            Debug.Log(
                "REINICIO: recargando " + escenaActual
            );
        }
    }

    public override void OnNetworkDespawn()
    {
        reiniciando = false;
    }

    private void OnDestroy()
    {
        if (Instancia == this)
            Instancia = null;
    }
}
