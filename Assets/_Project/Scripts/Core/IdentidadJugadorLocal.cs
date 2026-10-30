
using UnityEngine;
using Unity.Netcode;

public static class IdentidadJugadorLocal
{
    public static RolJugador ObtenerRol()
    {
#if UNITY_EDITOR
        // En pruebas directas del Editor,
        // respetar el rol seleccionado.
        if (RolPruebaJugador.Instancia != null)
        {
            return RolPruebaJugador.Instancia.RolPrueba;
        }
#endif

        // En multijugador real:
        // Host = Elian / Cliente = Lia.
        if (NetworkManager.Singleton != null &&
            NetworkManager.Singleton.IsListening)
        {
            return NetworkManager.Singleton.IsHost
                ? RolJugador.Elian
                : RolJugador.Lia;
        }

        // Valor temporal si todavia no hay conexion.
        return RolJugador.Elian;
    }

    public static bool EsElian()
    {
        return ObtenerRol() == RolJugador.Elian;
    }

    public static bool EsLia()
    {
        return ObtenerRol() == RolJugador.Lia;
    }
}
