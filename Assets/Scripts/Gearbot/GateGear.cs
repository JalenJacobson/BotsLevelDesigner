using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateGear : MonoBehaviour
{
   public Animator anim;

   public bool gearBox1 = false;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 void Update () {
        if (gearBox1 == true)
        {
            anim.Play("GateGear");

        }
                if (gearBox1 == false)
        {
            anim.Play("Stop");

        }
    }

    public void changeGearBox1()
    {
        print("worked");
        gearBox1 = !gearBox1; 
    }
}
