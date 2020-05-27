using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    private float timer = 1f;

    public GameObject over;

    void Start()
	{
        over.SetActive(true);
	}
    void Update()
    {
        timer -= 1;
        if(timer == 0)
		{
            over.SetActive(false);
		}
    }
}
