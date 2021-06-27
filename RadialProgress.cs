//==========================================
// writer : Jae Yoon Park.
// file : RadialProgress.cs.
// content : circle progress bar control.
// descript : .
//==========================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
    public Text ProgressIndicator;
    public Image LoadingBar;
    float currentValue;
    public float speed;

    public bool gameIsInProgress = false;

    void Start()
    {

    }

    void Update()
    {
        if (gameIsInProgress == true)
        {
            if (60 - currentValue > 0)
            {
                currentValue += speed * Time.deltaTime;
                ProgressIndicator.text = (60 - (int)currentValue).ToString();
                if (60 - currentValue <= 10)
                {
                    LoadingBar.color = new Color(1, 0, 0, 1);
                    if (currentValue % 1 < 0.5) { 
                        ProgressIndicator.color = new Color(1, 0, 0, 1);
                        ProgressIndicator.fontSize = 60;
                    }
                    else {
                        ProgressIndicator.color = new Color(1, 0, 0, 1);
                        ProgressIndicator.fontSize = 70;
                    }
                }
            }
            else
            {
                ProgressIndicator.text = "0";
            }

            LoadingBar.fillAmount = (60 - currentValue) / 60;
        }
    }
}