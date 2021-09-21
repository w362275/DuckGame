using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController player;
    public float speed;

    float gravity = -19.6f;
    public Transform groundCheck;
    float groundDistance = 0.2f;
    public LayerMask groundMask;
    float yVel;
    bool isGrounded;
    float jumpHeight = 2f;
    float fallVal = -2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);     //Uses layer mask to determine if player is grounded

        if (isGrounded)
        {
            yVel = -2f;         //Resets y-velocity if player is grounded
        }                       //NOTE: if y-velocity is set to 0 then initial falling will appear floaty

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            yVel = Mathf.Sqrt(jumpHeight * fallVal * gravity);      //Applies jump force that scales to gravity and falling rate
        }

        yVel += gravity * Time.deltaTime;       //Adds gravity on to y-velocity afterwards

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 playerMove = transform.right * x + transform.forward * z;       //Gets WASD/arrow key inputs and translates to player movement
        player.Move(playerMove * speed * Time.deltaTime);
        player.Move(Vector3.up * yVel * Time.deltaTime);        //Applies horizontal and vertical movement separately to avoid bugs in movement
    }
}