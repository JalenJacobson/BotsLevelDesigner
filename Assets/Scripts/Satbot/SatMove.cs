using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatMove : Player
{
    // public float moveSpeed = 7;
    // public float rotateSpeed = 10;
    // public Rigidbody rb;
    // public bool toggleSelected;
    // private Vector3 direction;
    // public bool fixPosition = false;
    // public Vector3 startPos;
    // public float breathRemaining = 5f;
    // public Joystick joystick;
    // public bool touchingAirBubble = false;
    // public bool inWater = false;
    
    public GameObject Rails;
    SatBotAnim Rails_Script;


    void Start()
    {
        startPos = new Vector3(40f, 0.9f, -240f);
        transform.position = startPos;
        Rails_Script = Rails.GetComponent<SatBotAnim>();
    }

    public override void Movement()
    {
        float horizontalMove = joystick.Horizontal;
        float verticalMove = joystick.Vertical;

        direction = new Vector3(horizontalMove, 0.0f, verticalMove);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotateSpeed * Time.deltaTime);
            Rails_Script.rails();
        }

        rb.MovePosition(transform.position + moveSpeed * Time.deltaTime * direction);
    }
}
