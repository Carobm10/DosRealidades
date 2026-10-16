using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class ModoPruebaLobby : MonoBehaviour
{
    [Header("Objetos para pruebas")]
    [SerializeField] private GameObject prefabNetworkManager;

    private IEnumerator Start()
    {
#if UNITY_EDITOR

        // Si entramos directamente al Lobby,
        // todavía no existe un NetworkManager.
        if (NetworkManager.Singleton == null)
        {
            Instantiate(prefabNetworkManager);

            // Esperamos un frame para que Unity termine
            // de inicializar el NetworkManager.
            yield return null;
        }

        // Si todavía no existe una conexión,
        // iniciamos un Host automáticamente.
        if (NetworkManager.Singleton != null &&
            !NetworkManager.Singleton.IsListening)
        {
            NetworkManager.Singleton.StartHost();

            Debug.Log("Modo prueba: Host iniciado automáticamente.");
        }

#else

        yield break;

#endif
    }
}