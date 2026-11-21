
using UnityEngine;
using Unity.Netcode;

public class ControlPuertasP2 : NetworkBehaviour
{
    private readonly bool[] puertasCerradasServidor =
        new bool[3];

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            for (int i = 0; i < puertasCerradasServidor.Length; i++)
                puertasCerradasServidor[i] = false;
        }
    }

    // SOLICITUD DE ELIAN

    public void SolicitarCerrarPuerta(int numeroPuerta)
    {
        if (!IsOwner)
            return;

        if (numeroPuerta < 1 || numeroPuerta > 3)
            return;

        NetworkPlayerSetup setup =
            GetComponent<NetworkPlayerSetup>();

        if (setup == null ||
            !setup.RolConfigurado ||
            !setup.EsElian)
            return;

        Debug.Log("P2: Elian solicita cerrar puerta " + numeroPuerta);

        SolicitarCerrarPuertaRpc(numeroPuerta);
    }

    // VALIDACION DEL SERVIDOR

    [Rpc(SendTo.Server, RequireOwnership = true)]
    private void SolicitarCerrarPuertaRpc(
        int numeroPuerta,
        RpcParams rpcParams = default)
    {
        if (!IsServer ||
            numeroPuerta < 1 ||
            numeroPuerta > 3)
            return;

        if (rpcParams.Receive.SenderClientId != OwnerClientId)
            return;

        NetworkPlayerSetup setup =
            GetComponent<NetworkPlayerSetup>();

        if (setup == null ||
            !setup.RolConfigurado ||
            !setup.EsElian)
            return;

        int indice = numeroPuerta - 1;

        if (puertasCerradasServidor[indice])
        {
            Debug.Log("P2: La puerta ya estaba cerrada.");
            return;
        }

        // Registrar la acción sin buscar la puerta
        // en la realidad local del servidor.

        puertasCerradasServidor[indice] = true;

        Debug.Log(
            "P2: Servidor confirma cierre de puerta " +
            numeroPuerta
        );

        CerrarPuertaLiaRpc(numeroPuerta);
    }

    // EJECUTAR EN TODOS LOS CLIENTES

    
    [Rpc(SendTo.Everyone, RequireOwnership = false)]
    private void CerrarPuertaLiaRpc(int numeroPuerta)
    {
        PuertaLiaP2[] puertas =
            FindObjectsByType<PuertaLiaP2>(
                FindObjectsSortMode.None
            );

        bool encontrada = false;

        foreach (PuertaLiaP2 puerta in puertas)
        {
            if (puerta == null ||
                !puerta.gameObject.activeInHierarchy ||
                puerta.NumeroPuerta != numeroPuerta)
                continue;

            puerta.CerrarVisualLocal();
            encontrada = true;

            Debug.Log(
                "P2: Puerta activa de Lia cerrada: " +
                numeroPuerta
            );
        }

        if (!encontrada)
        {
            Debug.LogWarning(
                "P2: No se encontró una puerta activa número " +
                numeroPuerta
            );
        }
    }

}
