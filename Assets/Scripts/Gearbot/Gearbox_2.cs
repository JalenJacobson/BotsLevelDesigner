using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gearbox_2 : MonoBehaviour
{
    public Animator anim;
    public float pos = 0;
    public GameObject GateDoors;
    Doors doorsOpen_script;

    // Start is called before the first frame update
    void Start()
    {
        doorsOpen_script = GateDoors.GetComponent<Doors>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeGearPos()
    {
        pos = 1; 
        doorsOpen_script.changeGearBox2();
        anim.Play("GearTrigger");
    }
}
