
using UnityEngine;
using TMPro;

public class UIContadorFragmentos : MonoBehaviour
{
    [Header("Interfaz")]
    [SerializeField] private TMP_Text textoContador;

    [Header("Configuracion")]
    [SerializeField] private int totalFragmentos = 2;

    private int fragmentosActuales = 0;

    private void Awake()
    {
        ActualizarVisual();
    }

    public void EstablecerProgreso(int cantidad, int total)
    {
        totalFragmentos = Mathf.Max(0, total);
        fragmentosActuales = Mathf.Clamp(
            cantidad, 0, totalFragmentos
        );

        ActualizarVisual();
    }

    public void AgregarFragmento()
    {
        EstablecerProgreso(
            fragmentosActuales + 1,
            totalFragmentos
        );
    }

    public void ReiniciarContador()
    {
        EstablecerProgreso(0, totalFragmentos);
    }

    private void ActualizarVisual()
    {
        if (textoContador != null)
        {
            textoContador.text =
                fragmentosActuales + "/" + totalFragmentos;
        }
    }
}
