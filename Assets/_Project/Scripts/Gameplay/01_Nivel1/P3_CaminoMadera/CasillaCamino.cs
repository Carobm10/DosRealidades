using UnityEngine;
using Unity.Netcode;

public class CasillaCamino : MonoBehaviour
{
    [SerializeField] private int fila;
    [SerializeField] private LadoCamino lado;

    private PuzzleCaminoMadera puzzle;

    private void Awake()
    {
        puzzle = FindAnyObjectByType<PuzzleCaminoMadera>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        NetworkObject jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null)
            return;

        // Solo procesamos al jugador local.
        if (!jugador.IsOwner)
            return;

        // SOLO Lia puede activar las casillas.
        if (!EsLiaLocal(jugador))
            return;

        if (puzzle == null)
            return;

        puzzle.IntentarPaso(
            fila,
            lado,
            jugador.NetworkObjectId
        );
    }

    private bool EsLiaLocal(NetworkObject jugador)
    {
#if UNITY_EDITOR
        if (RolPruebaJugador.Instancia != null)
        {
            return RolPruebaJugador
                .Instancia
                .EsLia();
        }
#endif

        // Regla temporal:
        // Host = Elian
        // Client = Lia
        return jugador.OwnerClientId !=
               NetworkManager.ServerClientId;
    }
}