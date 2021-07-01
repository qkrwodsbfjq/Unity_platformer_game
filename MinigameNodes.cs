using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameNodes : MonoBehaviour
{
    [SerializeField] public GameObject nextNode;
    [SerializeField] public GameObject currentObject;

    MinigameNodes nextNodeComponent;

    private void Awake()
    {
        nextNodeComponent = nextNode.GetComponent<MinigameNodes>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveObject()
    {
        MinigameObject currentObjectComponent = currentObject.GetComponent<MinigameObject>();
        currentObjectComponent.targetObject = nextNode;
        nextNode.GetComponent<MinigameNodes>().currentObject = currentObject;
    }

    public void MoveToAnswerNode()
    {
        MinigameObject currentObjectComponent = currentObject.GetComponent<MinigameObject>();
        currentObjectComponent.targetObject = nextNode;
        nextNode.GetComponent<MinigameAnswerNode>().currentObject = currentObject;
    }
}
