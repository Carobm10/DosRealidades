using UnityEngine;
using Unity.Netcode;

public class RecolectableP5 : MonoBehaviour
{
    [SerializeField]
    private ObjetosP5Controller controlador;

    [SerializeField]
    private ObjetosP5Controller.TipoObjetoP5 tipoObjeto;

    private void Awake()
    {
        if (controlador == null)
        {
            controlador =
                FindAnyObjectByType<ObjetosP5Controller>();
        }
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null)
            return;

        if (!jugador.IsOwner)
            return;

        if (controlador == null)
            return;

        controlador.IntentarRecoger(
            tipoObjeto
        );
    }
}