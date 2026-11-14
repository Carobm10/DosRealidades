
using System;
using UnityEngine;
using UnityEngine.UI;

public class SlotInventarioUI : MonoBehaviour
{
    [Header("Identificacion")]
    [SerializeField] private int indiceSlot;

    [Header("Componentes")]
    [SerializeField] private Button boton;
    [SerializeField] private Image fondoEstado;
    [SerializeField] private Image imagenObjeto;

    [Header("Sprites de estado")]
    [SerializeField] private Sprite fondoNormal;
    [SerializeField] private Sprite fondoSeleccionado;

    public int Indice => indiceSlot;

    public event Action<int> SeleccionSolicitada;

    private bool tieneObjeto;
    private bool seleccionado;

    private void Awake()
    {
        if (boton == null)
            boton = GetComponent<Button>();

        if (boton != null)
        {
            boton.transition = Selectable.Transition.None;
            boton.onClick.AddListener(AlPulsar);
        }

        ActualizarVisual();
    }

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

    private void ActualizarVisual()
    {
        if (fondoEstado != null)
        {
            fondoEstado.sprite = seleccionado
                ? fondoSeleccionado
                : fondoNormal;

            fondoEstado.color = Color.white;
        }

        if (boton != null)
            boton.interactable = tieneObjeto;
    }

    private void AlPulsar()
    {
        if (!tieneObjeto)
            return;

        SeleccionSolicitada?.Invoke(indiceSlot);
    }

    private void OnDestroy()
    {
        if (boton != null)
            boton.onClick.RemoveListener(AlPulsar);
    }
}
