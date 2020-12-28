using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpMove : MonoBehaviour
{
    public float moveSpeed = 7;
    public float rotateSpeed = 10;
    public Rigidbody rb;
    public bool toggleSelected;
    private Vector3 direction;
    public Vector3 startPos;
    public bool fixPosition = false;
    public Joystick joystick;
    public Animator anim;

    void Start()
    {
        startPos = new Vector3(69f, 0.48f, -230f);
        transform.position = startPos;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (toggleSelected == true && fixPosition == false){
            Movement();
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
            anim.Play("PumpWalk");
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
        moveSpeed = 10;
    }
         public void BlueWallOpen()
     {
         anim.Play("BlueWallOpen");
     }
          public void BlueWallClose()
     {
         anim.Play("BlueWallClose");
     }
}
