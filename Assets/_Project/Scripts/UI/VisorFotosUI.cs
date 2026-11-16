
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class VisorFotosUI : MonoBehaviour
{
    [Header("Fotografias en orden")]
    [SerializeField] private Sprite[] fotografias;

    [Header("Imagen")]
    [SerializeField] private Image imagenFoto;

    [Header("Botones")]
    [SerializeField] private Button botonAnterior;
    [SerializeField] private Button botonSiguiente;
    [SerializeField] private Button botonCerrar;

    [Header("Elementos HUD que se ocultan")]
    [SerializeField] private GameObject[] elementosHUDOcultar;

    private int indiceActual = 0;

    private bool[] estadosHUD;

    private NetworkPlayerMovement movimientoLocal;
    private bool movimientoEstabaBloqueado;

    private Coroutine rutinaConexion;

    private void Awake()
    {
        if (botonAnterior != null)
            botonAnterior.onClick.AddListener(Anterior);

        if (botonSiguiente != null)
            botonSiguiente.onClick.AddListener(Siguiente);

        if (botonCerrar != null)
            botonCerrar.onClick.AddListener(Cerrar);
    }

    private void OnEnable()
    {
        indiceActual = 0;

        MostrarFotografia();

        GuardarYOcultarHUD();

        rutinaConexion = StartCoroutine(
            ConectarJugadorLocal()
        );
    }

    // =====================================
    // CONECTAR JUGADOR LOCAL
    // =====================================

    private IEnumerator ConectarJugadorLocal()
    {
        while (true)
        {
            NetworkManager red = NetworkManager.Singleton;

            if (red != null &&
                red.IsListening &&
                red.LocalClient != null &&
                red.LocalClient.PlayerObject != null)
            {
                NetworkObject jugador =
                    red.LocalClient.PlayerObject;

                movimientoLocal =
                    jugador.GetComponent<NetworkPlayerMovement>();

                if (movimientoLocal != null)
                {
                    movimientoEstabaBloqueado =
                        movimientoLocal.MovimientoBloqueado;

                    movimientoLocal.BloquearMovimiento(true);

                    Debug.Log("VISOR FOTOS: Movimiento bloqueado.");

                    yield break;
                }
            }

            yield return null;
        }
    }

    // =====================================
    // MOSTRAR FOTOGRAFIA
    // =====================================

    private void MostrarFotografia()
    {
        if (fotografias == null ||
            fotografias.Length == 0 ||
            imagenFoto == null)
        {
            Debug.LogWarning(
                "VISOR FOTOS: Faltan fotografias o ImagenFoto."
            );

            return;
        }

        indiceActual = Mathf.Clamp(
            indiceActual, 0, fotografias.Length - 1
        );

        imagenFoto.sprite = fotografias[indiceActual];
        imagenFoto.preserveAspect = true;
        imagenFoto.enabled = fotografias[indiceActual] != null;
    }

    // =====================================
    // SIGUIENTE
    // =====================================

    public void Siguiente()
    {
        if (fotografias == null ||
            fotografias.Length == 0)
            return;

        indiceActual++;

        if (indiceActual >= fotografias.Length)
            indiceActual = 0;

        MostrarFotografia();
    }

    // =====================================
    // ANTERIOR
    // =====================================

    public void Anterior()
    {
        if (fotografias == null ||
            fotografias.Length == 0)
            return;

        indiceActual--;

        if (indiceActual < 0)
            indiceActual = fotografias.Length - 1;

        MostrarFotografia();
    }

    // =====================================
    // GUARDAR Y OCULTAR HUD
    // =====================================

    private void GuardarYOcultarHUD()
    {
        if (elementosHUDOcultar == null)
            return;

        estadosHUD =
            new bool[elementosHUDOcultar.Length];

        for (int i = 0;
             i < elementosHUDOcultar.Length;
             i++)
        {
            GameObject elemento = elementosHUDOcultar[i];

            if (elemento == null)
                continue;

            estadosHUD[i] = elemento.activeSelf;

            elemento.SetActive(false);
        }
    }

    // =====================================
    // RESTAURAR HUD
    // =====================================

    private void RestaurarHUD()
    {
        if (elementosHUDOcultar == null ||
            estadosHUD == null)
            return;

        for (int i = 0;
             i < elementosHUDOcultar.Length;
             i++)
        {
            if (elementosHUDOcultar[i] == null)
                continue;

            elementosHUDOcultar[i].SetActive(
                estadosHUD[i]
            );
        }

        estadosHUD = null;
    }

    // =====================================
    // CERRAR VISOR
    // =====================================

    public void Cerrar()
    {
        gameObject.SetActive(false);
    }

    // =====================================
    // LIMPIEZA
    // =====================================

    private void OnDisable()
    {
        if (rutinaConexion != null)
        {
            StopCoroutine(rutinaConexion);
            rutinaConexion = null;
        }

        if (movimientoLocal != null)
        {
            movimientoLocal.BloquearMovimiento(
                movimientoEstabaBloqueado
            );

            movimientoLocal = null;
        }

        RestaurarHUD();

        Debug.Log("VISOR FOTOS: Cerrado.");
    }

    private void OnDestroy()
    {
        if (botonAnterior != null)
            botonAnterior.onClick.RemoveListener(Anterior);

        if (botonSiguiente != null)
            botonSiguiente.onClick.RemoveListener(Siguiente);

        if (botonCerrar != null)
            botonCerrar.onClick.RemoveListener(Cerrar);
    }
}
