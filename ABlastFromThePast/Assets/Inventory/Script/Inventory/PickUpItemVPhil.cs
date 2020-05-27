using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    
    public Item item;
<<<<<<< HEAD
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
=======
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
>>>>>>> 1a4c050957cd9533ebe2dd0691ccf455b23551b6
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
            pickUpText.SetActive(true);

        } else {
            FullInventoryText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
<<<<<<< HEAD
        pickUpText.gameObject.SetActive(false);
        FullInventoryText.gameObject.SetActive(false);
=======
        pickUpText.SetActive(false);
        FullInventoryText.SetActive(false);
        
    }
>>>>>>> 1a4c050957cd9533ebe2dd0691ccf455b23551b6

    }
    public void plusplusphil(Queteobjet v)
    {
        play.listeQuete[v.indexQuete].qG.currentAmount++;
    }
    
}
