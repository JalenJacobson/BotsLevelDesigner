using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveBruteW : MonoBehaviour {

   public Animator anim;

 // Use this for initialization
 void Start () {
        anim = GetComponent<Animator>();
 }
 
 // Update is called once per frame
 void Update () {
        if (Input.GetKeyDown("w"))
        {
            anim.Play("BruteWalk");
        }
        if (Input.GetKeyDown("a"))
        {
            anim.Play("BruteWalk");
        }
        if (Input.GetKeyDown("s"))
        {
            anim.Play("BruteWalk");
        }
        if (Input.GetKeyDown("d"))
        {
            anim.Play("BruteWalk");
        }
        if (Input.GetKey("z"))
        {
            anim.Play("Push");
        }
        
    }
}