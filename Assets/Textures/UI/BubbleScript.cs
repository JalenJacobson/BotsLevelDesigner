using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
   public GameObject ActionBubbles;
   public Animator anim;
    public bool triggerEntered = false;
    public GameObject touching = null;


 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("Gear")){
             touching = other.gameObject;
        }
    }
     void Update()
     {
         if(touching != null)
         {
        anim.Play("ActionBubbleAnim");
         }
    }
}
