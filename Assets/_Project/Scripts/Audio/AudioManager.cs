
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
        if (clip == null) return;

        // Evita reiniciar el ambiente al cambiar
        // entre escenas del mismo nivel.
        if (ambienteSource.clip == clip &&
            ambienteSource.isPlaying)
            return;

        ambienteSource.clip = clip;
        ambienteSource.loop = true;
        ambienteSource.Play();
    }

    public void ReproducirEfecto(AudioClip clip)
    {
        if (clip != null)
            efectosSource.PlayOneShot(clip);
    }

    public void DetenerAmbiente()
    {
        ambienteSource.Stop();
    }
}
