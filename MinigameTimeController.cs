using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameTimeController : MonoBehaviour
{
    [SerializeField] float remainingTime = 60f;

    [SerializeField] GameObject timeTextObject;
    [SerializeField] GameObject timeOverTextObject;
    [SerializeField] GameObject resultScreenObject;
    [SerializeField] GameObject myCanvas;

    MinigameController myMinigameController;
    TextMeshProUGUI timeText;
    public bool gameOver = false;

    private void Awake()
    {
        myMinigameController = FindObjectOfType<MinigameController>().GetComponent<MinigameController>();
        timeText = timeTextObject.GetComponent<TextMeshProUGUI>();
        RenewRemainingTime();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMinigame()
    {
        RenewRemainingTime();
        StartCoroutine(DeductTime());
    }

    private void RenewRemainingTime()
    {
        timeText.text = Convert.ToString(remainingTime);
    }

    private IEnumerator DeductTime()
    {
        yield return new WaitForSeconds(1f);
        remainingTime--;
        RenewRemainingTime();
        CheckRemainingTime();
        if (gameOver == false)
        {
            StartCoroutine(DeductTime());
        }
    }

    private void CheckRemainingTime()
    {
        if(remainingTime <= 0)
        {
            gameOver = true;
            myMinigameController.canInput = false;
            var timeOverText = Instantiate(timeOverTextObject, new Vector3(myCanvas.transform.position.x, myCanvas.transform.position.y, myCanvas.transform.position.z), Quaternion.identity);
            timeOverText.transform.SetParent(myCanvas.transform);
            StartCoroutine(ResultScreen());
        }
    }

    private IEnumerator ResultScreen()
    {
        yield return new WaitForSeconds(2f);
        var resultScreen = Instantiate(resultScreenObject, new Vector3(myCanvas.transform.position.x, myCanvas.transform.position.y, myCanvas.transform.position.z), Quaternion.identity);
        resultScreen.transform.SetParent(myCanvas.transform);
    }
}
