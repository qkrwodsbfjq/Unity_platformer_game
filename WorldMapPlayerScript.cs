//==========================================
// writer : 노현석.
// file : WorldMapPlayerScript.cs.
// content : 월드맵에서 플레이어 제어 컨트롤러.
// discript : 게임 오브젝트가 항상 currentNode의 노드에 위치함.
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WorldMapPlayerScript : MonoBehaviour
{
    [SerializeField] GameObject currentNode;
    [SerializeField] float minimumDistanceForPlayerToMove = 1f;
    [SerializeField] float moveSpeed;

    bool playerCanInput = true;
    //PlayerStatus myPlayerStatus;
    StatusHandler myPlayerStatus;
    void Awake()
    {

    }

    void Start()
    {
        transform.position = currentNode.transform.position;
    }

    //==========================================

    void Update()
    {
        if (playerCanInput)
        {
            //myPlayerStatus = FindObjectOfType<PlayerStatus>();
            myPlayerStatus = FindObjectOfType<StatusHandler>();
            MovePlayer();
            myPlayerStatus.UpdatePlayerStatusOnWorldMap(currentNode);
        }
        MoveCharacterToTargetNode();
        MoveScene();
    }

    //==========================================

    private void MovePlayer()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentNode.GetComponent<NodeScript>().IsTargetNodePassable(1))
            {
                MoveLeft();
            }
            else
            {

            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentNode.GetComponent<NodeScript>().IsTargetNodePassable(2))
            {
                MoveRight();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentNode.GetComponent<NodeScript>().IsTargetNodePassable(3))
            {
                MoveUp();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentNode.GetComponent<NodeScript>().IsTargetNodePassable(4))
            {
                MoveDown();
            }
        }
        else
        {

        }
    }

    //==========================================

    private void MoveLeft()
    {
        if (currentNode.GetComponent<NodeScript>().CheckIfNodeIsEmpty(1))
        {
            currentNode = currentNode.GetComponent<NodeScript>().ReturnTargetNode(1); 
            myPlayerStatus.currentNode = this.currentNode;
        }
        else
        {

        }
    }

    //==========================================

    private void MoveRight()
    {
        if(currentNode.GetComponent<NodeScript>().CheckIfNodeIsEmpty(2))
        {
            currentNode = currentNode.GetComponent<NodeScript>().ReturnTargetNode(2); 
            myPlayerStatus.currentNode = this.currentNode;
        }
        else
        {

        }
    }

    //==========================================

    private void MoveUp()
    {
        if (currentNode.GetComponent<NodeScript>().CheckIfNodeIsEmpty(3))
        {
            currentNode = currentNode.GetComponent<NodeScript>().ReturnTargetNode(3); 
            myPlayerStatus.currentNode = this.currentNode;
        }
        else
        {

        }
    }

    //==========================================

    private void MoveDown()
    {
        if (currentNode.GetComponent<NodeScript>().CheckIfNodeIsEmpty(4))
        {
            currentNode = currentNode.GetComponent<NodeScript>().ReturnTargetNode(4);
            myPlayerStatus.currentNode = this.currentNode;
        }
        else
        {

        }
    }

    //==========================================

    public void MoveCharacterToTargetNode()
    {
        if(transform.position != currentNode.transform.position)
        {
            playerCanInput = false;
            transform.position = Vector2.MoveTowards(transform.position, currentNode.transform.position, moveSpeed);
            if(Vector2.Distance(transform.position, currentNode.transform.position) < minimumDistanceForPlayerToMove)
            {
                playerCanInput = true;
            }
        }
        else
        {

        }
    }

    //==========================================

    public void MoveScene()
    {
        if (Input.GetButtonDown("Submit"))
        {
            if (currentNode.GetComponent<NodeScript>().ReturnSceneName() == null)
            {

            }
            else
            {
                currentNode.GetComponent<NodeScript>().MoveToScene();
            }
        }
    }
}
