using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    
    public Item item;
    private PlayerControllerclem play;
    private GameObject inv;
    private bool isInRange;
    private static Inventory inventory;
    private static GameObject pickUpText;
    private static GameObject FullInventoryText;
    private float timer = 1;
    public static bool DejaInv = false;

   
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
            foreach (Queteobjet v in play.listeQuete)
            {
                if (v.isActive && v.qG.it.Equals(item.iT))
                {
                    Debug.Log("aa)");
                    PlayerControllerclem.incrementation(play, v.indexQuete);
                    plusplusphil(v);
                    Debug.Log(v.qG.it.ToString());
                    play.incrementeGoal(v.indexQuete);

                }

            }

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
        play.listeQuete[v.indexQuete].qG.currentAmount++;
    }
    
}
