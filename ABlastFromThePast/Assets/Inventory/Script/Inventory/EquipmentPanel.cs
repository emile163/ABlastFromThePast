using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlot[] equipmentSlots;
    private float AttaquePersonnage = 0;
    private float DefencPersonnage = 0;
    private float pourcentagespeed = 0;
    private Item Litem;
    private EquipableItem EI;
    private GameObject inv;
    private static InventoryManager inventory;
    public static bool DejaInv = false;

    public event Action<Item> OnItemRightClickedEvent;

    private void Start()
    {
        if (DejaInv == false)
        {
            inv = GameObject.Find("CaracterPanel");
            inventory = inv.GetComponent<InventoryManager>();
            DejaInv = true;
        }
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
    }

    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool AddItem(EquipableItem item, out EquipableItem previousItem)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if(equipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquipableItem)equipmentSlots[i].Item;
                equipmentSlots[i].Item = item;
                return true;
            }
        }
        previousItem = null;
        return false;
    }

    public bool RemoveItem(EquipableItem item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == item)
            {
                equipmentSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }
    
    public float Nombreattaque()
    {
        AttaquePersonnage = 0;
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if(equipmentSlots[i] != null)
            {
                Litem = equipmentSlots[i]._item;
                EI = (EquipableItem)Litem;
                if (EI != null && EI.NomStat == NomStat.Attaque)
                {
                    AttaquePersonnage = AttaquePersonnage + EI.stat;
                }
            }
        }
        return AttaquePersonnage;
    }

    public float NombreDefence()
    {
        DefencPersonnage = 0;
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i] != null)
            {
                Litem = equipmentSlots[i]._item;
                EI = (EquipableItem)Litem;
                if (EI != null && EI.NomStat == NomStat.Defence)
                {
                    DefencPersonnage = DefencPersonnage + EI.stat;
                }

            }
        }
        return DefencPersonnage;
    }

    public float nombreDeSpeed()
    {
        pourcentagespeed = 0;
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i] != null)
            {
                Litem = equipmentSlots[i]._item;
                EI = (EquipableItem)Litem;
                if (EI != null && EI.NomStat == NomStat.PourcentageDeVitesseDePlus)
                {
                    pourcentagespeed = EI.stat;
                }

            }
        }
        return pourcentagespeed;
    }

}
