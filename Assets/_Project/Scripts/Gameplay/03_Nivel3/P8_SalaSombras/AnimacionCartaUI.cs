
using UnityEngine;
using UnityEngine.UI;

public class AnimacionCartaUI : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private Image imagen;
    [SerializeField] private Sprite[] fotogramas;
    [SerializeField] private float fotogramasPorSegundo = 12f;
    [SerializeField] private bool repetir = false;

    private int indice;
    private float tiempo;
    private bool reproduciendo;

    private void OnEnable()
    {
        indice = 0;
        tiempo = 0f;
        reproduciendo = fotogramas != null &&
                        fotogramas.Length > 0;

        MostrarFotograma();
    }

    private void Update()
    {
        if (!reproduciendo ||
            fotogramas == null ||
            fotogramas.Length == 0)
            return;

        tiempo += Time.unscaledDeltaTime;

        float intervalo = 1f /
            Mathf.Max(1f, fotogramasPorSegundo);

        if (tiempo < intervalo)
            return;

        tiempo -= intervalo;
        indice++;

        if (indice >= fotogramas.Length)
        {
            if (repetir)
                indice = 0;
            else
            {
                indice = fotogramas.Length - 1;
                reproduciendo = false;
            }
        }

        MostrarFotograma();
    }

    private void MostrarFotograma()
    {
        if (imagen == null ||
            fotogramas == null ||
            fotogramas.Length == 0)
            return;

        imagen.sprite = fotogramas[indice];
        imagen.enabled = true;
    }

    public void Reproducir()
    {
        indice = 0;
        tiempo = 0f;
        reproduciendo = true;
        MostrarFotograma();
    }
}
