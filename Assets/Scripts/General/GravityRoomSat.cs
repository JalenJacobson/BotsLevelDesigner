using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRoomSat : MonoBehaviour


{
     public float slowSpeed = 1;
     private float normSpeed = 7;
     void OnTriggerEnter(UnityEngine.Collider other)
     {
    
         other.GetComponent<SatMove>().moveSpeed = slowSpeed;    
     }
     void OnTriggerExit(UnityEngine.Collider other)
     {
         other.GetComponent<SatMove>().moveSpeed = normSpeed;
     }
 }
 
     
 
     
 