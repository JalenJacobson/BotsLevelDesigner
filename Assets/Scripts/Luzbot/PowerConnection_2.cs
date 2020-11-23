using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerConnection_2 : MonoBehaviour
{
    public float pos = 0;
    public GameObject GateDoors;
    Doors doorsOpen_script;
    public GameObject GateLight2;
    LightOn2 lightactivate_script;
    public GameObject PowerLight2;
    LightOn2 powerlight_script;
    // Start is called before the first frame update
    void Start()
    {
        doorsOpen_script = GateDoors.GetComponent<Doors>();
        lightactivate_script = GateLight2.GetComponent<LightOn2>();
        powerlight_script = PowerLight2.GetComponent<LightOn2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changePowerConnectionPos()
    {
        pos = 1; 
        doorsOpen_script.changePowerConnection2();
        lightactivate_script.changePowerConnection2();
        powerlight_script.changePowerConnection2();
    }
}
