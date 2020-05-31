using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe déterminant le pnj de fin dans l'optique d'une quête d'exploration
/// </summary>
public class PNJFin : MonoBehaviour
{

    public DialogueHolder dhold { set; get; }
    
    void Start()
    {
        dhold = GetComponentInChildren<DialogueHolder>();
    }

 
}
