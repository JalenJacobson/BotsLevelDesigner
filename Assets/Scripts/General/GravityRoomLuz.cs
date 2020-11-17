using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRoomLuz : MonoBehaviour


{
     public float slowSpeed = 1;
     private float normSpeed = 7;
     void OnTriggerEnter(UnityEngine.Collider player)
     {
    
         player.GetComponent<LuzMove>().moveSpeed = slowSpeed;    
     }
     void OnTriggerExit(UnityEngine.Collider player)
     {
         player.GetComponent<LuzMove>().moveSpeed = normSpeed;
     }
 }
 
     
 
     
 