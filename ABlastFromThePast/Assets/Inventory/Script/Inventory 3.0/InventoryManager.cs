using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Inventory3 inventory;
    [SerializeField] EquipmentPanel equipmentPanel;

    private void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
    }

    private void EquipFromInventory(Item item)
    {
        if (item is EquipableItems) ;
        {
            Equip((EquipableItems)item);
        }
    }

    private void UnequipFromEquipPanel(Item item)
    {
        if (item is EquipableItems) ;
        {
            Unequip((EquipableItems)item);
        }
    }

    public void Equip(EquipableItems item)
    {
        if (inventory.RemoveItem(item))
        {
            EquipableItems previousItem;
            if(equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }
    public void Unequip(EquipableItems item)
    {
        if(!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {

        }
    }
}
