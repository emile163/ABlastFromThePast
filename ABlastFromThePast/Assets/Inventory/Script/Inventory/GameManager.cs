using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //MARKER SINGLETON PATTERN
    public bool isPaused;

    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots;

    public Item addItem_01;//TODO remove later
    public Item removeItem_01;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        DisplayItems();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddItem(addItem_01);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            RemoveItem(removeItem_01);
        }
    }
    private void DisplayItems()
    {
       
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                //Update slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;

                //Update slots count
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

                //Update throw button
                slots[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            else
            {
                //Update slots Item Image
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;

                //Update slots count
                slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(1).GetComponent<Text>().text = null;

                //Update throw button
                slots[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }

    public void AddItem(Item _item)
    {
        //s'il y a deja un item
        if (!items.Contains(_item))
        {
            items.Add(_item);
            itemNumbers.Add(1);
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i]== _item)
                {
                    itemNumbers[i]++;
                }
            }
        }
        DisplayItems();
    }

    public void RemoveItem (Item _item)
    {
        if (items.Contains(_item))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if ( items[i]== _item)
                {
                    itemNumbers[i]--;
                    if (itemNumbers[i] == 0)
                    {
                        items.Remove(_item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        else
        {
            Debug.Log("There is no " + _item + " in my bag");
        }
        DisplayItems();
    }
}
