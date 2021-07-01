using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameLaneController : MonoBehaviour
{
    [SerializeField] GameObject answerNode;
    [SerializeField] GameObject[] nodes;
    [SerializeField] GameObject firstNode;

    [SerializeField] public GameObject firstUpperStack;
    [SerializeField] public GameObject firstLowerStack;

    MinigameFirstNode myMinigameFirstNode;

    private void Awake()
    {
        myMinigameFirstNode = FindObjectOfType<MinigameFirstNode>().GetComponent<MinigameFirstNode>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TriggerNextMove();
        }
    }

    public void TriggerNextMove()
    {
        Debug.Log("Moving");
        myMinigameFirstNode.MoveObject();
        for (var i = 0; i < nodes.Length; i++)
        {
            if(i == 0)
            {
                if (nodes[i].GetComponent<MinigameNodes>().currentObject != null)
                {
                    nodes[i].GetComponent<MinigameNodes>().MoveToAnswerNode();
                }
                else
                {

                }
            }
            else
            {
                if (nodes[i].GetComponent<MinigameNodes>().currentObject != null)
                {
                    nodes[i].GetComponent<MinigameNodes>().MoveObject();
                }
                else
                {

                }
            }
        }
    }

}
