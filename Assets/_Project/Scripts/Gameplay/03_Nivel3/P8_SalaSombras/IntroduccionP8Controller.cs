
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

[RequireComponent(typeof(NetworkObject))]
public class IntroduccionP8Controller : NetworkBehaviour
{
    [Header("Panel principal")]
    [SerializeField] private GameObject panelIntroduccion;

    [Header("Animaciones")]
    [SerializeField] private GameObject animacionElian;
    [SerializeField] private GameObject animacionLia;
    [SerializeField] private Animator animatorElian;
    [SerializeField] private Animator animatorLia;
    [SerializeField] private string estadoAnimacionElian;
    [SerializeField] private string estadoAnimacionLia;
    [SerializeField] private float duracionAnimacion = 3f;

    [Header("Cartas")]
    [SerializeField] private GameObject cartaElian;
    [SerializeField] private GameObject cartaLia;
    [SerializeField] private Button botonCerrarElian;
    [SerializeField] private Button botonCerrarLia;

    [Header("Instrucciones de supervivencia")]
    [SerializeField] private GameObject instruccionSupervivencia;
    [SerializeField] private GameObject instruccionSupervivencia2;
    [SerializeField] private float duracionInstrucciones = 5f;

    [Header("Espera y cuenta regresiva")]
    [SerializeField] private GameObject textoEsperandoJugador;
    [SerializeField] private TMP_Text textoEsperandoTMP;
    [SerializeField] private float intervaloPuntos = 0.35f;
    [SerializeField] private float intervaloCuentaRegresiva = 0.8f;

    private NetworkPlayerMovement movimientoLocal;

    private bool esElian;
    private bool identidadLista;
    private bool confirmacionEnviada;
    private bool supervivenciaIniciada;

    private bool elianConfirmo;
    private bool liaConfirmo;

    private Coroutine rutinaEsperando;
    private Coroutine rutinaCuentaRegresiva;

    public event Action SupervivenciaIniciadaLocal;

    private void Awake()
    {
        if (botonCerrarElian != null)
            botonCerrarElian.onClick.AddListener(CerrarCarta);

        if (botonCerrarLia != null)
            botonCerrarLia.onClick.AddListener(CerrarCarta);

        if (textoEsperandoTMP == null &&
            textoEsperandoJugador != null)
        {
            textoEsperandoTMP =
                textoEsperandoJugador.GetComponent<TMP_Text>();
        }

        OcultarElementos();
    }

    public override void OnNetworkSpawn()
    {
        if (!IsClient)
            return;

        StartCoroutine(IniciarIntroduccionLocal());
    }

    public override void OnNetworkDespawn()
    {
        if (botonCerrarElian != null)
            botonCerrarElian.onClick.RemoveListener(CerrarCarta);

        if (botonCerrarLia != null)
            botonCerrarLia.onClick.RemoveListener(CerrarCarta);

        if (rutinaEsperando != null)
            StopCoroutine(rutinaEsperando);

        if (rutinaCuentaRegresiva != null)
            StopCoroutine(rutinaCuentaRegresiva);
    }

    private void OcultarElementos()
    {
        if (panelIntroduccion != null)
            panelIntroduccion.SetActive(false);

        if (animacionElian != null)
            animacionElian.SetActive(false);

        if (animacionLia != null)
            animacionLia.SetActive(false);

        if (cartaElian != null)
            cartaElian.SetActive(false);

        if (cartaLia != null)
            cartaLia.SetActive(false);

        if (instruccionSupervivencia != null)
            instruccionSupervivencia.SetActive(false);

        if (instruccionSupervivencia2 != null)
            instruccionSupervivencia2.SetActive(false);

        if (textoEsperandoJugador != null)
            textoEsperandoJugador.SetActive(false);
    }

    // =====================================
    // IDENTIFICAR JUGADOR
    // =====================================

