
using UnityEngine;
using UnityEngine.UI;

public class ConfiguracionAudioUI : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider sliderMusica;
    [SerializeField] private Slider sliderEfectos;

    private void Start()
    {
        if (AudioManager.Instance == null)
        {
            Debug.LogError(
                "No se encontro AudioManager."
            );

            return;
        }

        // Configurar rangos
        sliderMusica.minValue = 0f;
        sliderMusica.maxValue = 1f;

        sliderEfectos.minValue = 0f;
        sliderEfectos.maxValue = 1f;

        // Conectar eventos
        sliderMusica.onValueChanged.RemoveAllListeners();
        sliderEfectos.onValueChanged.RemoveAllListeners();

        sliderMusica.onValueChanged.AddListener(
            AudioManager.Instance.CambiarVolumenMusica
        );

        sliderEfectos.onValueChanged.AddListener(
            AudioManager.Instance.CambiarVolumenEfectos
        );

        // Cargar valores guardados
        float volumenMusica =
            AudioManager.Instance.ObtenerVolumenMusica();

        float volumenEfectos =
            AudioManager.Instance.ObtenerVolumenEfectos();

        // Actualizar sliders sin activar eventos
        sliderMusica.SetValueWithoutNotify(
            volumenMusica
        );

        sliderEfectos.SetValueWithoutNotify(
            volumenEfectos
        );

        // Aplicar valores al AudioManager
        AudioManager.Instance.CambiarVolumenMusica(
            volumenMusica
        );

        AudioManager.Instance.CambiarVolumenEfectos(
            volumenEfectos
        );
    }
}
