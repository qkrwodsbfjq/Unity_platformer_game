//==========================================
// writer : 노현석.
// file : PortalSubCollider.cs.
// content : 각 워프포탈 사용후 재활성화 확인용 추가 충돌박스.
// discript : 해당 스크립트 달린 충돌박스 밖으로 플레이어가 가야 포탈 재이용 가능.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSubCollider : MonoBehaviour
{
    WarpPortal motherPortal;
    WarpPortalAB myWarpPortalAB;

    // Start is called before the first frame update
    void Start()
    {
        myWarpPortalAB = GetComponentInParent<WarpPortalAB>();
        motherPortal = GetComponentInParent<WarpPortalAB>().GetComponentInParent<WarpPortal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //==========================================

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(GetComponentInParent<WarpPortalAB>().gameObject == motherPortal.portal1)
            {
                motherPortal.portal1CanBeUsed = true;
            }
            else if(GetComponentInParent<WarpPortalAB>().gameObject == motherPortal.portal2)
            {
                motherPortal.portal2CanBeUsed = true;
            }
            else
            {

            }
        }
    }
}
