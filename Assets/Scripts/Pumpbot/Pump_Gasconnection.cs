﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump_Gasconnection : MonoBehaviour
{
    // IDI's
    public GameObject Fire;
    Fire firestop_Script;
    public GameObject Fire_1;
    Fire firestop2_Script;
    public GameObject Fire_2;
    Fire firestop3_Script;



    // Start is called before the first frame update
    public void Start()
    {
        firestop_Script = Fire.GetComponent<Fire>();
        firestop2_Script = Fire_1.GetComponent<Fire>();
        firestop3_Script = Fire_2.GetComponent<Fire>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        firestop_Script.Play();
        firestop2_Script.Play();
        firestop3_Script.Play();

    }
    public void Deactivate()
    {
        firestop_Script.Stop();
        firestop2_Script.Stop();
        firestop3_Script.Stop();

    }
}
