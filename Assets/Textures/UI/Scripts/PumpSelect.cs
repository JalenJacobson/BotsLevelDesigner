using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpSelect : HeroSelectPlayer
{
    public GameObject PumpSelectButton;
    public GameObject Pump;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        name = "Pump";
 }
 
 // Update is called once per frame
    void Update()
    {

    }
    
   public void Up()
   {
       anim.Play("PumpSelectUp");
       

   }
   public void Down()
   {
       anim.Play("PumpSelectDown");

   }
    public void PumpUp()
    {
        anim.Play("PumpUp");
        isLocalPlayer = true;
        isSelected = true;
        sendState();
    }
}
   
