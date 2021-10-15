using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckMovement : MonoBehaviour
{
    public GameObject player;
    float health = 100f;
    float attackDelay = 3f;
    float lastAttack = 0f;
    public ShootPlayer attackPlayer;
    public Slider playerHealth;
    float delayDuck = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("health_bar").GetComponent<Slider>();
        Debug.Log(playerHealth.value);
    }

    // Update is called once per frame
    void Update()
    {
        float angleDif = Mathf.Atan2(player.transform.position.x - transform.position.x, player.transform.position.z - transform.position.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, angleDif, 0f);        //Rotates duck to face player

        if (delayDuck <= 0f)
        {
            float xSide = player.transform.position.x - transform.position.x;
            float zSide = player.transform.position.z - transform.position.z;
            float hypotenuse = Mathf.Sqrt((xSide * xSide) + (zSide * zSide));       //Pythagoras calculates direct distance to player

            if (hypotenuse > 10f)
            {
                transform.Translate(0f, 0f, 0.02f);     //Duck moves towards player if hypotenuse length is great enough
            }

            ManageAttacks(hypotenuse);
        }

        if (playerHealth.value <= 0f)
        {
            PlayerRespawn();        //Calls function to delay the duck if player is dead
        }

        if (delayDuck > 0f)
        {
            delayDuck -= Time.deltaTime;        //Decrements delayDuck until it hits 0
            Debug.Log(delayDuck);
        }
    }

    void ManageAttacks(float playerDistance)
    {
        if (lastAttack <= attackDelay)
        {
            lastAttack += Time.deltaTime;       //Adds time passed to value
        }

        if (lastAttack >= attackDelay && playerDistance < 15f)
        {
            attackPlayer.Attack();          //Calls attack function in other script and resets delay
            lastAttack = 0f;
        }
    }

    public void Shot(float damageTaken)
    {
        health -= damageTaken;
        if (health == 0f)
        {
            Destroy(gameObject);        //Destroys duck once it hits 0 health
        }
    }
    
    void PlayerRespawn()
    {
        delayDuck = 5f;
        Debug.Log("Delay set to " + delayDuck);
    }
}
