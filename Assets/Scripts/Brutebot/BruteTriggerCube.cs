using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteTriggerCube : MonoBehaviour
{
    public bool triggerEntered = false;
    public GameObject touching = null;
    // public GameObject Brute;
    public Vector3 liftPos;

    void Start()
    {
        liftPos = new Vector3(0.0f, 1.0f, 0.0f);
        print(GameObject.FindGameObjectWithTag("Brute").transform.position);
    }

    void OnTriggerEnter(Collider other)
     {
         
     }

    void OnTriggerStay(Collider other)
    {
        // if(other.name.Contains("box")){
             touching = other.gameObject;
            //  Brute = Collider.gameObject;
        // }
    }

     void OnTriggerExit(Collider other)
     {
         
            touching = null;
        
       
     }

     void Update()
     {
         if(touching != null && Input.GetKeyDown("z"))
         {
             // need state "lifting" and function if(lifting = true){do the following thing}
            touching.transform.position = GameObject.FindGameObjectWithTag("Brute").transform.position + liftPos;
         }
     }
}
