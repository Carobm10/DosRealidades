
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

[RequireComponent(typeof(NetworkObject))]
public class HistorietaFinalP8Controller : NetworkBehaviour
{
    [Header("Interfaz")]
    [SerializeField] private GameObject canvasHistorieta;
    [SerializeField] private Image imagenHistorieta;
    [SerializeField] private Button botonSalir;

    [Header("Imagenes")]
    [SerializeField] private bool mismaImagenParaAmbos = true;
    [SerializeField] private Sprite imagenGeneral;
    [SerializeField] private Sprite imagenElian;
    [SerializeField] private Sprite imagenLia;

    [Header("Lectura")]
    [SerializeField] private float tiempoMinimoLectura = 8f;

    private bool visibleLocal;
    private bool salirSolicitado;

    private Coroutine rutinaLectura;

    // =====================================
    // PREPARACION
    // =====================================

    private void Awake()
    {
        if (botonSalir != null)
        {
            botonSalir.onClick.AddListener(SalirDelJuego);
            botonSalir.gameObject.SetActive(false);
        }

        if (imagenHistorieta != null)
            imagenHistorieta.preserveAspect = true;
    }

    public override void OnNetworkSpawn()
    {
        visibleLocal = false;
        salirSolicitado = false;

        if (canvasHistorieta != null)
            canvasHistorieta.SetActive(false);

        if (botonSalir != null)
            botonSalir.gameObject.SetActive(false);

        Debug.Log("P8 | Historieta final preparada.");
    }

    // =====================================
    // MOSTRAR IMAGEN
    // =====================================

    private void MostrarImagenCorrespondiente()
    {
        if (imagenHistorieta == null)
            return;

        Sprite imagen;

        if (mismaImagenParaAmbos)
        {
            imagen = imagenGeneral;
        }
        else
        {
            imagen = IdentidadJugadorLocal.EsElian()
                ? imagenElian
                : imagenLia;
        }

        imagenHistorieta.sprite = imagen;
        imagenHistorieta.enabled = imagen != null;

        if (imagen == null)
        {
            Debug.LogWarning(
                "P8 | Falta asignar la imagen de la historieta final."
            );
        }
    }

    // =====================================
    // ACTIVAR HISTORIETA DESDE LA SALIDA
    // =====================================

    public void MostrarHistorietaFinal()
    {
        if (!IsSpawned || visibleLocal || salirSolicitado)
            return;

        visibleLocal = true;

        MostrarImagenCorrespondiente();

        if (canvasHistorieta != null)
            canvasHistorieta.SetActive(true);

        if (botonSalir != null)
            botonSalir.gameObject.SetActive(false);

        rutinaLectura = StartCoroutine(EsperarLectura());

        Debug.Log("P8 | HISTORIETA FINAL MOSTRADA.");
    }

    // =====================================
    // TIEMPO DE LECTURA
    // =====================================

    private IEnumerator EsperarLectura()
    {
        yield return new WaitForSecondsRealtime(
            Mathf.Max(0f, tiempoMinimoLectura)
        );

        rutinaLectura = null;

        if (!visibleLocal || salirSolicitado)
            yield break;

        if (botonSalir != null)
            botonSalir.gameObject.SetActive(true);

        Debug.Log("P8 | Boton de salida habilitado.");
    }

    // =====================================
    // SALIR DEL JUEGO
    // =====================================

    public void SalirDelJuego()
    {
        if (!visibleLocal || salirSolicitado)
            return;

        salirSolicitado = true;

        if (rutinaLectura != null)
        {
            StopCoroutine(rutinaLectura);
            rutinaLectura = null;
        }

        if (canvasHistorieta != null)
            canvasHistorieta.SetActive(false);

        NetworkManager red = NetworkManager.Singleton;

        if (red != null && red.IsListening)
        {
            red.Shutdown();
        }

        Debug.Log("P8 | Jugador salió del juego.");

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // =====================================
    // LIMPIEZA
    // =====================================

    public override void OnNetworkDespawn()
    {
        if (rutinaLectura != null)
            StopCoroutine(rutinaLectura);

        rutinaLectura = null;
    }

    private void OnDestroy()
    {
        if (botonSalir != null)
            botonSalir.onClick.RemoveListener(SalirDelJuego);
    }
}
