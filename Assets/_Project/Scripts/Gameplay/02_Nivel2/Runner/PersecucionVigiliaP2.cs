
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(Rigidbody2D))]
public class PersecucionVigiliaP2 : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidadPersecucion = 5.5f;

    [Header("Animacion")]
    [SerializeField] private Animator animator;

    [Header("Jugador perseguido")]
    private Transform objetivo;

    private Rigidbody2D cuerpo;
    private bool persecucionActiva;

    private void Awake()
    {
        cuerpo = GetComponent<Rigidbody2D>();

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        ConfigurarObjetivo();
    }

    private void ConfigurarObjetivo()
    {
        NetworkManager red = NetworkManager.Singleton;

        if (red == null || red.LocalClient == null)
            return;

        NetworkObject jugador =
            red.LocalClient.PlayerObject;

        if (jugador == null)
            return;

        NetworkPlayerSetup setup =
            jugador.GetComponent<NetworkPlayerSetup>();

        if (setup == null || setup.EsElian)
        {
            gameObject.SetActive(false);
            return;
        }

        objetivo = jugador.transform;
        persecucionActiva = true;

        Debug.Log("VIGILIA: Persiguiendo a Lía.");
    }

    private void FixedUpdate()
    {
        if (!persecucionActiva || objetivo == null)
            return;

        float diferenciaX =
            objetivo.position.x - cuerpo.position.x;

        if (Mathf.Abs(diferenciaX) < 0.05f)
            return;

        float direccion = Mathf.Sign(diferenciaX);

        Vector2 nuevaPosicion =
            cuerpo.position +
            Vector2.right *
            direccion *
            velocidadPersecucion *
            Time.fixedDeltaTime;

        cuerpo.MovePosition(nuevaPosicion);

        if (animator != null)
        {
            animator.SetBool(
                "MirandoIzquierda",
                direccion < 0
            );
        }
    }

    public void ModificarVelocidad(float nuevaVelocidad)
    {
        velocidadPersecucion =
            Mathf.Max(0f, nuevaVelocidad);
    }

    public float ObtenerVelocidad()
    {
        return velocidadPersecucion;
    }
}
