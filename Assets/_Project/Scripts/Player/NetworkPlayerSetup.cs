using UnityEngine;
using Unity.Netcode;

public class NetworkPlayerSetup : NetworkBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnNetworkSpawn()
    {
        // Jugador 0 = Host
        if (OwnerClientId == 0)
        {
            spriteRenderer.color = Color.blue;

            if (IsServer)
            {
                transform.position = new Vector3(-2f, 0f, 0f);
            }
        }
        // Jugador 1 = Client
        else
        {
            spriteRenderer.color = Color.magenta;

            if (IsServer)
            {
                transform.position = new Vector3(2f, 0f, 0f);
            }
        }

        Debug.Log(
            $"Jugador creado | ClientId: {OwnerClientId} | " +
            $"IsOwner: {IsOwner} | IsServer: {IsServer}"
        );
    }
}