using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class ModoPruebaLobby : MonoBehaviour
{
    [Header("Objetos para pruebas")]
    [SerializeField] private GameObject prefabNetworkManager;

    private bool hostPruebaIniciado = false;

    private IEnumerator Start()
    {
#if UNITY_EDITOR

        // Si abrimos directamente Level_01_Lobby,
        // creamos el NetworkManager de prueba.
        if (NetworkManager.Singleton == null)
        {
            Instantiate(prefabNetworkManager);

            // Dejamos un frame para que el NetworkManager
            // termine de inicializarse.
            yield return null;
        }

        // Si no existe una sesión activa, iniciamos Host local.
        if (NetworkManager.Singleton != null &&
            !NetworkManager.Singleton.IsListening)
        {
            bool iniciado =
                NetworkManager.Singleton.StartHost();

            if (iniciado)
            {
                hostPruebaIniciado = true;

                Debug.Log(
                    "Modo prueba: Host iniciado automáticamente."
                );
            }
            else
            {
                Debug.LogError(
                    "Modo prueba: no se pudo iniciar el Host."
                );
            }
        }

#else

        yield break;

#endif
    }

#if UNITY_EDITOR

    private void OnApplicationQuit()
    {
        CerrarHostPrueba();
    }

    private void CerrarHostPrueba()
    {
        if (!hostPruebaIniciado)
            return;

        if (NetworkManager.Singleton == null)
            return;

        if (!NetworkManager.Singleton.IsListening)
            return;

        Debug.Log("Modo prueba: cerrando Host correctamente.");

        NetworkManager.Singleton.Shutdown();

        hostPruebaIniciado = false;
    }

#endif
}