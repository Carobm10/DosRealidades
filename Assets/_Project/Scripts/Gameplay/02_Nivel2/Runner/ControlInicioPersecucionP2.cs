
using System.Collections;
using UnityEngine;
using Unity.Netcode;

public class ControlInicioPersecucionP2 : MonoBehaviour
{
    [Header("Enemigo")]
    [SerializeField] private GameObject laVigilia;

    [Header("Tiempo de espera")]
    [SerializeField] private float esperaAparicion = 1.5f;

    private IEnumerator Start()
    {
        // La Vigilia comienza oculta.
        if (laVigilia != null)
            laVigilia.SetActive(false);

        // Esperar a que Netcode cree al jugador local.
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

        if (setup == null)
        {
            Debug.LogError(
                "P2: No se encontró NetworkPlayerSetup."
            );
            yield break;
        }

        // La Vigilia solamente aparece en la realidad de Lía.
        if (setup.EsElian)
        {
            Debug.Log("P2: Elian. La Vigilia permanece oculta.");
            yield break;
        }

        // Espera breve antes de comenzar la persecución.
        yield return new WaitForSeconds(esperaAparicion);

        if (laVigilia != null)
        {
            laVigilia.SetActive(true);

            Debug.Log("P2: ¡La Vigilia ha aparecido!");
        }
    }
}
