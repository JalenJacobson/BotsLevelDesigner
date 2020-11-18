using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanInteract_Luz : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
     {
         print(other.name);
         if(other.name == "IdleLuz"){
             other.gameObject.SendMessage("canInteractEnter"); 
         } 
         else{
             print("not luz");
         }
            
     }
     void OnTriggerExit(Collider other)
     {
        print(other.name);
        if(other.name == "Gears"){
            other.gameObject.SendMessage("canInteractExit");
        }        
        else{
            print("not luz");
        }
     }
}
