
using UnityEngine;
using Unity.Netcode;
using Unity.Collections;
using System;

public class InventarioJugador : NetworkBehaviour
{
    [Header("Catalogo de objetos")]
    [SerializeField]
    private ObjetoInventario[] catalogoObjetos;

    // Lista sincronizada por Netcode.
    // Cada jugador tiene su propia lista.
    private NetworkList<FixedString64Bytes> objetos;

    public event Action InventarioActualizado;

    public int CantidadObjetos =>
        objetos != null ? objetos.Count : 0;

    private void Awake()
    {
        objetos = new NetworkList<FixedString64Bytes>();
    }

    public override void OnNetworkSpawn()
    {
        objetos.OnListChanged += AlCambiarInventario;

        InventarioActualizado?.Invoke();

        Debug.Log(
            "Inventario iniciado para jugador: " +
            OwnerClientId
        );
    }

    public override void OnNetworkDespawn()
    {
        if (objetos != null)
            objetos.OnListChanged -= AlCambiarInventario;
    }

    // =====================================
    // AGREGAR OBJETO
    // =====================================

    public void SolicitarAgregarObjeto(
        ObjetoInventario objeto)
    {
        if (!IsSpawned || !IsOwner || objeto == null)
            return;

        if (string.IsNullOrWhiteSpace(objeto.Id))
            return;

        if (TieneObjeto(objeto.Id))
            return;

        if (IsServer)
        {
            AgregarEnServidor(objeto.Id);
        }
        else
        {
            AgregarObjetoRpc(objeto.Id);
        }
    }

    [Rpc(SendTo.Server)]
    private void AgregarObjetoRpc(
        string id,
        RpcParams rpcParams = default)
    {
        if (rpcParams.Receive.SenderClientId != OwnerClientId)
            return;

        AgregarEnServidor(id);
    }

    
    public bool AgregarObjetoDesdeServidor(string id)
    {
        return AgregarEnServidor(id);
    }

    private bool AgregarEnServidor(string id)
    {
        if (!IsServer || !IsSpawned ||
            string.IsNullOrWhiteSpace(id))
            return false;

        if (BuscarDefinicion(id) == null)
        {
            Debug.LogWarning(
                "Inventario: objeto no registrado: " + id
            );
            return false;
        }

        if (TieneObjeto(id))
        {
            Debug.Log("Objeto duplicado: " + id);
            return false;
        }

        objetos.Add(new FixedString64Bytes(id));

        Debug.Log("Objeto agregado al inventario: " + id);

        return true;
    }


    // =====================================
    // CONSULTAR OBJETOS
    // =====================================

    public bool TieneObjeto(string id)
    {
        if (objetos == null)
            return false;

        for (int i = 0; i < objetos.Count; i++)
        {
            if (objetos[i].ToString() == id)
                return true;
        }

        return false;
    }

    public string ObtenerId(int indice)
    {
        if (objetos == null ||
            indice < 0 ||
            indice >= objetos.Count)
            return null;

        return objetos[indice].ToString();
    }

    public ObjetoInventario ObtenerObjeto(int indice)
    {
        string id = ObtenerId(indice);

        if (string.IsNullOrEmpty(id))
            return null;

        return BuscarDefinicion(id);
    }

    public ObjetoInventario ObtenerObjetoPorId(string id)
    {
        return BuscarDefinicion(id);
    }

    private ObjetoInventario BuscarDefinicion(string id)
    {
        if (catalogoObjetos == null)
            return null;

        foreach (ObjetoInventario objeto in catalogoObjetos)
        {
            if (objeto != null && objeto.Id == id)
                return objeto;
        }

        return null;
    }

    // =====================================
    // CONSUMIR OBJETO
    // =====================================

    public void SolicitarConsumirObjeto(string id)
    {
        if (!IsSpawned || !IsOwner ||
            string.IsNullOrWhiteSpace(id))
            return;

        if (IsServer)
        {
            ConsumirEnServidor(id);
        }
        else
        {
            ConsumirObjetoRpc(id);
        }
    }

    [Rpc(SendTo.Server)]
    private void ConsumirObjetoRpc(
        string id,
        RpcParams rpcParams = default)
    {
        if (rpcParams.Receive.SenderClientId != OwnerClientId)
            return;

        ConsumirEnServidor(id);
    }

    private void ConsumirEnServidor(string id)
    {
        if (!IsServer || !TieneObjeto(id))
            return;

        ObjetoInventario definicion =
            BuscarDefinicion(id);

        if (definicion == null ||
            !definicion.ConsumibleAlUsar)
            return;

        objetos.Remove(new FixedString64Bytes(id));

        Debug.Log("Objeto consumido: " + id);
    }

    // =====================================
    // ACTUALIZACION
    // =====================================

    private void AlCambiarInventario(
        NetworkListEvent<FixedString64Bytes> cambio)
    {
        InventarioActualizado?.Invoke();

        Debug.Log(
            "Inventario actualizado. Objetos: " +
            objetos.Count
        );
    }
}
