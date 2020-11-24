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

    //bring in animator and script here. like you have done with other animations

    void Start()
    {
        GearMove_Script = Gears.GetComponent<GearMove>();
        connectPos = new Vector3(0.0f, -0.5f, -1.0f);
        Bubble_Script = ActionBubbles.GetComponent<BubbleScript>();
    }

    void OnTriggerEnter(Collider other)
     {
         
     }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Gear")){
             touching = other.gameObject;
             Bubble_Script.actionBubbleStart();
        }
    }

     void OnTriggerExit(Collider other)
     {
            touching = null;
            Bubble_Script.actionBubbleStop();
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
             connected = true;  
             GearMove_Script.toggleFixPosition();     
     }
     
     void Disconnect()
     {
             connected = false;  
             GearMove_Script.toggleFixPosition();     
     }
}