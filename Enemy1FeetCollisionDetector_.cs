//==========================================
// writer : 노현석.
// file : Enemy1FeetCollisionDetector.cs.
// content : Enemy1발 밑에 땅이 있는지 충돌 확인용 스크립트.
// discript : 충돌 확인용 이외 목적 없음.
//==========================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1FeetCollisionDetector_ : MonoBehaviour
{
    Enemy1 enemy1Script;

    // Start is called before the first frame update
    void Start()
    {
        enemy1Script = GetComponentInParent<Enemy1>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            enemy1Script.SwitchDirection();
        }
    }
}
