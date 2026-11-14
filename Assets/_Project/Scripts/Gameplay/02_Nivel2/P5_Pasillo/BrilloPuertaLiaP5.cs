
using UnityEngine;

public class BrilloPuertaLiaP5 : MonoBehaviour
{
    [Header("Sprite de la puerta")]
    [SerializeField] private SpriteRenderer spritePuerta;
    [SerializeField] private Sprite spriteNormal;
    [SerializeField] private Sprite spriteBrillante;

    [Header("Opcional: brillo como objeto separado")]
    [SerializeField] private GameObject visualBrillo;

    [Header("Animacion de apertura")]
    [SerializeField] private Animator animatorPuerta;

    private bool brilloActivo;
    private bool puertaAbriendose;

    private void Awake()
    {
        if (spritePuerta == null)
            spritePuerta = GetComponent<SpriteRenderer>();

        if (animatorPuerta == null)
            animatorPuerta = GetComponent<Animator>();

        // Si no se asigna un sprite normal,
        // utilizamos el sprite inicial de la puerta.
        if (spriteNormal == null && spritePuerta != null)
            spriteNormal = spritePuerta.sprite;

        ActivarBrillo(false);
    }

    public void ActivarBrillo(bool activar)
    {
        if (puertaAbriendose)
            return;

        brilloActivo = activar;

        if (spritePuerta != null)
        {
            if (activar && spriteBrillante != null)
                spritePuerta.sprite = spriteBrillante;
            else if (!activar && spriteNormal != null)
                spritePuerta.sprite = spriteNormal;
        }

        if (visualBrillo != null)
            visualBrillo.SetActive(activar);
    }

    public void PrepararApertura()
    {
        // Desde este momento, el brillo deja
        // de modificar los sprites de la puerta.
        puertaAbriendose = true;
        brilloActivo = false;

        if (visualBrillo != null)
            visualBrillo.SetActive(false);

        if (animatorPuerta != null)
            Debug.Log("P5: Apertura visual preparada en " + name);
    }

    public void ReiniciarPuerta()
    {
        puertaAbriendose = false;
        ActivarBrillo(false);
    }

    public bool BrilloActivo => brilloActivo;
}
