using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameStackNode : MonoBehaviour
{
    [SerializeField] public GameObject currentObject;
    [SerializeField] public GameObject nextStack;
    [SerializeField] bool isLastStack = false;

    MinigameStackNode nextStackComponent;

    private void Awake()
    {
        if (nextStack != null)
        {
            nextStackComponent = nextStack.GetComponent<MinigameStackNode>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveObjectToNextStack()
    {
        if (nextStack.GetComponent<MinigameStackNode>().isLastStack == false)
        {
            if (nextStack.GetComponent<MinigameStackNode>().currentObject == null)
            {
                nextStack.GetComponent<MinigameStackNode>().currentObject = currentObject;
            }
            else if(nextStack.GetComponent<MinigameStackNode>().currentObject != null)
            {
                nextStack.GetComponent<MinigameStackNode>().MoveObjectToNextStack();
                nextStack.GetComponent<MinigameStackNode>().currentObject = currentObject;
            }
            currentObject.GetComponent<MinigameObject>().targetObject = nextStack;
            currentObject.GetComponent<MinigameObject>().MoveToNewPositionVector2(nextStack.transform.position);
            currentObject = null;
        }
        else if(nextStack.GetComponent<MinigameStackNode>().isLastStack == true)
        {
            currentObject.GetComponent<MinigameObject>().targetObject = nextStack;
            currentObject.GetComponent<MinigameObject>().MoveToNewPositionVector2(nextStack.transform.position);
            currentObject.GetComponent<MinigameObject>().ExitScreen = true;
        }
    }
}
