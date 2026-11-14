
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlHuellasP5 : MonoBehaviour
{
    [Header("Raices de las huellas")]
    [SerializeField] private Transform puerta201;
    [SerializeField] private Transform puerta202;
    [SerializeField] private Transform puerta203;
    [SerializeField] private Transform puerta204;

    [Header("Sprites de las huellas")]
    [SerializeField] private Sprite pasosApagados;
    [SerializeField] private Sprite pasosBrillo;

    [Header("Velocidad")]
    [SerializeField] private float intervaloBrillo = 0.35f;

    [Header("Brillo de puertas de Lia")]
    [SerializeField] private BrilloPuertaLiaP5 brilloPuerta201;
    [SerializeField] private BrilloPuertaLiaP5 brilloPuerta202;
    [SerializeField] private BrilloPuertaLiaP5 brilloPuerta203;
    [SerializeField] private BrilloPuertaLiaP5 brilloPuerta204;

    private SpriteRenderer[] huellas201;
    private SpriteRenderer[] huellas202;
    private SpriteRenderer[] huellas203;
    private SpriteRenderer[] huellas204;

    private Coroutine rutinaBrillo;

    private void Awake()
    {
        huellas201 = ObtenerHuellas(puerta201);
        huellas202 = ObtenerHuellas(puerta202);
        huellas203 = ObtenerHuellas(puerta203);
        huellas204 = ObtenerHuellas(puerta204);

        OcultarTodas();
        ApagarBrillosPuertas();
    }

    private SpriteRenderer[] ObtenerHuellas(Transform raiz)
    {
        if (raiz == null)
            return new SpriteRenderer[0];

        return raiz.GetComponentsInChildren<SpriteRenderer>(true);
    }

    private void OcultarTodas()
    {
        OcultarCamino(huellas201);
        OcultarCamino(huellas202);
        OcultarCamino(huellas203);
        OcultarCamino(huellas204);
    }

    private void OcultarCamino(SpriteRenderer[] camino)
    {
        if (camino == null)
            return;

        foreach (SpriteRenderer huella in camino)
        {
            if (huella == null)
                continue;

            if (pasosApagados != null)
                huella.sprite = pasosApagados;

            huella.enabled = false;
        }
    }

    private void ApagarBrillosPuertas()
    {
        if (brilloPuerta201 != null)
            brilloPuerta201.ActivarBrillo(false);

        if (brilloPuerta202 != null)
            brilloPuerta202.ActivarBrillo(false);

        if (brilloPuerta203 != null)
            brilloPuerta203.ActivarBrillo(false);

        if (brilloPuerta204 != null)
            brilloPuerta204.ActivarBrillo(false);
    }

    private void ActivarBrilloPuerta(int numeroPuerta)
    {
        switch (numeroPuerta)
        {
            case 201:
                if (brilloPuerta201 != null)
                    brilloPuerta201.ActivarBrillo(true);
                break;

            case 202:
                if (brilloPuerta202 != null)
                    brilloPuerta202.ActivarBrillo(true);
                break;

            case 203:
                if (brilloPuerta203 != null)
                    brilloPuerta203.ActivarBrillo(true);
                break;

            case 204:
                if (brilloPuerta204 != null)
                    brilloPuerta204.ActivarBrillo(true);
                break;
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
        ApagarBrillosPuertas();

        SpriteRenderer[] camino = ObtenerCamino(numeroPuerta);

        if (camino == null || camino.Length == 0)
        {
            Debug.LogWarning(
                "P5: No hay huellas configuradas para " + numeroPuerta
            );
            return;
        }

        foreach (SpriteRenderer huella in camino)
        {
            if (huella == null)
                continue;

            if (pasosApagados != null)
                huella.sprite = pasosApagados;

            huella.enabled = true;
        }

        ActivarBrilloPuerta(numeroPuerta);

        rutinaBrillo = StartCoroutine(RecorrerBrillo(camino));

        Debug.Log("P5: Huellas y brillo activados: " + numeroPuerta);
    }

    private SpriteRenderer[] ObtenerCamino(int numeroPuerta)
    {
        switch (numeroPuerta)
        {
            case 201: return huellas201;
            case 202: return huellas202;
            case 203: return huellas203;
            case 204: return huellas204;
            default: return null;
        }
    }

    private IEnumerator RecorrerBrillo(SpriteRenderer[] camino)
    {
        int indice = 0;

        while (camino != null && camino.Length > 0)
        {
            foreach (SpriteRenderer huella in camino)
            {
                if (huella != null && pasosApagados != null)
                    huella.sprite = pasosApagados;
            }

            if (camino[indice] != null && pasosBrillo != null)
                camino[indice].sprite = pasosBrillo;

            yield return new WaitForSeconds(
                Mathf.Max(0.05f, intervaloBrillo)
            );

            if (camino[indice] != null && pasosApagados != null)
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
        ApagarBrillosPuertas();
    }

    private void OnDisable()
    {
        DetenerRecorrido();
    }
}
