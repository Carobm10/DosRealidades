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
    [Header("Estado del puzzle")]
    [SerializeField] private bool trianguloEsCorrecto = true;

    [Header("Camara")]
    [SerializeField] private Transform puntoCamaraPuerta;
    [SerializeField] private float duracionEnfoquePuerta = 2f;

    private NetworkVariable<bool> puzzleResuelto =
        new NetworkVariable<bool>(false);

    public override void OnNetworkSpawn()
    {
        puzzleResuelto.OnValueChanged += AlCambiarEstadoPuzzle;

        // Por si un cliente entra cuando el puzzle ya fue resuelto.
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

        if (PanelSimbolosUI.Instancia != null)
        {
            PanelSimbolosUI.Instancia.SeleccionarCirculo();
        }

        EnviarSeleccionServidorRpc(0);
    }

    public void SeleccionarTriangulo()
    {
        if (puzzleResuelto.Value)
            return;

        if (PanelSimbolosUI.Instancia != null)
        {
            PanelSimbolosUI.Instancia.SeleccionarTriangulo();
        }

        EnviarSeleccionServidorRpc(1);
    }

    public void SeleccionarCuadrado()
    {
        if (puzzleResuelto.Value)
            return;

        if (PanelSimbolosUI.Instancia != null)
        {
            PanelSimbolosUI.Instancia.SeleccionarCuadrado();
        }

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

        // 0 = circulo
        // 1 = triangulo
        // 2 = cuadrado

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
        bool valorNuevo
    )
    {
        if (!valorNuevo)
            return;

        EjecutarSecuenciaResuelto();
    }

    private void EjecutarSecuenciaResuelto()
    {
        StartCoroutine(SecuenciaPuzzleResuelto());
    }

    private IEnumerator SecuenciaPuzzleResuelto()
    {
        // Mostramos medio segundo el resultado correcto.
        yield return new WaitForSeconds(0.5f);

        // Cerramos panel de Elian.
        if (ventanaPanelElian != null)
        {
            ventanaPanelElian.SetActive(false);
        }

        // Cerramos panel/pista de Lia.
        if (ventanaPanelLia != null)
        {
            ventanaPanelLia.SetActive(false);
        }

        // Quitamos cualquier boton de interactuar.
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

        // Ya no pueden volver a interactuar con el puzzle.
        if (interaccionPanelElian != null)
        {
            interaccionPanelElian.enabled = false;
        }

        if (interaccionPanelLia != null)
        {
            interaccionPanelLia.enabled = false;
        }

        // Ocultamos la misión durante el enfoque.
        if (HUDMision.Instancia != null)
        {
            HUDMision.Instancia.OcultarMision();
        }

        // Cámara hacia la puerta.
        EnfocarCamaraLocalEnPuerta();

        // Esperamos mientras la cámara está enfocando la puerta.
        yield return new WaitForSeconds(
            duracionEnfoquePuerta
        );

        // La cámara vuelve sola al jugador.
        // Mostramos la nueva misión.
        if (HUDMision.Instancia != null)
        {
            HUDMision.Instancia.CambiarMision(
                "Acércate a la puerta"
            );
        }
    }

    private void EnfocarCamaraLocalEnPuerta()
    {
        if (puntoCamaraPuerta == null)
        {
            Debug.LogWarning(
                "No se asigno PuntoCamaraPuerta en P1ElUmbralController."
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