
using System.Collections;
using UnityEngine;

public class FaseLlavesP8Controller : MonoBehaviour
{
    [Header("Panel de instrucciones")]
    [SerializeField] private GameObject panelInstrucciones;

    [Header("Duracion")]
    [SerializeField] private float duracionMensaje = 7f;

    private Coroutine rutinaMensaje;

    private void OnEnable()
    {
        MostrarInstrucciones();
    }

    private void MostrarInstrucciones()
    {
        if (panelInstrucciones == null)
        {
            Debug.LogError(
                "P8 | No se asigno el panel de instrucciones."
            );
            return;
        }

        panelInstrucciones.SetActive(true);

        if (rutinaMensaje != null)
            StopCoroutine(rutinaMensaje);

        rutinaMensaje = StartCoroutine(
            OcultarInstrucciones()
        );
    }

    private IEnumerator OcultarInstrucciones()
    {
        yield return new WaitForSeconds(duracionMensaje);

        if (panelInstrucciones != null)
            panelInstrucciones.SetActive(false);

        rutinaMensaje = null;

        Debug.Log("P8 | Instrucciones finalizadas.");
    }

    private void OnDisable()
    {
        if (rutinaMensaje != null)
        {
            StopCoroutine(rutinaMensaje);
            rutinaMensaje = null;
        }
    }
}
