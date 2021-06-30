//==========================================
// writer : 노현석.
// file : Coin.cs.
// content : 플레이어 습득 가능한 오브젝트(젬) 스크립트.
// discript : 습득시 제거외 기능 없음, 현재 습득한 재화량을 어디로 쏘는지는 없음.
//==========================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    //손지 소스수정 : 재화 기본값 및 습득여부 체크용 변수 추가
    Collider2D myCollider;
    PossessionGoods myPossessionGoods;
    public float point = 10;

    private void Awake()
    {
        myPossessionGoods = FindObjectOfType<PossessionGoods>().GetComponent<PossessionGoods>();
        myCollider = GetComponent<Collider2D>();
    }

    void Start()
    {

    }

    //==========================================

    void Update()
    {
    }

    //==========================================

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myPossessionGoods.IncreaseCoins(point);
            Destroy(gameObject);
        }
    }

}
