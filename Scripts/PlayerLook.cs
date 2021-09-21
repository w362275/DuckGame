using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity;              //Determines mouse sensitivity
    public Transform player;                    //Uses player as transform
    float xRot = 0f;                            //Used to prevent player overshooting camera limits

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;       //Locks cursor to center of screen
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;        //Gets mouse input

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);        //Prevents camera from moving above and below limits of looking

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
