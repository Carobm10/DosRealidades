
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

    [Header("Salida cooperativa")]
    [SerializeField] private ZonaSalidaCooperativa zonaSalida;

    private NetworkVariable<bool> puzzleResuelto =
        new NetworkVariable<bool>(false);

    private bool secuenciaIniciada = false;

    public override void OnNetworkSpawn()
    {
        puzzleResuelto.OnValueChanged +=
            AlCambiarEstadoPuzzle;

        if (puzzleResuelto.Value)
        {
            EjecutarSecuenciaResuelto();
        }
    }

    public override void OnNetworkDespawn()
    {
        puzzleResuelto.OnValueChanged -=
            AlCambiarEstadoPuzzle;
    }

    // =================================
    // BOTONES DEL PANEL
    // =================================

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

    // =================================
    // VALIDACION EN SERVIDOR
    // =================================

    [Rpc(SendTo.Server)]
    private void EnviarSeleccionServidorRpc(
        int simboloSeleccionado)
    {
        if (puzzleResuelto.Value)
            return;

        bool correcto =
            trianguloEsCorrecto &&
            simboloSeleccionado == 1;

        if (correcto)
        {
            puzzleResuelto.Value = true;

            Debug.Log(
                "P1: PUZZLE DE SIMBOLOS COMPLETADO."
            );
        }
    }

    // =================================
    // PUZZLE RESUELTO
    // =================================

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

        StartCoroutine(
            SecuenciaPuzzleResuelto()
        );
    }

    private IEnumerator SecuenciaPuzzleResuelto()
    {
        yield return new WaitForSeconds(0.5f);

        // Cerrar paneles de ambos jugadores.

        if (ventanaPanelElian != null)
            ventanaPanelElian.SetActive(false);

        if (ventanaPanelLia != null)
            ventanaPanelLia.SetActive(false);

        // Ocultar botones de interaccion.

        if (HUDInteraccion.Instancia != null)
        {
            if (interaccionPanelElian != null)
            {
                HUDInteraccion.Instancia.OcultarBoton(
                    interaccionPanelElian
                );
            }

            if (interaccionPanelLia != null)
            {
                HUDInteraccion.Instancia.OcultarBoton(
                    interaccionPanelLia
                );
            }
        }

        // Desactivar interacciones del puzzle.

        if (interaccionPanelElian != null)
            interaccionPanelElian.enabled = false;

        if (interaccionPanelLia != null)
            interaccionPanelLia.enabled = false;

        // Completar brillo de ambos objetivos.

        if (brilloPanelElian != null)
            brilloPanelElian.CompletarObjetivo();

        if (brilloPanelLia != null)
            brilloPanelLia.CompletarObjetivo();

        // Ocultar mision anterior.

        if (HUDMision.Instancia != null)
            HUDMision.Instancia.OcultarMision();

        // =================================
        // ACTIVAR SALIDA COOPERATIVA
        // =================================

        if (IsServer)
        {
            if (zonaSalida != null)
            {
                zonaSalida.HabilitarSalida();

                Debug.Log(
                    "P1: salida cooperativa activada."
                );
            }
            else
            {
                Debug.LogError(
                    "P1: no se asigno PF_ZonaSalida " +
                    "en P1ElUmbralController."
                );
            }
        }

        // Nueva mision para ambos jugadores.

        if (HUDMision.Instancia != null)
        {
            HUDMision.Instancia.CambiarMision(
                "Acércate a la puerta"
            );
        }

        Debug.Log(
            "P1: secuencia de puzzle finalizada."
        );
    }
}
