using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 7;
    public float rotateSpeed = 10;
    public Rigidbody rb;
    public bool toggleSelected;
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
        print(orangeGravityField);
        moveSpeed = 1;
        setConsoleDangerField("Gravity Filed", orangeGravityField);
        setConsoleDangerState("Speed Reduced", orangeGravityField);
        // DangerState.text = "Speed Reduced";
    }
    public virtual void highGravityExit ()
    {
        moveSpeed = 7;
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
