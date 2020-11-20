using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzTriggerCube : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
     {
         print(other.name.Contains("Sat"));
         if(other.name.Contains("Sat")){
             print("it worked");
         print(other.name);
         }
         
     }
     void OnTriggerExit(Collider other)
     {
       
     }
}
