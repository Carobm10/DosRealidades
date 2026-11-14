
using System.Collections;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class UIContadorFragmentos : MonoBehaviour
{
    [Header("Interfaz")]
    [SerializeField] private TMP_Text textoContador;

    [Header("Configuracion")]
    [SerializeField] private int totalFragmentos = 5;

    private int fragmentosActuales = 0;

    private InventarioJugador inventarioLocal;

    private Coroutine rutinaConexion;

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        ActualizarVisual();
    }

    private void Start()
    {
        rutinaConexion = StartCoroutine(
            ConectarInventarioLocal()
        );
    }

    // =====================================
    // CONECTAR INVENTARIO DEL JUGADOR LOCAL
    // =====================================

    private IEnumerator ConectarInventarioLocal()
    {
        while (inventarioLocal == null)
        {
            NetworkManager red = NetworkManager.Singleton;

            if (red != null &&
                red.IsListening &&
                red.LocalClient != null &&
                red.LocalClient.PlayerObject != null)
            {
                inventarioLocal =
                    red.LocalClient.PlayerObject
                    .GetComponent<InventarioJugador>();

                if (inventarioLocal != null)
                {
                    inventarioLocal.InventarioActualizado +=
                        ActualizarDesdeInventario;

                    ActualizarDesdeInventario();

                    Debug.Log(
                        "CONTADOR CONECTADO | Jugador: " +
                        red.LocalClientId
                    );

                    yield break;
                }
            }

            yield return null;
        }
    }

    // =====================================
    // CONTAR FRAGMENTOS DEL INVENTARIO
    // =====================================

    private void ActualizarDesdeInventario()
    {
        if (inventarioLocal == null)
            return;

        int cantidad = 0;

        for (int i = 0;
             i < inventarioLocal.CantidadObjetos;
             i++)
        {
            ObjetoInventario objeto =
                inventarioLocal.ObtenerObjeto(i);

            if (objeto != null &&
                objeto.Tipo ==
                TipoObjetoInventario.FragmentoCarta)
            {
                cantidad++;
            }
        }

        EstablecerProgreso(
            cantidad,
            totalFragmentos
        );
    }

    // =====================================
    // ESTABLECER PROGRESO
    // =====================================

    public void EstablecerProgreso(
        int cantidad,
        int total)
    {
        totalFragmentos = Mathf.Max(0, total);

        fragmentosActuales = Mathf.Clamp(
            cantidad,
            0,
            totalFragmentos
        );

        ActualizarVisual();
    }

    // =====================================
    // ACTUALIZAR INTERFAZ
    // =====================================

    private void ActualizarVisual()
    {
        if (textoContador != null)
        {
            textoContador.text =
                fragmentosActuales +
                "/" +
                totalFragmentos;
        }
    }

    // =====================================
    // LIMPIEZA
    // =====================================

    private void OnDestroy()
    {
        if (inventarioLocal != null)
        {
            inventarioLocal.InventarioActualizado -=
                ActualizarDesdeInventario;
        }

        if (rutinaConexion != null)
            StopCoroutine(rutinaConexion);
    }
}
