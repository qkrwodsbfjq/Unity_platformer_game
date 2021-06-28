//==========================================
// writer : 노현석.
// file : PlayerStatus.cs.
// content : 플레이어 스테이터스 데이터 처리 스크립트.
// discript : 절대 파괴되어선 안되는 스크립트.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    /*
    [SerializeField] public GameObject currentNode;
    [SerializeField] public int[] stageDebuffID;
    [SerializeField] public int[] worldDebuffID;
    [SerializeField] public int enemiesKilled;
    */

    [Header("Global Attributes")]
    [SerializeField] public float totalCoins;

    [Header("Player Controller Attributes")]

    [SerializeField] public float moveSpeed = 30f; //플레이어 기본 이동 속도, 관성으로 제어.
    [SerializeField] public float maxSpeed = 10f; //플레이어 최대 이동 속도.
    [SerializeField] public float slowGroundMaxSpeed = 2f; //플레이어가 슬로우장판 밟을때 속도.
    [SerializeField] public float runningExtreaSpeed = 20f; //달리기시 최대 속도.
    [SerializeField] public float jumpForce = 10f; //점프 속도, 관성으로 제어.
    [SerializeField] public float doubleJumpForce = 30f; //더블 점프 속도, 관성으로 제어.

    [SerializeField] public float jumpStamina = 10f; //점프 시 소모하는 스테미너.
    [SerializeField] public float doubleJumpStamina = 10f; //더블점프 시 소모하는 스테미너.

    [SerializeField] public float playerDamage = 10f; //플레이어 공격력.
    [SerializeField] public float playerDefense = 0f; //플레이어 방어력.

    [SerializeField] public float addedForceUponDamageX = 10; //플레이어가 데미지를 입을 경우 받는 관성충격량 X.
    [SerializeField] public float addedForceUponDamageY = 10; //플레이어가 데미지를 입을 경우 받는 관성충격량 Y.
    [SerializeField] public float secondsOfRefrainedPlayerControl = 1f; //피격시 n초간 행동불가.
    [SerializeField] public float secondsOfPlayerInvincibility = 2f; // 피격시 n초간 무적시간.

    [Header("Stamina Controller Attributes")]

    [SerializeField] public float IncreaseStaminaPerTick = 1f; //틱당 스테미너 증가량.
    [SerializeField] public float ticksPerSec = 1f; //초당틱수.

    [SerializeField] public float RunningStaminaPerTick = 1f; //달리기 틱당 스테미너 추가 증가량.
    [SerializeField] public float RunningTicksPerSec = 1f; //달리기 초당틱수.

    [SerializeField] public float SlowGroundStaminaPerTick = 1f; //슬로우 장판 틱당 스테미너 추가 증가량.
    [SerializeField] public float SlowGroundTicksPerSec = 1f; //슬로우 장판 초당틱수.

    public float point = 0;

    void Awake()
    {
        var obj = FindObjectsOfType<PlayerStatus>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
