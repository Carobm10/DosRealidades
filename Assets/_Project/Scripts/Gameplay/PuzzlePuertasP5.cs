using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class PuzzlePuertasP5 : NetworkBehaviour
{
    [Header("Secuencia correcta")]
    [SerializeField] private int[] secuenciaCorrecta =
    {
        204, 201, 203
    };

    [Header("Errores")]
    [SerializeField] private int fallosParaVigilia = 3;

    [Tooltip("Si está activo, un error vuelve al primer paso.")]
    [SerializeField] private bool reiniciarProgresoAlFallar = false;

    [Header("La Vigilia")]
    [SerializeField] private GameObject vigiliaVisual;
    [SerializeField] private float tiempoVigilia = 5f;

    [Header("Misión después del puzzle")]
    [SerializeField]
    private string misionElian =
        "Busca el objeto que necesitas para continuar";

    [SerializeField]
    private string misionLia =
        "Busca el objeto que necesitas para continuar";

    private NetworkVariable<int> pasoActual =
        new NetworkVariable<int>(0);

    private NetworkVariable<int> fallosActuales =
        new NetworkVariable<int>(0);

    private NetworkVariable<bool> puzzleCompletado =
        new NetworkVariable<bool>(false);

    // Sirve para evitar que el segundo jugador
    // vuelva a activar inmediatamente la puerta
    // que acabamos de validar.
    private NetworkVariable<int> ultimaPuertaCorrecta =
        new NetworkVariable<int>(-1);

    public bool PuzzleCompletado =>
        puzzleCompletado.Value;

    public override void OnNetworkSpawn()
    {
        puzzleCompletado.OnValueChanged +=
            AlCambiarPuzzleCompletado;

        if (vigiliaVisual != null)
            vigiliaVisual.SetActive(false);

        if (puzzleCompletado.Value)
            FinalizarPuzzleLocal();
    }

    public override void OnNetworkDespawn()
    {
        puzzleCompletado.OnValueChanged -=
            AlCambiarPuzzleCompletado;
    }

    public void IntentarPuerta(int numeroPuerta)
    {
        if (!IsSpawned)
            return;

        if (puzzleCompletado.Value)
            return;

        IntentarPuertaRpc(numeroPuerta);
    }

    [Rpc(SendTo.Server)]
    private void IntentarPuertaRpc(int numeroPuerta)
    {
        if (puzzleCompletado.Value)
            return;

        if (secuenciaCorrecta == null ||
            secuenciaCorrecta.Length == 0)
        {
            Debug.LogWarning(
                "P5: no hay secuencia configurada."
            );

            return;
        }

        if (pasoActual.Value >=
            secuenciaCorrecta.Length)
        {
            return;
        }

        int puertaEsperada =
            secuenciaCorrecta[pasoActual.Value];

        // Evita que el segundo jugador,
        // al atravesar la misma puerta correcta,
        // genere un error falso.
        if (numeroPuerta ==
                ultimaPuertaCorrecta.Value &&
            numeroPuerta != puertaEsperada)
        {
            return;
        }

        if (numeroPuerta == puertaEsperada)
        {
            ProcesarAcierto(numeroPuerta);
        }
        else
        {
            ProcesarError(numeroPuerta);
        }
    }

    private void ProcesarAcierto(
        int numeroPuerta)
    {
        ultimaPuertaCorrecta.Value =
            numeroPuerta;

        pasoActual.Value++;

        Debug.Log(
            "P5 | Puerta " +
            numeroPuerta +
            " CORRECTA | Paso " +
            pasoActual.Value +
            "/" +
            secuenciaCorrecta.Length
        );

        if (pasoActual.Value >=
            secuenciaCorrecta.Length)
        {
            puzzleCompletado.Value = true;
        }
    }

    private void ProcesarError(
        int numeroPuerta)
    {
        fallosActuales.Value++;

        Debug.Log(
            "P5 | Puerta " +
            numeroPuerta +
            " INCORRECTA | Fallos: " +
            fallosActuales.Value +
            "/" +
            fallosParaVigilia
        );

        if (reiniciarProgresoAlFallar)
        {
            pasoActual.Value = 0;
            ultimaPuertaCorrecta.Value = -1;
        }

        if (fallosActuales.Value >=
            fallosParaVigilia)
        {
            fallosActuales.Value = 0;

            MostrarVigiliaRpc();
        }
    }

    [Rpc(SendTo.Everyone)]
    private void MostrarVigiliaRpc()
    {
        if (vigiliaVisual == null)
            return;

        StopCoroutine(
            nameof(RutinaVigilia)
        );

        StartCoroutine(
            RutinaVigilia()
        );
    }

    private IEnumerator RutinaVigilia()
    {
        vigiliaVisual.SetActive(true);

        yield return new WaitForSeconds(
            tiempoVigilia
        );

        vigiliaVisual.SetActive(false);
    }

    private void AlCambiarPuzzleCompletado(
        bool anterior,
        bool nuevo)
    {
        if (!nuevo)
            return;

        FinalizarPuzzleLocal();
    }

    private void FinalizarPuzzleLocal()
    {
        Debug.Log(
            "P5 PUERTAS COMPLETADO ✅"
        );

        bool esElian;

#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
        {
            esElian =
                RolPruebaJugador.Instancia.EsElian();
        }
        else
        {
            esElian =
                NetworkManager.Singleton != null &&
                NetworkManager.Singleton.IsHost;
        }
#else
        esElian =
            NetworkManager.Singleton != null &&
            NetworkManager.Singleton.IsHost;
#endif

        if (HUDMision.Instancia != null)
        {
            HUDMision.Instancia.CambiarMision(
                esElian
                    ? misionElian
                    : misionLia
            );
        }
    }
}