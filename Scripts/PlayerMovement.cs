using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController player;      //Base variables for horizontal player movement
    public float speed;

    public float health = 500f;
    float maxHealth = 500f;
    float regenDelay = 5f;                  //Variables for managing player's health and corresponding UI elements
    float regenRate = 0.2f;
    float regenDelayPassed = 5f;
    public Slider healthBar;

    public Transform spawnPoint;
    Renderer playerRender;                  //Variables for managing player death and respawn
    public Renderer gunRender, scopeRender;
    float deathDelay = 3f;
    bool isDead = false;

    float gravity = -19.6f;
    public Transform groundCheck;
    float groundDistance = 0.2f;
    public LayerMask groundMask;            //Variables for player jumping
    float yVel;
    bool isGrounded;
    float jumpHeight = 2f;
    float fallVal = -2f;

    // Start is called before the first frame update
    void Start()
    {
        playerRender = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)        //Will only move player if they are not dead
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

            MovePlayer();       //Calls function for moving player every frame
        }
        
        ManageHealth();
        healthBar.value = health;       //Sets slider scale to equal health value
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health -= 30f;
            regenDelayPassed = 0f;      //Decrements health and resets delay when hit by enemy projectile
            
            if (health <= 0)
            {
                healthBar.value = 0f;       //Manually sets health bar to 0 due to issue in slider functionality with ducks
                Debug.Log("Health upon death: " + healthBar.value);
            }
        }
    }
    
    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 playerMove = transform.right * x + transform.forward * z;       //Gets WASD/arrow key inputs and translates to player movement
        player.Move(playerMove * speed * Time.deltaTime);
        player.Move(Vector3.up * yVel * Time.deltaTime);        //Applies horizontal and vertical movement separately to avoid bugs in movement
    }

    void ManageHealth()
    {
        if (health <= 0f)
        {
            PlayerDeath();      //Calls function for player's death if health is at 0
        }
        else
        {
            if (regenDelayPassed >= regenDelay && health < maxHealth)
            {
                health += regenRate;        //Slowly regenerates player health if not hit by enemy for 5 seconds
            }
            else if (regenDelayPassed < regenDelay)
            {
                regenDelayPassed += Time.deltaTime;     //Increases value of regenDelayPassed
            }
        }
    }
    
    void PlayerDeath()
    {
        isDead = true;
        playerRender.enabled = false;       //Boolean flips to show player is dead and disables renderers for models
        gunRender.enabled = false;
        scopeRender.enabled = false;

        deathDelay -= Time.deltaTime;
        if (deathDelay <= 0f)
        {
            RespawnPlayer();        //Decremenets deathDelay and calls RespawnPlayer once it hits 0
        }
    }

    void RespawnPlayer()
    {
        health = maxHealth;
        transform.position = spawnPoint.position;       //Sets player location and rotation to that of spawn point
        transform.rotation = spawnPoint.rotation;

        playerRender.enabled = true;
        gunRender.enabled = true;       //Reenables renderers for models
        scopeRender.enabled = true;

        deathDelay = 3f;
        isDead = false;         //Resets value of deathDelay and flips boolean to show player is alive
    }
}
