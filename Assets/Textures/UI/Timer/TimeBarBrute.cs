﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBarBrute : MonoBehaviour
{
   public GameObject TimerBarBrute;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
    void Update()
    {

    }
    

   public void timerStart()
   {
       anim.Play("Timer");
   }
   public void timerStop()
   {
       anim.Play("NonEnterIdle");
   }
   
}
