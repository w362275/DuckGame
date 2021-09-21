using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public FireBullet bulletPrefab;
    float fireBuffer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fireBuffer > 0f)
        {
            fireBuffer -= Time.deltaTime;       //Decreases value if buffer value has not yet hit 0
        }

        if (Input.GetMouseButtonDown(0) && fireBuffer <= 0f)
        {
            FireBullet clone;
            clone = Instantiate(bulletPrefab, transform.position, transform.rotation);
            fireBuffer = 1f;        //Spawns in bullet and sets a fire buffer of 1 second
        }
    }
}
