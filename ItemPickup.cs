using UnityEngine;

public class ItemPickup : InteractiveObject
{
    public Item item;
    public override void Interact()
    {
        base.Interact();
        pickUp();
    }
    void pickUp()
    {
        Inventory.instance.Add(item); //เพิ่มไอเทมใน slot
        Destroy(gameObject); //ลบ obj ที่เก็บ
    }
}
