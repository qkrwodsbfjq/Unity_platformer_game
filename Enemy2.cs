//==========================================
// writer : 노현석.
// file : Enemy2.cs.
// content : 적들을 위한 기본 행동 스크립트.
// discript : 최초로 작성한 Enemy2가 터져서 이거 사용, 기본적으로 테스트용으로 만든 EnemyBehavior 기반으로 작성.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] float enemyHealth; //적 체력.
    [SerializeField] float enemyDamage; //적 데미지.
    [SerializeField] float enemyDefense; //적 방어력.
    [SerializeField] float movementSpeed = 5f;//적 이동 속도.

    [SerializeField] GameObject headCollisionDetector;
    [SerializeField] GameObject feetCollisionDetector;

    [SerializeField] float secondsOfEnemyInvincibility = 2f; // 피격시 n초간 무적시간.
    [SerializeField] Vector2 enemyKnockback; //넉백 물리 충격량 x,y.
    [SerializeField] float secondsToReactAfterKnockback; //넉백후 다시 이동하기 시작하기까지 시간.

    Rigidbody2D myRigidbody;
    Collider2D myCollider2D;
    PlayerController myPlayerController;
    Animator myAnimator;
    CoinDrops myCoinDrops;

    public bool isInvincible = false;
    private bool isWalking = true;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<Collider2D>();
        myPlayerController = FindObjectOfType<PlayerController>();
        myAnimator = GetComponent<Animator>();
        myCoinDrops = GetComponent<CoinDrops>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    //==========================================

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<PlayerController>().isInvincible == false && isInvincible == false)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerFeet")
        {
            if(isInvincible == false && myPlayerController.isInvincible == false)
            {
                StartCoroutine(ProcessDamage(myPlayerController.playerDamage, collision));
            }
            else
            {

            }
        }
    }

    //==========================================

    private IEnumerator ProcessDamage(float damage, Collider2D collision)
    {
        EnableIgnoreCollisionWithPlayer(true);
        isInvincible = true;
        myPlayerController.BounceBackUp();
        EnemyKnockback(collision);
        enemyHealth = enemyHealth - (damage - enemyDefense);
        Debug.Log($"데미지 디버그 : 플레이어 공격력 : {damage}, 적 방어력 : {enemyDefense}, 최종데미지 연산값 : {damage - enemyDefense}, 남은 적 체력 : {enemyHealth}");
        if (enemyHealth <= 0)
        {
            myCoinDrops.DropCoins();
            isWalking = false;
            myRigidbody.velocity = new Vector2(0, 0);
            myAnimator.SetBool("IsDead", true);
        }
        else
        {
            myAnimator.SetBool("IsInvincible", true);
            yield return new WaitForSeconds(secondsOfEnemyInvincibility);
            myAnimator.SetBool("IsInvincible", false);
            isInvincible = false;
            EnableIgnoreCollisionWithPlayer(false);
        }
    }

    //==========================================

    private void EnableIgnoreCollisionWithPlayer(bool trigger)
    {
        Physics2D.IgnoreCollision(myCollider2D, FindObjectOfType<PlayerController>().GetComponent<Collider2D>(), trigger);
        Physics2D.IgnoreCollision(myCollider2D, FindObjectOfType<FeetCollider>().GetComponent<Collider2D>(), trigger);
    }

    //==========================================

    private void Patrol()
    {
        if (isWalking == true)
        {
            if (transform.localScale.x > 0)
            {
                myRigidbody.velocity = new Vector2(movementSpeed * -1, myRigidbody.velocity.y);
            }
            else if (transform.localScale.x < 0)
            {
                myRigidbody.velocity = new Vector2(movementSpeed, myRigidbody.velocity.y);
            }
        }
        else if(isWalking == false)
        {

        }
    }

    //==========================================

    public void SwitchDirection()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    //==========================================

    private void EnemyKnockback(Collider2D collision)
    {
        float enemyDirection = collision.gameObject.transform.position.x - transform.position.x;
        if(enemyDirection > 0)
        {
            myRigidbody.velocity = new Vector2(- enemyKnockback.x, enemyKnockback.y);
            StartCoroutine(waitToStartMoving());
        }
        else if (enemyDirection <= 0)
        {
            myRigidbody.velocity = new Vector2(enemyKnockback.x, enemyKnockback.y);
            StartCoroutine(waitToStartMoving());
        }
    }

    //==========================================

    private IEnumerator waitToStartMoving()
    {
        isWalking = false;
        yield return new WaitForSeconds(secondsToReactAfterKnockback);
        isWalking = true;
    }

    //==========================================

    public void DestoryThisGameObject()
    {
        Destroy(gameObject);
    }
}
