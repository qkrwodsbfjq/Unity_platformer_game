//==========================================
// writer : 노현석.
// file : ExplosionParticle.cs.
// content : 스테이지에서 폭발 파티클 제어 스크립트.
// discript : n초뒤 오브젝트 없애주세요 말고 기능 없음.
//==========================================

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour
{
    [SerializeField] float secondsToDestroy = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyObjectSecondsLater(secondsToDestroy));
    }

    IEnumerator DestroyObjectSecondsLater(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
