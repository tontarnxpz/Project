using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 10; //จำนวนพื้นที่ในกระเป๋า
    public List<Item> items = new List<Item>();
    public static Inventory instance; //ให้คลาสอื่นใช้งานได้

    private void Awake()
    {
        instance = this;
    }

    public delegate void OnItemChanged(); //การเปลี่ยนแปลงไอเทม เช่น เพิ่ม hp แล้วไอเทมหาย
    public OnItemChanged onItemChangedCallback;

    public void Add(Item item)
    {
        if (item.showInventory)
        {
            if (items.Count >= space) // ถ้าเกินกว่าพื้นที่ที่กำหนด
                return;
            items.Add(item); //ไปเรียกใช้ฟังก์ชั่น item

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke(); //มีการเปลี่ยนแปลงข้อมูลในกระเป๋า
            }
        }
    }

    public void Remove(Item item) //ลบไอเทม
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke(); //มีการเปลี่ยนแปลงข้อมูลในกระเป๋า
        }
    }
}