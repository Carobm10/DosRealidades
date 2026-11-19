
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource ambienteSource;
    [SerializeField] private AudioSource efectosSource;

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer mixerJuego;

    [Header("Parametros expuestos")]
    [SerializeField] private string parametroMusica = "VolumenMusica";
    [SerializeField] private string parametroEfectos = "VolumenEfectos";

    private const string PREF_MUSICA = "VolumenMusica";
    private const string PREF_EFECTOS = "VolumenEfectos";

    private float volumenMusica = 1f;
    private float volumenEfectos = 1f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Recuperar volumenes guardados
        volumenMusica = PlayerPrefs.GetFloat(
            PREF_MUSICA, 1f
        );

        volumenEfectos = PlayerPrefs.GetFloat(
            PREF_EFECTOS, 1f
        );

        AplicarVolumenes();
    }
    // =====================================
    // MUSICA AMBIENTE
    // =====================================

    public void ReproducirAmbiente(AudioClip clip)
    {
        if (clip == null || ambienteSource == null)
            return;

        // Evita reiniciar el ambiente entre escenas
        if (ambienteSource.clip == clip &&
            ambienteSource.isPlaying)
        {
            return;
        }

        ambienteSource.clip = clip;
        ambienteSource.loop = true;
        ambienteSource.Play();
    }

    public void DetenerAmbiente()
    {
        if (ambienteSource != null)
            ambienteSource.Stop();
    }

    // =====================================
    // EFECTOS DE SONIDO
    // =====================================

    public void ReproducirEfecto(AudioClip clip)
    {
        if (clip != null && efectosSource != null)
        {
            efectosSource.PlayOneShot(clip);
        }
    }

    // =====================================
    // VOLUMEN MUSICA
    // =====================================

    public void CambiarVolumenMusica(float valor)
    {
        volumenMusica = valor;

        AplicarVolumenMusica();

        PlayerPrefs.SetFloat(
            PREF_MUSICA, volumenMusica
        );

        PlayerPrefs.Save();
    }

    // =====================================
    // VOLUMEN EFECTOS
    // =====================================

    public void CambiarVolumenEfectos(float valor)
    {
        volumenEfectos = valor;

        AplicarVolumenEfectos();

        PlayerPrefs.SetFloat(
            PREF_EFECTOS, volumenEfectos
        );

        PlayerPrefs.Save();
    }

    // =====================================
    // APLICAR VOLUMEN
    // =====================================

    private void AplicarVolumenes()
    {
        AplicarVolumenMusica();
        AplicarVolumenEfectos();
    }

    private void AplicarVolumenMusica()
    {
        if (mixerJuego != null)
        {
            mixerJuego.SetFloat(
                parametroMusica,
                ConvertirVolumenADecibel(volumenMusica)
            );
        }
    }

    private void AplicarVolumenEfectos()
    {
        if (mixerJuego != null)
        {
            mixerJuego.SetFloat(
                parametroEfectos,
                ConvertirVolumenADecibel(volumenEfectos)
            );
        }
    }

    private float ConvertirVolumenADecibel(float valor)
    {
        if (valor <= 0.0001f)
            return -80f;

        return Mathf.Log10(valor) * 20f;
    }

    // =====================================
    // OBTENER VOLUMEN ACTUAL
    // =====================================

    public float ObtenerVolumenMusica()
    {
        return volumenMusica;
    }

    public float ObtenerVolumenEfectos()
    {
        return volumenEfectos;
    }
}
