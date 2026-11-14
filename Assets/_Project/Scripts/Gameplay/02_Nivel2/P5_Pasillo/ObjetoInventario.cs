
using UnityEngine;

public enum TipoObjetoInventario
{
    FragmentoCarta,
    Pista,
    Llave,
    Otro
}

[CreateAssetMenu(
    fileName = "NuevoObjetoInventario",
    menuName = "Dos Realidades/Inventario/Objeto"
)]
public class ObjetoInventario : ScriptableObject
{
    [Header("Identificacion")]
    [SerializeField] private string id;
    [SerializeField] private string nombre;

    [Header("Informacion")]
    [TextArea(2, 4)]
    [SerializeField] private string descripcion;

    [SerializeField] private TipoObjetoInventario tipo;

    [Header("Imagen")]
    [SerializeField] private Sprite imagen;

    [Header("Comportamiento")]
    [SerializeField] private bool permiteSeleccion = true;
    [SerializeField] private bool consumibleAlUsar = false;

    public string Id => id;
    public string Nombre => nombre;
    public string Descripcion => descripcion;
    public TipoObjetoInventario Tipo => tipo;
    public Sprite Imagen => imagen;
    public bool PermiteSeleccion => permiteSeleccion;
    public bool ConsumibleAlUsar => consumibleAlUsar;
}
