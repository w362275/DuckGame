using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    public GameObject player;
    float health = 100f;

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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health -= 10f;
            Debug.Log("Current health: " + health);     //Decrements health by 10 if hit by bullet
            if (health <= 0f)
            {
                Destroy(gameObject);        //Destroys duck once health hits 0
            }
        }
    }
}
