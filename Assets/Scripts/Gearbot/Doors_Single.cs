using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors_Single : Doors
{
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    public override void Update () {
        if (gearBox1 == true && powerConnection1 == true)
        {
            anim.Play("Doors");
            print("doors should open");

        }
    }
}
