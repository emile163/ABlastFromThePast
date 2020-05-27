using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    
    public Item item;
    private static Inventory inventory;
    private GameObject inv;
    private static GameObject pickUpText;
    private static GameObject FullInventoryText;
    private float timer = 1;
    public static bool DejaInv = false;
     

    private bool isInRange;

    void Start()
	{
        if (DejaInv == false)
        {
            FullInventoryText = GameObject.Find("InventaireRempli");
            pickUpText = GameObject.Find("PickUpText");
            inv = GameObject.Find("Inventory");
            inventory = inv.GetComponent<Inventory>();
            DejaInv = true;
        }
	}

    private void Update()
    {
        timer -= 1;
        if(timer == 0)
		{
            pickUpText.SetActive(false);
            FullInventoryText.SetActive(false);
		}

        if(isInRange && Input.GetKeyDown(KeyCode.E) && item is RessourceItem)
        {
            inventory.AddRessourceItem(item);
            Destroy(gameObject);
        }
        else if (isInRange && Input.GetKeyDown(KeyCode.E) && inventory.IsFull() == false)
        {
            
           // PickUp();///////////////// mods ici

            inventory.AddItem(item);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isInRange = true;
        if (inventory.IsFull() == false)
        {
            pickUpText.SetActive(true);

        } else {
            FullInventoryText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
        pickUpText.SetActive(false);
        FullInventoryText.SetActive(false);
        
    }

    
}
