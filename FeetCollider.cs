//==========================================
// writer : 노현석.
// file : FeetCollider.cs.
// content : 플레이어 캐릭터의 발 충돌박스 처리용.
// discript : 발 충돌박스가 지면과 충돌할 경우 점프 가능을 PlayerController에게 전달.
// 추가 : 장판밟는여부도 여기서 확인.
//==========================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollider : MonoBehaviour
{
    [SerializeField] GameObject Ground;

    PlayerController playerController;
    StaminaController myStaminaController;
    Collider2D myCollider2D;

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        myStaminaController = FindObjectOfType<StaminaController>();
        myCollider2D = GetComponent<Collider2D>();
    }

    //==========================================

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerController.ResetJump();
        }
        if(collision.gameObject.tag == "SlowGround")
        {
            playerController.isOnSlowGround = true;
            myStaminaController.PlayerIsOnSlowGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SlowGround")
        {
            playerController.isOnSlowGround = false;
            myStaminaController.PlayerIsOnSlowGround = false;
            playerController.ResetJump();
        }
    }
}
