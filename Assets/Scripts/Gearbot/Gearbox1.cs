using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gearbox1 : MonoBehaviour
{
    public Animator anim;
    public float pos = 0;
    public GameObject GateDoors;
    Doors doorsOpen_script;
    public GameObject GateGearObj;
    GateGear gategearactivate_script;
    public AudioSource mySound;

    // Start is called before the first frame update
    void Start()
    
    {
        doorsOpen_script = GateDoors.GetComponent<Doors>();
        anim = GetComponent<Animator>();
        gategearactivate_script = GateGearObj.GetComponent<GateGear>();
        var audioClip = Resources.Load<AudioClip>("GearTrigger");  //Load the AudioClip from the Resources Folder
        mySound.clip = audioClip;  //Assign it as AudioSource's clip
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeGearPos()
    {
        pos = 1; 
        doorsOpen_script.changeGearBox1();
        gategearactivate_script.changeGearBox1();
        anim.Play("GearTrigger");
        mySound.Play();
    }
}
