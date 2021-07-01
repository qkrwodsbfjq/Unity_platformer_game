using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [SerializeField] float penaltyDelayTime = 1f;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject startingTimerObject;

    public float upAnswer;
    public float downAnswer;

    MinigameLaneController myMinigameLaneController;
    MinigameAnswerNode myAnswerNode;
    MinigameAnswerGenerator myAnswerGenerator;
    MinigameScoreController myScoreController;
    Animator myAnimator;
    TextMeshProUGUI startingTimerText;
    MinigameTimeController myMinigameTimeController;
    RadialProgress myRadialProgress;

    public bool canInput = false;

    private void Awake()
    {
        myMinigameTimeController = FindObjectOfType<MinigameTimeController>().GetComponent<MinigameTimeController>();
        startingTimerText = startingTimerObject.GetComponent<TextMeshProUGUI>();
        myAnimator = playerObject.GetComponent<Animator>();
        myMinigameLaneController = FindObjectOfType<MinigameLaneController>();
        myAnswerNode = FindObjectOfType<MinigameAnswerNode>();
        myAnswerGenerator = FindObjectOfType<MinigameAnswerGenerator>();
        myScoreController = FindObjectOfType<MinigameScoreController>();
        myRadialProgress = FindObjectOfType<RadialProgress>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartingCountdown());
    }

    private IEnumerator StartingCountdown()
    {
        startingTimerText.text = "3";
        yield return new WaitForSeconds(1);
        startingTimerText.text = "2";
        yield return new WaitForSeconds(1);
        startingTimerText.text = "1";
        yield return new WaitForSeconds(1);
        startingTimerText.text = "Satrt!";
        canInput = true;
        myMinigameTimeController.StartMinigame();
        myRadialProgress.gameIsInProgress = true;
        yield return new WaitForSeconds(1);
        Destroy(startingTimerObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (canInput)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                var tempAnswerObject = myAnswerNode.GetComponent<MinigameAnswerNode>().currentObject;
                MinigameObject tempAnswerObjectComponent = tempAnswerObject.GetComponent<MinigameObject>();
                if (tempAnswerObjectComponent.objectAnswerNo == upAnswer)
                {
                    if(myMinigameLaneController.firstUpperStack.GetComponent<MinigameStackNode>().currentObject == null)
                    {
                        myAnswerNode.currentObject = null;
                        tempAnswerObjectComponent.targetObject = myMinigameLaneController.firstUpperStack;
                        tempAnswerObjectComponent.MoveToNewPositionVector2(myMinigameLaneController.firstUpperStack.transform.position);
                        myMinigameLaneController.firstUpperStack.GetComponent<MinigameStackNode>().currentObject = tempAnswerObject;
                    }
                    else if(myMinigameLaneController.firstUpperStack.GetComponent<MinigameStackNode>().currentObject != null)
                    {
                        myAnswerNode.currentObject = null;
                        myMinigameLaneController.firstUpperStack.GetComponent<MinigameStackNode>().MoveObjectToNextStack();
                        tempAnswerObjectComponent.targetObject = myMinigameLaneController.firstUpperStack;
                        tempAnswerObjectComponent.MoveToNewPositionVector2(myMinigameLaneController.firstUpperStack.transform.position);
                        myMinigameLaneController.firstUpperStack.GetComponent<MinigameStackNode>().currentObject = tempAnswerObject;
                    }                    
                    Debug.Log("Correct");
                    myScoreController.IncresaeScore();
                }
                else
                {
                    canInput = false;
                    Debug.Log("Wrong");
                    myAnimator.SetTrigger("Wrong");
                    StartCoroutine(PenaltyDelay(penaltyDelayTime));
                    myScoreController.DecreaseScore();
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                var tempAnswerObject = myAnswerNode.GetComponent<MinigameAnswerNode>().currentObject;
                MinigameObject tempAnswerObjectComponent = tempAnswerObject.GetComponent<MinigameObject>();
                if (tempAnswerObjectComponent.objectAnswerNo == downAnswer)
                {
                    if (myMinigameLaneController.firstLowerStack.GetComponent<MinigameStackNode>().currentObject == null)
                    {
                        myAnswerNode.currentObject = null;
                        tempAnswerObjectComponent.targetObject = myMinigameLaneController.firstLowerStack;
                        tempAnswerObjectComponent.MoveToNewPositionVector2(myMinigameLaneController.firstLowerStack.transform.position);
                        myMinigameLaneController.firstLowerStack.GetComponent<MinigameStackNode>().currentObject = tempAnswerObject;
                    }
                    else if (myMinigameLaneController.firstLowerStack.GetComponent<MinigameStackNode>().currentObject != null)
                    {
                        myAnswerNode.currentObject = null;
                        myMinigameLaneController.firstLowerStack.GetComponent<MinigameStackNode>().MoveObjectToNextStack();
                        tempAnswerObjectComponent.targetObject = myMinigameLaneController.firstLowerStack;
                        tempAnswerObjectComponent.MoveToNewPositionVector2(myMinigameLaneController.firstLowerStack.transform.position);
                        myMinigameLaneController.firstLowerStack.GetComponent<MinigameStackNode>().currentObject = tempAnswerObject;
                    }
                    Debug.Log("Correct");
                    myScoreController.IncresaeScore();
                }
                else
                {
                    canInput = false;
                    Debug.Log("Wrong");
                    myAnimator.SetTrigger("Wrong");
                    StartCoroutine(PenaltyDelay(penaltyDelayTime));
                    myScoreController.DecreaseScore();
                }
            }
        }
    }

    public void CallNextMove()
    {
        myMinigameLaneController.TriggerNextMove();
    }

    private IEnumerator PenaltyDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (myMinigameTimeController.gameOver == false)
        {
            canInput = true;
        }
    }

    public bool CheckAnswer()
    {
        return true;
    }
}
