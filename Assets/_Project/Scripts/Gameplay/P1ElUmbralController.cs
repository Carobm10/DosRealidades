using UnityEngine;
using Unity.Netcode;

public class P1ElUmbralController : NetworkBehaviour
{
    private enum SimboloP1
    {
        Circulo = 0,
        Triangulo = 1,
        Cuadrado = 2
    }

    [Header("Puerta de recepcion")]
    [SerializeField] private GameObject visualPuerta;
    [SerializeField] private Collider2D colliderPuerta;

    private NetworkVariable<bool> puertaAbierta =
        new NetworkVariable<bool>(false);

    public override void OnNetworkSpawn()
    {
        puertaAbierta.OnValueChanged += AlCambiarEstadoPuerta;

        AplicarEstadoPuerta(puertaAbierta.Value);
    }

    public override void OnNetworkDespawn()
    {
        puertaAbierta.OnValueChanged -= AlCambiarEstadoPuerta;
    }

    // --------------------------------------------------
    // BOTONES DEL PANEL
    // --------------------------------------------------

    public void SeleccionarCirculo()
    {
        SolicitarSeleccionRpc((int)SimboloP1.Circulo);
    }

    public void SeleccionarTriangulo()
    {
        SolicitarSeleccionRpc((int)SimboloP1.Triangulo);
    }

    public void SeleccionarCuadrado()
    {
        SolicitarSeleccionRpc((int)SimboloP1.Cuadrado);
    }

    // --------------------------------------------------
    // VALIDACION EN EL HOST
    // --------------------------------------------------

    [Rpc(SendTo.Server)]
    private void SolicitarSeleccionRpc(
        int simbolo,
        RpcParams rpcParams = default)
    {
        if (puertaAbierta.Value)
            return;

        ulong clienteQueRespondio =
            rpcParams.Receive.SenderClientId;

        bool esCorrecto =
            simbolo == (int)SimboloP1.Triangulo;

        if (esCorrecto)
        {
            puertaAbierta.Value = true;

            Debug.Log("P1 completado: TRIANGULO correcto.");
        }
        else
        {
            Debug.Log("P1: simbolo incorrecto.");
        }

        MostrarResultadoRpc(
            esCorrecto,
            RpcTarget.Single(
                clienteQueRespondio,
                RpcTargetUse.Temp
            )
        );
    }

    // --------------------------------------------------
    // RESULTADO SOLO PARA QUIEN RESPONDIO
    // --------------------------------------------------

    [Rpc(SendTo.SpecifiedInParams)]
    private void MostrarResultadoRpc(
        bool correcto,
        RpcParams rpcParams = default)
    {
        if (PanelSimbolosUI.Instancia != null)
        {
            PanelSimbolosUI.Instancia.MostrarResultado(correcto);
        }
    }

    // --------------------------------------------------
    // PUERTA SINCRONIZADA
    // --------------------------------------------------

    private void AlCambiarEstadoPuerta(
        bool anterior,
        bool nuevo)
    {
        AplicarEstadoPuerta(nuevo);
    }

    private void AplicarEstadoPuerta(bool abierta)
    {
        if (visualPuerta != null)
        {
            visualPuerta.SetActive(!abierta);
        }

        if (colliderPuerta != null)
        {
            colliderPuerta.enabled = !abierta;
        }
    }
}