using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class ModoPruebaLobby : MonoBehaviour
{
    [Header("Objetos para pruebas")]
    [SerializeField] private GameObject prefabNetworkManager;

    private IEnumerator Start()
    {
        // Si entramos directamente a una escena jugable,
        // creamos el NetworkManager únicamente si no existe.
        if (NetworkManager.Singleton == null)
        {
            Instantiate(prefabNetworkManager);

            // Esperamos un frame para que se registre el Singleton.
            yield return null;
        }

        if (NetworkManager.Singleton == null)
        {
            Debug.LogError(
                "Modo prueba: no se pudo crear NetworkManager."
            );

            yield break;
        }

        // Solo iniciamos Host si todavía no existe una sesión.
        if (!NetworkManager.Singleton.IsListening)
        {
            bool iniciado =
                NetworkManager.Singleton.StartHost();

            if (iniciado)
            {
                Debug.Log(
                    "Modo prueba: Host iniciado automaticamente."
                );
            }
            else
            {
                Debug.LogError(
                    "Modo prueba: no se pudo iniciar Host."
                );
            }
        }
    }
}