using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PrendItem : MonoBehaviour
{
    [SerializeField] private Text pickUpText;

    private bool pickUpAllowed;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            pickUp();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("  = e");

        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("  ");
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }

    private void pickUp()
    {
        Destroy(gameObject);
    }
}
