
using UnityEngine;
using Unity.Netcode;

public class BrilloObjetivo : MonoBehaviour
{
    [Header("Sprites del panel")]
    [SerializeField] private SpriteRenderer spriteObjetivo;
    [SerializeField] private Sprite spriteNormal;
    [SerializeField] private Sprite spriteBrillante;

    [Header("Configuracion")]
    [SerializeField] private float velocidadParpadeo = 1f;

    private bool jugadorCerca = false;
    private bool objetivoCompletado = false;

    private float temporizador = 0f;
    private bool mostrarBrillo = false;

    private void Awake()
    {
        if (spriteObjetivo == null)
            spriteObjetivo = GetComponent<SpriteRenderer>();

        if (spriteObjetivo != null)
            spriteObjetivo.sprite = spriteNormal;
    }

    private void Update()
    {
        if (spriteObjetivo == null || objetivoCompletado)
            return;

        if (jugadorCerca)
        {
            spriteObjetivo.sprite = spriteBrillante;
            return;
        }

        temporizador += Time.deltaTime;

        if (temporizador >= velocidadParpadeo)
        {
            temporizador = 0f;
            mostrarBrillo = !mostrarBrillo;

            spriteObjetivo.sprite = mostrarBrillo
                ? spriteBrillante
                : spriteNormal;
        }
    }

    public void CompletarObjetivo()
    {
        objetivoCompletado = true;
        jugadorCerca = false;
        temporizador = 0f;
        mostrarBrillo = false;

        if (spriteObjetivo != null)
            spriteObjetivo.sprite = spriteNormal;
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner || objetivoCompletado)
            return;

        jugadorCerca = true;
        spriteObjetivo.sprite = spriteBrillante;
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner || objetivoCompletado)
            return;

        jugadorCerca = false;
    }
}
