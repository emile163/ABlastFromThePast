using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJFin : MonoBehaviour
{

    public DialogueHolder dhold { set; get; }
    
    void Start()
    {
        dhold = GetComponentInChildren<DialogueHolder>();
    }

 
}
