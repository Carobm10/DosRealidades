
using UnityEngine;

public class PuertaElianPaso : MonoBehaviour
{
    [Header("Colision de la puerta")]
    [SerializeField] private Collider2D colliderBloqueo;

    private bool pasoLiberado;

    // Se ejecuta cuando termina de abrirse la puerta.
    public void LiberarPaso()
    {
        if (pasoLiberado)
            return;

        pasoLiberado = true;

        if (colliderBloqueo != null)
        {
            colliderBloqueo.enabled = false;
        }

        Debug.Log("PUERTA ELIAN: Paso liberado.");
    }
}
