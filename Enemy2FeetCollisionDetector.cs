//==========================================
// writer : 노현석.
// file : Enemy2FeetCollisionDetector.cs.
// content : Enemy2발 밑에 땅이 있는지 충돌 확인용 스크립트.
// discript : 충돌 확인용 이외 목적 없음.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2FeetCollisionDetector : MonoBehaviour
{
    Enemy2 enemy2Script;

    // Start is called before the first frame update
    void Start()
    {
        enemy2Script = GetComponentInParent<Enemy2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //==========================================

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            if (enemy2Script.isInvincible == false)
            {
                enemy2Script.SwitchDirection();
            }
        }
    }
}
