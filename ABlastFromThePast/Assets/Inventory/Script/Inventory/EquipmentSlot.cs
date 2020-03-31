using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : ItemSlot
{
    public EquipmentType EquipmentType;
    [SerializeField] EquipmentPanel equipmentPanel;

    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = EquipmentType.ToString() + " Slot";
    }

    public override void DeleteItem()
    {
        button.SetActive(false);
        RemoveButton.interactable = false;
        equipmentPanel.RemoveItem((EquipableItem)_item);
    }
}
