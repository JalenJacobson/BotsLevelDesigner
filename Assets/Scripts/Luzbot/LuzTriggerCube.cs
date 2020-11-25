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

    void Start()
    {
        LuzMove_Script = IdleLuz.GetComponent<LuzMove>();
    }

    void OnTriggerEnter(Collider other)
     {
         
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
             connected = true;  
             LuzMove_Script.toggleFixPosition();     
     }
     
     void Disconnect()
     {
             connected = false;  
             LuzMove_Script.toggleFixPosition();     
     }
}
