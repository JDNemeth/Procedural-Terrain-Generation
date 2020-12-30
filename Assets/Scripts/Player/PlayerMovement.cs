using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public Transform groundCheck;
    private float groundDistance = 0.2f;
    public LayerMask enviroment;
    private bool isGrounded = true;


    private float accelerationForce = 300f;
    private float jumpMultiplier = 20f;

    private float maxSpeed = 2f;
    private float playerMaxSpeed = 2f;
    private float sprintMultiplier = 2f;

    // Update is called once per frame
    void FixedUpdate()
    {

        //pohyb po ploche s obmedzenim maximalnej rychlosti pohybu
        //W
        if (Input.GetKey(KeyCode.W) && maxSpeed > rb.velocity.z)
        {
            rb.AddRelativeForce(accelerationForce * new Vector3(0, 0, 1f));
        }


        //A
        if (Input.GetKey(KeyCode.A) && maxSpeed > -rb.velocity.x)
        {
            rb.AddRelativeForce(accelerationForce * new Vector3(-1f, 0, 0));
        }


        //S
        if (Input.GetKey(KeyCode.S) && maxSpeed > -rb.velocity.z)
        {
            rb.AddRelativeForce(accelerationForce * new Vector3(0, 0, -0.7f));
        }


        //D
        if (Input.GetKey(KeyCode.D) && maxSpeed > rb.velocity.x)
        {
            rb.AddRelativeForce(accelerationForce * new Vector3(1f, 0, 0));
        }


        //SPRINT zvysi rychlost pohybu sprintmultiplier

        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = playerMaxSpeed * sprintMultiplier;
            accelerationForce = 600f;
        }
        else
        {
            maxSpeed = 2f;
            accelerationForce = 300f;
        }

        // klesanie
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.AddRelativeForce(accelerationForce * new Vector3(0, -1f, 0));
        }

    }
    private void Update()
    {
        //JUMP

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, enviroment);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(accelerationForce / 5 * new Vector3(0, 1f, 0));
        }
    }
}

