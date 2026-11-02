
using UnityEngine;

public class NPCVisualController : MonoBehaviour
{
    [Header("Animador del NPC")]
    [SerializeField] private Animator animatorNPC;

    private static readonly int JugadorCerca =
        Animator.StringToHash("JugadorCerca");

    private void Awake()
    {
        if (animatorNPC == null)
        {
            animatorNPC = GetComponentInChildren<Animator>();
        }
    }

    private void Start()
    {
        CambiarBrillo(false);
    }

    public void CambiarBrillo(bool activar)
    {
        if (animatorNPC == null)
            return;

        animatorNPC.SetBool(JugadorCerca, activar);
    }
}
