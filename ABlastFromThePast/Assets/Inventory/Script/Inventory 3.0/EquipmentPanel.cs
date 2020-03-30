using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlot[] equipmentSlots;
    private int AttaquePersonnage = 0;
    private int DefencPersonnage = 0;
    private Item Litem;
    private EquipableItem EI;

    public event Action<Item> OnItemRightClickedEvent;

    private void Start()
    {
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
    
    public int Nombreattaque()
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

    public int NombreDefence()
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
    
}
