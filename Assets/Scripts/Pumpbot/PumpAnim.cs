using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpAnim : MonoBehaviour
{
   public Animator anim;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 void Update () {
        if (Input.GetKey("w"))
        {
            anim.Play("PumpWalk");
        }
        if (Input.GetKey("a"))
        {
            anim.Play("PumpWalk");
        }
        if (Input.GetKey("s"))
        {
            anim.Play("PumpWalk");
        }
        if (Input.GetKey("d"))
        {
            anim.Play("PumpWalk");
        }

    }
}