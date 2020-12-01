using System.Collections;
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


    //bring in animator and script here. like you have done with other animations

    void Start()
    {
        GearMove_Script = Gears.GetComponent<GearMove>();
        connectPos = new Vector3(0.0f, -0.5f, -1.0f);
        Bubble_Script = ActionBubbles.GetComponent<BubbleScript>();
        Light_Script = ActionLight.GetComponent<BubbleScript>();
        Circle_Script = ActionCircles.GetComponent<BubbleScript>();
    }

    void OnTriggerEnter(Collider other)
     {
    if(other.name.Contains("Gear")){
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();

        }
     }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Gear")){
             touching = other.gameObject;
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

     void Activate()
     {
             touching.SendMessage("changeGearPos");
     }

     void Connect()
     {
             connected = !connected;  
             GearMove_Script.toggleFixPosition();     
     }
     
     void Disconnect()
     {
             connected = false;  
             GearMove_Script.toggleFixPosition();     
     }
}