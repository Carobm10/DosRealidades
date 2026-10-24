using UnityEngine;

public class NPCDialogo : MonoBehaviour
{
    [Header("NPC")]
    [SerializeField] private string nombreNPC;
    [SerializeField] private Sprite retratoNPC;

    [Header("Inicio")]
    [TextArea(2, 4)]
    [SerializeField] private string textoInicial;

    [Header("Opcion 1")]
    [SerializeField] private string opcion1;

    [TextArea(2, 4)]
    [SerializeField] private string respuesta1;

    [Header("Opcion 2")]
    [SerializeField] private string opcion2;

    [TextArea(2, 4)]
    [SerializeField] private string respuesta2;

    [Header("Opcion 3")]
    [SerializeField] private string opcion3;

    [TextArea(2, 4)]
    [SerializeField] private string respuesta3;

    public string NombreNPC => nombreNPC;
    public Sprite RetratoNPC => retratoNPC;

    public string TextoInicial => textoInicial;

    public string Opcion1 => opcion1;
    public string Respuesta1 => respuesta1;

    public string Opcion2 => opcion2;
    public string Respuesta2 => respuesta2;

    public string Opcion3 => opcion3;
    public string Respuesta3 => respuesta3;

    public void IniciarDialogo()
    {
        HUDDialogoNPC.Instancia?.AbrirDialogo(this);
    }
}