using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Float variable for speed
    public float speed = 5;

    //Variable to call the Rigidbody
    private Rigidbody playerRb;

    //Variable to call the focalPoint that the main camera is attached to
    private GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody gets initialized
        playerRb = GetComponent<Rigidbody>();
        //Getting the Values and finding the Focal Point GameObject
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        //Float Variable to get the values of the (W/Up & S/Down) movement 
        float forwardInput = Input.GetAxis("Vertical");
        //Adds force to the Rigidbody of the player and makes it move with the focal point 
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
    }
}
