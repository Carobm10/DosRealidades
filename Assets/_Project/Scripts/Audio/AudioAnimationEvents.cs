using UnityEngine;

public class AudioAnimationEvents : MonoBehaviour
{
    [Header("Sonidos")]
    [SerializeField] private AudioClip sonidoAbrir;
    [SerializeField] private AudioClip sonidoCerrar;
    [SerializeField] private AudioClip sonidoMovimiento;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
    }

    public void SonidoAbrirPuerta()
    {
        Reproducir(sonidoAbrir);
    }

    public void SonidoCerrarPuerta()
    {
        Reproducir(sonidoCerrar);
    }

    public void SonidoMovimiento()
    {
        Reproducir(sonidoMovimiento);
    }

    private void Reproducir(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}