using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Permet de déterminer quel est le pnj  est le pnj du départ dans l'optique d'une quête 
/// d'exploration.
/// </summary>
public class PNJDebut : MonoBehaviour
{

    private DialogueHolder dhold { set; get; }   
    // Start is called before the first frame update
    void Start()
    {
        dhold = GetComponentInChildren<DialogueHolder>();
    }

   
}
