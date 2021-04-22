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
        name = "Sat";
        isUp = false;
        isLocalPlayer = false;
        isSelected = false;
        sendState();
 }
 
 // Update is called once per frame
    void Update()
    {
        if(!isUp && isSelected)
        {
            satUp();
        }
    }
    
   public void Up()
   {
       anim.Play("SatSelectUp");
       

   }
   public void Down()
   {
       anim.Play("SatSelectDown");

   }

    public void Select()
    {
        isLocalPlayer = true;
        isSelected = true;
        sendState();
    }

    public void satUp()
    {
        isUp = true;
        anim.Play("SatUp");
    }
}
   
