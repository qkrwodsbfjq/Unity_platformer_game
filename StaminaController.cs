//==========================================
// writer : 노현석.
// file : StaminaController.cs.
// content : 플레이어 피로도 마스터 컨트롤러.
// discript : 플레이어 피로도를 프레임당 갱신, 차감/증가 등 여기서 처리.
//==========================================

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [SerializeField] GameObject StaminaText; //스테미너 텍스트 UI 연결용.

    [SerializeField] public float maxStageStamina; //최대 스테미너, 현재는 미사용값.
    [SerializeField] float IncreaseStaminaPerTick = 1f; //틱당 스테미너 증가량.
    [SerializeField] public float currentStamina = 0; //시작시 스테미너량, 어지간해서는 0.
    [SerializeField] float ticksPerSec = 1f; //초당틱수.

    [SerializeField] public bool PlayerIsRunning = false; //달리기여부.
    [SerializeField] float runningStaminaPerTick = 1f; //달리기 틱당 스테미너 추가 증가량.
    [SerializeField] float runningTicksPerSecond = 1f; //달리기 초당틱수.

    [SerializeField] public bool PlayerIsOnSlowGround = false; //슬로우 장판밟기여부.
    [SerializeField] float slowGroundStaminaPerTick = 1f; //슬로우 장판 틱당 스테미너 추가 증가량.
    [SerializeField] float slowGroundTickPerSec = 1f; //슬로우 장판 초당틱수.

    PlayerController myPlayerController;
    //PlayerStatus myPlayerStatus;
    StatusHandler myPlayerStatus;
    bool calculatingRunningStamina = false;
    bool calculatingSlowGroundStamina = false;
    public bool isCalculatingStaminaPerSecond = true;

    void Start()
    {
        //myPlayerStatus = FindObjectOfType<PlayerStatus>().GetComponent<PlayerStatus>();
        myPlayerStatus = FindObjectOfType<StatusHandler>().GetComponent<StatusHandler>();
        UpdateAttributesFromStatusHandler();
        UpdateStaminaToText();
        myPlayerController = FindObjectOfType<PlayerController>();
        StartCoroutine(IncresaeStaminaPerSecond());
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerIsRunning == true)
        {
            StartCoroutine(RunningStaminaPerSecond());
        }
        if(PlayerIsOnSlowGround == true)
        {
            StartCoroutine(SlowGroundStaminaPerSecond());
        }
    }

    private void FixedUpdate()
    {

    }

    //==========================================

    private void UpdateStaminaToText()
    {
        StaminaText.GetComponent<Text>().text = Convert.ToString(currentStamina);
    }

    //==========================================

    IEnumerator IncresaeStaminaPerSecond()
    {
        currentStamina += IncreaseStaminaPerTick;
        yield return new WaitForSeconds(1/ticksPerSec);
        UpdateStaminaToText();
        StartCoroutine(IncresaeStaminaPerSecond());
    }

    //==========================================

    public void IncresaeStaminaByAmount(float incresae)
    {
        currentStamina += incresae;
        UpdateStaminaToText();
    }

    //==========================================

    IEnumerator RunningStaminaPerSecond()
    {
        if (calculatingRunningStamina == false)
        {
            calculatingRunningStamina = true;
            currentStamina += runningStaminaPerTick;
            yield return new WaitForSeconds(1 / runningTicksPerSecond);
            UpdateStaminaToText();
            calculatingRunningStamina = false;
            if (PlayerIsRunning == true)
            {
                StartCoroutine(RunningStaminaPerSecond());
            }
            else
            {

            }
        }
        else if(calculatingRunningStamina == true)
        {

        }
    }

    //==========================================

    IEnumerator SlowGroundStaminaPerSecond()
    {
        if (calculatingSlowGroundStamina == false)
        {
            calculatingSlowGroundStamina = true;
            currentStamina += slowGroundStaminaPerTick;
            yield return new WaitForSeconds(1 / slowGroundTickPerSec);
            UpdateStaminaToText();
            calculatingSlowGroundStamina = false;
            if(PlayerIsOnSlowGround == true)
            {
                StartCoroutine(SlowGroundStaminaPerSecond());
            }
            else
            {

            }
        }
    }

    private void UpdateAttributesFromStatusHandler()
    {
        IncreaseStaminaPerTick = myPlayerStatus.ReturnIncreaseStaminaPerTick();
        ticksPerSec = myPlayerStatus.ReturnTicksPerSec();
        runningStaminaPerTick = myPlayerStatus.ReturnRunningStaminaPerTick();
        runningTicksPerSecond = myPlayerStatus.ReturnRunningTicksPerSec();
        slowGroundStaminaPerTick = myPlayerStatus.ReturnSlowGroundStaminaPerTick();
        slowGroundTickPerSec = myPlayerStatus.ReturnSlowGroundTicksPerSec();
    }
}
