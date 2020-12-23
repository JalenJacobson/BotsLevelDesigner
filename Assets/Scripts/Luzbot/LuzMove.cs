using System.Collections;
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
        blueCircuitField = new Color(0.06799023f, 0.0f, 0.8584906f, 1.0f);
    }

    public override void pumpAirBubbleEnter()
    {
        DangerState.text = "Danger State: Short Circuit - Delayed";
        breathRemaining = .1f;
        touchingAirBubble = true;
    }
   
    public override void waterExit()
    {
        DangerState.text = "Danger State: None";
        // DangerField.text = "Danger Area: None"; 
        resetConsoleDangerField();  
        inWater = false;
        breathRemaining = .1f;
    }
}
