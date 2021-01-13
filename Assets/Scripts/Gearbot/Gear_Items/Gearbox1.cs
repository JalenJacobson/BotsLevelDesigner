﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gearbox1 : CDI_Class
{
    public GameObject GateDoors;
    Doors doorsOpen_script;
    public GameObject GateGearObj;
    GateGear gategearactivate_script;
    

    void Start()
    {
        doorsOpen_script = GateDoors.GetComponent<Doors>();
        anim = GetComponent<Animator>();
        gategearactivate_script = GateGearObj.GetComponent<GateGear>();
        // message = "Gate Gear 1 Activated";
    }


    public override void Activate(Text sndMessage)
    {
        // pos = 1; 
        doorsOpen_script.changeGearBox1();
        gategearactivate_script.changeGearBox1();
        anim.Play("GearTrigger");
        sndMessage.text = message;
    }
}
