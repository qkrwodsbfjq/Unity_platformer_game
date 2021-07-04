//==========================================
// writer : 노현석.
// file : NodeScript.cs.
// content : 월드맵에서 플레이어가 이동할 수 있는 노드 컨트롤러.
// discript : [SerializeField]처리된 상하좌우 노드 위치에 따른 다른 노드를 배치해 플레이어가 그간 이동하도록 제어.
//==========================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeScript : MonoBehaviour
{
    [SerializeField] GameObject leftNode; //1
    [SerializeField] GameObject rightNode; //2
    [SerializeField] GameObject upNode; //3
    [SerializeField] GameObject downNode; //4
    [SerializeField] GameObject WorldMapPlayer;

    [SerializeField] string sceneName;
    [SerializeField] bool isPassable = true; //노드로 갈 수 있는지 여부, 아직 작업중.

    [SerializeField] public int[] nodeStageDebuffID;

    PlayerStatus myPlayerStatus;

    void Awake()
    {
        myPlayerStatus = FindObjectOfType<PlayerStatus>();
    }

    void Start()
    {
        
    }

    //==========================================

    void Update()
    {
        
    }

    //==========================================

    public bool CheckIfNodeIsEmpty(float nodeNumber)
    {
        if(nodeNumber == 1) //left
        {
            if(leftNode.gameObject == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else if(nodeNumber == 2) //right
        {
            if (rightNode.gameObject == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (nodeNumber == 3) //up
        {
            if (upNode.gameObject == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else if (nodeNumber == 4) //down
        {
            if (downNode.gameObject == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }

    //==========================================

    public Vector2 ReturnTargetNodeLocation(float nodeNumber)
    {
        if (nodeNumber == 1)
        {
            return leftNode.transform.position;
        }
        else if(nodeNumber == 2)
        {
            return rightNode.transform.position;
        }
        else if(nodeNumber == 3)
        {
            return upNode.transform.position;
        }
        else if(nodeNumber == 4)
        {
            return downNode.transform.position;
        }
        else
        {
            return gameObject.transform.position;
        }
    }

    //==========================================

    public GameObject ReturnTargetNode(float nodeNumber)
    {
        if (nodeNumber == 1)
        {
            return leftNode;
        }
        else if (nodeNumber == 2)
        {
            return rightNode;
        }
        else if (nodeNumber == 3)
        {
            return upNode;
        }
        else if (nodeNumber == 4)
        {
            return downNode;
        }
        else
        {
            return null;
        }
    }

    //==========================================

    public void MoveToScene()
    {
        if(String.IsNullOrEmpty(sceneName))
        {

        }
        else
        {
            FindObjectOfType<SceneController>().MoveToScene(sceneName);
        }
    }

    //==========================================

    public string ReturnSceneName()
    {
        return sceneName;
    }


    //==========================================

    public bool isNodePassable()
    {
        return isPassable;
    }

    //==========================================

    public bool IsTargetNodePassable(float nodeNumber)
    {
        switch (nodeNumber)
        {
            case 1:
                try
                {
                    return leftNode.GetComponent<NodeScript>().isNodePassable();
                }
                catch
                {
                    return false;
                }
            case 2:
                try
                {
                    return rightNode.GetComponent<NodeScript>().isNodePassable();
                }
                catch
                {
                    return false;
                }
            case 3:
                try
                {
                    return upNode.GetComponent<NodeScript>().isNodePassable();
                }
                catch
                {
                    return false;
                }
            case 4:
                try
                {
                    return downNode.GetComponent<NodeScript>().isNodePassable();
                }
                catch
                {
                    return false;
                }
            default:
                return false;
        }
    }
}
