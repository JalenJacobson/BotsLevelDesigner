using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpSelect : MonoBehaviour
{
    public GameObject PumpSelectButton;
    public GameObject Pump;
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
       anim.Play("PumpSelectUp");

   }
   public void Down()
   {
       anim.Play("PumpSelectDown");

   }
      public void PumpUp()
   {
       anim.Play("PumpUp");

   }
}
   
