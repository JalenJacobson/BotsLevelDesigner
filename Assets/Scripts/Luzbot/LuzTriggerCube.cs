using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzTriggerCube : MonoBehaviour
{

    public GameObject IdleLuz;
    LuzMove LuzMove_Script;
    
    public bool triggerEntered = false;
    public bool connected = false;
    public Vector3 connectPos;
    public GameObject touching = null;

    public GameObject ActionPower;
    ActionPowerScript Bubble_Script;
    public GameObject ActionLight;
    ActionPowerScript Light_Script;
    public GameObject ActionCircles;
    ActionPowerScript Circle_Script;

    void Start()
    {
        LuzMove_Script = IdleLuz.GetComponent<LuzMove>();
        Bubble_Script = ActionPower.GetComponent<ActionPowerScript>();
        Light_Script = ActionLight.GetComponent<ActionPowerScript>();
        Circle_Script = ActionCircles.GetComponent<ActionPowerScript>();
    }

    void OnTriggerEnter(Collider other)
     {
        if(other.name.Contains("luz"))
        {
            Bubble_Script.actionBubbleStart();
            Light_Script.actionBubbleStart();
            Circle_Script.actionBubbleStart();    
        }
     }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("luz")){
             touching = other.gameObject;
        }
    }

     void OnTriggerExit(Collider other)
     {
            touching = null;
        if(other.name.Contains("luz")){
             
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
             touching.SendMessage("changePowerConnectionPos");
     }

     void Connect()
     {
             connected = !connected;  
             LuzMove_Script.toggleFixPosition();     
     }
     
     void Disconnect()
     {
             connected = false;  
             LuzMove_Script.toggleFixPosition();     
     }
}
