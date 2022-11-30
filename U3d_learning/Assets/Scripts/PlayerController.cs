using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;

    public float speedTurn = 1.0f;      // movement speed
    public float speedLook = 1.0f;      // How fast we turn left or right
    public float modifierRun = 2.0f;    // Running is 2 time the walk speed
    public float jumpSpeed = 8.0f;      // Speed to jump
    public float gravity = 10.0f;       // grafity force
    private Vector3 moveDirection = Vector3.zero;

    // -1 Don't invert mouse, 1 Invert Mouse
    [Range(-1f, 1f)]
    public int InvertMouse = -1;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    /*void Update()
    {
        
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical")); //  Input.GetAxis("Horizontal")
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);

        if (controller.isGrounded)
        {
            Vector3 rotateDir = new Vector3(0, Input.GetAxis("Horizontal"), 0);
            moveDirection = transform.TransformDirection(rotateDir);
            controller.transform.Rotate(rotateDir);
        }
    }*/


    private float turner = 1.0f;
    private float looker = 1.0f;
    public float sensitivity = 1f;
    // Update is called once per frame
    void Update()
    {

        // is the controller on the ground?
        if (controller.isGrounded) // This is not needed since we want to be able to change direction mid air
        {
            // Feed moveDirection with input.
            // If I want to strafe instead of turn -> x should be Input.GetAxis("Horizontal")
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            // Multiply it by speed.
            moveDirection *= speedTurn;
            // Are we running (holdng Shift)
            // if (Input.GetButton("left shift"))
            //  moveDirection *= modifierRun;

            // Jumping
            if (Input.GetButton("Jump"))
            {
                // Just for test: turner = Input.GetAxis("Horizontal") * sensitivity;
                moveDirection.y = jumpSpeed;
            }
        }
        //turner = Input.GetAxis("Horizontal") * sensitivity; //  Input.GetAxis("Mouse X")
        turner = 0;
        if (!Input.GetMouseButton(1))    // Holding right mouse button
        {
            // speedLook affects only mouse input
            looker = Input.GetAxis("Mouse Y") * sensitivity * speedLook * this.InvertMouse;
            turner = Input.GetAxis("Mouse X") * sensitivity * speedLook * speedTurn;
        }
        else
            looker = 0;

        if (turner != 0)
        {
            // 
            transform.eulerAngles += new Vector3(0, turner, 0);
        }
        if (looker != 0)
        {
            // 
            transform.eulerAngles += new Vector3(looker, 0, 0);
        }

        // Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        // Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }
}
