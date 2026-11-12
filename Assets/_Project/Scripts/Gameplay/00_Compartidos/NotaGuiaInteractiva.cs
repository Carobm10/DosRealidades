
using UnityEngine;

public class NotaGuiaInteractiva : MonoBehaviour
{
    public enum RolPermitido
    {
        Ambos,
        Elian,
        Lia
    }

    [Header("Identificacion")]
    [SerializeField] private string idNota = "NOTA_P1_01";

    [Header("Imagen que aparecera en pantalla")]
    [SerializeField] private Sprite imagenNotaGrande;

    [Header("Personaje permitido")]
    [SerializeField] private RolPermitido rolPermitido =
        RolPermitido.Ambos;

    public string IdNota => idNota;

    // =====================================
    // COMPROBAR ACCESO
    // =====================================

    public bool PuedeLeerla()
    {
        switch (rolPermitido)
        {
            case RolPermitido.Elian:
                return IdentidadJugadorLocal.EsElian();

            case RolPermitido.Lia:
                return IdentidadJugadorLocal.EsLia();

            default:
                return true;
        }
    }

    // =====================================
    // ABRIR NOTA
    // =====================================

    public void AbrirNota()
    {
        if (!PuedeLeerla())
            return;

        if (imagenNotaGrande == null)
        {
            Debug.LogError(
                "NOTA: falta asignar la imagen en " +
                idNota
            );
            return;
        }

        VisorNotasUI visor = VisorNotasUI.Instancia;

        if (visor == null)
        {
            visor = FindAnyObjectByType<VisorNotasUI>(
                FindObjectsInactive.Include
            );
        }

        if (visor == null)
        {
            Debug.LogError(
                "NOTA: no se encontro VisorNotasUI."
            );
            return;
        }

        visor.MostrarNota(imagenNotaGrande);

        Debug.Log("NOTA ABIERTA: " + idNota);
    }
}
