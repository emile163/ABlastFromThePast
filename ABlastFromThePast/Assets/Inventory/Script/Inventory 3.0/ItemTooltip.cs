﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    [SerializeField] Text nomItem;
    [SerializeField] Text Description;
    [SerializeField] Text nomStat;
    [SerializeField] Text ChiffreStat;
    [SerializeField] Text typeDitem;

    public void ShowTooltip(EquipableItem item)
    {
        nomItem.text = item.itemName;
        Description.text = item.itemDes;
        nomStat.text = item.nomStat;
        ChiffreStat.text = item.stat.ToString();
        typeDitem.text = item.EquipmentType.ToString();
        gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }

}
