//==========================================
// writer : 노현석.
// file : TemporaryCameraScript.cs.
// content : 임시 카메라 컨트롤러, 삭제 예정.
// discript : player 오브젝트에 카메라 초점이 항상 맞춰짐.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryCameraScript : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Start()
    {
        
    }

    //==========================================

    void Update()
    {
        transform.position = new Vector3(player.gameObject.transform.position.x, player.gameObject.transform.position.y, -10);
    }
}
