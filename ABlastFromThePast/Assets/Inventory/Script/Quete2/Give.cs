using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Give : MonoBehaviour
{
    private Inventory inv;



    // Start is called before the first frame update
    void Start()
    {
        inv = FindObjectOfType<Inventory>();
    }

    
}
