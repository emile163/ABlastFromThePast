using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextInfo : MonoBehaviour
{
    public GameObject thisgameobject;

    public GameObject nextone;
    
    public void clicky()
	{
        if (nextone != null)
        {
            thisgameobject.SetActive(false);

            nextone.SetActive(true);
        }
        else
            thisgameobject.SetActive(false);
	}

    
}
