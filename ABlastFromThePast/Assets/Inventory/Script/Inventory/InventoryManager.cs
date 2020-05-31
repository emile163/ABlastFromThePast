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
    private float Healing;
    private float AttaquePersonnageEnPlus;
    private float DefencPersonnage;
    private float speed;
    private EatableItem EI;
    private PlayerSmg player;
    private PlayerCombat mmplayer;
    private PlayerControllerclem pcm;
    private GameObject pla;

    private void Awake()
    {
        pla = GameObject.FindWithTag("Player");
        player = pla.GetComponent<PlayerSmg>();
        mmplayer = pla.GetComponent<PlayerCombat>();
        pcm = player.GetComponent<PlayerControllerclem>();
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
            AttaquePersonnageEnPlus = 10 + equipmentPanel.Nombreattaque();
            AttackDisplay.text = AttaquePersonnageEnPlus.ToString();
            mmplayer.SetAttaque(AttaquePersonnageEnPlus);
            speed = equipmentPanel.nombreDeSpeed();
            pcm.SetSpeed(speed);

            DefencPersonnage = equipmentPanel.NombreDefence();
            DeffenceDisplay.text = DefencPersonnage.ToString();
            player.AjouterArmure(DefencPersonnage);
        }
    }
    private void UnequipFromEquipmentPanel(Item item)
    {
        if(item is EquipableItem)
        {
            Unequip((EquipableItem)item);
            checkStat();
        }
    }

    public void checkStat()
	{
        AttaquePersonnageEnPlus = 10 + equipmentPanel.Nombreattaque();
        AttackDisplay.text = AttaquePersonnageEnPlus.ToString();
        mmplayer.SetAttaque(AttaquePersonnageEnPlus);
        speed = equipmentPanel.nombreDeSpeed();
        pcm.SetSpeed(speed);

        DefencPersonnage = equipmentPanel.NombreDefence();
        DeffenceDisplay.text = DefencPersonnage.ToString();
        player.EnleverArmure(DefencPersonnage);
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
            if(item is EquipableItem)
			{
                item.stat = item.stat / 2;

            }
        }
    }
}
