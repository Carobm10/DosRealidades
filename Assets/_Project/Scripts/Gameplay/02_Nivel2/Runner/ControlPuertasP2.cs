
using UnityEngine;
using Unity.Netcode;

public class ControlPuertasP2 : NetworkBehaviour
{
    // Control de puertas cerradas en el servidor.
    private readonly bool[] puertasCerradasServidor =
        new bool[3];

    // =====================================
    // SOLICITUD DE ELIAN
    // =====================================

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

        SolicitarCerrarPuertaRpc(numeroPuerta);
    }

    // =====================================
    // VALIDACION DEL SERVIDOR
    // =====================================

    [Rpc(SendTo.Server)]
    private void SolicitarCerrarPuertaRpc(
        int numeroPuerta,
        RpcParams rpcParams = default)
    {
        if (numeroPuerta < 1 || numeroPuerta > 3)
            return;

        ulong clienteSolicitante =
            rpcParams.Receive.SenderClientId;

        if (OwnerClientId != clienteSolicitante)
            return;

        NetworkPlayerSetup setup =
            GetComponent<NetworkPlayerSetup>();

        if (setup == null ||
            !setup.RolConfigurado ||
            !setup.EsElian)
            return;

        int indice = numeroPuerta - 1;

        // Evitar solicitudes repetidas.
        if (puertasCerradasServidor[indice])
        {
            Debug.Log(
                "P2: La puerta " + numeroPuerta +
                " ya fue cerrada."
            );

            return;
        }

        // Comprobar que la puerta existe.
        PuertaLiaP2[] puertas =
            FindObjectsByType<PuertaLiaP2>(
                FindObjectsSortMode.None
            );

        bool puertaEncontrada = false;

        foreach (PuertaLiaP2 puerta in puertas)
        {
            if (puerta.NumeroPuerta == numeroPuerta)
            {
                puertaEncontrada = true;
                break;
            }
        }

        if (!puertaEncontrada)
        {
            Debug.LogWarning(
                "P2: No existe la puerta " + numeroPuerta
            );

            return;
        }

        // Registrar el cierre en el servidor.
        puertasCerradasServidor[indice] = true;

        Debug.Log(
            "P2: Elian activa la puerta " + numeroPuerta
        );

        CerrarPuertaLiaRpc(numeroPuerta);
    }

    // =====================================
    // COMUNICAR CIERRE A LOS JUGADORES
    // =====================================

    [Rpc(SendTo.Everyone)]
    private void CerrarPuertaLiaRpc(int numeroPuerta)
    {
        PuertaLiaP2[] puertas =
            FindObjectsByType<PuertaLiaP2>(
                FindObjectsSortMode.None
            );

        foreach (PuertaLiaP2 puerta in puertas)
        {
            if (puerta.NumeroPuerta == numeroPuerta)
            {
                puerta.CerrarVisualLocal();

                Debug.Log(
                    "P2: Cerrando puerta de Lía " +
                    numeroPuerta
                );

                return;
            }
        }

        Debug.LogWarning(
            "P2: No se encontró la puerta de Lía " +
            numeroPuerta
        );
    }
}
