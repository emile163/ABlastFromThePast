using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerInventory : MonoBehaviour
{
    private static GameObject inv;

    private int timer = 1;

    static bool unefois = true;

    private void Start()
    {
        if(unefois == true)
		{
            inv = GameObject.Find("Inventaire");
            unefois = false;
        }
        
        inv.gameObject.SetActive(true);
    }
    
    void Update()
    {
        timer -= 1;
        if(timer == 0)
		{
            inv.gameObject.SetActive(false);
            Resume();
        }
        InventoryControl();
    }

    private void InventoryControl()
    {
        if (Input.GetKeyDown(KeyCode.I)) { 
            
            if(GameManager.instance.isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
      }
    }
    
    private void Resume()
    {
        inv.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        GameManager.instance.isPaused = false;
    }

    private void Pause()
    {
        inv.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        GameManager.instance.isPaused = true;
    }
}
