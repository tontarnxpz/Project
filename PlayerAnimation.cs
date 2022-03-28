using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
    Transform target = null; //ตำแหน่งที่จะเดินไป
    public Animator anim;
    NavMeshAgent agent; //ตำแหน่งที่สามารถเดินได้
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); //นำ Navmeshagent มาใช้
    }

    public void MovetoPoint(Vector3 point) //method ที่สั่งให้ผู้เล่นเดิน
    {
        agent.SetDestination(point); //เอา point จาก movement มาไว้
    }

    void Update()
    {
        float speed = agent.velocity.magnitude / agent.speed; //ได้ความเร็วการเคลื่อนที่
        if (speed > 0)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

        if (target != null)
        {
            MovetoPoint(target.position); //เอาค่าตำแหน่งที่ได้ x y z มาเก็บไว้
        }
    }
}
