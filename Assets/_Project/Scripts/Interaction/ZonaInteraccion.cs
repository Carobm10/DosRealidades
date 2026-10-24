using UnityEngine;
using Unity.Netcode;

public class ZonaInteraccion : MonoBehaviour
{
    [SerializeField] private string textoAccion = "INTERACTUAR";

    [Header("Ventana normal")]
    [SerializeField] private GameObject ventanaAbrir;

    [Header("NPC opcional")]
    [SerializeField] private NPCDialogo npcDialogo;

    private void Awake()
    {
        // Si este objeto tiene NPCDialogo,
        // lo encuentra automáticamente.
        if (npcDialogo == null)
        {
            npcDialogo = GetComponent<NPCDialogo>();
        }
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        var jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        HUDInteraccion.Instancia?.MostrarBoton(
            textoAccion,
            this
        );
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        var jugador =
            otro.GetComponentInParent<NetworkObject>();

        if (jugador == null || !jugador.IsOwner)
            return;

        HUDInteraccion.Instancia?.OcultarBoton(this);
    }

    public void Interactuar()
    {
        // Si este objeto es NPC:
        if (npcDialogo != null)
        {
            npcDialogo.IniciarDialogo();
            return;
        }

        // Si es un panel/puzzle:
        if (ventanaAbrir != null)
        {
            ventanaAbrir.SetActive(true);
        }
    }
}