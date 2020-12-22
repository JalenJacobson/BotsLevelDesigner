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
        ConsoleMessage.text = "Message: In Water: Breathing";
        breathRemaining = .1f;
        touchingAirBubble = true;
    }
   
    public override void waterExit()
    {
        
        inWater = false;
        breathRemaining = .1f;
    }
}
