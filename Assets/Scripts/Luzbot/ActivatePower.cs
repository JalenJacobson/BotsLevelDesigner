﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePower : MonoBehaviour
{
   public Animator anim;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 void Update () {
        if (Input.GetKeyDown("z"))
        {
            anim.Play("ActivatePower");

        }
        if (Input.GetKeyUp("z"))
        {
            anim.Play("ReleasePower");

        }
    }
}