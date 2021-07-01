using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameScoreController : MonoBehaviour
{
    [SerializeField] public float currentScore = 0;
    [SerializeField] float scorePerAnswer = 100f;
    [SerializeField] float scorePerWrong = -200f;

    [SerializeField] GameObject scoreTextObject;

    TextMeshProUGUI myScoreText;

    private void Awake()
    {
        myScoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreborad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncresaeScore()
    {
        currentScore += scorePerAnswer;
        UpdateScoreborad();
    }

    public void DecreaseScore()
    {
        currentScore += scorePerWrong;
        UpdateScoreborad();
    }

    public void UpdateScoreborad()
    {
        myScoreText.text = Convert.ToString(currentScore);
    }
}
