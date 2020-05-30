using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item _item;

    [SerializeField] Image image;
    [SerializeField] ItemTooltip tooltip;
    [SerializeField] Inventory inventory;
    [SerializeField] Text NombreDeRessource;
    [SerializeField] GameObject contenant;
    public int nombreDeRessource=1;
    public GameObject button; 
    public event Action<Item> OnRightClickEvent;
    public Button RemoveButton;


    void Start()
    {
        button.SetActive(false);
        nombreDeRessource = 1;
    }

    void Update()
    {
        if (_item!=null && _item is EquipableItem || _item is RessourceItem || _item is EatableItem)
        {
            button.SetActive(true);
        } else 
        {
            button.SetActive(false);
        }
        
        if ( _item != null && nombreDeRessource > 1)
        {
            NombreDeRessource.text = nombreDeRessource.ToString();
            contenant.SetActive(true);
        }
        else
        {
            contenant.SetActive(false);
        }
    }
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
                RemoveButton.interactable = true;
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
            tooltip.ShowTooltipEquipableItem((EquipableItem)Item);
        } else if(Item is EatableItem)
		{
            tooltip.ShowTooltipEatableItem((EatableItem)Item);

        }
        else if(Item is Item)
        {
            tooltip.ShowTooltipItem(Item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
         tooltip.HideToolTip();
    }

    public virtual void DeleteItem()
    {
        if (nombreDeRessource <= 1)
        {
            button.SetActive(false);
            RemoveButton.interactable = false;
            inventory.RemoveItem(_item);
        }
        else
        {
            nombreDeRessource--;
        }
    }
}
