using System.Collections;
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

    public void ShowTooltipEquipableItem(EquipableItem item)
    {
        nomItem.text = item.itemName;
        Description.text = item.itemDes;
        nomStat.text = item.NomStat.ToString();
        ChiffreStat.text = item.stat.ToString();
        typeDitem.text = item.EquipmentType.ToString();
        gameObject.SetActive(true);
    }

    public void ShowTooltipEatableItem(EatableItem item)
	{
        nomItem.text = item.itemName;
        Description.text = item.itemDes;
        nomStat.text = "Vie donée:";
        ChiffreStat.text = item.healingDone.ToString();
        typeDitem.text = null;
        gameObject.SetActive(true);
    }

    public void ShowTooltipItem(Item item)
    {
        nomItem.text = item.itemName;
        Description.text = item.itemDes;
        nomStat.text = null;
        ChiffreStat.text = null;
        typeDitem.text = null;
        gameObject.SetActive(true);
    }
    public void HideToolTip()
    {
        gameObject.SetActive(false);
    }

}
