using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public GameObject player;
    float health = 100f;
    float attackDelay = 3f;
    float lastAttack = 0f;
    public ShootPlayer attackPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angleDif = Mathf.Atan2(player.transform.position.x - transform.position.x, player.transform.position.z - transform.position.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, angleDif, 0f);        //Rotates duck to face player

        float xSide = player.transform.position.x - transform.position.x;
        float zSide = player.transform.position.z - transform.position.z;
        float hypotenuse = Mathf.Sqrt((xSide * xSide) + (zSide * zSide));       //Pythagoras calculates direct distance to player

        if (hypotenuse > 10f)
        {
            transform.Translate(0f, 0f, 0.02f);     //Duck moves towards player if hypotenuse length is great enough
        }
        
        ManageAttacks(hypotenuse);
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
}
