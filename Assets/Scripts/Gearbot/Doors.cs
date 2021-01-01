using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
   public Animator anim;

   public bool gearBox1 = false;
   public bool gearBox2;
   public bool powerConnection1 = false;
   public bool powerConnection2 = false;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 public virtual void Update () {
        if (gearBox1 == true && gearBox2 == true && powerConnection1 == true && powerConnection2 == true)
        {
            anim.Play("Doors");

        }
    }

    public void changeGearBox1()
    {
        print("worked");
        gearBox1 = !gearBox1; 
    }
    public void changeGearBox2()
    {
        print("worked");
        gearBox2 = !gearBox2; 
    }
    
    public void changePowerConnection1()
    {
        powerConnection1 = !powerConnection1; 
    }
    public void changePowerConnection2()
    {
        powerConnection2 = !powerConnection2; 
    }
}
