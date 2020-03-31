using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    private Item _item;
    [SerializeField] Image image;

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
    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Item!=null && OnRightClickEvent != null)
        {
            OnRightClickEvent(Item);
        }
    }
}
