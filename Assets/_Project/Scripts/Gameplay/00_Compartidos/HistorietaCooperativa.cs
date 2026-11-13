
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using TMPro;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NetworkObject))]
public class HistorietaCooperativa : NetworkBehaviour
{
    [Header("Interfaz")]
    [SerializeField] private GameObject canvasHistorieta;
    [SerializeField] private Image imagenHistorieta;
    [SerializeField] private Button botonContinuar;
    [SerializeField] private TMP_Text textoEsperandoJugador;

    [Header("Imagenes")]
    [SerializeField] private bool mismaImagenParaAmbos = true;
    [SerializeField] private Sprite imagenGeneral;
    [SerializeField] private Sprite imagenElian;
    [SerializeField] private Sprite imagenLia;

    [Header("Lectura")]
    [SerializeField] private float tiempoMinimoLectura = 8f;

    [Header("Inicio del nivel")]
    [SerializeField] private bool ubicarEnSpawnsAlContinuar = true;
    [SerializeField] private Transform spawnElian;
    [SerializeField] private Transform spawnLia;

    private NetworkPlayerMovement movimientoLocal;

    private readonly HashSet<ulong> jugadoresListos =
        new HashSet<ulong>();

    private bool listoLocal;
    private bool introduccionFinalizada;

    private Coroutine rutinaInicio;
    private Coroutine rutinaLectura;

    // =====================================
    // PREPARACION
    // =====================================

    private void Awake()
    {
        if (botonContinuar != null)
        {
            botonContinuar.onClick.AddListener(
                PulsarContinuar
            );
        }

        if (imagenHistorieta != null)
            imagenHistorieta.preserveAspect = false;
    }

    public override void OnNetworkSpawn()
    {
        listoLocal = false;
        introduccionFinalizada = false;

        if (IsServer)
            jugadoresListos.Clear();

        if (botonContinuar != null)
            botonContinuar.gameObject.SetActive(false);

        if (textoEsperandoJugador != null)
            textoEsperandoJugador.gameObject.SetActive(false);

        if (canvasHistorieta != null)
            canvasHistorieta.SetActive(true);

        MostrarImagenCorrespondiente();

        rutinaInicio = StartCoroutine(
            EsperarJugadorLocal()
        );
    }

    // =====================================
    // IMAGEN SEGUN PERSONAJE
    // =====================================

    private void MostrarImagenCorrespondiente()
    {
        if (imagenHistorieta == null)
            return;

        Sprite imagen;

        if (mismaImagenParaAmbos)
        {
            imagen = imagenGeneral;
        }
        else
        {
            imagen = IdentidadJugadorLocal.EsElian()
                ? imagenElian
                : imagenLia;
        }

        imagenHistorieta.sprite = imagen;
        imagenHistorieta.enabled = imagen != null;

        if (imagen == null)
        {
            Debug.LogWarning(
                "HISTORIETA: falta asignar una imagen."
            );
        }
    }

    // =====================================
    // ESPERAR AL JUGADOR LOCAL
    // =====================================

    private IEnumerator EsperarJugadorLocal()
    {
        while (!introduccionFinalizada)
        {
            NetworkManager red = NetworkManager.Singleton;

            if (red != null &&
                red.IsConnectedClient &&
                red.LocalClient != null &&
                red.LocalClient.PlayerObject != null)
            {
                movimientoLocal =
                    red.LocalClient.PlayerObject
                    .GetComponent<NetworkPlayerMovement>();

                if (movimientoLocal != null)
                {
                    movimientoLocal.BloquearMovimiento(true);
                    break;
                }
            }

            yield return null;
        }

        rutinaInicio = null;

        if (introduccionFinalizada)
            yield break;

        rutinaLectura = StartCoroutine(
            EsperarTiempoLectura()
        );
    }

    // =====================================
    // TIEMPO MINIMO DE LECTURA
    // =====================================

    private IEnumerator EsperarTiempoLectura()
    {
        yield return new WaitForSecondsRealtime(
            Mathf.Max(0f, tiempoMinimoLectura)
        );

        rutinaLectura = null;

        if (introduccionFinalizada)
            yield break;

        if (botonContinuar != null)
            botonContinuar.gameObject.SetActive(true);
    }