    private IEnumerator IniciarIntroduccionLocal()
    {
        yield return new WaitUntil(() =>
        {
            NetworkManager red = NetworkManager.Singleton;

            if (red == null ||
                !red.IsListening ||
                red.LocalClient == null ||
                red.LocalClient.PlayerObject == null)
                return false;

            NetworkPlayerSetup setup =
                red.LocalClient.PlayerObject
                    .GetComponent<NetworkPlayerSetup>();

            return setup != null && setup.RolConfigurado;
        });

        NetworkObject jugador =
            NetworkManager.Singleton.LocalClient.PlayerObject;

        NetworkPlayerSetup configuracion =
            jugador.GetComponent<NetworkPlayerSetup>();

        esElian = configuracion.EsElian;
        identidadLista = true;

        movimientoLocal =
            jugador.GetComponent<NetworkPlayerMovement>();

        if (movimientoLocal != null)
            movimientoLocal.BloquearMovimiento(true);

        MostrarAnimacionLocal();
    }

    // =====================================
    // ANIMACION Y CARTA
    // =====================================

    private void MostrarAnimacionLocal()
    {
        if (!identidadLista)
            return;

        if (panelIntroduccion != null)
            panelIntroduccion.SetActive(true);

        GameObject animacion =
            esElian ? animacionElian : animacionLia;

        Animator animator =
            esElian ? animatorElian : animatorLia;

        string estado =
            esElian ? estadoAnimacionElian : estadoAnimacionLia;

        if (animacion != null)
            animacion.SetActive(true);

        if (animator != null &&
            !string.IsNullOrWhiteSpace(estado))
        {
            animator.Play(estado, 0, 0f);
        }

        StartCoroutine(EsperarAnimacion());
    }

    private IEnumerator EsperarAnimacion()
    {
        yield return new WaitForSecondsRealtime(
            Mathf.Max(0.1f, duracionAnimacion)
        );

        if (!IsSpawned || supervivenciaIniciada)
            yield break;

        if (esElian)
        {
            if (animacionElian != null)
                animacionElian.SetActive(false);

            if (cartaElian != null)
                cartaElian.SetActive(true);
        }
        else
        {
            if (animacionLia != null)
                animacionLia.SetActive(false);

            if (cartaLia != null)
                cartaLia.SetActive(true);
        }
    }

    // =====================================
    // CERRAR CARTA
    // =====================================

    private void CerrarCarta()
    {
        if (!IsSpawned ||
            !identidadLista ||
            confirmacionEnviada ||
            supervivenciaIniciada)
            return;

        confirmacionEnviada = true;

        if (cartaElian != null)
            cartaElian.SetActive(false);

        if (cartaLia != null)
            cartaLia.SetActive(false);

        if (botonCerrarElian != null)
            botonCerrarElian.interactable = false;

        if (botonCerrarLia != null)
            botonCerrarLia.interactable = false;

        MostrarEsperaAnimada();

        Debug.Log(
            "P8 | " +
            (esElian ? "ELIAN" : "LIA") +
            " confirmó la lectura."
        );

        ConfirmarLecturaRpc();
    }

    // =====================================
    // ESPERAR AL OTRO JUGADOR
    // =====================================

    private void MostrarEsperaAnimada()
    {
        if (textoEsperandoJugador != null)
            textoEsperandoJugador.SetActive(true);

        if (rutinaEsperando != null)
            StopCoroutine(rutinaEsperando);

        rutinaEsperando = StartCoroutine(AnimarEsperando());
    }

    private IEnumerator AnimarEsperando()
    {
        if (textoEsperandoTMP == null)
            yield break;

        string baseTexto = "Esperando al otro jugador";

        while (!supervivenciaIniciada)
        {
            textoEsperandoTMP.text = baseTexto + ".";
            yield return new WaitForSecondsRealtime(intervaloPuntos);

            if (supervivenciaIniciada) yield break;

            textoEsperandoTMP.text = baseTexto + "..";
            yield return new WaitForSecondsRealtime(intervaloPuntos);

            if (supervivenciaIniciada) yield break;

            textoEsperandoTMP.text = baseTexto + "...";
            yield return new WaitForSecondsRealtime(intervaloPuntos);
        }
    }

    // =====================================
    // CONFIRMACION EN SERVIDOR
    // =====================================

