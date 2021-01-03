using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerConnection_LuzLifter : MonoBehaviour
{
    public GameObject LuzLifter;
    Lifter LuzLifter_script;
    // Start is called before the first frame update
    void Start()
    {
        LuzLifter_script = LuzLifter.GetComponent<Lifter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        LuzLifter_script.Activate();
    }
}
