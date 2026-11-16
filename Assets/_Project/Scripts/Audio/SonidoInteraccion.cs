
using UnityEngine;

public class SonidoInteraccion : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sonido;

    public void ReproducirSonido()
    {
        if (audioSource != null && sonido != null)
        {
            audioSource.PlayOneShot(sonido);
        }
    }
}
