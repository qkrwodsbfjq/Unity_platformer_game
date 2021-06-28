//==========================================
// writer : 손지.
// file : StatusHandler.cs.
// content : 플레이어 스테이터스 데이터 처리 메소드 모음 스크립트.
// discript : 플레이어 스테이터스 캡슐화를 위한 핸들러 스크립트.
//==========================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class StatusHandler : MonoBehaviour
{
    [SerializeField] public GameObject currentNode;
    [SerializeField] public int[] stageDebuffID;
    [SerializeField] public int[] worldDebuffID;
    [SerializeField] public int enemiesKilled;
    PlayerStatus myPlayerStatus;

    void Awake()
    {
        var obj = FindObjectsOfType<StatusHandler>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        myPlayerStatus = FindObjectOfType<PlayerStatus>();
    }

    public void UpdatePlayerStatusOnWorldMap(GameObject newCurrentNode)
    {
        currentNode = newCurrentNode;
        var currentNodeDebuffID = currentNode.GetComponent<NodeScript>().nodeStageDebuffID;
        if (currentNodeDebuffID.Length != 0)
        {
            for (var i = 0; i < currentNodeDebuffID.Length; i++)
            {
                stageDebuffID[i] = currentNodeDebuffID[i];
            }
            for (var i = currentNodeDebuffID.Length; i < stageDebuffID.Length; i++)
            {
                stageDebuffID[i] = 0;
            }
        }
        else if (currentNodeDebuffID.Length == 0)
        {
            for (var i = 0; i < stageDebuffID.Length; i++)
            {
                stageDebuffID[i] = 0;
            }
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

    public float ReturnMoveSpeed()
    {
        return myPlayerStatus.moveSpeed;
    }

    public float ReturnMaxSpeed()
    {
        return myPlayerStatus.maxSpeed;
    }

    public float ReturnSlowGroundMaxSpeed()
    {
        return myPlayerStatus.slowGroundMaxSpeed;
    }

    public float ReturnRunningExtraSpeed()
    {
        return myPlayerStatus.runningExtreaSpeed;
    }

    public float ReturnJumpForce()
    {
        return myPlayerStatus.jumpForce;
    }

    public float ReturnDoubleJumpForce()
    {
        if (Array.Exists(stageDebuffID, element => element == 10010))
        {
            return myPlayerStatus.doubleJumpForce + 100;
        }
        else
        {
            return myPlayerStatus.doubleJumpForce;
        }
    }

    public float ReturnJumpStamina()
    {
        return myPlayerStatus.jumpStamina;
    }

    public float ReturnDoubleJumpStamina()
    {
        return myPlayerStatus.doubleJumpStamina;
    }

    public float ReturnPlayerDamage()
    {
        return myPlayerStatus.playerDamage;
    }

    public float ReturnPlayerDefense()
    {
        return myPlayerStatus.playerDefense;
    }

    public float ReturnAddedForceUponDamageX()
    {
        return myPlayerStatus.addedForceUponDamageX;
    }

    public float ReturnAddedForceUponDamageY()
    {
        return myPlayerStatus.addedForceUponDamageY;
    }

    public float ReturnSecondsOfRefrainedPlayerControl()
    {
        if (Array.Exists(stageDebuffID, element => element == 10020))
        {
            return 0;
        }
        else
        {
            return myPlayerStatus.secondsOfRefrainedPlayerControl;
        }
    }

    public float ReturnSecondsOfPlayerInvincibility()
    {
        return myPlayerStatus.secondsOfPlayerInvincibility;
    }

    public float ReturnIncreaseStaminaPerTick()
    {
        return myPlayerStatus.IncreaseStaminaPerTick;
    }

    public float ReturnTicksPerSec()
    {
        if (Array.Exists(stageDebuffID, element => element == 10000))
        {
            return myPlayerStatus.ticksPerSec + 20;
        }
        else
        {
            return myPlayerStatus.ticksPerSec;
        }
    }

    public float ReturnRunningStaminaPerTick()
    {
        return myPlayerStatus.RunningStaminaPerTick;
    }

    public float ReturnRunningTicksPerSec()
    {
        return myPlayerStatus.RunningTicksPerSec;
    }

    public float ReturnSlowGroundStaminaPerTick()
    {
        return myPlayerStatus.SlowGroundStaminaPerTick;
    }

    public float ReturnSlowGroundTicksPerSec()
    {
        return myPlayerStatus.SlowGroundTicksPerSec;
    }

    public float ReturnPoint()
    {
        return myPlayerStatus.point;
    }

    public void SetPoint(float point)
    {
        myPlayerStatus.point += point;
    }

}