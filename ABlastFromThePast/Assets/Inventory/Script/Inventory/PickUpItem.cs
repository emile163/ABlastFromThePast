using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    private Text pickUpText;
    private bool pickUpAllowed;
    public Item item;
    private PlayerControllerclem play;
    [SerializeField] private Text FullInventoryText;
    // [SerializeField] private Text pickUpText;
    private Inventory inventory;
    private GameObject inv;

    private bool isInRange;

    void Awake()
    {
        play = FindObjectOfType<PlayerControllerclem>();
        inv = GameObject.Find("Inventory");
        inventory = inv.GetComponent<Inventory>();
    }
    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && item is RessourceItem)
        {
            inventory.AddRessourceItem(item);
            foreach (Queteobjet v in play.listeQuete)
            {
                if (v.isActive && v.qG.it.Equals(item.iT))
                {
                    Debug.Log("aa)");
                    PlayerControllerclem.incrementation(play, v.indexQuete);
                    plusplusphil(v );
                    Debug.Log(v.qG.it.ToString());
                    play.incrementeGoal(v.indexQuete);

                }

            }

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
    public void plusplusphil(Queteobjet v)
    {
        play.listeQuete[v.indexQuete].qG.currentAmount++;
    }
    
}
