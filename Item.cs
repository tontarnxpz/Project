using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Item" , menuName = "Inventory/Item")] //เมนูคลิกขวา สร้างไอเทม

public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null; //รูปไอเทม
    public bool showInventory = false; //ใช้งานไอเทมนี้ได้ก็ต่อเมื่อกดเรียกใช้กระเป๋า //true

    //คำสั่งกรณีใช้ไอเทม
    public void Use()
    {
        if (name.Equals("Axe"))
        {
            PlayerMovement.instance.ShowAxe();
            RemoveItemFromInventory();
        }
    }

    public void RemoveItemFromInventory()
    {
        Inventory.instance.Remove(this);
    }

}
