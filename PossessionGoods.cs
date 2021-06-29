//==========================================
// writer : 손지. 노현석 러티칭.
// file : PosessionGoods.cs.
// content : 아이템 및 재화 관리 소스.
// discript : 
//==========================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PossessionGoods : MonoBehaviour
{
    CoinText myCoinText;
    [SerializeField] float currentStageCoins = 0; //현석 : 스테이지의 젬은 여기에 저장, 스테이지 클리어 후 PlayerStatus에서 총 젬 보유량으로 합산.

    StatusHandler myStatusHandler;

    // Start is called before the first frame update
    void Start()
    {
        myCoinText = FindObjectOfType<CoinText>();
        DontDestroyOnLoad(gameObject);
        myStatusHandler = FindObjectOfType<StatusHandler>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //==========================================

    public void UpdateGoodsToText()
    {
        myCoinText.GetComponent<Text>().text = Convert.ToString(currentStageCoins);
    }

    public void IncreaseCoins(float amount)
    {
        currentStageCoins += amount;
        UpdateGoodsToText();
    }

    public void IncreaseOnlyInternalCountCoins(float amount)
    {
        currentStageCoins += amount;
    }
}
