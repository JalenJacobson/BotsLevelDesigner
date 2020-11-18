using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzMove : MonoBehaviour
{
    public float moveSpeed = 5;

    public float rotateSpeed = 10;

    public Rigidbody rb;

    public bool toggleSelected;

    private Vector3 direction;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (toggleSelected == true){
            Movement();
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

    public void highGravityEnter ()
    {
        moveSpeed = 1;
    }
    public void highGravityExit ()
    {
        moveSpeed = 5;
    }
}
