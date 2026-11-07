
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(NetworkObject))]
[RequireComponent(typeof(Collider2D))]
public class PlataformaCamino : NetworkBehaviour
{
    [Header("Configuración")]
    [SerializeField] private bool esSeguro = false;

    private NetworkVariable<bool> destruida =
        new NetworkVariable<bool>(
            false,
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Server
        );

    private Collider2D[] colisiones;
    private SpriteRenderer[] sprites;

    public bool EsSeguro => esSeguro;
    public bool EstaDestruida => destruida.Value;

    private void Awake()
    {
        colisiones = GetComponents<Collider2D>();
        sprites = GetComponentsInChildren<SpriteRenderer>(true);
    }

    public override void OnNetworkSpawn()
    {
        destruida.OnValueChanged += AlCambiarEstado;
        AplicarEstado(destruida.Value);
    }

    public override void OnNetworkDespawn()
    {
        destruida.OnValueChanged -= AlCambiarEstado;
    }

    public void DestruirServidor()
    {
        if (!IsServer || destruida.Value)
            return;

        destruida.Value = true;

        Debug.Log("TABLÓN DESTRUIDO: " + name);
    }

    public void RestablecerServidor()
    {
        if (!IsServer)
            return;

        destruida.Value = false;
        AplicarEstado(false);
    }

    private void AlCambiarEstado(bool anterior, bool nuevo)
    {
        AplicarEstado(nuevo);
    }

    private void AplicarEstado(bool estaDestruida)
    {
        if (sprites != null)
        {
            foreach (SpriteRenderer sprite in sprites)
            {
                if (sprite != null)
                    sprite.enabled = !estaDestruida;
            }
        }

        if (colisiones != null)
        {
            foreach (Collider2D colision in colisiones)
            {
                if (colision != null)
                    colision.enabled = !estaDestruida;
            }
        }
    }
}
