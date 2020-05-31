using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeGOUI : MonoBehaviour
{
    public GameObject gameoverui;
    private float timer = 1;


    void start()
	{
        gameoverui.SetActive(true);
	}
    // Update is called once per frame
    void Update()
    {
        timer -= 1;
        if(timer == 0)
		{
            gameoverui.SetActive(false);
		}
    }
}
