using UnityEngine;
using Unity.Netcode;

public enum LadoCamino
{
    Izquierda,
    Derecha
}

public class PuzzleCaminoMadera : NetworkBehaviour
{
    [Header("Secuencia correcta")]
    [SerializeField]
    private LadoCamino[] secuenciaCorrecta;

    [Header("Zonas seguras de Lia")]
    [SerializeField]
    private BoxCollider2D[] zonasSeguras;

    [Header("Tramo final")]
    [SerializeField]
    private GameObject plataformaMovilLia;

    private NetworkVariable<int> pasoActual =
        new NetworkVariable<int>(0);

    private NetworkVariable<bool> filasCompletadas =
        new NetworkVariable<bool>(false);

    public int PasoActual => pasoActual.Value;

    public override void OnNetworkSpawn()
    {
        pasoActual.OnValueChanged += AlCambiarPaso;
        filasCompletadas.OnValueChanged +=
            AlCompletarFilas;

        if (plataformaMovilLia != null)
        {
            plataformaMovilLia.SetActive(
                filasCompletadas.Value
            );
        }

        if (filasCompletadas.Value)
        {
            PrepararTramoFinal();
        }
    }

    public override void OnNetworkDespawn()
    {
        pasoActual.OnValueChanged -= AlCambiarPaso;
        filasCompletadas.OnValueChanged -=
            AlCompletarFilas;
    }

    public void IntentarPaso(
        int fila,
        LadoCamino lado,
        ulong jugadorNetworkObjectId)
    {
        if (!IsSpawned)
            return;

        if (filasCompletadas.Value)
            return;

        RegistrarPasoRpc(
            fila,
            (int)lado,
            jugadorNetworkObjectId
        );
    }

    [Rpc(SendTo.Server)]
    private void RegistrarPasoRpc(
        int fila,
        int lado,
        ulong jugadorNetworkObjectId)
    {
        if (filasCompletadas.Value)
            return;

        if (secuenciaCorrecta == null ||
            secuenciaCorrecta.Length == 0)
            return;

        bool filaCorrecta =
            fila == pasoActual.Value;

        bool ladoCorrecto = false;

        if (filaCorrecta &&
            fila >= 0 &&
            fila < secuenciaCorrecta.Length)
        {
            ladoCorrecto =
                (int)secuenciaCorrecta[fila] ==
                lado;
        }

        if (!filaCorrecta || !ladoCorrecto)
        {
            ProcesarError(
                jugadorNetworkObjectId
            );

            return;
        }

        // Acierto.
        pasoActual.Value++;

        Debug.Log(
            "LIA ACERTO | Paso " +
            pasoActual.Value +
            "/" +
            secuenciaCorrecta.Length
        );

        if (pasoActual.Value >=
            secuenciaCorrecta.Length)
        {
            filasCompletadas.Value = true;
        }
    }

    private void ProcesarError(
        ulong jugadorNetworkObjectId)
    {
        Debug.Log(
            "LIA FALLO | -1 vida de equipo"
        );

        if (VidasEquipo.Instancia != null)
        {
            VidasEquipo.Instancia.PerderVida();
        }

        // Le avisamos al cliente dueño de Lia
        // que debe volver al checkpoint.
        VolverCheckpointRpc(
            jugadorNetworkObjectId,
            pasoActual.Value
        );
    }

    [Rpc(SendTo.Everyone)]
    private void VolverCheckpointRpc(
        ulong jugadorNetworkObjectId,
        int indiceZonaSegura)
    {
        if (NetworkManager.Singleton == null)
            return;

        if (!NetworkManager.Singleton
            .SpawnManager
            .SpawnedObjects
            .TryGetValue(
                jugadorNetworkObjectId,
                out NetworkObject jugador))
        {
            return;
        }

        // Solo el dueño de ese jugador
        // mueve su propio personaje.
        if (!jugador.IsOwner)
            return;

        if (zonasSeguras == null ||
            zonasSeguras.Length == 0)
        {
            return;
        }

        int indice = Mathf.Clamp(
            indiceZonaSegura,
            0,
            zonasSeguras.Length - 1
        );

        BoxCollider2D zona =
            zonasSeguras[indice];

        if (zona == null)
            return;

        Vector2 posicionSegura =
            zona.bounds.center;

        Rigidbody2D rb =
            jugador.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.position = posicionSegura;
        }
        else
        {
            jugador.transform.position =
                posicionSegura;
        }

        Debug.Log(
            "Lia vuelve a " +
            zona.name
        );
    }

    private void AlCambiarPaso(
        int anterior,
        int nuevo)
    {
        Debug.Log(
            "Camino: " +
            nuevo +
            "/" +
            secuenciaCorrecta.Length
        );
    }

    private void AlCompletarFilas(
        bool anterior,
        bool nuevo)
    {
        if (!nuevo)
            return;

        PrepararTramoFinal();
    }

    private void PrepararTramoFinal()
    {
        if (plataformaMovilLia != null)
        {
            plataformaMovilLia.SetActive(true);
        }

        bool esLia;

#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
        {
            esLia =
                RolPruebaJugador.Instancia.EsLia();
        }
        else
        {
            esLia =
                NetworkManager.Singleton != null &&
                !NetworkManager.Singleton.IsHost;
        }
#else
        esLia =
            NetworkManager.Singleton != null &&
            !NetworkManager.Singleton.IsHost;
#endif

        if (HUDMision.Instancia != null)
        {
            if (esLia)
            {
                HUDMision.Instancia.CambiarMision(
                    "Usa la plataforma y salta al otro lado"
                );
            }
            else
            {
                HUDMision.Instancia.CambiarMision(
                    "Ayuda a Lía a llegar al otro lado"
                );
            }
        }

        Debug.Log(
            "FILAS COMPLETADAS - TRAMO FINAL ACTIVO"
        );
    }
}