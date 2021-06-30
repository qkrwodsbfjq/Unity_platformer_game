//==========================================
// writer : 노현석.
// file : ExplosionVFX.cs.
// content : 스테이지에서 폭발 효과 제어 스크립트.
// discript : 애니메이터에서 '이때 오브젝트 없애주세요'말고 기능 없음.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionVFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
