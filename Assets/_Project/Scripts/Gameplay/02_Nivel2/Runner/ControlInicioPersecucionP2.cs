
using System.Collections;
using UnityEngine;
using Unity.Netcode;

public class ControlInicioPersecucionP2 : MonoBehaviour
{
    [Header("Enemigo")]
    [SerializeField] private GameObject laVigilia;

    [Header("Historieta")]
    [SerializeField] private HistorietaCooperativa historieta;

    [Header("Tiempo de aparición")]
    [SerializeField] private float esperaAparicion = 5f;

    private IEnumerator Start()
    {
        if (laVigilia == null || historieta == null)
        {
            Debug.LogError(
                "P2: Falta asignar La Vigilia o la Historieta."
            );
            yield break;
        }

        // La Vigilia comienza oculta.
        laVigilia.SetActive(false);

        Debug.Log("P2: Esperando configuración del jugador.");

        // Esperar configuración de Netcode.
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

        // Elian nunca ve La Vigilia.
        if (configuracion.EsElian)
        {
            Debug.Log(
                "P2: Elian identificado. Vigilia oculta."
            );
        }

        // Esperar a que AMBOS pulsen Continuar.
        yield return new WaitUntil(() =>
            historieta.IntroduccionFinalizada
        );

        Debug.Log(
            "P2: Ambos terminaron la historieta. " +
            "Comienza el juego."
        );

        // Comenzar los cinco segundos.
        yield return new WaitForSecondsRealtime(
            esperaAparicion
        );

        // Solo Lía activa La Vigilia.
        if (!configuracion.EsElian)
        {
            laVigilia.SetActive(true);

            Debug.Log(
                "P2: ¡La Vigilia aparece después de 5 segundos!"
            );
        }
    }
}
