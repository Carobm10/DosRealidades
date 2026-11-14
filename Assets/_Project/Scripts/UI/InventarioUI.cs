
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class InventarioUI : MonoBehaviour
{
    public static InventarioUI Instancia { get; private set; }

    [Header("Panel de inventario")]
    [SerializeField] private GameObject panelInventario;
    [SerializeField] private Button botonAbrirInventario;
    [SerializeField] private Button botonCerrarInventario;

    [Header("Espacios del inventario")]
    [SerializeField] private SlotInventarioUI[] slots;

    [Header("Objeto preparado")]
    [SerializeField] private GameObject indicadorObjetoPreparado;
    [SerializeField] private Image imagenObjetoPreparado;
    [SerializeField] private TMP_Text textoObjetoPreparado;

    [Header("Tarjeta de objeto recolectado")]
    [SerializeField] private GameObject panelObjetoRecolectado;
    [SerializeField] private TMP_Text tituloObjetoRecolectado;
    [SerializeField] private TMP_Text descripcionObjetoRecolectado;
    [SerializeField] private Image imagenObjetoRecolectado;
    [SerializeField] private Button botonCerrarObjetoRecolectado;


    [Header("Controles que se ocultan")]
    [SerializeField] private GameObject[] controlesOcultar;

    private bool[] estadosControles;

    private InventarioJugador inventarioJugador;
    private NetworkPlayerMovement movimientoLocal;

    private ObjetoInventario objetoPreparado;

    private bool movimientoEstabaBloqueado;

    // =====================================
    // PROPIEDADES
    // =====================================

    public ObjetoInventario ObjetoPreparado =>
        objetoPreparado;

    public bool TieneObjetoPreparado =>
        objetoPreparado != null;

    public bool InventarioAbierto =>
        panelInventario != null &&
        panelInventario.activeSelf;

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            Destroy(this);
            return;
        }

        Instancia = this;

        if (botonAbrirInventario != null)
            botonAbrirInventario.onClick.AddListener(
                AlternarInventario
            );

        if (botonCerrarInventario != null)
            botonCerrarInventario.onClick.AddListener(
                CerrarInventario
            );

        if (slots != null)
        {
            foreach (SlotInventarioUI slot in slots)
            {
                if (slot != null)
                {
                    slot.SeleccionSolicitada +=
                        SeleccionarObjeto;
                }
            }
        }

        if (panelInventario != null)
            panelInventario.SetActive(false);

        if (indicadorObjetoPreparado != null)
            indicadorObjetoPreparado.SetActive(false);
        
        if (panelObjetoRecolectado != null)
            panelObjetoRecolectado.SetActive(false);

        if (botonCerrarObjetoRecolectado != null)
        {
            botonCerrarObjetoRecolectado.onClick.AddListener(
                CerrarTarjetaObjeto
            );
        }
    }

    private void Start()
    {
        StartCoroutine(ConectarInventarioLocal());
    }

    // =====================================
    // CONECTAR CON EL JUGADOR LOCAL
    // =====================================

    private IEnumerator ConectarInventarioLocal()
    {
        while (true)
        {
            NetworkManager red = NetworkManager.Singleton;

            if (red != null &&
                red.IsListening &&
                red.LocalClient != null &&
                red.LocalClient.PlayerObject != null)
            {
                NetworkObject jugador =
                    red.LocalClient.PlayerObject;

                inventarioJugador =
                    jugador.GetComponent<InventarioJugador>();

                movimientoLocal =
                    jugador.GetComponent<NetworkPlayerMovement>();

                if (inventarioJugador != null)
                {
                    inventarioJugador.InventarioActualizado +=
                        RefrescarInventario;

                    RefrescarInventario();

                    Debug.Log(
                        "INVENTARIO UI CONECTADO | Jugador: " +
                        jugador.OwnerClientId
                    );

                    yield break;
                }

                Debug.LogError(
                    "No se encontró InventarioJugador " +
                    "en el jugador local."
                );

                yield break;
            }

            yield return null;
        }
    }

    // =====================================
    // ABRIR INVENTARIO
    // =====================================

    public void AbrirInventario()
    {
        if (panelInventario == null ||
            InventarioAbierto ||
            inventarioJugador == null)
            return;

        GuardarYOcultarControles();

        if (movimientoLocal != null)
        {
            movimientoEstabaBloqueado =
                movimientoLocal.MovimientoBloqueado;

            movimientoLocal.BloquearMovimiento(true);
        }

        RefrescarInventario();

        panelInventario.SetActive(true);

        Debug.Log("INVENTARIO ABIERTO");
    }

    // =====================================
    // ALTERNAR INVENTARIO
    // =====================================

    public void AlternarInventario()
    {
        if (InventarioAbierto)
            CerrarInventario();
        else
            AbrirInventario();
    }

    // =====================================
    // CERRAR INVENTARIO
    // =====================================

    public void CerrarInventario()
    {
        if (panelInventario != null)
            panelInventario.SetActive(false);

        RestaurarControles();

        if (movimientoLocal != null)
        {
            movimientoLocal.BloquearMovimiento(
                movimientoEstabaBloqueado
            );
        }

        ActualizarIndicadorPreparado();

        Debug.Log("INVENTARIO CERRADO");
    }

    // =====================================
    // ACTUALIZAR ESPACIOS
    // =====================================

    public void RefrescarInventario()
    {
        if (inventarioJugador == null ||
            slots == null)
            return;

        if (objetoPreparado != null &&
            !inventarioJugador.TieneObjeto(
                objetoPreparado.Id))
        {
            objetoPreparado = null;
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
                continue;

            ObjetoInventario objeto =
                inventarioJugador.ObtenerObjeto(i);

            bool ocupado = objeto != null;

            bool seleccionado =
                ocupado &&
                objetoPreparado != null &&
                objeto.Id == objetoPreparado.Id;

            slots[i].Configurar(
                ocupado ? objeto.Imagen : null,
                ocupado,
                seleccionado
            );
        }

        ActualizarIndicadorPreparado();
    }

    // =====================================
    // SELECCIONAR OBJETO
    // =====================================

    private void SeleccionarObjeto(int indice)
    {
        if (inventarioJugador == null)
            return;

        ObjetoInventario objeto =
            inventarioJugador.ObtenerObjeto(indice);

        if (objeto == null)
            return;

        if (!objeto.PermiteSeleccion)
        {
            Debug.Log(
                "Este objeto no permite selección."
            );
            return;
        }

        objetoPreparado = objeto;

        RefrescarInventario();

        // Cerrar automáticamente.
        CerrarInventario();

        Debug.Log(
            "OBJETO PREPARADO: " + objeto.Nombre
        );
    }

    // =====================================
    // INDICADOR DEL OBJETO PREPARADO
    // =====================================

    private void ActualizarIndicadorPreparado()
    {
        bool tieneObjeto =
            objetoPreparado != null;

        if (indicadorObjetoPreparado != null)
        {
            indicadorObjetoPreparado.SetActive(
                tieneObjeto
            );
        }

        if (imagenObjetoPreparado != null)
        {
            imagenObjetoPreparado.sprite =
                tieneObjeto
                ? objetoPreparado.Imagen
                : null;

            imagenObjetoPreparado.enabled =
                tieneObjeto &&
                objetoPreparado.Imagen != null;
        }

        if (textoObjetoPreparado != null)
        {
            textoObjetoPreparado.text =
                tieneObjeto
                ? "Objeto preparado: " +
                  objetoPreparado.Nombre
                : "";
        }
    }

    // =====================================
    // OCULTAR CONTROLES
    // =====================================

    private void GuardarYOcultarControles()
    {
        if (controlesOcultar == null)
            return;

        estadosControles =
            new bool[controlesOcultar.Length];

        for (int i = 0;
             i < controlesOcultar.Length;
             i++)
        {
            if (controlesOcultar[i] == null)
                continue;

            estadosControles[i] =
                controlesOcultar[i].activeSelf;

            controlesOcultar[i].SetActive(false);
        }
    }

    // =====================================
    // RESTAURAR CONTROLES
    // =====================================

    private void RestaurarControles()
    {
        if (controlesOcultar == null ||
            estadosControles == null)
            return;

        for (int i = 0;
             i < controlesOcultar.Length;
             i++)
        {
            if (controlesOcultar[i] == null)
                continue;

            controlesOcultar[i].SetActive(
                estadosControles[i]
            );
        }

        estadosControles = null;
    }

    // =====================================
    // LIMPIEZA
    // =====================================

    private void OnDestroy()
    {
        if (botonAbrirInventario != null)
            botonAbrirInventario.onClick.RemoveListener(
                AlternarInventario
            );

        if (botonCerrarInventario != null)
            botonCerrarInventario.onClick.RemoveListener(
                CerrarInventario
            );

        if (slots != null)
        {
            foreach (SlotInventarioUI slot in slots)
            {
                if (slot != null)
                {
                    slot.SeleccionSolicitada -=
                        SeleccionarObjeto;
                }
            }
        }

        if (inventarioJugador != null)
        {
            inventarioJugador.InventarioActualizado -=
                RefrescarInventario;
        }

        if (Instancia == this)
            Instancia = null;

        if (botonCerrarObjetoRecolectado != null)
        {
            botonCerrarObjetoRecolectado.onClick.RemoveListener(
                CerrarTarjetaObjeto
            );
        }
    }


    private void OnEnable()
    {
        ObjetoRecolectable.RecoleccionConfirmadaLocal +=
            MostrarTarjetaObjeto;
    }

    private void OnDisable()
    {
        ObjetoRecolectable.RecoleccionConfirmadaLocal -=
            MostrarTarjetaObjeto;
    }


    private void MostrarTarjetaObjeto(ObjetoInventario objeto)
    {
        if (objeto == null || panelObjetoRecolectado == null)
            return;

        // Si el inventario estaba abierto, cerrarlo primero.
        if (InventarioAbierto)
            CerrarInventario();

        // Guardar y ocultar controles.
        GuardarYOcultarControles();

        if (movimientoLocal != null)
        {
            movimientoEstabaBloqueado =
                movimientoLocal.MovimientoBloqueado;

            movimientoLocal.BloquearMovimiento(true);
        }

        // Mostrar información del objeto.
        if (tituloObjetoRecolectado != null)
            tituloObjetoRecolectado.text = objeto.Nombre;

        if (descripcionObjetoRecolectado != null)
            descripcionObjetoRecolectado.text =
                objeto.Descripcion;

        if (imagenObjetoRecolectado != null)
        {
            imagenObjetoRecolectado.sprite = objeto.Imagen;

            imagenObjetoRecolectado.enabled =
                objeto.Imagen != null;
        }

        panelObjetoRecolectado.SetActive(true);

        Debug.Log("TARJETA MOSTRADA: " + objeto.Nombre);
    }

    private void CerrarTarjetaObjeto()
    {
        if (panelObjetoRecolectado == null ||
            !panelObjetoRecolectado.activeSelf)
            return;

        panelObjetoRecolectado.SetActive(false);

        RestaurarControles();

        if (movimientoLocal != null)
        {
            movimientoLocal.BloquearMovimiento(
                movimientoEstabaBloqueado
            );
        }

        Debug.Log("TARJETA CERRADA");
    }


}
