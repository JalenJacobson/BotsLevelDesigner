using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteMove : Player
{
    // public float moveSpeed = 5;
    //public float rotateSpeed = 10;
    

    void Start()
    {
        moveSpeed = 5f;
        startPos = new Vector3(41f, 0.18f, -248f);
        transform.position = startPos;
        // TimerBar_Script = TimerBarBrute.GetComponent<TimeBarBrute>();
    }
    public override void highGravityEnter ()
    {
        moveSpeed = 5;
    }
    public override void highGravityExit ()
    {
        moveSpeed = 5;
    }
}