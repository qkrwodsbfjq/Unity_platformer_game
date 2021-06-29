//==========================================
// writer : 노현석.
// file : CoinDrops.cs.
// content : 코인 드랍 컨트롤러 및 계산기.
// discript : 코인 갯수 조절 및 Instantiate 조절 기능 탑재, 실제 드랍은 호출되야 발동.
//==========================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrops : MonoBehaviour
{
    [SerializeField] float dropCoinAmount;
    [SerializeField] GameObject bronzeCoinObject;
    [SerializeField] GameObject silverCoinObject;
    [SerializeField] GameObject goldCoinObject;

    private float bronzeCoinValue;
    private float silverCoinValue;
    private float goldCoinValue;

    [SerializeField] float droppingBronzeCoins;
    [SerializeField] float droppingSilverCoins;
    [SerializeField] float droppingGoldCoins;

    [SerializeField] float dropCoinForceRangeX = 10f;
    [SerializeField] float dropCoinForceRangeY = 10f;

    private void Awake()
    {
        bronzeCoinValue = bronzeCoinObject.GetComponent<DropCoin>().point;
        silverCoinValue = silverCoinObject.GetComponent<DropCoin>().point;
        goldCoinValue = goldCoinObject.GetComponent<DropCoin>().point;
        CalculateDroppingCoins();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropCoins()
    {
        for(var i = 0; i<droppingGoldCoins; i++)
        {
            var goldCoinDrop = Instantiate(goldCoinObject, transform.position, Quaternion.identity);
            var randomXRange = UnityEngine.Random.Range(-dropCoinForceRangeX, dropCoinForceRangeX);
            var randomYRange = UnityEngine.Random.Range(0, dropCoinForceRangeY);
            goldCoinDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomXRange, randomYRange));
        }
        for (var i = 0; i < droppingSilverCoins; i++)
        {
            var goldCoinDrop = Instantiate(silverCoinObject, transform.position, Quaternion.identity);
            var randomXRange = UnityEngine.Random.Range(-dropCoinForceRangeX, dropCoinForceRangeX);
            var randomYRange = UnityEngine.Random.Range(0, dropCoinForceRangeY);
            goldCoinDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomXRange, randomYRange));
        }
        for (var i = 0; i < droppingBronzeCoins; i++)
        {
            var goldCoinDrop = Instantiate(bronzeCoinObject, transform.position, Quaternion.identity);
            var randomXRange = UnityEngine.Random.Range(-dropCoinForceRangeX, dropCoinForceRangeX);
            var randomYRange = UnityEngine.Random.Range(0, dropCoinForceRangeY);
            goldCoinDrop.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomXRange, randomYRange));
        }
    }

    private void CalculateDroppingCoins()
    {
        droppingGoldCoins = Convert.ToInt64(Math.Truncate(dropCoinAmount / goldCoinValue));
        droppingSilverCoins = Convert.ToInt64(Math.Truncate((dropCoinAmount - goldCoinValue * droppingGoldCoins) / silverCoinValue));
        droppingBronzeCoins = Convert.ToInt64(Math.Truncate((dropCoinAmount - (goldCoinValue * droppingGoldCoins) - (silverCoinValue * droppingSilverCoins)) / bronzeCoinValue));
    }
}
