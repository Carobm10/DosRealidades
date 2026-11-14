
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class SlotInventarioUI : MonoBehaviour
{
    [Header("Identificacion")]
    [SerializeField] private int indiceSlot;

    [Header("Componentes")]
    [SerializeField] private Button boton;
    [SerializeField] private Image fondoEstado;
    [SerializeField] private Image imagenObjeto;

    [Header("Sprites Elian")]
    [SerializeField] private Sprite fondoNormalElian;
    [SerializeField] private Sprite fondoSeleccionadoElian;

    [Header("Sprites Lia")]
    [SerializeField] private Sprite fondoNormalLia;
    [SerializeField] private Sprite fondoSeleccionadoLia;

    private bool esElian;
    private bool identidadLista;
    private bool tieneObjeto;
    private bool seleccionado;

    public int Indice => indiceSlot;

    public event Action<int> SeleccionSolicitada;

    private void Awake()
    {
        if (boton == null)
            boton = GetComponent<Button>();

        if (boton != null)
        {
            boton.transition = Selectable.Transition.None;
            boton.onClick.AddListener(AlPulsar);
        }

        if (imagenObjeto != null)
            imagenObjeto.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(EsperarIdentidadLocal());
    }

    // =====================================
    // IDENTIFICAR JUGADOR LOCAL
    // =====================================

    private IEnumerator EsperarIdentidadLocal()
    {
        while (true)
        {
            NetworkManager red = NetworkManager.Singleton;

            if (red != null &&
                red.IsListening &&
                red.LocalClient != null &&
                red.LocalClient.PlayerObject != null)
            {
                NetworkPlayerSetup setup =
                    red.LocalClient.PlayerObject
                    .GetComponent<NetworkPlayerSetup>();

                if (setup != null && setup.RolConfigurado)
                {
                    esElian = setup.EsElian;
                    identidadLista = true;

                    ActualizarVisual();

                    Debug.Log(
                        "INVENTARIO UI | Slot: " +
                        indiceSlot +
                        " | Personaje: " +
                        (esElian ? "Elian" : "Lia")
                    );

                    yield break;
                }
            }

            yield return null;
        }
    }

    // =====================================
    // CONFIGURAR OBJETO
    // =====================================

    public void Configurar(
        Sprite sprite,
        bool ocupado,
        bool estaSeleccionado)
    {
        tieneObjeto = ocupado;
        seleccionado = ocupado && estaSeleccionado;

        if (imagenObjeto != null)
        {
            imagenObjeto.sprite = sprite;
            imagenObjeto.enabled =
                ocupado && sprite != null;
        }

        ActualizarVisual();
    }

    // =====================================
    // ACTUALIZAR APARIENCIA
    // =====================================

    private void ActualizarVisual()
    {
        if (!identidadLista)
            return;

        if (fondoEstado != null)
        {
            Sprite fondo;

            if (esElian)
            {
                fondo = seleccionado
                    ? fondoSeleccionadoElian
                    : fondoNormalElian;
            }
            else
            {
                fondo = seleccionado
                    ? fondoSeleccionadoLia
                    : fondoNormalLia;
            }

            fondoEstado.sprite = fondo;
            fondoEstado.color = Color.white;
        }

        if (boton != null)
            boton.interactable = tieneObjeto;
    }

    // =====================================
    // SELECCION
    // =====================================

    private void AlPulsar()
    {
        if (!tieneObjeto || !identidadLista)
            return;

        SeleccionSolicitada?.Invoke(indiceSlot);
    }

    // =====================================
    // LIMPIEZA
    // =====================================

    private void OnDestroy()
    {
        if (boton != null)
            boton.onClick.RemoveListener(AlPulsar);
    }
}
