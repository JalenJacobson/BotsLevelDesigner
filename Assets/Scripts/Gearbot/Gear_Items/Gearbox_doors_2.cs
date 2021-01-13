using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gearbox_doors_2 : CDI_Class
{
    public GameObject GateDoors;
    Doors doorsOpen_script;
    public GameObject GateGearObj;
    GateGear2 gategearactivate_script;
    

    void Start()
    {
        doorsOpen_script = GateDoors.GetComponent<Doors>();
        anim = GetComponent<Animator>();
        gategearactivate_script = GateGearObj.GetComponent<GateGear2>();
        // message = "Gate Gear 2 Activated";
    }


    public override void Activate(Text sndMessage)
    {
        // pos = 1; 
        doorsOpen_script.changeGearBox2();
        gategearactivate_script.changeGearBox2();
        anim.Play("GearTrigger");
        sndMessage.text = message;
    }
}
