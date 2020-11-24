using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatTriggerCube : MonoBehaviour
{
   public bool triggerEntered = false;
    public GameObject touching = null;

    void OnTriggerEnter(Collider other)
     {
         
     }

    void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Gear")){
             touching = other.gameObject;
        }
    }

     void OnTriggerExit(Collider other)
     {
         
            touching = null;
        
       
     }

     void Update()
     {
         if(touching != null && Input.GetKeyDown("z"))
         {
             touching.SendMessage("changeGearPos");
         }
     }
}
