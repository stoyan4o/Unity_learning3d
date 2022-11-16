using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

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


   // public float speed = 6.0F;
    //public float jumpSpeed = 8.0F;
    //public float gravity = 20.0F;
    //private Vector3 moveDirection = Vector3.zero;
    private float turner = 1;
    private float looker = 1;
    public float sensitivity = 10f;
    // Update is called once per frame
    void Update()
    {
       controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical")); // Input.GetAxis("Horizontal")
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
            { 
                //turner = Input.GetAxis("Horizontal") * sensitivity;
                 moveDirection.y = jumpSpeed;
            }
                

        }
         turner = Input.GetAxis("Horizontal") * sensitivity; //  Input.GetAxis("Mouse X")


        if (Input.GetMouseButton(1))
        {
            looker = -Input.GetAxis("Mouse Y") * sensitivity;
            turner += Input.GetAxis("Mouse X") * sensitivity;
        }
        else
            looker = 0;

        if (turner != 0)
        {
            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(0, turner, 0);
        }
        if (looker != 0)
        {
            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(looker, 0, 0);
        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }
}
