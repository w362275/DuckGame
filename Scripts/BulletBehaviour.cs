using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    float speed = 1000f;
    float lifetime = 0f;
    Rigidbody bullet;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bullet.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
        lifetime += Time.deltaTime;

        if (lifetime >= 5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
