using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour //default
{
    public Image icon; //รูปไอเทม
    //public Button removeButton;
    Item item; //ไอเทมในกระเป๋าตอนนี้


    public void AddItem(Item newItem) //ใส่ไอเทมมาในslot
    {
        item = newItem;
        icon.sprite = item.icon; //ดึงค่าที่อยู่ในไอเทมมาแสดง
        icon.enabled = true; //ให้ไอคอนแสดง ให้ทำงาน
        //removeButton.interactable = true;

    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        //removeButton.interactable = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

}
