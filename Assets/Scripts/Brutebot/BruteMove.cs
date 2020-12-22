﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteMove : Player
{
    // public float moveSpeed = 5;
    //public float rotateSpeed = 10;
    public GameObject TimerBarBrute;
    TimeBarBrute TimerBar_Script;
    

    void Start()
    {
        moveSpeed = 5f;
        startPos = new Vector3(63.5f, 0.77f, -230f);
        transform.position = startPos;
        TimerBar_Script = TimerBarBrute.GetComponent<TimeBarBrute>();
    }
    public override void highGravityEnter ()
    {
        moveSpeed = 5;
    }
    public override void highGravityExit ()
    {
        moveSpeed = 5;
    }

    void Update()
    {
        if(inWater == true)
        {
            if(touchingAirBubble == true)
            {
                DangerState.text = "Danger State: Short Circuit - Delayed";
                TimerBar_Script.enterbluewall();
            }
            else
            {
                DangerState.text = "Danger State: Short Circuit - Danger";;
                drowning();
            }
            
        }

        if(breathRemaining <= 0f)
        {
            returnToStart();
            waterExit();
        }
    }
    public override void drowning()
    {
        // print("drowning");
        TimerBar_Script.timerStart();
        if (breathRemaining > 0)
        {
            breathRemaining -= Time.deltaTime;
        }
    }
    public override void waterExit()
    {
        DangerState.text = "Danger State: None";
        DangerField.text = "Danger Area: None";
        TimerBar_Script.timerStop();
        inWater = false;
        breathRemaining = 5f;
    }
}