    // =====================================
    // BOTON CONTINUAR
    // =====================================

    public void PulsarContinuar()
    {
        if (!IsSpawned ||
            introduccionFinalizada ||
            listoLocal ||
            rutinaLectura != null)
        {
            return;
        }

        listoLocal = true;

        if (botonContinuar != null)
            botonContinuar.gameObject.SetActive(false);

        if (textoEsperandoJugador != null)
        {
            textoEsperandoJugador.text =
                "Esperando al otro jugador...";

            textoEsperandoJugador.gameObject.SetActive(true);
        }

        ConfirmarLecturaRpc();
    }

    // =====================================
    // REGISTRAR CONFIRMACION EN SERVIDOR
    // =====================================

    [Rpc(
        SendTo.Server,
        RequireOwnership = false
    )]
    private void ConfirmarLecturaRpc(
        RpcParams rpcParams = default)
    {
        if (!IsServer || introduccionFinalizada)
            return;

        ulong jugadorId =
            rpcParams.Receive.SenderClientId;

        NetworkManager red = NetworkManager.Singleton;

        if (red == null ||
            !red.ConnectedClients.ContainsKey(jugadorId))
        {
            return;
        }

        jugadoresListos.Add(jugadorId);

        Debug.Log(
            "HISTORIETA: jugadores listos " +
            jugadoresListos.Count + "/2"
        );

        if (red.ConnectedClientsIds.Count != 2)
            return;

        foreach (ulong id in red.ConnectedClientsIds)
        {
            if (!jugadoresListos.Contains(id))
                return;
        }

        introduccionFinalizada = true;

        FinalizarHistorietaRpc();
    }

    // =====================================
    // FINALIZAR PARA AMBOS
    // =====================================

    [Rpc(SendTo.Everyone)]
    private void FinalizarHistorietaRpc()
    {
        if (rutinaInicio != null)
        {
            StopCoroutine(rutinaInicio);
            rutinaInicio = null;
        }

        if (rutinaLectura != null)
        {
            StopCoroutine(rutinaLectura);
            rutinaLectura = null;
        }

        introduccionFinalizada = true;

        if (ubicarEnSpawnsAlContinuar)
            UbicarJugadorLocal();

        if (canvasHistorieta != null)
            canvasHistorieta.SetActive(false);

        if (movimientoLocal != null)
            movimientoLocal.BloquearMovimiento(false);

        Debug.Log(
            "HISTORIETA: ambos jugadores listos."
        );
    }

    // =====================================
    // COLOCAR EN PUNTO DE INICIO
    // =====================================

    private void UbicarJugadorLocal()
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red == null ||
            red.LocalClient == null ||
            red.LocalClient.PlayerObject == null)
        {
            return;
        }

        Transform punto = IdentidadJugadorLocal.EsElian()
            ? spawnElian
            : spawnLia;

        if (punto == null)
        {
            Debug.LogWarning(
                "HISTORIETA: falta asignar el spawn."
            );
            return;
        }

        NetworkObject jugador =
            red.LocalClient.PlayerObject;

        Rigidbody2D cuerpo =
            jugador.GetComponent<Rigidbody2D>();

        if (cuerpo != null)
        {
            cuerpo.linearVelocity = Vector2.zero;
            cuerpo.angularVelocity = 0f;
            cuerpo.position = punto.position;
        }

        jugador.transform.position = punto.position;

        Physics2D.SyncTransforms();
    }

    // =====================================
    // LIMPIEZA
    // =====================================

    public override void OnNetworkDespawn()
    {
        if (rutinaInicio != null)
            StopCoroutine(rutinaInicio);

        if (rutinaLectura != null)
            StopCoroutine(rutinaLectura);

        rutinaInicio = null;
        rutinaLectura = null;

        jugadoresListos.Clear();
    }

    private void OnDestroy()
    {
        if (botonContinuar != null)
        {
            botonContinuar.onClick.RemoveListener(
                PulsarContinuar
            );
        }
    }
}
