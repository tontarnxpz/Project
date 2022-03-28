using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Camera cam;
    public LayerMask groundMask;
    public PlayerAnimation playerAnim;
    public GameObject inventoryUI; //ให้ invUI มาทำงาน
    
    public GameObject axe; //n
    public bool showAxe = false; //n
    public bool isAttack = false; //n
    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray ,out hit,groundMask))
            {
                //Debug.Log(hit.point); //ไว้เช็คตำแหน่ง
                if (!inventoryUI.activeSelf) //ให้ invUI ไม่ทำแสดงถึงจะเคลื่อนที่ได้
                {
                    playerAnim.MovetoPoint(hit.point); //เคลื่อนที่ไปยังตำแหน่งที่คลิก
                }
            }
        }
    }

    //n
    public void ShowAxe()
    {
        axe.SetActive(true);
        showAxe = true;
    }
}
