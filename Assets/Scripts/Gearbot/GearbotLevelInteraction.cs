﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearbotLevelInteraction : MonoBehaviour
{
    public GameObject GearBoxTrigger;
    Gearbox1 GearBoxTrigger_script;
    // Start is called before the first frame update
    void Start()
    {
        GearBoxTrigger_script = GearBoxTrigger.GetComponent<Gearbox1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            GearBoxTrigger_script.changeGearPos(1);
        }
        
    }
}