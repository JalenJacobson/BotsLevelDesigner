using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerConnection : MonoBehaviour
{

    public float pos = 0;
    public GameObject GateDoors;
    Doors doorsOpen_script;
    // Start is called before the first frame update
    void Start()
    {
        doorsOpen_script = GateDoors.GetComponent<Doors>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changePowerConnectionPos(float postion)
    {
        pos = postion; 
        doorsOpen_script.changePowerConnection1();
    }
}
