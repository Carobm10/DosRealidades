
using System;
using System.Collections;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class SupervivenciaP8Controller : NetworkBehaviour
{
    [Header("Introduccion")]
    [SerializeField] private IntroduccionP8Controller introduccion;

    [Header("Temporizador")]
    [SerializeField] private int duracionSupervivencia = 20;
    [SerializeField] private TMP_Text textoTemporizador;

    [Header("Vigilias")]
    [SerializeField] private GameObject vigiliaElian;
    [SerializeField] private GameObject vigiliaLia;

    [Header("Siguiente fase")]
    [SerializeField] private GameObject faseLlaves;

    private NetworkVariable<int> segundosRestantes =
        new NetworkVariable<int>(
            20,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private NetworkVariable<bool> desafioActivo =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private NetworkVariable<bool> desafioCompletado =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private Coroutine rutinaTemporizador;

    public event Action SupervivenciaCompletadaLocal;

    public int SegundosRestantes => segundosRestantes.Value;

    public bool DesafioActivo => desafioActivo.Value;

    // =====================================
    // DESACTIVAR VIGILIAS AL CARGAR
    // =====================================

    private void Awake()
    {
        DesactivarVigiliasLocales();
    }

    private void DesactivarVigiliasLocales()
    {
        if (vigiliaElian != null)
            vigiliaElian.SetActive(false);

        if (vigiliaLia != null)
            vigiliaLia.SetActive(false);
    }

    // =====================================
    // INICIO
    // =====================================

    public override void OnNetworkSpawn()
    {
        // Garantizar que no estén activas
        // durante la introducción.
        DesactivarVigiliasLocales();

        if (textoTemporizador != null)
            textoTemporizador.gameObject.SetActive(false);

        segundosRestantes.OnValueChanged += ActualizarTemporizador;

        if (introduccion == null)
            introduccion = GetComponent<IntroduccionP8Controller>();

        if (introduccion != null)
            introduccion.SupervivenciaIniciadaLocal += SolicitarInicio;

        if (IsServer)
        {
            segundosRestantes.Value = duracionSupervivencia;
            desafioActivo.Value = false;
            desafioCompletado.Value = false;
        }

        ActualizarTexto(segundosRestantes.Value);

        if (faseLlaves != null)
            faseLlaves.SetActive(false);
    }

    public override void OnNetworkDespawn()
    {
        segundosRestantes.OnValueChanged -= ActualizarTemporizador;

        if (introduccion != null)
            introduccion.SupervivenciaIniciadaLocal -= SolicitarInicio;

        if (rutinaTemporizador != null)
            StopCoroutine(rutinaTemporizador);

        rutinaTemporizador = null;
    }

    // =====================================
    // SOLICITAR INICIO
    // =====================================

    private void SolicitarInicio()
    {
        if (!IsSpawned)
            return;

        if (IsServer)
        {
            IniciarDesafioServidor();
        }
        else
        {
            SolicitarInicioRpc();
        }
    }

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void SolicitarInicioRpc(RpcParams rpcParams = default)
    {
        ulong clienteId = rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients.TryGetValue(
            clienteId, out NetworkClient cliente))
            return;

        if (cliente.PlayerObject == null)
            return;

        IniciarDesafioServidor();
    }

    // =====================================
    // INICIAR SUPERVIVENCIA
    // =====================================

    private void IniciarDesafioServidor()
    {
        if (!IsServer ||
            desafioActivo.Value ||
            desafioCompletado.Value)
            return;

        desafioActivo.Value = true;
        segundosRestantes.Value = duracionSupervivencia;

        Debug.Log("P8 | INICIO DE SUPERVIVENCIA.");

        ActivarVigiliasRpc();

        rutinaTemporizador = StartCoroutine(
            ContarSupervivencia()
        );
    }

    // =====================================
    // ACTIVAR VIGILIAS
    // =====================================

    [Rpc(SendTo.Everyone)]
    private void ActivarVigiliasRpc()
    {
        if (vigiliaElian != null)
            vigiliaElian.SetActive(true);

        if (vigiliaLia != null)
            vigiliaLia.SetActive(true);

        if (textoTemporizador != null)
        {
            textoTemporizador.gameObject.SetActive(true);
            textoTemporizador.text = "00:20";
        }

        Debug.Log(
            "P8 | VIGILIAS ACTIVADAS. SUPERVIVENCIA EN CURSO."
        );
    }

    // =====================================
    // TEMPORIZADOR
    // =====================================

    private IEnumerator ContarSupervivencia()
    {
        while (IsServer && desafioActivo.Value)
        {
            yield return new WaitForSecondsRealtime(1f);

            if (!desafioActivo.Value)
                yield break;

            if (segundosRestantes.Value > 0)
                segundosRestantes.Value--;

            if (segundosRestantes.Value <= 0)
            {
                CompletarDesafioServidor();
                yield break;
            }
        }

        rutinaTemporizador = null;
    }

    private void ActualizarTemporizador(int anterior, int nuevo)
    {
        ActualizarTexto(nuevo);
    }

    private void ActualizarTexto(int segundos)
    {
        if (textoTemporizador != null)
        {
            textoTemporizador.text =
                "00:" + Mathf.Max(0, segundos).ToString("00");
        }
    }

    // =====================================
    // REGISTRAR ATRAPAMIENTO
    // =====================================

    
    public void RegistrarAtrapamientoServidor()
    {
        if (!IsServer || !desafioActivo.Value)
            return;

        VidasEquipo vidas = VidasEquipo.Instancia;

        if (vidas == null || !vidas.IsSpawned)
        {
            Debug.LogError("P8 | No se encontró VidasEquipo.");
            return;
        }

        // Descontar una vida compartida.
        vidas.PerderVidaServidor();

        // Si se agotaron las vidas, el sistema existente
        // se encarga de reiniciar el nivel completo.
        if (vidas.VidasActuales <= 0)
            return;

        // IMPORTANTE:
        // Ya NO reiniciamos el temporizador al recibir daño.
        // La cuenta regresiva continúa normalmente.

        Debug.Log(
            "P8 | JUGADOR ATRAPADO. VIDAS: " +
            vidas.VidasActuales +
            " | TIEMPO CONTINÚA: " +
            segundosRestantes.Value
        );
    }

    // =====================================
    // COMPLETAR SUPERVIVENCIA
    // =====================================

    private void CompletarDesafioServidor()
    {
        if (!IsServer || !desafioActivo.Value)
            return;

        desafioActivo.Value = false;
        desafioCompletado.Value = true;

        Debug.Log("P8 | SUPERVIVENCIA COMPLETADA.");

        FinalizarDesafioRpc();
    }

    [Rpc(SendTo.Everyone)]
    private void FinalizarDesafioRpc()
    {
        if (vigiliaElian != null)
            vigiliaElian.SetActive(false);

        if (vigiliaLia != null)
            vigiliaLia.SetActive(false);

        if (textoTemporizador != null)
            textoTemporizador.gameObject.SetActive(false);

        if (faseLlaves != null)
            faseLlaves.SetActive(true);

        Debug.Log("P8 | COMIENZA LA FASE DE LAS LLAVES.");

        SupervivenciaCompletadaLocal?.Invoke();
    }
}
