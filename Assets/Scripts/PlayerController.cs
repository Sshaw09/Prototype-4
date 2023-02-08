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
    //Boolean variable to check if we have the powerup
    public bool hasPowerup = false;
    //Varible for how strong the power up is 
    float powerupStrength = 15f;
    //Variable to get the power up indicator
    public GameObject powerupIndicator;
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
        //
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    //Void OnTriggerEnter activates when the ball collides with the powerup making hasPowerup true and destroys the powerup while starting the timer
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            //makes the haspowerup true
            hasPowerup = true;
            //Destroys the powerup
            Destroy(other.gameObject);
            //Makes it so that the powerupIndicator is shown
            powerupIndicator.gameObject.SetActive(true);
            //Starts the Powerup Timer and starts to remove certain things
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    //Sets a timer for 7 seconds, after 7 seconds you lose your powerup buff
    IEnumerator PowerupCountdownRoutine()
    {
        //Starts the timer
        yield return new WaitForSeconds(7);
        //When timer ends, the powerup turns off
        hasPowerup = false;
        //When the timer ends,the powerupIndicator turns off
        powerupIndicator.gameObject.SetActive(false);
    }

    //Makes it so that when you collect the powerup, it makes up POWERUP!!!!
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            //This variable stores the enemies rigidbody inside of it
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            //This variable calculates how hard does the player hit with the powerup, in terms of distance
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            //
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

            //Logs when the player has the powerup and has collided with the enemy
            Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + hasPowerup); 
        }
    }

}
