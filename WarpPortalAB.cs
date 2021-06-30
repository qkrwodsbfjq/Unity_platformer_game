//==========================================
// writer : 노현석.
// file : WarpPortalAB.cs.
// content : 각 워프포탈 충돌확인용 스크립트.
// discript : 2개 포탈은 각각 oneOrTwo에 1 또는 2를 입력해야함.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPortalAB : MonoBehaviour
{
    [SerializeField] float oneOrTwo;
    public bool isAccessible = true;

    WarpPortal motherPortal;
    Collider2D myCollider2D;
    PlayerController myPlayerController;

    private void Awake()
    {
        motherPortal = GetComponentInParent<WarpPortal>();
        myCollider2D = GetComponent<Collider2D>();
        myPlayerController = FindObjectOfType<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (myPlayerController.playerInput.y > 0)
            {
                if (motherPortal.portalsCanBeUsed)
                {
                    motherPortal.Teleport(oneOrTwo);
                }
                else
                {

                }
            }
        }
    }
}
