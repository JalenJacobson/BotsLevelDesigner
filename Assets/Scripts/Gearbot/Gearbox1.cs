﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gearbox1 : MonoBehaviour
{
    public Animator anim;
    public float pos = 0;
    public GameObject GateDoors;
    Doors doorsOpen_script;
    public GameObject GateGearObj;
    GateGear gategearactivate_script;

    // Start is called before the first frame update
    void Start()
    
    {
        doorsOpen_script = GateDoors.GetComponent<Doors>();
        anim = GetComponent<Animator>();
        gategearactivate_script = GateGearObj.GetComponent<GateGear>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeGearPos(float postion)
    {
        pos = postion; 
        doorsOpen_script.changeGearBox1();
        gategearactivate_script.changeGearBox1();
        anim.Play("GearTrigger");
    }
}
