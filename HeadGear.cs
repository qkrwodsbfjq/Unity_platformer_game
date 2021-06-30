//==========================================
// writer : 손지원.
// file : HeadGear.cs.
// content : 플레이어 습득 가능한 오브젝트(투구) 스크립트.
// discript : 습득시 제거외 기능 없음.
//==========================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGear : MonoBehaviour
{
    Collider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }
}
