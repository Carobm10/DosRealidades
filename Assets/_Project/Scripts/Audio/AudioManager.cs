using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource ambienteSource;
    [SerializeField] private AudioSource efectosSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ReproducirAmbiente(AudioClip clip)
    {
        if (clip == null || ambienteSource == null)
            return;

        // Si ya está sonando esta música, no la reinicia.
        if (ambienteSource.clip == clip &&
            ambienteSource.isPlaying)
        {
            return;
        }

        // Si es otra música, cambia a la nueva.
        ambienteSource.clip = clip;
        ambienteSource.loop = true;
        ambienteSource.Play();
    }

    public void ReproducirEfecto(AudioClip clip)
    {
        if (clip != null && efectosSource != null)
            efectosSource.PlayOneShot(clip);
    }

    public void DetenerAmbiente()
    {
        if (ambienteSource != null)
            ambienteSource.Stop();
    }
}