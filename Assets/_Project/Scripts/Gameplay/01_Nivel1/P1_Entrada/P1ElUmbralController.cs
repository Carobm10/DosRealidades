
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

    private bool secuenciaIniciada;

    public bool PuzzleResuelto => puzzleResuelto.Value;

    // =================================
    // INICIO
    // =================================

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

    [Rpc(SendTo.Server, RequireOwnership = false)]
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
        else
        {
            Debug.Log(
                "P1: SIMBOLO INCORRECTO. " +
                "El jugador puede volver a intentarlo."
            );
        }
    }

    // =================================
    // SOLICITAR REINICIO
    // =================================

    public void SolicitarReinicioPuzzle()
    {
        if (!IsSpawned || puzzleResuelto.Value)
            return;

        SolicitarReinicioServidorRpc();
    }

    // =================================
    // VALIDAR REINICIO EN SERVIDOR
    // =================================

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void SolicitarReinicioServidorRpc()
    {
        if (puzzleResuelto.Value)
        {
            Debug.Log(
                "P1: reinicio ignorado. " +
                "El puzzle ya está completado."
            );

            return;
        }

        Debug.Log(
            "P1: un jugador abandono la interaccion. " +
            "Reiniciando puzzle para ambos."
        );

        ReiniciarPuzzleClientRpc();
    }

    // =================================
    // REINICIO SINCRONIZADO
    // =================================

    [Rpc(SendTo.Everyone)]
    private void ReiniciarPuzzleClientRpc()
    {
        // Nunca reiniciar un puzzle completado.

        if (puzzleResuelto.Value)
            return;

        // Cerrar panel de Elian.

        if (ventanaPanelElian != null)
            ventanaPanelElian.SetActive(false);

        // Cerrar panel de Lia.

        if (ventanaPanelLia != null)
            ventanaPanelLia.SetActive(false);

        // Restablecer los simbolos y mensajes
        // de la interfaz local.

        if (PanelSimbolosUI.Instancia != null)
        {
            PanelSimbolosUI.Instancia.RestablecerPanel();
        }

        Debug.Log(
            "P1: PUZZLE REINICIADO PARA AMBOS JUGADORES."
        );
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

        // Restablecer interfaz local.

        if (PanelSimbolosUI.Instancia != null)
        {
            PanelSimbolosUI.Instancia.RestablecerPanel();
        }

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

        // Actualizar mision.

        if (HUDMision.Instancia != null)
        {
            HUDMision.Instancia.OcultarMision();
        }

        // Activar salida cooperativa desde servidor.

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
