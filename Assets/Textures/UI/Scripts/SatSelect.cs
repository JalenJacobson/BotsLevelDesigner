using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatSelect : HeroSelectPlayer
{
    public GameObject SatSelectButton;
    public GameObject SatBot;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        isLocalPlayer = true;
        isSelected = true;
        name = "Sat";
 }
 
 // Update is called once per frame
    void Update()
    {

    }
    
   public void Up()
   {
       anim.Play("SatSelectUp");
       

   }
   public void Down()
   {
       anim.Play("SatSelectDown");

   }
    public void Sat()
    {
        anim.Play("SatUp");
        isLocalPlayer = true;
        isSelected = true;
        sendState();
    }
}
   
