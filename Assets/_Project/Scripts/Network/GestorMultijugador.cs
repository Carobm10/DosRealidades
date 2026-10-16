using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Multiplayer;
using System;
using System.Threading.Tasks;

public class GestorMultijugador : MonoBehaviour
{
    public bool ServiciosListos { get; private set; }

    private ISession sesionActual;


    // --------------------------------------------------
    // INICIO
    // --------------------------------------------------

    private async void Start()
    {
        await InicializarServicios();
    }


    // --------------------------------------------------
    // UNITY SERVICES
    // --------------------------------------------------

    private async Task InicializarServicios()
    {
        try
        {
            await UnityServices.InitializeAsync();

            if (!AuthenticationService.Instance.IsSignedIn)
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
            }

            ServiciosListos = true;

            Debug.Log(
                "Unity Services listo. Jugador: " +
                AuthenticationService.Instance.PlayerId
            );
        }
        catch (Exception error)
        {
            ServiciosListos = false;

            Debug.LogError(
                "No se pudieron inicializar Unity Services: " +
                error.Message
            );
        }
    }


    // --------------------------------------------------
    // CREAR PARTIDA
    // --------------------------------------------------

    public async Task<string> CrearPartida()
    {
        if (!ServiciosListos)
        {
            Debug.LogWarning("Unity Services todavía no está listo.");
            return null;
        }

        try
        {
            SessionOptions opciones = new SessionOptions
            {
                MaxPlayers = 2
            }
            .WithRelayNetwork();

            sesionActual =
                await MultiplayerService.Instance.CreateSessionAsync(opciones);

            string codigo = sesionActual.Code;

            Debug.Log("Partida creada.");
            Debug.Log("Código real: " + codigo);

            return codigo;
        }
        catch (Exception error)
        {
            Debug.LogError(
                "No se pudo crear la partida: " +
                error.Message
            );

            return null;
        }
    }


    // --------------------------------------------------
    // UNIRSE A PARTIDA
    // --------------------------------------------------

    public async Task<bool> UnirsePartida(string codigo)
    {
        if (!ServiciosListos)
        {
            Debug.LogWarning("Unity Services todavía no está listo.");
            return false;
        }

        try
        {
            sesionActual =
                await MultiplayerService.Instance.JoinSessionByCodeAsync(codigo);

            Debug.Log(
                "Conectado a la partida: " +
                sesionActual.Id
            );

            return true;
        }
        catch (Exception error)
        {
            Debug.LogError(
                "No se pudo unir a la partida: " +
                error.Message
            );

            return false;
        }
    }
}