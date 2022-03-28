using UnityEngine;
using UnityEngine.AI;

public class InteractiveObject : MonoBehaviour
{
    public float radius = 3f; //กำหนดระยะการชนและการมองเห็น
    public Transform player; //ชนระหว่าง player
    public Transform interactItem; //กับ item
    bool hasInteract = false; //เช็คว่าชนกันหรือยัง

    void Update()
    {
        float distance = Vector3.Distance(player.position, interactItem.position); //ระยะ player กับ item
        if (distance <= radius && !hasInteract) //ถ้าชนวัตถุ
        {
            hasInteract = true; //ให้เห็นว่าชน
            Interact();
        }
    }

    public virtual void Interact()
    {
        //Debug.Log("Item Active"); //ดีบัค ว่าชนไอเทม
    }

    //สร้างขอบเขตการชนไอเทม(บริเวณที่พบไอเทม)
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactItem.position, radius);
    }
}
