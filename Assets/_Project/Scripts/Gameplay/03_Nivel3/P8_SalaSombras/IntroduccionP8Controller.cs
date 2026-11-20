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

    [Header("Texto de espera / cuenta regresiva")]
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

    // =====================================
    // INICIO
    // =====================================

    private void Awake()
    {
        if (botonCerrarElian != null)
            botonCerrarElian.onClick.AddListener(CerrarCarta);

        if (botonCerrarLia != null)
            botonCerrarLia.onClick.AddListener(CerrarCarta);

        if (textoEsperandoTMP == null && textoEsperandoJugador != null)
            textoEsperandoTMP = textoEsperandoJugador.GetComponent<TMP_Text>();

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
    }

    // =====================================
    // OCULTAR ELEMENTOS
    // =====================================

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

        if (textoEsperandoJugador != null)
            textoEsperandoJugador.SetActive(false);
    }

    // =====================================
    // IDENTIFICAR JUGADOR LOCAL
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
    // ANIMACION INDIVIDUAL
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
        yield return new WaitForSeconds(
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
            " confirmó la lectura. Esperando al otro jugador."
        );

        ConfirmarLecturaRpc();
    }

    // =====================================
    // TEXTO ESPERANDO ANIMADO
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
            yield return new WaitForSeconds(intervaloPuntos);

            if (supervivenciaIniciada) yield break;

            textoEsperandoTMP.text = baseTexto + "..";
            yield return new WaitForSeconds(intervaloPuntos);

            if (supervivenciaIniciada) yield break;

            textoEsperandoTMP.text = baseTexto + "...";
            yield return new WaitForSeconds(intervaloPuntos);
        }
    }

    // =====================================
    // VALIDACION EN SERVIDOR
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
    // CUENTA REGRESIVA EN AMBOS
    // =====================================

    [Rpc(SendTo.Everyone)]
    private void IniciarCuentaRegresivaRpc()
    {
        if (!IsClient)
            return;

        if (rutinaEsperando != null)
        {
            StopCoroutine(rutinaEsperando);
            rutinaEsperando = null;
        }

        if (rutinaCuentaRegresiva != null)
            StopCoroutine(rutinaCuentaRegresiva);

        rutinaCuentaRegresiva = StartCoroutine(MostrarCuentaRegresiva());
    }

    private IEnumerator MostrarCuentaRegresiva()
    {
        if (textoEsperandoJugador != null)
            textoEsperandoJugador.SetActive(true);

        if (textoEsperandoTMP != null)
        {
            textoEsperandoTMP.text = "3";
            yield return new WaitForSeconds(intervaloCuentaRegresiva);

            textoEsperandoTMP.text = "2";
            yield return new WaitForSeconds(intervaloCuentaRegresiva);

            textoEsperandoTMP.text = "1";
            yield return new WaitForSeconds(intervaloCuentaRegresiva);

            textoEsperandoTMP.text = "¡YA!";
            yield return new WaitForSeconds(0.45f);
        }
        else
        {
            yield return new WaitForSeconds(2.85f);
        }

        if (textoEsperandoJugador != null)
            textoEsperandoJugador.SetActive(false);

        if (panelIntroduccion != null)
            panelIntroduccion.SetActive(false);

        if (movimientoLocal != null)
            movimientoLocal.BloquearMovimiento(false);

        Debug.Log("P8 | INICIO DE SUPERVIVENCIA.");

        SupervivenciaIniciadaLocal?.Invoke();
    }

    private void OnDestroy()
    {
        if (botonCerrarElian != null)
            botonCerrarElian.onClick.RemoveListener(CerrarCarta);

        if (botonCerrarLia != null)
            botonCerrarLia.onClick.RemoveListener(CerrarCarta);
    }
}