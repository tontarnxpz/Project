using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; //เอาตำแหน่งของ player มา
    public Vector3 offset; //ระยะห่างของ player กับกล้อง
    public float smoothSpeed = 2f; //ความสมูทในการเลื่อนเข้าเลื่อนออก
    public float currentZoom = 1f; //ซูมเข้าซูมออก
    public float maxZoom = 3f; //ซูมเข้าสูงสุด
    public float minZoom = 0.3f; //ซูมออกสูงสุด
    public float yawSpeed = 70f; //ความเร็วในการหมุนกล้อง
    public float zoomSensitive = 0.7f; //ความเร็วในการซูม
    float distance; //ระยะห่างของ player กับกล้อง
    float zoomSmooth; 
    float targetZoom;


    void Start()
    {
        distance = offset.magnitude; //ความห่างกล้อง
        transform.LookAt(target); //กล้องจะโฟกัสที่ player
        targetZoom = currentZoom; //ซูมที่ player
    }

    void Update()
    {
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel") * zoomSensitive; //การซูมเข้าซูมออกตาม scroll mouse
        if (scroll != 0f)
        {
            targetZoom = Mathf.Clamp(targetZoom - scroll, minZoom, maxZoom); //คำสั่งจำกัดตำแหน่งการซูม
        }
        currentZoom = Mathf.SmoothDamp(currentZoom, targetZoom, ref zoomSmooth, 0.15f);
    }
    private void LateUpdate()
    {
        transform.position = target.position - transform.forward * distance * currentZoom;
        transform.LookAt(target.position);

        float yawInput = Input.GetAxisRaw("Horizontal");
        transform.RotateAround(target.position,Vector3.up,-yawInput*yawSpeed*Time.deltaTime); //ใช้กล้องหมุนรอบ player , แกน x,y,z , ค่าที่รับมาxค่าความเร็วxเวลา
    }
}
