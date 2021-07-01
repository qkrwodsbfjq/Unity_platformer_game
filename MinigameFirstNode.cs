using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameFirstNode : MonoBehaviour
{
    [SerializeField] GameObject answerObject_1;
    [SerializeField] GameObject answerObject_2;

    [SerializeField] GameObject objectsParentObject;

    [SerializeField] GameObject nextNode;
    [SerializeField] public GameObject currentObject;

    private int orderOfLayer = 1;

    MinigameController myMinigameController;
    MinigameNodes nextNodeComponent;

    private void Awake()
    {
        myMinigameController = FindObjectOfType<MinigameController>();
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

    public void GenerateObject()
    {
        var objectRNG = Random.Range(0, 2);
        GameObject newAnswerObject;
        Debug.Log(objectRNG);
        if(objectRNG == 0)
        {
            newAnswerObject = answerObject_1;
        }
        else if(objectRNG == 1)
        {
            newAnswerObject = answerObject_2;
        }
        else
        {
            newAnswerObject = answerObject_1;
        }
        var instantiatedGameObject = Instantiate(newAnswerObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
        instantiatedGameObject.GetComponent<SpriteRenderer>().sortingOrder = orderOfLayer;
        orderOfLayer++;
        instantiatedGameObject.GetComponent<MinigameObject>().targetObject = this.gameObject;
        instantiatedGameObject.transform.parent = objectsParentObject.transform;
        currentObject = instantiatedGameObject;
    }

    public void MoveObject() 
    {
        MinigameObject currentObjectComponent = currentObject.GetComponent<MinigameObject>();
        currentObjectComponent.targetObject = nextNode;
        nextNode.GetComponent<MinigameNodes>().currentObject = currentObject;
        GenerateObject();    
    }
}
