
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System.Collections;

public class ControlFinalP3 : NetworkBehaviour
{
    [Header("Botones")]
    [SerializeField] private Animator animatorBotonElian;
    [SerializeField] private Animator animatorBotonLia;

    [Header("Configuracion")]
    [SerializeField] private float tiempoPresion = 2f;

    [Header("Prueba individual")]
    [SerializeField] private bool modoPruebaSoloLia = true;

    [Header("Puertas")]
    [SerializeField] private Animator puertaElian;
    [SerializeField] private Animator puertaLia;

    [Header("Cinematica")]
    [SerializeField] private float duracionZoom = 1.2f;
    [SerializeField] private float esperaAntesDeAbrir = 0.35f;

    // =====================================
    // VARIABLES DE RED
    // =====================================

    private NetworkVariable<bool> botonesActivados =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private NetworkVariable<bool> finalCompletado =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private bool elianPresionando;
    private bool liaPresionando;

    private bool elianSalio;
    private bool liaSalio;

    private bool cambioEscenaSolicitado;

    private Coroutine rutinaPresion;
    private Coroutine rutinaCinematica;
    private Coroutine rutinaMensaje;

    public bool BotonesActivados => botonesActivados.Value;
    public bool FinalCompletado => finalCompletado.Value;

    // =====================================
    // INICIO
    // =====================================

    public override void OnNetworkSpawn()
    {
        finalCompletado.OnValueChanged += AlCambiarFinal;

        if (IsServer)
        {
            botonesActivados.Value = true;
        }

        // Ambos botones comienzan en estado normal.
        if (animatorBotonElian != null)
            animatorBotonElian.Play("Normal", 0, 0f);

        if (animatorBotonLia != null)
            animatorBotonLia.Play("Normal", 0, 0f);

        // Esperar a que el HUD esté disponible.
        rutinaMensaje = StartCoroutine(
            ActualizarMensajeMision()
        );

        Debug.Log("P3: CONTROL FINAL INICIADO");
    }

    public override void OnNetworkDespawn()
    {
        finalCompletado.OnValueChanged -= AlCambiarFinal;

        if (rutinaPresion != null)
            StopCoroutine(rutinaPresion);

        if (rutinaCinematica != null)
            StopCoroutine(rutinaCinematica);

        if (rutinaMensaje != null)
            StopCoroutine(rutinaMensaje);
    }

    // =====================================
    // MENSAJE DE LA MISION
    // =====================================

    private IEnumerator ActualizarMensajeMision()
    {
        while (HUDMision.Instancia == null)
        {
            yield return null;
        }

        yield return null;

        string mensaje = modoPruebaSoloLia
            ? "¡Llega al botón!"
            : "¡Lleguen a los botones!";

        HUDMision.Instancia.CambiarMision(mensaje);

        Debug.Log("P3: MENSAJE DE MISION ACTUALIZADO");

        rutinaMensaje = null;
    }

    // =====================================
    // ACTIVACION DE BOTONES
    // =====================================

    public void ActivarBotonesServidor()
    {
        if (!IsServer)
            return;

        botonesActivados.Value = true;
    }

    // Se llama cuando el jugador entra
    // en la zona de interacción.

    public void ActivarBotonLocal(bool esLia)
    {
        if (finalCompletado.Value)
            return;

        Animator boton = esLia
            ? animatorBotonLia
            : animatorBotonElian;

        if (boton != null)
        {
            boton.Play("Activado", 0, 0f);
            boton.Update(0f);

            Debug.Log(
                "P3: BOTON ACTIVADO | LIA: " + esLia
            );
        }
        else
        {
            Debug.LogError(
                "P3: NO SE ENCONTRO EL ANIMATOR DEL BOTON"
            );
        }
    }

    // Se llama cuando el jugador sale
    // de la zona sin completar la interacción.

    public void PonerBotonNormalLocal(bool esLia)
    {
        Animator boton = esLia
            ? animatorBotonLia
            : animatorBotonElian;

        if (boton != null && !finalCompletado.Value)
        {
            boton.Play("Normal", 0, 0f);
            boton.Update(0f);
        }
    }

    // =====================================
    // IDENTIFICAR JUGADOR
    // =====================================

    private bool EsLiaJugador(ulong jugador)
    {
        if (modoPruebaSoloLia)
            return true;

        return jugador != NetworkManager.ServerClientId;
    }

    // =====================================
    // COMENZAR Y TERMINAR PRESION
    // =====================================

    public void ComenzarPresion()
    {
        if (!IsSpawned ||
            finalCompletado.Value ||
            !botonesActivados.Value)
            return;

        ComenzarPresionRpc();
    }

    public void TerminarPresion()
    {
        if (!IsSpawned || finalCompletado.Value)
            return;

        TerminarPresionRpc();
    }

