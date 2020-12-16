using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMove : Player
{
    // public GameObject TimerBarGear;
    // public TimeBarGear TimerBar_Script;

    void Start()
    {
        startPos = new Vector3(47f, 0.58f, -246f);
        transform.position = startPos;
        TimerBar_Script = TimerBarGear.GetComponent<TimeBarGear>();
    }
}
