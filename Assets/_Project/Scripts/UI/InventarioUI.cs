
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

public class InventarioUI : MonoBehaviour
{
    public static InventarioUI Instancia { get; private set; }
    public static event System.Action<string>
        TarjetaObjetoCerradaLocal;

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

    private string idObjetoTarjetaActual;

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
        if (Instancia == null)
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
                    slot.SeleccionSolicitada += SeleccionarObjeto;
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

        panelInventario.SetActive(true);

        RefrescarInventario();

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

    // =====================================
    // ACTIVAR INVENTARIO UI
    // =====================================

    private void OnEnable()
    {
        if (Instancia == null ||
            !Instancia.isActiveAndEnabled)
        {
            Instancia = this;
        }

        ObjetoRecolectable.RecoleccionConfirmadaLocal +=
            MostrarTarjetaObjeto;

        Debug.Log(
            "INVENTARIO UI ACTIVADO: " + gameObject.name
        );
    }

    private void OnDisable()
    {
        ObjetoRecolectable.RecoleccionConfirmadaLocal -=
            MostrarTarjetaObjeto;

        if (Instancia == this)
        {
            Instancia =
                FindAnyObjectByType<InventarioUI>();
        }

        Debug.Log(
            "INVENTARIO UI DESACTIVADO: " + gameObject.name
        );
    }

    // =====================================
    // RECIBIR OBJETO RECOLECTADO
    // =====================================

    private void MostrarTarjetaObjeto(
        ObjetoInventario objeto)
    {
        if (objeto == null ||
            panelObjetoRecolectado == null)
            return;

        // Los fragmentos de carta no muestran
        // su tarjeta automáticamente.
        // Esperan la cinematografía.

        if (objeto.Tipo ==
            TipoObjetoInventario.FragmentoCarta)
        {
            Debug.Log(
                "CARTA RECOLECTADA. " +
                "Tarjeta pendiente de cinematografía: " +
                objeto.Id
            );

            return;
        }

        MostrarTarjetaDirecta(objeto);
    }

    // =====================================
    // MOSTRAR TARJETA DIRECTAMENTE
    // =====================================

    private void MostrarTarjetaDirecta(
        ObjetoInventario objeto)
    {
        if (objeto == null ||
            panelObjetoRecolectado == null)
            return;

        idObjetoTarjetaActual = objeto.Id;

        if (InventarioAbierto)
            CerrarInventario();

        GuardarYOcultarControles();

        if (movimientoLocal != null)
        {
            movimientoEstabaBloqueado =
                movimientoLocal.MovimientoBloqueado;

            movimientoLocal.BloquearMovimiento(true);
        }

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

        Debug.Log(
            "TARJETA MOSTRADA: " + objeto.Nombre
        );
    }

    // =====================================
    // CERRAR TARJETA
    // =====================================

    private void CerrarTarjetaObjeto()
    {
        if (panelObjetoRecolectado == null ||
            !panelObjetoRecolectado.activeSelf)
            return;

        string idCerrado = idObjetoTarjetaActual;

        panelObjetoRecolectado.SetActive(false);

        RestaurarControles();

        if (movimientoLocal != null)
        {
            movimientoLocal.BloquearMovimiento(
                movimientoEstabaBloqueado
            );
        }

        RefrescarInventario();

        // Confirmar únicamente las llaves de caja 201.

        if (idCerrado == "Llave_Elian" ||
            idCerrado == "Llave_lia")
        {
            CajaFuerte201Controller caja =
                FindAnyObjectByType<CajaFuerte201Controller>();

            if (caja != null && caja.IsSpawned)
            {
                caja.ConfirmarCierreTarjetaLlave(idCerrado);

                Debug.Log(
                    "CAJA 201: Confirmación de cierre enviada: " +
                    idCerrado
                );
            }
            else
            {
                Debug.LogError(
                    "CAJA 201: No se encontró el controlador de la caja."
                );
            }
        }

        idObjetoTarjetaActual = null;

        // Avisar a los controladores que esperan
        // la confirmación del cierre de una tarjeta.
        if (!string.IsNullOrEmpty(idCerrado))
        {
            TarjetaObjetoCerradaLocal?.Invoke(idCerrado);
        }

        Debug.Log("TARJETA CERRADA: " + idCerrado);
    }

    public bool PuedeMostrarTarjetaPorId(string id)
    {
        if (string.IsNullOrWhiteSpace(id) ||
            panelObjetoRecolectado == null ||
            inventarioJugador == null)
            return false;

        if (!inventarioJugador.TieneObjeto(id))
            return false;

        return inventarioJugador.ObtenerObjetoPorId(id) != null;
    }


    // =====================================
    // MOSTRAR TARJETA POR ID
    // =====================================

    // Este método lo utilizará la cinematografía
    // para mostrar la carta cuando corresponda.

    public void MostrarTarjetaPorId(string id)
    {
        if (inventarioJugador == null)
        {
            Debug.LogError(
                "INVENTARIO UI: Inventario local no conectado."
            );
            return;
        }

        if (!inventarioJugador.TieneObjeto(id))
        {
            Debug.LogError(
                "INVENTARIO UI: No tiene el objeto: " + id
            );
            return;
        }

        ObjetoInventario objeto =
            inventarioJugador.ObtenerObjetoPorId(id);

        if (objeto == null)
        {
            Debug.LogError(
                "INVENTARIO UI: No se encontró la definición: " + id
            );
            return;
        }

        // Mostrar directamente, sin pasar por
        // el filtro de fragmentos de carta.

        MostrarTarjetaDirecta(objeto);
    }
}
