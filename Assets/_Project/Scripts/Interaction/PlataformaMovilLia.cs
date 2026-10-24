using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(Rigidbody2D))]
public class PlataformaMovilLia : MonoBehaviour
{
    [Header("Recorrido")]
    [SerializeField] private Transform puntoIzquierda;
    [SerializeField] private Transform puntoDerecha;

    [Header("Movimiento")]
    [SerializeField] private float velocidad = 1.5f;
    [SerializeField] private float pausaEnExtremo = 0.3f;

    private Rigidbody2D rbPlataforma;
    private Vector2 destino;
    private float pausaActual;

    private Rigidbody2D rbLia;
    private NetworkObject liaSobrePlataforma;

    private void Awake()
    {
        rbPlataforma = GetComponent<Rigidbody2D>();

        rbPlataforma.bodyType =
            RigidbodyType2D.Kinematic;
    }

    private void OnEnable()
    {
        if (puntoDerecha != null)
        {
            destino = puntoDerecha.position;
        }

        pausaActual = 0f;
    }

    private void FixedUpdate()
    {
        if (puntoIzquierda == null ||
            puntoDerecha == null)
        {
            return;
        }

        if (pausaActual > 0f)
        {
            pausaActual -= Time.fixedDeltaTime;
            return;
        }

        Vector2 posicionAnterior =
            rbPlataforma.position;

        Vector2 nuevaPosicion =
            Vector2.MoveTowards(
                posicionAnterior,
                destino,
                velocidad * Time.fixedDeltaTime
            );

        Vector2 desplazamiento =
            nuevaPosicion - posicionAnterior;

        rbPlataforma.MovePosition(
            nuevaPosicion
        );

        // Si Lia está encima,
        // se mueve junto con la plataforma.
        if (rbLia != null &&
            liaSobrePlataforma != null)
        {
            rbLia.position +=
                desplazamiento;
        }

        if (Vector2.Distance(
                nuevaPosicion,
                destino
            ) < 0.02f)
        {
            bool estabaEnDerecha =
                Vector2.Distance(
                    destino,
                    puntoDerecha.position
                ) < 0.05f;

            destino =
                estabaEnDerecha
                ? (Vector2)puntoIzquierda.position
                : (Vector2)puntoDerecha.position;

            pausaActual = pausaEnExtremo;
        }
    }

    private void OnTriggerEnter2D(
        Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent
            <NetworkObject>();

        if (jugador == null ||
            !jugador.IsOwner)
        {
            return;
        }

        if (!EsLia(jugador))
            return;

        liaSobrePlataforma = jugador;

        rbLia =
            jugador.GetComponent<Rigidbody2D>();

        Debug.Log(
            "Lia subio a la plataforma."
        );
    }

    private void OnTriggerExit2D(
        Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent
            <NetworkObject>();

        if (jugador == null)
            return;

        if (jugador != liaSobrePlataforma)
            return;

        liaSobrePlataforma = null;
        rbLia = null;

        Debug.Log(
            "Lia bajo de la plataforma."
        );
    }

    private bool EsLia(
        NetworkObject jugador)
    {
#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
        {
            return RolPruebaJugador
                .Instancia
                .EsLia();
        }
#endif

        return jugador.OwnerClientId !=
               NetworkManager.ServerClientId;
    }
}