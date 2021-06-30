//==========================================
// writer : 노현석.
// file : WarpPortal.cs.
// content : 워프포탈 컨트롤러.
// discript : 포탈 1로 들어가면 2로, 2로 들어가면 1로 나오게끔. 포탈오브젝트는 항상 2개 있어야 작동.
//==========================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPortal : MonoBehaviour
{
    [SerializeField] public GameObject portal1;
    [SerializeField] public GameObject portal2;
    [SerializeField] float portalDelayTime = 1f;

    PlayerController playerController;
    public bool portalsCanBeUsed = true;
    public bool portal1CanBeUsed = true;
    public bool portal2CanBeUsed = true;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Teleport (float playerEnteredPortal)
    {
        if(playerEnteredPortal == 1)
        {
            playerController.TeleportToLocation(new Vector2(portal2.transform.position.x, portal2.transform.position.y));
            StartCoroutine(PortalReuseDelay());
        }
        else if(playerEnteredPortal == 2)
        {
            playerController.TeleportToLocation(new Vector2(portal1.transform.position.x, portal1.transform.position.y));
            StartCoroutine(PortalReuseDelay());
        }
    }

    private IEnumerator PortalReuseDelay()
    {
        portalsCanBeUsed = false;
        yield return new WaitForSeconds(portalDelayTime);
        portalsCanBeUsed = true;
    }
}
