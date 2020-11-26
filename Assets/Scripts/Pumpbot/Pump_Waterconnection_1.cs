using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump_Waterconnection_1 : MonoBehaviour
{
    // IDI's
    public GameObject Water_raise_1;
    WaterRaise waterraise_script;

    public GameObject Water_drain_1;
    WaterDrain waterdrain_script;

    // Start is called before the first frame update
    void Start()
    {
        waterraise_script = Water_raise_1.GetComponent<WaterRaise>();
        waterdrain_script = Water_drain_1.GetComponent<WaterDrain>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        waterraise_script.raiseWater();
        waterdrain_script.drainWater();
    }
}
