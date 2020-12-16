﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearTriggerCube : MonoBehaviour
{
    public GameObject Gears;
    GearMove GearMove_Script;

    public bool triggerEntered = false;
    public bool connected = false;
    public GameObject touching = null;
    public Vector3 connectPos;

    public GameObject ActionBubbles;
    BubbleScript Bubble_Script;
    public GameObject ActionLight;
    BubbleScript Light_Script;
    public GameObject ActionCircles;
    BubbleScript Circle_Script;
    public GameObject Activate1;
    Act1Script Act1Button_Script;
    public GameObject Cancel;
    CancelButton CancelButton_Script;
    // public GameObject TimerBarGear;
    // TimeBarGear TimerBar_Script;


    //bring in animator and script here. like you have done with other animations

    void Start()
    {
        GearMove_Script = Gears.GetComponent<GearMove>();
        connectPos = new Vector3(0.0f, -0.5f, -1.0f);
        Bubble_Script = ActionBubbles.GetComponent<BubbleScript>();
        Light_Script = ActionLight.GetComponent<BubbleScript>();
        Circle_Script = ActionCircles.GetComponent<BubbleScript>();
        Act1Button_Script = Activate1.GetComponent<Act1Script>();
        CancelButton_Script = Cancel.GetComponent<CancelButton>();
        // TimerBar_Script = TimerBarGear.GetComponent<TimeBarGear>();
    }

    void OnTriggerEnter(Collider other)
     {
    if(other.name.Contains("Gear")){
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();

        }
                if(other.name.Contains("Water"))
        {
            // TimerBar_Script.timerStart();
        }

     }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Gear")){
             touching = other.gameObject;
        }
        if(other.name.Contains("BlueWall"))
        {
            // TimerBar_Script.enterbluewall();
        }
    }

     void OnTriggerExit(Collider other)
     {
            if(other.name.Contains("Gear")){
            touching = null;
            Bubble_Script.actionBubbleStop();
            Light_Script.actionBubbleStop();
            Circle_Script.actionBubbleStop();
        }
            if(other.name.Contains("Water"))
        {
            // TimerBar_Script.timerStop();
        }
            if(other.name.Contains("BlueWall"))
        {
            // TimerBar_Script.exitbluewall();
        }
        
     }

     void Update()
     {
         if(touching != null && Input.GetKeyDown("c"))
         {
             Connect();
         }
         if(touching != null && Input.GetKeyDown("d"))
         {
             Disconnect();
         }

        //  if(connected == true)
        //  {
        //      GearMove_Script.fixPosition = true;
        //  }

         if(connected == true && Input.GetKeyDown("z"))
         {
             Activate();
         }
     }

     public void Activate()
     {
             touching.SendMessage("changeGearPos");
     }

     public void Connect()
     {
             connected = !connected;  
             GearMove_Script.toggleFixPosition();
            Bubble_Script.actionBubbleStop();
            Act1Button_Script.activate1();
            CancelButton_Script.CancelStart();     
     }
     
     public void Disconnect()
     {
             connected = false;  
             GearMove_Script.toggleFixPosition();
            Light_Script.actionBubbleStop();
            Circle_Script.actionBubbleStop();
            Act1Button_Script.activate1Stop();
            CancelButton_Script.CancelStop();       
     }
}