
using System;
using UnityEngine;

[Serializable]
public class OpcionDialogo
{
    [TextArea(2, 3)]
    public string texto;

    [Tooltip("ID del siguiente nodo. Dejar vacío para terminar.")]
    public string siguienteNodo;
}

[Serializable]
public class NodoDialogo
{
    public string id;

    public enum Hablante
    {
        NPC,
        Jugador
    }

    public Hablante hablante = Hablante.NPC;

    [TextArea(2, 5)]
    public string texto;

    [Header("Respuestas disponibles")]
    public OpcionDialogo[] opciones =
        new OpcionDialogo[3];
}

public class NPCDialogo : MonoBehaviour
{
    [Header("Datos del NPC")]
    [SerializeField] private string nombreNPC = "Recepcionista";
    [SerializeField] private Sprite retratoNPC;

    [Header("Nombre del jugador")]
    [SerializeField] private string nombreJugador = "Elian";
    [SerializeField] private Sprite retratoJugador;

    [Header("Arbol de dialogos")]
    [SerializeField] private string nodoInicial = "inicio";
    [SerializeField] private NodoDialogo[] nodos;

    public string NombreNPC => nombreNPC;
    public Sprite RetratoNPC => retratoNPC;
    public string NombreJugador => nombreJugador;
    public Sprite RetratoJugador => retratoJugador;
    public string NodoInicial => nodoInicial;

    public NodoDialogo BuscarNodo(string id)
    {
        if (string.IsNullOrWhiteSpace(id) || nodos == null)
            return null;

        foreach (NodoDialogo nodo in nodos)
        {
            if (nodo != null && nodo.id == id)
                return nodo;
        }

        return null;
    }

    
    public void IniciarDialogo()
    {
        // Busca primero el HUD que pertenece a este NPC.
        HUDDialogoNPC hudPropio =
            GetComponentInChildren<HUDDialogoNPC>(true);

        if (hudPropio != null)
        {
            hudPropio.AbrirDialogo(this);
            return;
        }

        // Compatibilidad con NPC anteriores.
        HUDDialogoNPC.Instancia?.AbrirDialogo(this);
    }

}
