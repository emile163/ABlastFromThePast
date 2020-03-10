using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;

    private bool isInRange;

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            inventory.AddItem(item);
            Debug.Log("HIIIIIIIIIIIIIIII");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
    }

}
