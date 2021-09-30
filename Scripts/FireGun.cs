using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public Camera playerCam;
    RaycastHit objShot;
    float lastShot;
    float shotDelay = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        lastShot = shotDelay;       //Prevents having to change values of both in testing (yes I'm lazy)
    }

    // Update is called once per frame
    void Update()
    {
        if (lastShot < shotDelay)
        {
            lastShot += Time.deltaTime;     //Adds time passed to value if it hasn't fulfilled the delay period yet
        }

        if (Input.GetMouseButton(0) && lastShot >= shotDelay)
        {
            if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out objShot))
            {
                Debug.Log(objShot.transform.tag);       //Shoots raycast forward from camera when input detected and there is no delay
            }

            DuckMovement hitEnemy = objShot.transform.GetComponent<DuckMovement>();
            if (hitEnemy != null)
            {
                hitEnemy.Shot(10f);     //Calls duck script and subtracts health when a duck is hit
            }

            lastShot = 0f;      //Resets value for time since last shot to count the delay
        }
    }
}
