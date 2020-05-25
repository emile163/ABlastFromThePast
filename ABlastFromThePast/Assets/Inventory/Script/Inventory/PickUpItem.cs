using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    private Text pickUpText;
    private bool pickUpAllowed;
    public GameObject pickupEffect;
    public Item itemData;

    [SerializeField] private Text FullInventoryText;
    [SerializeField] private Text pickUpText;
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;
     

    private bool isInRange;

    private void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E) && item is RessourceItem)
        {
            inventory.AddRessourceItem(item);
            Destroy(gameObject);
        }
        else if (isInRange && Input.GetKeyDown(KeyCode.E) && inventory.IsFull() == false)
        {
            
            PickUp();///////////////// mods ici

            inventory.AddItem(item);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isInRange = true;
        if (inventory.IsFull() == false)
        {
            pickUpText.gameObject.SetActive(true);

        } else {
            FullInventoryText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
        pickUpText.gameObject.SetActive(false);
        FullInventoryText.gameObject.SetActive(false);
        
    }

    
}
