﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSelect : MonoBehaviour
{
    public GameObject BotSelectButton;
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
    

   public void Stop()
   {
       anim.Play("BotSelectDown");

   }
}
   
