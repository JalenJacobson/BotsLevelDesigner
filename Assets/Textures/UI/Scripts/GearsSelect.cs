using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearsSelect : HeroSelectPlayer
{
    public GameObject GearsSelectButton;
    public GameObject Gears;
   public Animator anim;
    // public bool displayBubble = false;
    public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
        name = "Gears";
 }
 
 // Update is called once per frame
    void Update()
    {

    }
    
   public void Up()
   {
       anim.Play("GearsSelectUp");
       

   }
   public void Down()
   {
       anim.Play("GearsSelectDown");

   }
    public void Gear()
    {
        anim.Play("GearUp");
        isLocalPlayer = true;
        isSelected = true;
        sendState();
    }
}
   
