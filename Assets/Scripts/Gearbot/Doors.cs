using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
   public Animator anim;

   public bool gearBox1 = false;
   public bool gearBox2;
   public bool powerConnection1 = false;
   public bool powerConnection2;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 void Update () {
        if (gearBox1 == true && powerConnection1 == true)
        {
            anim.Play("Doors");

        }
    }

    public void changeGearBox1()
    {
        gearBox1 = !gearBox1; 
    }
    
    public void changePowerConnection1()
    {
        powerConnection1 = !powerConnection1; 
    }
}
