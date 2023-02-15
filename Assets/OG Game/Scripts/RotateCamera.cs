using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    //Float variable for the rotation speed of the camera
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Uses float to capture the horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        //Rotates the camera based on the Horizontal input 
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
