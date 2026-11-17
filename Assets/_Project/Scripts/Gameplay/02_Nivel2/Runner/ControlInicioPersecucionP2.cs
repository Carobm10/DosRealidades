
using System.Collections;
using UnityEngine;
using Unity.Netcode;

public class ControlInicioPersecucionP2 : MonoBehaviour
{
    [Header("Enemigo")]
    [SerializeField] private GameObject laVigilia;

    [Header("Historieta introductoria")]
    [SerializeField] private HistorietaCooperativa historieta;

    [Header("Tiempo de espera")]
    [SerializeField] private float esperaAparicion = 1.2f;

    [Header("Velocidad del nivel")]
    [SerializeField] private float velocidadJugadores = 3f;

    private NetworkPlayerMovement movimientoLocal;

    private IEnumerator Start()
    {
        // Mantener oculta La Vigilia al comenzar.
        if (laVigilia != null)
            laVigilia.SetActive(false);

        // =====================================
        // ESPERAR CONEXION Y JUGADOR LOCAL
        // =====================================

        yield return new WaitUntil(() =>
            NetworkManager.Singleton != null &&
            NetworkManager.Singleton.IsListening &&
            NetworkManager.Singleton.LocalClient != null &&
            NetworkManager.Singleton.LocalClient.PlayerObject != null
        );

        NetworkObject jugadorLocal =
            NetworkManager.Singleton.LocalClient.PlayerObject;

        NetworkPlayerSetup setup =
            jugadorLocal.GetComponent<NetworkPlayerSetup>();

        movimientoLocal =
            jugadorLocal.GetComponent<NetworkPlayerMovement>();

        if (setup == null || movimientoLocal == null)
        {
            Debug.LogError(
                "P2: No se encontraron los componentes del jugador."
            );
            yield break;
        }

        // Esperar a que se configure la identidad.
        yield return new WaitUntil(() => setup.RolConfigurado);

        // =====================================
        // ENCONTRAR HISTORIETA
        // =====================================

        if (historieta == null)
        {
            historieta =
                FindFirstObjectByType<HistorietaCooperativa>();
        }

        while (historieta == null)
        {
            yield return null;

            historieta =
                FindFirstObjectByType<HistorietaCooperativa>();
        }

        // =====================================
        // ESPERAR A QUE AMBOS TERMINEN
        // =====================================

        Debug.Log(
            "P2: Esperando que ambos jugadores terminen la historieta."
        );

        yield return new WaitUntil(() =>
            historieta != null &&
            historieta.IsSpawned &&
            historieta.IntroduccionFinalizada
        );

        Debug.Log(
            "P2: Historieta finalizada para ambos jugadores."
        );

        // =====================================
        // CONFIGURAR VELOCIDAD
        // =====================================

        movimientoLocal.ConfigurarVelocidadNivel(
            velocidadJugadores
        );

        Debug.Log(
            "P2: Velocidad configurada para " +
            (setup.EsElian ? "Elian" : "Lia") +
            " | Velocidad: " + velocidadJugadores
        );

        // =====================================
        // ELIAN NO VE LA VIGILIA
        // =====================================

        if (setup.EsElian)
        {
            Debug.Log(
                "P2: Elian. La Vigilia permanece oculta."
            );

            yield break;
        }

        // =====================================
        // INICIAR PERSECUCION DE LIA
        // =====================================

        yield return new WaitForSeconds(
            Mathf.Max(0f, esperaAparicion)
        );

        if (laVigilia != null)
        {
            laVigilia.SetActive(true);

            Debug.Log(
                "P2: ¡La Vigilia ha aparecido! Comienza la persecución."
            );
        }
        else
        {
            Debug.LogError(
                "P2: No se ha asignado La Vigilia."
            );
        }
    }

    // =====================================
    // LIMPIEZA
    // =====================================

    private void OnDestroy()
    {
        if (movimientoLocal != null &&
            movimientoLocal.IsSpawned &&
            movimientoLocal.IsOwner)
        {
            movimientoLocal.RestaurarVelocidadOriginal();
        }
    }
}
