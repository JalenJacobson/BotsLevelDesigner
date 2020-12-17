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
        startPos = new Vector3(41f, 0.18f, -248f);
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
                TimerBar_Script.enterbluewall();
            }
            else
            {
                drowning();
            }
            
        }

        if(breathRemaining <= 0f)
        {
            returnToStart();
            waterExit();
        }
    }
    public void drowning()
    {
        // print("drowning");
        TimerBar_Script.timerStart();
        if (breathRemaining > 0)
        {
            breathRemaining -= Time.deltaTime;
        }
    }
    public virtual void waterExit()
    {
        TimerBar_Script.timerStop();
        inWater = false;
        breathRemaining = 5f;
    }
}