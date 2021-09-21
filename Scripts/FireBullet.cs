using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    float speed = 2000f;
    float activeTime = 0f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();         //Fetches Rigidbody component attached to the GameObject
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);  //Adds force relative to rotation and increases time active
        activeTime += Time.deltaTime;

        if (activeTime >= 2.5f)
        {
            Destroy(gameObject);        //Destroys bullet after set period to prevent scene getting cluttered
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);        //Destroys bullet once an enemy has been hit
        }
    }
}
