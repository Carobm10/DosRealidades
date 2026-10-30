
using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class P1ElUmbralController : NetworkBehaviour
{
    [Header("Paneles de ambos jugadores")]
    [SerializeField] private GameObject ventanaPanelElian;
    [SerializeField] private GameObject ventanaPanelLia;

    [Header("Interacciones")]
    [SerializeField] private ZonaInteraccion interaccionPanelElian;
    [SerializeField] private ZonaInteraccion interaccionPanelLia;
    [Header("Brillo de los objetivos")]
    [SerializeField] private BrilloObjetivo brilloPanelElian;
    [SerializeField] private BrilloObjetivo brilloPanelLia;

    [Header("Estado del puzzle")]
    [SerializeField] private bool trianguloEsCorrecto = true;

    [Header("Puertas")]
    [SerializeField] private Animator animatorPuertaElian;
    [SerializeField] private Animator animatorPuertaLia;
    [SerializeField] private string parametroAbrir = "Abrir";

    [Header("Camara")]
    [SerializeField] private Transform puntoCamaraPuerta;
    [SerializeField] private float duracionEnfoquePuerta = 2f;

    [Header("Animacion")]
    [SerializeField] private float esperaAnimacion = 0.35f;

    private NetworkVariable<bool> puzzleResuelto =
        new NetworkVariable<bool>(false);

    private bool secuenciaIniciada = false;

    public override void OnNetworkSpawn()
    {
        puzzleResuelto.OnValueChanged += AlCambiarEstadoPuzzle;

        if (puzzleResuelto.Value)
        {
            EjecutarSecuenciaResuelto();
        }
    }

    public override void OnNetworkDespawn()
    {
        puzzleResuelto.OnValueChanged -= AlCambiarEstadoPuzzle;
    }

    // =========================
    // BOTONES DEL PANEL
    // =========================

    public void SeleccionarCirculo()
    {
        if (puzzleResuelto.Value)
            return;

        PanelSimbolosUI.Instancia?.SeleccionarCirculo();

        EnviarSeleccionServidorRpc(0);
    }

    public void SeleccionarTriangulo()
    {
        if (puzzleResuelto.Value)
            return;

        PanelSimbolosUI.Instancia?.SeleccionarTriangulo();

        EnviarSeleccionServidorRpc(1);
    }

    public void SeleccionarCuadrado()
    {
        if (puzzleResuelto.Value)
            return;

        PanelSimbolosUI.Instancia?.SeleccionarCuadrado();

        EnviarSeleccionServidorRpc(2);
    }

    // =========================
    // VALIDACION EN SERVIDOR
    // =========================

    [Rpc(SendTo.Server)]
    private void EnviarSeleccionServidorRpc(int simboloSeleccionado)
    {
        if (puzzleResuelto.Value)
            return;

        bool correcto =
            trianguloEsCorrecto &&
            simboloSeleccionado == 1;

        if (correcto)
        {
            puzzleResuelto.Value = true;
        }
    }

    // =========================
    // PUZZLE RESUELTO
    // =========================

    private void AlCambiarEstadoPuzzle(
        bool valorAnterior,
        bool valorNuevo)
    {
        if (!valorNuevo)
            return;

        EjecutarSecuenciaResuelto();
    }

    private void EjecutarSecuenciaResuelto()
    {
        if (secuenciaIniciada)
            return;

        secuenciaIniciada = true;

        StartCoroutine(SecuenciaPuzzleResuelto());
    }

    private IEnumerator SecuenciaPuzzleResuelto()
    {
        yield return new WaitForSeconds(0.5f);

        // Cerrar paneles
        if (ventanaPanelElian != null)
            ventanaPanelElian.SetActive(false);

        if (ventanaPanelLia != null)
            ventanaPanelLia.SetActive(false);

        // Ocultar botones de interaccion
        if (HUDInteraccion.Instancia != null)
        {
            if (interaccionPanelElian != null)
                HUDInteraccion.Instancia.OcultarBoton(interaccionPanelElian);

            if (interaccionPanelLia != null)
                HUDInteraccion.Instancia.OcultarBoton(interaccionPanelLia);
        }

        // Desactivar interacciones del puzzle
        if (interaccionPanelElian != null)
            interaccionPanelElian.enabled = false;

        if (interaccionPanelLia != null)
            interaccionPanelLia.enabled = false;

        // Detener el brillo de ambos paneles
        if (brilloPanelElian != null)
            brilloPanelElian.CompletarObjetivo();

        if (brilloPanelLia != null)
            brilloPanelLia.CompletarObjetivo();

        // Ocultar mision
        if (HUDMision.Instancia != null)
            HUDMision.Instancia.OcultarMision();

        // Enfocar camara en la puerta
        EnfocarCamaraLocalEnPuerta();

        // Dar tiempo para que la camara llegue a la puerta
        yield return new WaitForSeconds(esperaAnimacion);

        // Reproducir animacion de la puerta correspondiente
        Animator puertaLocal = ObtenerAnimatorPuertaLocal();

        if (puertaLocal != null)
        {
            puertaLocal.SetTrigger(parametroAbrir);
        }
        else
        {
            Debug.LogWarning(
                "No se encontro el Animator de la puerta local."
            );
        }

        // Esperar el resto del enfoque
        yield return new WaitForSeconds(
            Mathf.Max(0f, duracionEnfoquePuerta - esperaAnimacion)
        );

        // Mostrar nueva mision
        if (HUDMision.Instancia != null)
        {
            HUDMision.Instancia.CambiarMision(
                "Acércate a la puerta"
            );
        }
    }

    // =========================
    // IDENTIFICAR PUERTA LOCAL
    // =========================

    private Animator ObtenerAnimatorPuertaLocal()
    {
        bool esElian;

#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
        {
            esElian = RolPruebaJugador.Instancia.EsElian();
        }
        else
        {
            esElian =
                NetworkManager.Singleton == null ||
                NetworkManager.Singleton.IsHost;
        }
#else
        esElian =
            NetworkManager.Singleton != null &&
            NetworkManager.Singleton.IsHost;
#endif

        return esElian
            ? animatorPuertaElian
            : animatorPuertaLia;
    }

    // =========================
    // CAMARA
    // =========================

    private void EnfocarCamaraLocalEnPuerta()
    {
        if (puntoCamaraPuerta == null)
        {
            Debug.LogWarning(
                "No se asigno PuntoCamaraPuerta."
            );
            return;
        }

        if (NetworkManager.Singleton == null)
            return;

        if (NetworkManager.Singleton.LocalClient == null)
            return;

        NetworkObject jugadorLocal =
            NetworkManager.Singleton.LocalClient.PlayerObject;

        if (jugadorLocal == null)
            return;

        CamaraJugadorLocal camara =
            jugadorLocal.GetComponent<CamaraJugadorLocal>();

        if (camara == null)
        {
            Debug.LogWarning(
                "El jugador local no tiene CamaraJugadorLocal."
            );
            return;
        }

        camara.EnfocarTemporalmente(
            puntoCamaraPuerta.position,
            duracionEnfoquePuerta
        );
    }
}
