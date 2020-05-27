using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class est : MonoBehaviour
{
    public GameObject inv;

    private Inventory inv2;

    // Update is called once per frame
    void Update()
    {
        inv2 = inv.GetComponent<Inventory>();
    }
}
