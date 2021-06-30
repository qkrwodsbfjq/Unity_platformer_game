//==========================================
// writer : 노현석.
// file : Spikes.cs.
// content : 스테이지에서 가시 오브젝트에 대한 기본 스크립트.
// discript : 가시 움직이는건 애니메이터에서 조종, 여기서는 플레이어 데미지를 입히는 스크립트만 존재.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    Collider2D myCollider2D;
    PlayerController myPlayerController;

    private Vector2 originalPosition;
    private Vector2 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        myCollider2D = GetComponent<Collider2D>();
        myPlayerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            myPlayerController.RecieveDamage(damage, myPlayerController.gameObject.transform.position.x - transform.position.x);
        }
    }
}
