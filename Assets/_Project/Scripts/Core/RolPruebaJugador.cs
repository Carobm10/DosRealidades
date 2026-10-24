using UnityEngine;

public enum RolJugador
{
    Elian,
    Lia
}

public class RolPruebaJugador : MonoBehaviour
{
    public static RolPruebaJugador Instancia { get; private set; }

    [Header("Solo para pruebas en Editor")]
    [SerializeField] private RolJugador rolPrueba = RolJugador.Elian;

    public RolJugador RolPrueba => rolPrueba;

    private void Awake()
    {
        Instancia = this;
    }

    public bool EsLia()
    {
        return rolPrueba == RolJugador.Lia;
    }

    public bool EsElian()
    {
        return rolPrueba == RolJugador.Elian;
    }
}