using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutSAcene : MonoBehaviour
{
    private GameObject inv;

    private int timer =1 ;

    void Start()
    {
        inv = GameObject.Find("Inventaire");
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1;
        if (timer == 0)
        {
            inv.gameObject.SetActive(false);
        }
    }
}
