using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb; 
    public float movementForce = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        print("move");
        if( Input.GetKey("l")){
            rb.AddForce(movementForce * Time.deltaTime , 0,0);
        }
        if( Input.GetKey("i")){
            rb.AddForce(0, 0, movementForce * Time.deltaTime );
        }
        if( Input.GetKey("j")){
            rb.AddForce(-movementForce * Time.deltaTime , 0,0);
        }
        if( Input.GetKey("k")){
            rb.AddForce(0, 0, -movementForce * Time.deltaTime );
        }
            
       
    }
}
