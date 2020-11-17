﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzbotLevelInteraction : MonoBehaviour
{

    public bool toggleSelected = false;
    public GameObject level_luz_powerconnection_1;
    PowerConnection powerConnectionTrigger_script;
    // Start is called before the first frame update
    void Start()
    {
        powerConnectionTrigger_script = level_luz_powerconnection_1.GetComponent<PowerConnection>();
    }

    // Update is called once per frame
    void Update()
    {
        if(toggleSelected == true){
            if (Input.GetKeyDown("z"))
                {
                    powerConnectionTrigger_script.changePowerConnectionPos(1);
                }
        }
        
        
    }

    public void toggleSelectedState (){
        toggleSelected = !toggleSelected;
    }
}
