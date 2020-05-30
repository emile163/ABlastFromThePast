using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJDebut : MonoBehaviour
{

    private DialogueHolder dhold { set; get; }   
    // Start is called before the first frame update
    void Start()
    {
        dhold = GetComponentInChildren<DialogueHolder>();
    }

   
}
