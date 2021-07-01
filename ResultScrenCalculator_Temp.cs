using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScrenCalculator_Temp : MonoBehaviour
{
    [SerializeField] GameObject scoreTextObject;

    MinigameScoreController myMinigameScoreController;

    private void Awake()
    {
        myMinigameScoreController = FindObjectOfType<MinigameScoreController>().GetComponent<MinigameScoreController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreTextObject.GetComponent<TextMeshProUGUI>().text = Convert.ToString(myMinigameScoreController.currentScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetStage()
    {
        SceneManager.LoadScene("AlbaTestScene");
    }
}
