using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
   public GameObject ActionBubbles;
   public Animator anim;
    public bool displayBubble = false;
    public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
    void Update()
    {
        if(displayBubble == true)
        {
            anim.Play("ActionBubbleAnim");
        }
    }
    

   void toggleDisplayAction()
   {
       displayBubble = !displayBubble;
   }

   
}
