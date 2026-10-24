using UnityEngine;
using TMPro;

public class HUDMision : MonoBehaviour
{
    public static HUDMision Instancia { get; private set; }

    [SerializeField] private TMP_Text textoMision;

    private void Awake()
    {
        Instancia = this;
    }

    public void CambiarMision(string nuevaMision)
    {
        if (textoMision == null)
            return;

        gameObject.SetActive(true);
        textoMision.text = nuevaMision;
    }

    public void OcultarMision()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (Instancia == this)
        {
            Instancia = null;
        }
    }
}