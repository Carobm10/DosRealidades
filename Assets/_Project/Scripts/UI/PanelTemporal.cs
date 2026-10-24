using UnityEngine;
using System.Collections;

public class PanelTemporal : MonoBehaviour
{
    [SerializeField] private float duracionVisible = 2f;

    private void OnEnable()
    {
        StartCoroutine(CerrarPanel());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator CerrarPanel()
    {
        yield return new WaitForSeconds(duracionVisible);

        gameObject.SetActive(false);
    }
}