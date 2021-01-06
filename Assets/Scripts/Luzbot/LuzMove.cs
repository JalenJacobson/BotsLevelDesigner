﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzMove : Player
{

    void Start()
    {
        breathRemaining = .1f;
        startPos = new Vector3(52.5f, 0.58f, -230f);
        transform.position = startPos;
        orangeGravityField = new Color(0.689f, 0.452f, 0.016f, 1.000f);
        greenConsole = new Color(0.0f, 1.0f, 0.1144f, 1.0f);
        blueCircuitField = new Color(0.06799023f, 0.5f, 0.8584906f, 1.0f);
    }

     void Update()
    {
        if(inWater == true)
        {
            if(touchingAirBubble == true)
            {
                // DangerState.text = "Danger State: Short Circuit - Delayed";
                setConsoleDangerField("Circuit Field", blueCircuitField);
                setConsoleDangerState("Short Circuit - Delayed", greenConsole);
            }
            else
            {
                // DangerState.text = "Danger State: Short Circuit - Danger";
                setConsoleDangerField("Circuit Field", blueCircuitField);
                setConsoleDangerState("Short Circuit - Danger", redDanger);
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
        if (breathRemaining > 0)
        {
            breathRemaining -= Time.deltaTime;
        }
    }
public virtual void pumpAirBubbleEnter()
    {
        breathRemaining = .1f;
        touchingAirBubble = true;
    }

    public override void waterExit()
    {
        // DangerState.text = "Danger State: None";
        // DangerField.text = "Danger Area: None";
        resetConsoleDangerField();
        resetConsoleDangerState();
        inWater = false;
        breathRemaining = .1f;
    }
}
