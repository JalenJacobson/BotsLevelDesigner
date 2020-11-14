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
            anim.Play("Movement");
        }
        if (Input.GetKeyDown("a"))
        {
            anim.Play("Movement");
        }
        if (Input.GetKeyDown("s"))
        {
            anim.Play("Movement");
        }
        if (Input.GetKeyDown("d"))
        {
            anim.Play("Movement");
        if (Input.GetKeyDown("k"))
        {
            anim.Play("Push");
        }
        }
    }
}