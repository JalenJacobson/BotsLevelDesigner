using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMove : Player
{
    public GameObject TimerBarGear;
    public TimeBarGear TimerBar_Script;

    void Start()
    {
        startPos = new Vector3(47f, 0.58f, -246f);
        transform.position = startPos;
        TimerBar_Script = TimerBarGear.GetComponent<TimeBarGear>();
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
