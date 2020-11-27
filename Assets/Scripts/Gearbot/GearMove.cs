using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMove : MonoBehaviour
{
    public float moveSpeed = 7;
    public float rotateSpeed = 10;
    public Rigidbody rb;
    public bool toggleSelected;
    private Vector3 direction;
    public bool fixPosition = false;
    public Vector3 startPos;
    public float timeRemaining = 5f;

    void Start()
    {
        startPos = new Vector3(38f, 1.29f, 1.8f);
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
        if(timeRemaining <= 0f)
        {
            returnToStart();
            resetBreath();
        }
    }

    void Movement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");

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

    public void highGravityEnter ()
    {
        moveSpeed = 1;
    }
    public void highGravityExit ()
    {
        moveSpeed = 7;
    }
    public void waterEnter()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }
    void returnToStart()
    {
        transform.position = startPos;
    }
    public void resetBreath()
    {
        timeRemaining = 5f;
    }
}
