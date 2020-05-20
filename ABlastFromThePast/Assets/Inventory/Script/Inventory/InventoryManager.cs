using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] Text AttackDisplay;
    [SerializeField] Text DeffenceDisplay;
    private int Healing;
    private int AttaquePersonnage;
    private int DefencPersonnage;
    private EatableItem EI;
    public PlayerSmg player;

    private void Awake()
    {
        player.GetComponent<PlayerSmg>();
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipmentPanel;
    }

    private void EquipFromInventory(Item item)
    {
        if(item is EatableItem)
        {
            EI = (EatableItem)item;
            Healing = EI.healingDone;
            player.Heal(Healing);
            inventory.RemoveItem(item);
        }
        if(item is EquipableItem)
        {
            Equip((EquipableItem)item);
            AttaquePersonnage = 10 + equipmentPanel.Nombreattaque();
            AttackDisplay.text = AttaquePersonnage.ToString();

            DefencPersonnage = 10 + equipmentPanel.NombreDefence();
            DeffenceDisplay.text = DefencPersonnage.ToString();
        }
    }
    private void UnequipFromEquipmentPanel(Item item)
    {
        if(item is EquipableItem)
        {
            Unequip((EquipableItem)item);
            AttaquePersonnage = 10 + equipmentPanel.Nombreattaque();
            AttackDisplay.text = AttaquePersonnage.ToString();

            DefencPersonnage = 10 + equipmentPanel.NombreDefence();
            DeffenceDisplay.text = DefencPersonnage.ToString();
        }
    }


    public void Equip(EquipableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquipableItem previousItem;
            if(equipmentPanel.AddItem(item, out previousItem))
            {
                if(previousItem != null)
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

    public void Unequip(EquipableItem item)
    {
        if(!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }
}
