using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerInventory : MonoBehaviour
{
    public GameObject inventoryMenu;

    private int timer = 1;

    private void Start()
    {
        inventoryMenu.gameObject.SetActive(true);
    }
    
    void Update()
    {
        timer -= 1;
        if(timer == 0)
		{
            inventoryMenu.gameObject.SetActive(false);
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
        inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        GameManager.instance.isPaused = false;
    }

    private void Pause()
    {
        inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        GameManager.instance.isPaused = true;
    }
}
