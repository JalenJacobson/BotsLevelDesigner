﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using System;
using System.Text;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 10;
    public Rigidbody rb;
    public bool toggleSelected;

    public bool blueWall;
    public bool isLocalPlayer;
    public bool isBeingCarried;
    public string name;
    public GameObject Brute;
    public Vector3 liftPos;
    public Vector3 direction;
    public bool fixPosition = false;
    public Vector3 startPos;
    public float breathRemaining = 5f;
    public bool touchingAirBubble = false;
    public bool inWater = false;
    public Text DangerField;
    public Text DangerState;
    public Color orangeGravityField;
    public Color greenConsole;
    public Color blueCircuitField;
    public Color redDanger;

    private static readonly HttpClient client = new HttpClient();

    public Joystick joystick;

    void Start()
    {
        startPos = new Vector3(47f, 1.29f, -246f);
        transform.position = startPos;
    }

    void FixedUpdate()
    {
        if (isLocalPlayer == true && fixPosition == false){
            Movement();
        }
    }
    void Update()
    {
        if(inWater == true)
        {
            if(touchingAirBubble == true)
            {
                
            }
            else
            {
                drowning();
            }
            
        }

        if(breathRemaining <= 0f)
        {
            returnToStart();
            waterExit();
        }
    }

    public virtual void Movement()
    {
        float horizontalMove = joystick.Horizontal;
        float verticalMove = joystick.Vertical;

        direction = new Vector3(horizontalMove, 0.0f, verticalMove);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
        }

        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);

        sendPos();
    }

    async public void sendPos()
    {
        // var currentPos = transform.position.Round(2);
        // time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        var robot = new RobotPosition();
        robot.name = name;
        robot.position = new Position();
        robot.position.position = transform.position;
        robot.position.rotation = transform.rotation;
    
        string json = JsonUtility.ToJson(robot);

        var response = await client.PostAsync("http://74.207.254.19:7000/position/save", new StringContent(json, Encoding.UTF8, "application/json"));
        // var response = await client.PostAsync("http://localhost:7000/position/save", new StringContent(json, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();
    }

    public async void sendState()
    {
        // time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        var robot = new RobotState();
        robot.name = name;
        robot.state = new State();
        robot.state.isBeingCarried = isBeingCarried;
        robot.state.toggleSelected = toggleSelected;
        print("THIS SHOULD OPEN WALL " + blueWall);
        robot.state.blueWall = blueWall;
    
        string json = JsonUtility.ToJson(robot);

        var response = await client.PostAsync("http://74.207.254.19:7000/state/save", new StringContent(json, Encoding.UTF8, "application/json"));
        // var response = await client.PostAsync("http://localhost:7000/state/save", new StringContent(json, Encoding.UTF8, "application/json"));

        var responseString = await response.Content.ReadAsStringAsync();
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
        setConsoleDangerField("Gravity Field", orangeGravityField);
        setConsoleDangerState("Speed Reduced", orangeGravityField);
        // DangerState.text = "Speed Reduced";
    }
    public virtual void highGravityExit ()
    {
        moveSpeed = 10;
        resetConsoleDangerField();
        resetConsoleDangerState();
        // DangerState.text = "None";
    }
    public virtual void drowning()
    {
        // print("drowning");
        // TimerBar_Script.timerStart();
        if (breathRemaining > 0)
        {
            breathRemaining -= Time.deltaTime;
        }
    }
    public void waterEnter()
    {
        // DangerField.text = "Circuit Field";
        setConsoleDangerField("Circuit Field", blueCircuitField);
        inWater = true;
    }
    public virtual void pumpAirBubbleEnter()
    {
        breathRemaining = 5f;
        touchingAirBubble = true;
    }
    void pumpAirBubbleExit()
    {
        touchingAirBubble = false;
    }

    public void returnToStart()
    {
        transform.position = startPos;
    }
    public virtual void waterExit()
    {
        DangerField.text = "None";
        // TimerBar_Script.timerStop();
        inWater = false;
        breathRemaining = 5f;
    }

    public void setConsoleDangerField(string text, Color color)
    {
        DangerField.text = text;
        DangerField.color = color;
    }
    public void resetConsoleDangerField()
    {
        DangerField.text = "None";
        DangerField.color = greenConsole;
    }
    public void setConsoleDangerState(string text, Color color)
    {
        DangerState.text = text;
        DangerState.color = color;
    }
    public void resetConsoleDangerState()
    {
        DangerState.text = "None";
        DangerState.color = greenConsole;
    }
}


[Serializable]
public class Position
{
    public Vector3 position;
    public Quaternion rotation;
}

[Serializable]
public class RobotPosition
{
    public string name;
    public Position position;
}

[Serializable]
public class RobotState
{
    public string name;
    public State state;
}

[Serializable]
public class State
{
    // public bool isLocalPlayer;
    public bool blueWall;
    public bool isBeingCarried;
    public bool toggleSelected;
}