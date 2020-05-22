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
    public QuestGoal qG;

    //initialiser le text de pick up invisible
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();///////////////// mods ici
            if (qG.goalType== GoalType.Gathering)
            if (itemData.iT == qG.it)
            {
                qG.currentAmount++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void PickUp()
    {
        /*for (int i = 0; i < GameManager.instance.items.Count; i++)
        {
            Debug.Log("CANNOT PICK UP!!   "+ GameManager.instance.items.Count);
            if (GameManager.instance.items.Contains(itemData))
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameManager.instance.AddItem(itemData);
            }
            else
            {
                if (GameManager.instance.items.Count < GameManager.instance.slots.Length)
                {
                    Instantiate(pickupEffect, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    GameManager.instance.AddItem(itemData);
                }
                else
                {
                    Debug.Log("CANNOT PICK UP!!");*/
                                    Instantiate(pickupEffect, transform.position, Quaternion.identity);
                       Destroy(gameObject);
                     GameManager.instance.AddItem(itemData);
              /*  }
            }
        }*/
    }
}
