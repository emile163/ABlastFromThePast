 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;
    private bool PeuStack = false;
 

    public event Action<Item> OnItemRightClickedEvent;

    private void Start()
    {
      
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
        DontDestroyOnLoad(gameObject);
    }

    public List<Item> GetListItem()
	{
        return items;
	}

    private void OnValidate()
    {
        if (itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }
        RefreshUI();
    }

    private void RefreshUI()
    {
        int i = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }

    }

    public bool AddItem(Item item)
    {
        
            if (IsFull())
                return false;

            items.Add(item);
            RefreshUI();
            return true;
        
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            PeuStack = false;
            return true;
        }
        return false;
    }

    public bool IsFull()
    {
        return items.Count >= itemSlots.Length;
    }

    public void AddRessourceItem(Item item)
    {
       
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].itemName == item.itemName && item is RessourceItem)
                {
                itemSlots[i].nombreDeRessource++;
                PeuStack = true;
                }
            }
        
            if(PeuStack == false)
        {
            AddItem(item);
        }
        
    }

    public void AddEatableItem(Item item)
	{
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemName == item.itemName && item is EatableItem)
            {
                itemSlots[i].nombreDeRessource++;
                PeuStack = true;
            }
        }

        if (PeuStack == false)
        {
            AddItem(item);
        }
    }

public ItemSlot[] GetItemSlots()
    {
        return itemSlots;
    }


}
public enum itemType
{
    Bois,
    Ble,
    medecinal,
    Equipement,
    Clément
    

}
