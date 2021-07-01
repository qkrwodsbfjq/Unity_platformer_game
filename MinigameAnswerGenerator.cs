using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MinigameAnswerGenerator : MonoBehaviour
{
    [SerializeField] GameObject upAnswer;
    [SerializeField] GameObject downAnswer;

    [SerializeField] GameObject upAnswerReady;
    [SerializeField] GameObject downAnswerReady;

    [SerializeField] GameObject answerObject_1; //1
    [SerializeField] GameObject answerObject_2; //2

    MinigameController myMinigameController;
    MinigameFirstNode myFirstNode;

    private void Awake()
    { 
        myMinigameController = FindObjectOfType<MinigameController>();
        myFirstNode = FindObjectOfType<MinigameFirstNode>();

        float answerRoll = Random.Range(0, 2);
        if(answerRoll == 0)
        {
            upAnswerReady = answerObject_1;
            downAnswerReady = answerObject_2;
            myMinigameController.upAnswer = 1;
            myMinigameController.downAnswer = 2;
        }
        else if(answerRoll == 1)
        {
            upAnswerReady = answerObject_2;
            downAnswerReady = answerObject_1;
            myMinigameController.upAnswer = 2;
            myMinigameController.downAnswer = 1;
        }
        var upAnswerSprite = Instantiate(upAnswerReady, upAnswer.transform.position, Quaternion.identity);
        upAnswerSprite.transform.parent = this.gameObject.transform;
        var downAnswerSprite = Instantiate(downAnswerReady, downAnswer.transform.position, Quaternion.identity);
        downAnswerSprite.transform.parent = this.gameObject.transform;
        myFirstNode.GenerateObject();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
