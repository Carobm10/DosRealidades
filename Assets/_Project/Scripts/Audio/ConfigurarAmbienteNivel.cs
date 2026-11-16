
using UnityEngine;

public class ConfigurarAmbienteNivel : MonoBehaviour
{
    [SerializeField] private AudioClip ambienteDelNivel;

    private void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ReproducirAmbiente(
                ambienteDelNivel
            );
        }
        else
        {
            Debug.LogError("No se encontró el AudioManager en la escena.");
        }
    }
}
