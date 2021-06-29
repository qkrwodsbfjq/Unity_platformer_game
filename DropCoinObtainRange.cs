//==========================================
// writer : 노현석.
// file : DropCoinObtainRange.cs.
// content : 드랍되는 코인 습득 가능 범위 조절용 충돌박스.
// discript : 드랍되는 코인용 cs, 범위조절하려면 CircleCollider 수정할것.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCoinObtainRange : MonoBehaviour
{
    DropCoin myDropCoin;
    Collider2D myCollider;

    private void Awake()
    {
        myDropCoin = GetComponentInParent<DropCoin>();
        myCollider = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (myDropCoin.delayIsOver == true && myDropCoin.hasUpdatedScore == false)
            {
                myDropCoin.isChasingPlayer = true;
                myDropCoin.IncreasePossessionGoodsCount();
                myDropCoin.hasUpdatedScore = true;
            }
        }
    }
}
