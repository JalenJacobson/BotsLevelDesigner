using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteTriggerCube : MonoBehaviour
{
    public bool triggerEntered = false;
    public GameObject touching = null;
    public Vector3 liftPos;
    private bool lifting;

    void Start()
    {
        liftPos = new Vector3(0.0f, -0.5f, -1.0f);
        
    }

    void OnTriggerEnter(Collider other)
     {
          
     }

    void OnTriggerStay(Collider other)
    {
        if(other.name == "IdleLuz")
        {
        touching = other.gameObject; 
        }
              
    }

     void OnTriggerExit(Collider other)
     {
         
        // touching = null;
        // lifting = false;
       
     }

     void Update()
     {
         

         if(touching != null && Input.GetKeyDown("z"))
         {
             lift();
         }
         
         if(lifting == true)
        {
            touching.transform.position = transform.TransformPoint(liftPos);
        }
        
     }
    
    void lift() 
    {
        lifting = !lifting;
    }
}
