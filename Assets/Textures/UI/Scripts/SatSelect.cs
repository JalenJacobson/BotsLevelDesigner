using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatSelect : MonoBehaviour
{
    public GameObject SatSelectButton;
    public GameObject SatBot;
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
       anim.Play("SatSelectUp");

   }
   public void Down()
   {
       anim.Play("SatSelectDown");

   }
      public void Sat()
   {
       anim.Play("SatUp");

   }
}
   