    [Rpc(SendTo.Server, RequireOwnership = false)]
    private void ConfirmarLecturaRpc(RpcParams rpcParams = default)
    {
        if (!IsServer || supervivenciaIniciada)
            return;

        ulong clienteId = rpcParams.Receive.SenderClientId;

        if (!NetworkManager.Singleton.ConnectedClients.TryGetValue(
            clienteId, out NetworkClient cliente))
            return;

        if (cliente.PlayerObject == null)
            return;

        NetworkPlayerSetup setup =
            cliente.PlayerObject.GetComponent<NetworkPlayerSetup>();

        if (setup == null || !setup.RolConfigurado)
            return;

        if (setup.EsElian)
            elianConfirmo = true;
        else
            liaConfirmo = true;

        Debug.Log(
            "P8 | Confirmaciones: Elian = " +
            elianConfirmo +
            " | Lia = " + liaConfirmo
        );

        if (elianConfirmo && liaConfirmo)
        {
            supervivenciaIniciada = true;
            IniciarCuentaRegresivaRpc();
        }
    }

    // =====================================
    // INSTRUCCIONES + CUENTA REGRESIVA
    // =====================================

    [Rpc(SendTo.Everyone)]
    private void IniciarCuentaRegresivaRpc()
    {
        if (!IsClient)
            return;

        supervivenciaIniciada = true;

        if (rutinaEsperando != null)
        {
            StopCoroutine(rutinaEsperando);
            rutinaEsperando = null;
        }

        if (rutinaCuentaRegresiva != null)
            StopCoroutine(rutinaCuentaRegresiva);

        rutinaCuentaRegresiva =
            StartCoroutine(MostrarCuentaRegresiva());
    }

    private IEnumerator MostrarCuentaRegresiva()
    {
        // 1. MOSTRAR INSTRUCCIONES

        if (textoEsperandoJugador != null)
            textoEsperandoJugador.SetActive(false);

        if (instruccionSupervivencia != null)
            instruccionSupervivencia.SetActive(true);

        if (instruccionSupervivencia2 != null)
            instruccionSupervivencia2.SetActive(true);

        Debug.Log("P8 | Mostrando instrucciones de supervivencia.");

        yield return new WaitForSecondsRealtime(
            Mathf.Max(0f, duracionInstrucciones)
        );

        // 2. OCULTAR INSTRUCCIONES

        if (instruccionSupervivencia != null)
            instruccionSupervivencia.SetActive(false);

        if (instruccionSupervivencia2 != null)
            instruccionSupervivencia2.SetActive(false);

        // 3. CUENTA REGRESIVA

        if (textoEsperandoJugador != null)
            textoEsperandoJugador.SetActive(true);

        if (textoEsperandoTMP != null)
        {
            textoEsperandoTMP.text = "3";
            yield return new WaitForSecondsRealtime(intervaloCuentaRegresiva);

            textoEsperandoTMP.text = "2";
            yield return new WaitForSecondsRealtime(intervaloCuentaRegresiva);

            textoEsperandoTMP.text = "1";
            yield return new WaitForSecondsRealtime(intervaloCuentaRegresiva);

            textoEsperandoTMP.text = "¡YA!";
            yield return new WaitForSecondsRealtime(0.45f);
        }
        else
        {
            yield return new WaitForSecondsRealtime(
                intervaloCuentaRegresiva * 3f + 0.45f
            );
        }

        // 4. DESBLOQUEAR JUGADOR

        if (textoEsperandoJugador != null)
            textoEsperandoJugador.SetActive(false);

        if (panelIntroduccion != null)
            panelIntroduccion.SetActive(false);

        if (movimientoLocal != null)
            movimientoLocal.BloquearMovimiento(false);

        Debug.Log("P8 | INICIO DE SUPERVIVENCIA.");

        SupervivenciaIniciadaLocal?.Invoke();

        rutinaCuentaRegresiva = null;
    }

    private void OnDestroy()
    {
        if (botonCerrarElian != null)
            botonCerrarElian.onClick.RemoveListener(CerrarCarta);

        if (botonCerrarLia != null)
            botonCerrarLia.onClick.RemoveListener(CerrarCarta);
    }
}
