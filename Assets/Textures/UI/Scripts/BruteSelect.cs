using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruteSelect : MonoBehaviour
{
    public GameObject BruteSelectButton;
    public GameObject Brute;
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
       anim.Play("BruteSelectUp");

   }
   public void Down()
   {
       anim.Play("BruteSelectDown");

   }
      public void Select()
   {
       anim.Play("BruteUp");

   }
}
   
