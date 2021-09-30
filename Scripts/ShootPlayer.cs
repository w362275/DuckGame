using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public Transform firePoint;
    public BulletBehaviour fireBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        BulletBehaviour newBullet;
        newBullet = Instantiate(fireBullet, firePoint.transform.position, firePoint.transform.rotation);
    }
}
