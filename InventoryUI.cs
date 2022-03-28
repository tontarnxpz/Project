using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    InventorySlot[] slots;
    public GameObject inventoryUI; //รับค่า invUI
    public Transform itemsParent; //รับค่า items
    Inventory inventory;
    void Start()
    {
        inventory = Inventory.instance; //ดึงค่า inventory
        inventory.onItemChangedCallback += UpdateUI; //เรียกใช้งาน UpdateUI
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();//ในช่อง slot แต่ละตัว

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //กดปุ่ม R เพื่อเปิดปิด inv
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf); //ให้เปิดปิดตามการกดปุ่ม
        }
        //UpdateUI(); //ใช้ fn
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length;i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
