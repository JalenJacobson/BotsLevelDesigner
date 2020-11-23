using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateGear2 : MonoBehaviour
{
   public Animator anim;

   public bool gearBox2 = false;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 void Update () {
        if (gearBox2 == true)
        {
            anim.Play("GateGear");

        }
    }

    public void changeGearBox2()
    {
        print("worked");
        gearBox2 = !gearBox2; 
    }
}
