
using UnityEngine;
using UnityEngine.UI;

public class VisorNotasUI : MonoBehaviour
{
    public static VisorNotasUI Instancia { get; private set; }

    [Header("Elementos del visor")]
    [SerializeField] private Image imagenNotaGrande;
    [SerializeField] private Button botonCerrar;

    
    private void Awake()
    {
        Instancia = this;

        if (botonCerrar != null)
        {
            botonCerrar.onClick.AddListener(CerrarNota);
        }

        if (imagenNotaGrande != null)
        {
            imagenNotaGrande.preserveAspect = true;
        }

        // No limpiar ni desactivar aqui:
        // el visor puede recibir la imagen
        // antes de ejecutar Awake por primera vez.
    }


    // =====================================
    // MOSTRAR LA NOTA SELECCIONADA
    // =====================================

    public void MostrarNota(Sprite imagen)
    {
        if (imagen == null)
        {
            Debug.LogWarning(
                "VISOR NOTAS: no se recibio una imagen."
            );
            return;
        }

        if (imagenNotaGrande == null)
        {
            Debug.LogError(
                "VISOR NOTAS: falta ImagenNotaGrande."
            );
            return;
        }

        imagenNotaGrande.sprite = imagen;
        imagenNotaGrande.preserveAspect = true;
        imagenNotaGrande.enabled = true;

        gameObject.SetActive(true);

        Debug.Log(
            "VISOR NOTAS: imagen mostrada correctamente."
        );
    }

    // =====================================
    // CERRAR NOTA
    // =====================================

    public void CerrarNota()
    {
        gameObject.SetActive(false);

        if (imagenNotaGrande != null)
        {
            imagenNotaGrande.sprite = null;
            imagenNotaGrande.enabled = false;
        }

        Debug.Log("VISOR NOTAS: cerrado.");
    }

    private void OnDestroy()
    {
        if (botonCerrar != null)
        {
            botonCerrar.onClick.RemoveListener(CerrarNota);
        }

        if (Instancia == this)
            Instancia = null;
    }
}
