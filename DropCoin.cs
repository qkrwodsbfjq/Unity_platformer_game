//==========================================
// writer : 노현석.
// file : DropCoin.cs.
// content : 드랍되는 코인.
// discript : 드랍되는 코인용 cs, Coin.cs랑은 구분해서 사용할것.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DropCoin : MonoBehaviour
{
    Collider2D myCollider;
    PlayerController myPlayerController;
    PossessionGoods myPossessionGoods;
    DropCoinObtainRange myObtainRange;
    [SerializeField] float genDelay = 1.5f;
    public float point = 10;
    public bool isChasingPlayer = false;
    public bool delayIsOver = false;
    public bool hasUpdatedScore = false;
    [SerializeField] public float chaseSpeed = 0f;
    [SerializeField] public float chaseAcceleration = 0.001f;

    private void Awake()
    {
        myObtainRange = GetComponentInChildren<DropCoinObtainRange>();
        myPlayerController = FindObjectOfType<PlayerController>();
        myPossessionGoods = FindObjectOfType<PossessionGoods>().GetComponent<PossessionGoods>();
        myCollider = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoinGenTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (isChasingPlayer == true && delayIsOver == true)
        {
            ChasePlayer();
        }
        else
        {

        }
    }

    public void IncreasePossessionGoodsCount()
    {
        myPossessionGoods.IncreaseOnlyInternalCountCoins(point);
    }

    public void UpdateCoinText()
    {
        myPossessionGoods.UpdateGoodsToText();
    }

    private void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, myPlayerController.gameObject.transform.position, chaseSpeed);
        chaseSpeed += chaseAcceleration;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (hasUpdatedScore == false)
            {
                IncreasePossessionGoodsCount();
            }
            UpdateCoinText();
            Destroy(gameObject);
        }
    }

    IEnumerator CoinGenTimer()
    {
        yield return new WaitForSeconds(genDelay);
        delayIsOver = true;
        ChangeCoinLayer(15);
    }

    private void ChangeCoinLayer(int id)
    {
        gameObject.layer = id;
        myObtainRange.gameObject.layer = id;
    }

    
}
