
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class RegresoPasilloP5 : NetworkBehaviour
{
    private bool regresoSolicitado;

    public void SolicitarRegreso()
    {
        if (!IsSpawned || regresoSolicitado)
            return;

        RegresarRpc();
    }

    [Rpc(SendTo.Server)]
    private void RegresarRpc()
    {
        if (regresoSolicitado)
            return;

        regresoSolicitado = true;

        Debug.Log("P5: Regresando al pasillo");

        NetworkManager.Singleton.SceneManager.LoadScene(
            "P5_Pasillo",
            LoadSceneMode.Single
        );
    }
}