    [Rpc(
        SendTo.Server,
        InvokePermission = RpcInvokePermission.Everyone
    )]
    private void ComenzarPresionRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer ||
            !botonesActivados.Value ||
            finalCompletado.Value)
            return;

        ulong jugador =
            rpcParams.Receive.SenderClientId;

        bool esLia = EsLiaJugador(jugador);

        if (esLia)
            liaPresionando = true;
        else
            elianPresionando = true;

        AplicarEstadoBotonClientRpc(esLia, true);

        ActualizarEstadoPresion();
    }

    [Rpc(
        SendTo.Server,
        InvokePermission = RpcInvokePermission.Everyone
    )]
    private void TerminarPresionRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer || finalCompletado.Value)
            return;

        ulong jugador =
            rpcParams.Receive.SenderClientId;

        bool esLia = EsLiaJugador(jugador);

        if (esLia)
            liaPresionando = false;
        else
            elianPresionando = false;

        AplicarEstadoBotonClientRpc(esLia, false);

        ActualizarEstadoPresion();
    }

    // =====================================
    // VALIDAR PRESION COOPERATIVA
    // =====================================

    private void ActualizarEstadoPresion()
    {
        bool puedeCompletar = modoPruebaSoloLia
            ? liaPresionando
            : elianPresionando && liaPresionando;

        if (!puedeCompletar)
        {
            if (rutinaPresion != null)
            {
                StopCoroutine(rutinaPresion);
                rutinaPresion = null;
            }

            return;
        }

        if (rutinaPresion == null)
        {
            rutinaPresion = StartCoroutine(
                ContarPresion()
            );
        }
    }

    private IEnumerator ContarPresion()
    {
        yield return new WaitForSeconds(tiempoPresion);

        rutinaPresion = null;

        bool puedeCompletar = modoPruebaSoloLia
            ? liaPresionando
            : elianPresionando && liaPresionando;

        if (!IsServer ||
            !puedeCompletar ||
            finalCompletado.Value)
            yield break;

        finalCompletado.Value = true;

        Debug.Log("P3: INTERACCION COMPLETADA");

        // Regresar botones a normal.
        FinalizarBotonesClientRpc();

        // Iniciar zoom y apertura de puertas.
        AbrirPuertasClientRpc();
    }

    // =====================================
    // ANIMACIONES DE LOS BOTONES
    // =====================================

    [ClientRpc]
    private void AplicarEstadoBotonClientRpc(
        bool esLia,
        bool presionando)
    {
        Animator boton = esLia
            ? animatorBotonLia
            : animatorBotonElian;

        if (boton != null)
        {
            boton.Play(
                presionando ? "Presionado" : "Activado",
                0,
                0f
            );

            boton.Update(0f);
        }
    }

    [ClientRpc]
    private void FinalizarBotonesClientRpc()
    {
        if (animatorBotonElian != null)
        {
            animatorBotonElian.Play("Normal", 0, 0f);
            animatorBotonElian.Update(0f);
        }

        if (animatorBotonLia != null)
        {
            animatorBotonLia.Play("Normal", 0, 0f);
            animatorBotonLia.Update(0f);
        }

        // Ocultar el botón de interacción del HUD local.
        HUDInteraccion.Instancia?.OcultarBotonActual();

        Debug.Log("P3: BOTONES REGRESAN A NORMAL");
    }

    private void AlCambiarFinal(bool anterior, bool nuevo)
    {
        if (nuevo)
        {
            Debug.Log(
                "P3: FINAL COOPERATIVO COMPLETADO"
            );
        }
    }

    // =====================================
    // CINEMATICA DE APERTURA
    // =====================================

    [ClientRpc]
    private void AbrirPuertasClientRpc()
    {
        if (rutinaCinematica != null)
            StopCoroutine(rutinaCinematica);

        rutinaCinematica =
            StartCoroutine(RutinaCinematica());
    }

    private IEnumerator RutinaCinematica()
    {
        if (NetworkManager.Singleton == null)
            yield break;

        NetworkObject jugador =
            NetworkManager.Singleton.SpawnManager
            .GetLocalPlayerObject();

        if (jugador == null)
            yield break;

        CamaraJugadorLocal camara =
            jugador.GetComponent<CamaraJugadorLocal>();

        bool esLia = IdentidadJugadorLocal.EsLia();

        Animator puertaLocal = esLia
            ? puertaLia
            : puertaElian;

        if (puertaLocal == null)
        {
            Debug.LogError(
                "P3: No se encontró la puerta local."
            );

            yield break;
        }

        Vector3 posicionPuerta =
            puertaLocal.transform.position;

        // Enfoque de cámara.
        if (camara != null)
        {
            camara.EnfocarConZoom(
                posicionPuerta,
                duracionZoom
            );
        }

        Debug.Log("P3: ENFOQUE DE CAMARA");

        yield return new WaitForSeconds(
            esperaAntesDeAbrir
        );

        // Abrir ambas puertas.
        if (puertaElian != null)
            puertaElian.SetBool("Abrir", true);

        if (puertaLia != null)
            puertaLia.SetBool("Abrir", true);

        Debug.Log("P3: PUERTAS ABIERTAS");

        rutinaCinematica = null;
    }

    // =====================================
    // REGISTRO DE SALIDA
    // =====================================

    public void RegistrarSalida()
    {
        if (!IsSpawned ||
            !finalCompletado.Value)
            return;

        RegistrarSalidaRpc();
    }

    [Rpc(
        SendTo.Server,
        InvokePermission = RpcInvokePermission.Everyone
    )]
    private void RegistrarSalidaRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer ||
            cambioEscenaSolicitado ||
            !finalCompletado.Value)
            return;

        ulong jugador =
            rpcParams.Receive.SenderClientId;

        bool esLia = EsLiaJugador(jugador);

        if (esLia)
            liaSalio = true;
        else
            elianSalio = true;

        Debug.Log(
            "SALIDAS P3 | Elian: " + elianSalio +
            " | Lia: " + liaSalio
        );

        bool todosSalieron = modoPruebaSoloLia
            ? liaSalio
            : elianSalio && liaSalio;

        if (todosSalieron)
        {
            cambioEscenaSolicitado = true;

            Debug.Log(
                "P3: CARGANDO " + siguienteEscena
            );
        }
    }
}
