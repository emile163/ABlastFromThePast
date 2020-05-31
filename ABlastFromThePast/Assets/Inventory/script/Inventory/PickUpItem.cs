using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    
    public Item item;
    private static PlayerControllerclem pla;
    private GameObject player;
    private GameObject inv;
    private bool isInRange;
    private static Inventory inventory;
    private static GameObject pickUpText;
    private static GameObject FullInventoryText;
    private float timer = 1;
    public static bool DejaInv = false;
    private bool unfois = false;

   
    void Start()
	{
        player = GameObject.Find("Player");
        pla = player.GetComponent<PlayerControllerclem>();

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
            if (pla.listeQuete != null)
            {
               
                unfois = false;
                foreach (Queteobjet v in pla.listeQuete)
                {
                    if (v.isActive && v.qG.it.Equals(item.iT) && unfois == false)
                    {
                        pla.incrementeGoal(pla.listeQuete.IndexOf(v)) ;
                        unfois = true;
                    }
                }

                
            }
            
            Destroy(gameObject);

        } else if(isInRange && Input.GetKeyDown(KeyCode.E) && item is EatableItem)
		{
            inventory.AddEatableItem(item);
            Destroy(gameObject);
        }
        else if (isInRange && Input.GetKeyDown(KeyCode.E) && inventory.IsFull() == false)
        {
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

    
    public void plusplusphil(Queteobjet v)
    {
        pla.listeQuete[v.indexQuete].qG.currentAmount++;
    }
    
}
