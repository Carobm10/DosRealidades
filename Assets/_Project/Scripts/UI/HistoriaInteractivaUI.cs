
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;

public class HistoriaInteractivaUI : MonoBehaviour
{
    [Header("Contenido de la historia")]
    [SerializeField] private Image imagenHistoria;
    [SerializeField] private TMP_Text tituloHistoria;
    [SerializeField] private TMP_Text textoHistoria;

    [Header("Boton cerrar")]
    [SerializeField] private Button botonCerrar;

    [Header("Configuracion")]
    [SerializeField] private bool bloquearMovimiento = true;

    private NetworkPlayerMovement movimientoLocal;
    private bool movimientoEstabaBloqueado;
    private bool bloqueoAplicado;

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        if (botonCerrar != null)
        {
            botonCerrar.onClick.AddListener(CerrarHistoria);
        }
    }

    // =====================================
    // AL ABRIR LA HISTORIA
    // =====================================

    private void OnEnable()
    {
        if (!Application.isPlaying)
            return;

        if (bloquearMovimiento)
            BloquearJugadorLocal();

        Debug.Log("HISTORIA: abierta.");
    }

    // =====================================
    // BLOQUEAR MOVIMIENTO LOCAL
    // =====================================

    private void BloquearJugadorLocal()
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red == null ||
            red.LocalClient == null ||
            red.LocalClient.PlayerObject == null)
            return;

        movimientoLocal =
            red.LocalClient.PlayerObject
                .GetComponent<NetworkPlayerMovement>();

        if (movimientoLocal == null)
            return;

        movimientoEstabaBloqueado =
            movimientoLocal.MovimientoBloqueado;

        movimientoLocal.BloquearMovimiento(true);

        bloqueoAplicado = true;
    }

    // =====================================
    // CERRAR HISTORIA
    // =====================================

    public void CerrarHistoria()
    {
        gameObject.SetActive(false);

        Debug.Log("HISTORIA: cerrada.");
    }

    // =====================================
    // RESTAURAR MOVIMIENTO
    // =====================================

    private void OnDisable()
    {
        if (!Application.isPlaying ||
            !bloqueoAplicado)
            return;

        // No desbloquear si se perdio la conexion.
        NetworkManager red = NetworkManager.Singleton;

        if (red != null &&
            red.IsListening &&
            red.IsConnectedClient &&
            movimientoLocal != null)
        {
            movimientoLocal.BloquearMovimiento(
                movimientoEstabaBloqueado
            );
        }

        bloqueoAplicado = false;
        movimientoLocal = null;
    }

    private void OnDestroy()
    {
        if (botonCerrar != null)
        {
            botonCerrar.onClick.RemoveListener(
                CerrarHistoria
            );
        }
    }
}
