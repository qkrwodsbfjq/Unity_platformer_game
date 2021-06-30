//==========================================
// writer : 노현석.
// file : Enemy1.cs.
// content : Enemy1을 위한 기본 행동 스크립트.
// discript : EnemyBehavior를 모태로 삼음. feetcollider와 충돌 없음, 단순좌우이동.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] float enemyDamage; //적 데미지.
    [SerializeField] float movementSpeed = 10f; //적 이동 속도.
    [SerializeField] GameObject headCollisionDetector;
    [SerializeField] GameObject feetCollisionDetector;

    Rigidbody2D myRigidbody;
    Collider2D myCollider2D;
    PlayerController myPlayerController;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<Collider2D>();
        myPlayerController = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    //==========================================

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerController>().isInvincible == false)
            {
                float enemyDirection = collision.gameObject.transform.position.x - transform.position.x;
                myPlayerController.RecieveDamage(enemyDamage, enemyDirection);
            }
            else
            {

            }
        }
    }

    //==========================================

    private void Patrol()
    {
        if (transform.localScale.x > 0) //왼쪽볼때.
        {
            myRigidbody.velocity = new Vector2(movementSpeed * -1, myRigidbody.velocity.y);
        }
        else if (transform.localScale.x < 0) //오른쪽볼때
        {
            myRigidbody.velocity = new Vector2(movementSpeed, myRigidbody.velocity.y);
        }
    }

    //==========================================

    public void SwitchDirection()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
