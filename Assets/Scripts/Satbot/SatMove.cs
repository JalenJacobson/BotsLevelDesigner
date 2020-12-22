using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatMove : Player
{
    

    public GameObject TimerBarSat;
    TimeBarSat TimerBar_Script;
    
    public GameObject Rails;
    SatBotAnim Rails_Script;


    void Start()
    {
        startPos = new Vector3(58f, 1.3f, -230f);
        transform.position = startPos;
        Rails_Script = Rails.GetComponent<SatBotAnim>();
        TimerBar_Script = TimerBarSat.GetComponent<TimeBarSat>();
    }

    public override void Movement()
    {
        float horizontalMove = joystick.Horizontal;
        float verticalMove = joystick.Vertical;

        direction = new Vector3(horizontalMove, 0.0f, verticalMove);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
            Rails_Script.rails();
        }

        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
    }

    void Update()
    {
        if(inWater == true)
        {
            if(touchingAirBubble == true)
            {
                ConsoleMessage.text = "Message: In Water: Breathing";
                TimerBar_Script.enterbluewall();
            }
            else
            {
                ConsoleMessage.text = "Message: In Water: Drowning";
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
        TimerBar_Script.timerStop();
        inWater = false;
        breathRemaining = 5f;
    }
}
