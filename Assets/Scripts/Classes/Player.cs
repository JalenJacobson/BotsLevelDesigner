﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 7;
    public float rotateSpeed = 10;
    public Rigidbody rb;
    public bool toggleSelected;
    private Vector3 direction;
    public bool fixPosition = false;
    public Vector3 startPos;
    public float breathRemaining = 5f;
    public bool touchingAirBubble = false;
    public bool inWater = false;

    public Joystick joystick;

    void Start()
    {
        startPos = new Vector3(47f, 1.29f, -246f);
        transform.position = startPos;
    }

    void FixedUpdate()
    {
        if (toggleSelected == true && fixPosition == false){
            Movement();
        }
    }
    void Update()
    {
        if(inWater == true && touchingAirBubble == false)
        {
            drowning();
        }

        if(breathRemaining <= 0f)
        {
            returnToStart();
            waterExit();
        }
    }

    void Movement()
    {
        float horizontalMove = joystick.Horizontal;
        float verticalMove = joystick.Vertical;

        direction = new Vector3(horizontalMove, 0.0f, verticalMove);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
        }

        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
    }

    public void toggleSelectedState (){
        toggleSelected = !toggleSelected;
    }

    public void toggleFixPosition()
    {
        print("togglefixpos");
        fixPosition = !fixPosition;
    }

    public virtual void highGravityEnter ()
    {
        moveSpeed = 1;
    }
    public virtual void highGravityExit ()
    {
        moveSpeed = 7;
    }
    public void drowning()
    {
        if (breathRemaining > 0)
        {
            breathRemaining -= Time.deltaTime;
        }
    }
    public void waterEnter()
    {
        inWater = true;
    }
    void pumpAirBubbleEnter()
    {
        touchingAirBubble = true;
    }
    void pumpAirBubbleExit()
    {
        touchingAirBubble = false;
    }

    void returnToStart()
    {
        transform.position = startPos;
    }
    public void waterExit()
    {
        inWater = false;
        breathRemaining = 5f;
    }
}