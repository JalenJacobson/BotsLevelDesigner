﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzSelect : MonoBehaviour
{
    public GameObject LuzSelectButton;
    public GameObject Luz;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
    void Update()
    {

    }
    
   public void Up()
   {
       anim.Play("LuzSelectUp");

   }
   public void Down()
   {
       anim.Play("LuzSelectDown");

   }
      public void LuzUp()
   {
       anim.Play("LuzUp");

   }
}
   