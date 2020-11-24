﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteTriggerCube : MonoBehaviour
{
    public Animator anim;
    public bool triggerEntered = false;
    public GameObject touching = null;
    public bool canLift = false;
    public Vector3 liftPos;
    public bool lifting;

    void Start()
    {
        liftPos = new Vector3(0.0f, -0.5f, -1.0f);
        anim = GetComponent<Animator>();
        
    }

    void OnTriggerEnter(Collider other)
     {
          canLift = true;
        
     }

    void OnTriggerStay(Collider other)
    {
        var characterName = other.name;
        if(characterName == "IdleLuz" || characterName == "Gears" || characterName == "SatBot" || characterName == "Pump" || characterName.Contains("Box"))
        {
            if(touching == null)
            {
                touching = other.gameObject; 
            }
            
        }
              
    }

     void OnTriggerExit(Collider other)
     {
        if(lifting == false)
        {
            canLift = false;
            touching = null;
        }
        
        // lifting = false;
       
     }

     void Update()
     {
         if(touching != null && Input.GetKeyDown("z") && canLift == true)
         {
             lift();
         }
         
         if(lifting == true)
        {
            anim.Play("Push");
            touching.transform.position = transform.TransformPoint(liftPos);
        }
        
     }
    
    void lift() 
    {
        lifting = !lifting;
    }
}