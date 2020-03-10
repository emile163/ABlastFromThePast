using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Item _item;

    [SerializeField] Image image;
    [SerializeField] ItemTooltip tooltip;

    public event Action<Item> OnRightClickEvent;

    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;

            if(_item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = _item.itemSprite;
                image.enabled = true;
            }
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (Item != null && OnRightClickEvent != null)
                OnRightClickEvent(Item);
        }
    }

    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        if (tooltip == null)
            tooltip = FindObjectOfType<ItemTooltip>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(Item is EquipableItem)
        {
            tooltip.ShowTooltip((EquipableItem)Item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
         tooltip.HideToolTip();
    }

}
