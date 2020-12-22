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
        DangerField.text = "Danger Area: None";   
        inWater = false;
        breathRemaining = .1f;
    }
}
