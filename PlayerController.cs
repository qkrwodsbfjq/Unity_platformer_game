//==========================================
// writer : 노현석.
// file : PlayerController.cs.
// content : 플레이어 행동 제어 컨트롤러.
// discript : 하기 [SerializeField] 각 항목 참조, 본 스크립트는 동시에 2개 이상 존재하면 안됨. 내용이 원체 많아서 문의사항은 노현석에게 직접 문의.
//==========================================

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float playerRunInput; // 플레이어 달리기 인풋 확인용, 달리기 버튼 왼쪽 Ctrl.
    [SerializeField] public Vector2 playerInput = new Vector2(0, 0); //플레이어 상하좌우 실시간 인풋, 엔진에서 수정용 아님.
    
    [SerializeField] float moveSpeed = 30f; //플레이어 기본 이동 속도, 관성으로 제어.
    [SerializeField] float maxSpeed = 10f; //플레이어 최대 이동 속도.
    [SerializeField] float slowGroundMaxSpeed = 2f; //플레이어가 슬로우장판 밟을때 속도.
    [SerializeField] float runningExtraSpeed = 30f; //달리기시 최대 속도.
    [SerializeField] float jumpForce = 30f; //점프 속도, 관성으로 제어.
    [SerializeField] float doubleJumpForce = 30f; //더블 점프 속도, 관성으로 제어.

    [SerializeField] float jumpStamina = 10f; //점프 시 소모하는 스테미너.
    [SerializeField] float doubleJumpStamina = 10f; //더블점프 시 소모하는 스테미너.

    [SerializeField] public float playerDamage = 10f; //플레이어 공격력.
    [SerializeField] public float playerDefense = 0f; //플레이어 방어력.

    [SerializeField] float addedForceUponDamageX = 40; //플레이어가 데미지를 입을 경우 받는 관성충격량 X.
    [SerializeField] float addedForceUponDamageY = 20; //플레이어가 데미지를 입을 경우 받는 관성충격량 Y.
    [SerializeField] float secondsOfRefrainedPlayerControl = 1f; //피격시 n초간 행동불가.
    [SerializeField] float secondsOfPlayerInvincibility = 2f; // 피격시 n초간 무적시간.
    
    [SerializeField] public GameObject FeetColliderObject; //발 충돌박스 연결용.
    [SerializeField] public GameObject jumpDustVFXObject; //점프시 바닥에 먼지 이펙트.
    
    //PlayerStatus myPlayerStatus;
    StatusHandler myStatusHandler; 
    Collider2D myCollider;
    Rigidbody2D myrigidbody;
    SpriteRenderer mySpriteRenderer;
    BoxCollider2D feetCollider;
    StaminaController myStaminaController;
    Animator myAnimator;
    float originalScaleX;
    public bool canControl = true; //조작가능여부.
    bool canJump = true; //점프가능여부.
    bool canDoubleJump = true; //더블점프 가능여부.
    bool isTakingDamage = false; //데미지입는중.
    bool timescaleSlowed = false;
    public bool isRunning = false;
    public bool isInvincible = false; //무적판정여부.
    public bool isOnSlowGround = false; //슬로우장판 밟았는지 여부.

    private void Awake()
    {
        myStatusHandler = FindObjectOfType<StatusHandler>().GetComponent<StatusHandler>();
    }

    void Start()
    {
        //myPlayerStatus = FindObjectOfType<PlayerStatus>();
        UpdateAttributesFromStatusHandler();
        myrigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        feetCollider = FeetColliderObject.GetComponent<BoxCollider2D>();
        myStaminaController = FindObjectOfType<StaminaController>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        originalScaleX = transform.localScale.x;
    }

    //==========================================

    void Update()
    {
        if (canControl)
        {
            playerRunInput = RefreshRunInput();
            playerInput = RefreshInput();

            if (isOnSlowGround == false)
            {
                Jump();
            }
        }
        MoveCharacterHorizontal();
        CheckDirection();
        CheckMovingUpOrDown();
    }


    //==========================================

    private void FixedUpdate()
    {
        CheckMaxSpeed();
        if (isTakingDamage == false)
        {
            CheckMinSpeed();
            CheckRunning();
        }
    }

    //==========================================

    private Vector2 RefreshInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    //==========================================

    private float RefreshRunInput()
    {
        return Input.GetAxis("Fire1");
    }

    //==========================================

    private void MoveCharacterHorizontal()
    {
        if (Mathf.Abs(playerInput.x) > 0)
        {
            myrigidbody.velocity = new Vector2 (playerInput.x * moveSpeed, myrigidbody.velocity.y);
            myAnimator.SetBool("IsWalking", true);
        }
    }

    //==========================================

    private void CheckMaxSpeed() 
    {
        float secondaryMaxSpeed = CalculateSecondaryMaxSpeed();

        if (myrigidbody.velocity.x > secondaryMaxSpeed)
        {
            myrigidbody.velocity = new Vector2(secondaryMaxSpeed, myrigidbody.velocity.y);
        }
        else if (myrigidbody.velocity.x < -secondaryMaxSpeed)
        {
            myrigidbody.velocity = new Vector2(-secondaryMaxSpeed, myrigidbody.velocity.y);
        }
    }

    //==========================================

    private float CalculateSecondaryMaxSpeed()
    {
        if (isTakingDamage == false)
        {
            if (isRunning == true)
            {
                return runningExtraSpeed;
            }
            else if (isOnSlowGround)
            {
                return slowGroundMaxSpeed;
            }
            else
            {
                return maxSpeed;
            }
        }
        else
        {
            return maxSpeed;
        }
    }


    //==========================================

    private void CheckMinSpeed()
    {
        if(playerInput.x == 0)
        {
            myAnimator.SetBool("IsWalking", false);
            myrigidbody.velocity = new Vector2(0, myrigidbody.velocity.y);
        }
    }

    //==========================================

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (canJump == true)
            {
                float Vector3Xpos = Convert.ToInt64(transform.position.x + (Mathf.Sign(transform.localScale.x) * -1)) ;
                var JumpDustVFX = Instantiate(jumpDustVFXObject, new Vector3(Vector3Xpos , transform.position.y - 0.5f, 0), Quaternion.identity);
                JumpDustVFX.transform.localScale = new Vector3(JumpDustVFX.transform.localScale.x * Mathf.Sign(transform.localScale.x), JumpDustVFX.transform.localScale.y, JumpDustVFX.transform.localScale.z);
                StartCoroutine(JumpDustDestroyDelay(JumpDustVFX));
                myStaminaController.IncresaeStaminaByAmount(jumpStamina);
                myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, jumpForce);
                canJump = false;
            }
            else if(canJump != true && canDoubleJump == true)
            {
                myStaminaController.IncresaeStaminaByAmount(doubleJumpStamina);
                myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, doubleJumpForce);
                canDoubleJump = false;
            }
            else
            {

            }
        }
    }

    IEnumerator JumpDustDestroyDelay(GameObject JumpDustObject)
    {
        yield return new WaitForSeconds(1f);
        Destroy(JumpDustObject);
    }

    //==========================================

    private void CheckDirection()
    {
        if(playerInput.x > 0)
        {
            transform.localScale = new Vector3(originalScaleX, transform.localScale.y, transform.localScale.z);
        }
        else if(playerInput.x < 0)
        {
            transform.localScale = new Vector3(-originalScaleX, transform.localScale.y, transform.localScale.z);
        }
        else
        {

        }
    }

    //==========================================

    public void ResetJump()
    {
        canJump = true;
        canDoubleJump = true;
    }

    //==========================================

    public void RecieveDamage(float enemyDamage, float enemyDirection)
    {
        StartCoroutine(RefrainPlayerMovement(secondsOfRefrainedPlayerControl));
        StartCoroutine(PlayerIsInvincible());
        float finalCalculatedDamage = enemyDamage - playerDefense;
        if(finalCalculatedDamage < 0)
        {
            finalCalculatedDamage = 0;
        }
        myStaminaController.IncresaeStaminaByAmount(finalCalculatedDamage);
        Debug.Log($"데미지 디버그 : 적 공격력 : {enemyDamage}, 플레이어 방어력 : {playerDefense}, 최종데미지 연산값{finalCalculatedDamage}");
        float damageForceX;
        if(Mathf.Sign(enemyDirection) >= 0)
        {
            damageForceX = addedForceUponDamageX * 1;
        }
        else if(Mathf.Sign(enemyDirection) < 0)
        {
            damageForceX = addedForceUponDamageX * -1;
        }
        else
        {
            damageForceX = 1;
        }
        myrigidbody.velocity = new Vector2(damageForceX, addedForceUponDamageY);
    }

    //==========================================

    private IEnumerator RefrainPlayerMovement(float seconds)
    {
        myAnimator.SetBool("IsDamaged", true);
        isTakingDamage = true;
        playerInput = new Vector2(0, 0);
        playerRunInput = 0;
        isRunning = false;
        myStaminaController.PlayerIsRunning = false;
        canControl = false;
        yield return new WaitForSeconds(seconds);
        canControl = true;
        isTakingDamage = false;
        myAnimator.SetBool("IsDamaged", false);
    }

    //==========================================

    private IEnumerator PlayerIsInvincible()
    {
        DisablePlayerCollisionWithEnemy(true);
        myAnimator.SetBool("IsBlinking", true);
        isInvincible = true;
        yield return new WaitForSeconds(secondsOfPlayerInvincibility);
        isInvincible = false;
        myAnimator.SetBool("IsBlinking", false);
        DisablePlayerCollisionWithEnemy(false);
    }

    //==========================================

    public void BounceBackUp()
    {
        myrigidbody.velocity = new Vector2(myrigidbody.velocity.x, jumpForce);
        canDoubleJump = true;
    }

    //==========================================

    public void DisablePlayerCollisionWithEnemy(bool disable)
    {
        Physics2D.IgnoreLayerCollision(8, 10, disable);
        Physics2D.IgnoreLayerCollision(11, 10, disable);
    }

    //==========================================

    public void PlayerCollisionWithPortals(bool disable)
    {
        Physics2D.IgnoreLayerCollision(8, 13, disable);
    }

    //==========================================

    private void CheckRunning()
    {
        if(playerRunInput > 0)
        {
            myAnimator.SetBool("IsRunning", true);
            isRunning = true;
            myStaminaController.PlayerIsRunning = true;
            if(playerInput.x == 0)
            {
                myAnimator.SetBool("IsRunning", false);
                isRunning = false;
                myStaminaController.PlayerIsRunning = false;
            }
        }
        if(playerRunInput<= 0)
        {
                myAnimator.SetBool("IsRunning", false);
                isRunning = false;
                myStaminaController.PlayerIsRunning = false;
        }
    }

    //==========================================

    public void TeleportToLocation(Vector2 destination)
    {
        transform.position = destination;
        myrigidbody.velocity = new Vector3(0, 0, 0);
        StartCoroutine(RefrainPlayerMovement(0.2f));
    }

    private void CheckMovingUpOrDown()
    {
        if(myrigidbody.velocity.y > 1)
        {
            myAnimator.SetBool("IsJumpingDown", false);
            myAnimator.SetBool("IsJumpingUp", true);
        }
        else if(myrigidbody.velocity.y < -1)
        {
            myAnimator.SetBool("IsJumpingDown", true);
            myAnimator.SetBool("IsJumpingUp", false);
        }
        else
        {
            myAnimator.SetBool("IsJumpingDown", false);
            myAnimator.SetBool("IsJumpingUp", false);

        }
    }

    private void UpdateAttributesFromStatusHandler()
    {
        //PlayerStatus playerStatusComponent = myPlayerStatus.GetComponent<PlayerStatus>();
        StatusHandler StatusHandlerComponent = myStatusHandler.GetComponent<StatusHandler>();

        moveSpeed = StatusHandlerComponent.ReturnMoveSpeed();
        maxSpeed = StatusHandlerComponent.ReturnMaxSpeed();
        slowGroundMaxSpeed = StatusHandlerComponent.ReturnSlowGroundMaxSpeed();
        runningExtraSpeed = StatusHandlerComponent.ReturnRunningExtraSpeed();
        jumpForce = StatusHandlerComponent.ReturnJumpForce();
        doubleJumpForce = StatusHandlerComponent.ReturnDoubleJumpForce();
        jumpStamina = StatusHandlerComponent.ReturnJumpStamina();
        doubleJumpStamina = StatusHandlerComponent.ReturnDoubleJumpStamina();
        playerDamage = StatusHandlerComponent.ReturnPlayerDamage();
        playerDefense = StatusHandlerComponent.ReturnPlayerDefense();
        addedForceUponDamageX = StatusHandlerComponent.ReturnAddedForceUponDamageX();
        addedForceUponDamageY = StatusHandlerComponent.ReturnAddedForceUponDamageY();
        secondsOfRefrainedPlayerControl = StatusHandlerComponent.ReturnSecondsOfRefrainedPlayerControl();
        secondsOfPlayerInvincibility = StatusHandlerComponent.ReturnSecondsOfPlayerInvincibility();
    }
}
