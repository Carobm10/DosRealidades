
using System.Collections;
using UnityEngine;
using Unity.Netcode;

public class ControlInicioPersecucionP2 : MonoBehaviour
{
    [Header("Enemigo")]
    [SerializeField] private GameObject laVigilia;

    [Header("Tiempo de espera")]
    [SerializeField] private float esperaAparicion = 2f;

    private IEnumerator Start()
    {
        if (laVigilia == null)
        {
            Debug.LogError(
                "P2: No está asignada La Vigilia."
            );
            yield break;
        }

        // Comienza oculta mientras se identifica al jugador.
        laVigilia.SetActive(false);

        Debug.Log(
            "P2: Esperando configuración del jugador local."
        );

        // Esperar hasta que Netcode configure completamente
        // el jugador y su personaje.
        yield return new WaitUntil(() =>
        {
            NetworkManager red = NetworkManager.Singleton;

            if (red == null ||
                !red.IsListening ||
                red.LocalClient == null ||
                red.LocalClient.PlayerObject == null)
                return false;

            NetworkPlayerSetup setup =
                red.LocalClient.PlayerObject
                .GetComponent<NetworkPlayerSetup>();

            return setup != null && setup.RolConfigurado;
        });

        NetworkObject jugador =
            NetworkManager.Singleton.LocalClient.PlayerObject;

        NetworkPlayerSetup configuracion =
            jugador.GetComponent<NetworkPlayerSetup>();

        // La Vigilia nunca aparece en la realidad de Elian.
        if (configuracion.EsElian)
        {
            Debug.Log(
                "P2: Jugador Elian. Vigilia permanece oculta."
            );
            yield break;
        }

        Debug.Log(
            "P2: Jugador Lía identificado correctamente."
        );

        yield return new WaitForSeconds(esperaAparicion);

        // Aparecer únicamente para Lía.
        laVigilia.SetActive(true);

        Debug.Log(
            "P2: ¡La Vigilia ha aparecido para Lía!"
        );
    }
}
