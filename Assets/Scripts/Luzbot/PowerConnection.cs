﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerConnection : CDI_Class
{

    public float pos = 0;
    public GameObject GateDoors;
    Doors doorsOpen_script; 
    public GameObject GateLight1;
    LightOn1 lightactivate_script;
    public GameObject PowerLight1;
    LightOn1 powerlight_script;
    // Start is called before the first frame update
    void Start()
    {
        doorsOpen_script = GateDoors.GetComponent<Doors>();
        lightactivate_script = GateLight1.GetComponent<LightOn1>();
        powerlight_script = PowerLight1.GetComponent<LightOn1>();
        // message = "Gate Power 1 Activated";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Activate(Text sndMessage)
    {
        pos = 1; 
        doorsOpen_script.changePowerConnection1();
        lightactivate_script.changePowerConnection1();
        powerlight_script.changePowerConnection1();
        sndMessage.text = message;
    }
}
