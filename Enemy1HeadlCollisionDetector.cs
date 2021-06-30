//==========================================
// writer : 노현석.
// file : Enemy1FeetCollisionDetector.cs.
// content : Enemy1 벽 충돌 확인용 스크립트.
// discript : Enemy1 앞에 벽이 없다면 몬스터 스크립트한테 방향 전환하라고 호출용.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1HeadlCollisionDetector : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            enemy1Script.SwitchDirection();
        }
    }
}
