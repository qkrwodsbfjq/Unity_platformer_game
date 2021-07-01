using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameObject : MonoBehaviour
{
    [SerializeField] public GameObject targetObject;
    [SerializeField] float distanceToDestination;
    [SerializeField] float minimumDistance = 0.5f;

    [SerializeField] float objectMovementSpeed = 0.01f;
    [SerializeField] public float objectAnswerNo;
    [SerializeField] public bool ExitScreen = false;

    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToDestination = Vector2.Distance(transform.position, targetObject.transform.position);
        if (distanceToDestination < minimumDistance)
        {
            isMoving = false;
        }
        else if (distanceToDestination >= minimumDistance)
        {
            isMoving = true;
            MoveToNewPositionVector2(targetObject.transform.position);
        }

        if(ExitScreen == true && isMoving == false)
        {
            Destroy(gameObject);
        }
    }

    public void MoveToNewPositionVector2(Vector2 destination)
    {
        isMoving = true;
        transform.position = Vector2.MoveTowards(transform.position, destination, objectMovementSpeed);
    }

    public void MoveToNewPositionVector3(Vector3 destination)
    {
        isMoving = true;
        transform.position = Vector3.MoveTowards(transform.position, destination, objectMovementSpeed);
    }
}
