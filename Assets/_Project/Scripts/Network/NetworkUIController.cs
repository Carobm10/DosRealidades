using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class NetworkUIController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private Button stopButton;

    private void Start()
    {
        hostButton.onClick.AddListener(StartHost);
        clientButton.onClick.AddListener(StartClient);
        stopButton.onClick.AddListener(StopNetwork);

        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnected;

        UpdateStatus("Desconectado");
    }

    private void StartHost()
    {
        bool started = NetworkManager.Singleton.StartHost();

        if (started)
        {
            UpdateStatus("Host iniciado");
            Debug.Log("HOST iniciado correctamente.");
        }
        else
        {
            UpdateStatus("Error al iniciar Host");
            Debug.LogError("No se pudo iniciar el HOST.");
        }
    }

    private void StartClient()
    {
        bool started = NetworkManager.Singleton.StartClient();

        if (started)
        {
            UpdateStatus("Conectando como Client...");
            Debug.Log("CLIENT intentando conectarse.");
        }
        else
        {
            UpdateStatus("Error al iniciar Client");
            Debug.LogError("No se pudo iniciar el CLIENT.");
        }
    }

    private void StopNetwork()
    {
        if (NetworkManager.Singleton != null &&
            NetworkManager.Singleton.IsListening)
        {
            NetworkManager.Singleton.Shutdown();
        }

        UpdateStatus("Desconectado");
        Debug.Log("Conexión detenida.");
    }

    private void OnClientConnected(ulong clientId)
    {
        if (NetworkManager.Singleton.IsHost)
        {
            UpdateStatus("Host activo - Cliente " + clientId + " conectado");
        }
        else
        {
            UpdateStatus("Client conectado");
        }

        Debug.Log("Cliente conectado. ID: " + clientId);
    }

    private void OnClientDisconnected(ulong clientId)
    {
        UpdateStatus("Cliente desconectado");
        Debug.Log("Cliente desconectado. ID: " + clientId);
    }

    private void UpdateStatus(string message)
    {
        if (statusText != null)
        {
            statusText.text = "Estado: " + message;
        }
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton == null)
            return;

        NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
        NetworkManager.Singleton.OnClientDisconnectCallback -= OnClientDisconnected;
    }
}