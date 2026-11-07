
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlHuellasP5 : MonoBehaviour
{
    [Header("Recorridos existentes")]
    [SerializeField] private Transform puerta202;
    [SerializeField] private Transform puerta203;
    [SerializeField] private Transform puerta204;

    [Header("Sprites")]
    [SerializeField] private Sprite pasosApagados;
    [SerializeField] private Sprite pasosBrillo;

    [Header("Velocidad")]
    [SerializeField] private float intervaloBrillo = 0.35f;

    private SpriteRenderer[] huellas202;
    private SpriteRenderer[] huellas203;
    private SpriteRenderer[] huellas204;

    private Coroutine rutinaBrillo;

    private void Awake()
    {
        huellas202 = ObtenerHuellas(puerta202);
        huellas203 = ObtenerHuellas(puerta203);
        huellas204 = ObtenerHuellas(puerta204);

        OcultarTodas();
    }

    private SpriteRenderer[] ObtenerHuellas(Transform puerta)
    {
        if (puerta == null)
            return new SpriteRenderer[0];

        SpriteRenderer[] sprites =
            puerta.GetComponentsInChildren<SpriteRenderer>(true);

        List<SpriteRenderer> resultado =
            new List<SpriteRenderer>();

        foreach (SpriteRenderer sprite in sprites)
        {
            if (sprite.transform == puerta)
                continue;

            resultado.Add(sprite);
        }

        return resultado.ToArray();
    }

    private void OcultarTodas()
    {
        OcultarCamino(huellas202);
        OcultarCamino(huellas203);
        OcultarCamino(huellas204);
    }

    private void OcultarCamino(SpriteRenderer[] camino)
    {
        foreach (SpriteRenderer huella in camino)
        {
            if (huella == null)
                continue;

            huella.sprite = pasosApagados;
            huella.enabled = false;
        }
    }

    public void ActivarCamino(int numeroPuerta)
    {
        if (rutinaBrillo != null)
        {
            StopCoroutine(rutinaBrillo);
            rutinaBrillo = null;
        }

        OcultarTodas();

        SpriteRenderer[] camino = ObtenerCamino(numeroPuerta);

        if (camino == null || camino.Length == 0)
        {
            Debug.LogWarning(
                "P5: No hay huellas para la puerta " + numeroPuerta
            );
            return;
        }

        foreach (SpriteRenderer huella in camino)
        {
            huella.sprite = pasosApagados;
            huella.enabled = true;
        }

        rutinaBrillo = StartCoroutine(RecorrerBrillo(camino));

        Debug.Log("P5: Recorrido activado: " + numeroPuerta);
    }

    private SpriteRenderer[] ObtenerCamino(int numeroPuerta)
    {
        switch (numeroPuerta)
        {
            case 202: return huellas202;
            case 203: return huellas203;
            case 204: return huellas204;
            default: return null;
        }
    }

    private IEnumerator RecorrerBrillo(SpriteRenderer[] camino)
    {
        int indice = 0;

        while (camino.Length > 0)
        {
            foreach (SpriteRenderer huella in camino)
            {
                if (huella != null)
                    huella.sprite = pasosApagados;
            }

            if (camino[indice] != null)
                camino[indice].sprite = pasosBrillo;

            yield return new WaitForSeconds(
                Mathf.Max(0.05f, intervaloBrillo)
            );

            if (camino[indice] != null)
                camino[indice].sprite = pasosApagados;

            indice = (indice + 1) % camino.Length;
        }
    }

    public void DetenerRecorrido()
    {
        if (rutinaBrillo != null)
        {
            StopCoroutine(rutinaBrillo);
            rutinaBrillo = null;
        }

        OcultarTodas();
    }

    private void OnDisable()
    {
        DetenerRecorrido();
    }
}
