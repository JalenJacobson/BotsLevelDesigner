using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRoom : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
     {
         print(other.name);
         if(other.name != "Brute" || other.name != "polySurface63" || other.name != "polySurface57"){
             other.gameObject.SendMessage("highGravityEnter"); 
         }
            
     }
     void OnTriggerExit(Collider other)
     {
        print(other.name);
        if(other.name != "Brute" || other.name != "polySurface63" || other.name != "polySurface57"){
            other.gameObject.SendMessage("highGravityExit");
        }        
     }
 }
 
     
 
     
 