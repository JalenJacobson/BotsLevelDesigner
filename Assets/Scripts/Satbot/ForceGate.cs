using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceGate : MonoBehaviour
{
   public Animator anim;
   public bool forceGateDownBool;

    // Use this for initialization
    void Start () 
    {
        anim = GetComponent<Animator>();
    }
 
    // Update is called once per frame
    void Update () 
    {
       if(forceGateDownBool)
       {
           forceGateDown();
       } 
    }

    public void forceGateDown()
    {
        anim.Play("ForceGateDown");
    }
}
