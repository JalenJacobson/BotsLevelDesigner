using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpTriggerCube : MonoBehaviour
{
    public GameObject Pump;
    PumpMove PumpMove_Script;
    
    public bool connected = false;
    public Vector3 connectPos;
    public GameObject touching = null;

    // Start is called before the first frame update
    void Start()
    {
        PumpMove_Script = Pump.GetComponent<PumpMove>();
    }

    void OnTriggerEnter(Collider other)
     {
        if(other.name.Contains("pump"))
        {
            //do stuff    
        }
     }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("pump")){
             touching = other.gameObject;
        }
    }

     void OnTriggerExit(Collider other)
     {
        touching = null;
        if(other.name.Contains("pump"))
        {
           //do stuff     
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
         if(connected == true && Input.GetKeyDown("z"))
         {
             Activate();
         }
     }

     void Activate()
     {
             touching.SendMessage("Activate");
     }

     void Connect()
     {
             connected = !connected;  
             PumpMove_Script.toggleFixPosition();     
     }
     
     void Disconnect()
     {
             connected = false;  
             PumpMove_Script.toggleFixPosition();     
     }
}
