using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Float variable for speed
    public float speed = 3f;
    //Variable to call the Rigidbody
    private Rigidbody enemyRb;
    //Variable to call the player 
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody gets initialized
        enemyRb = GetComponent<Rigidbody>();
        //Getting the Values and finding the player GameObject
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Takes the players movement and subtracts this by the enemies current movement, normalized makes it a constant value 
        Vector3 lookDirection = (player.transform.forward - transform.position).normalized;
        //Makes the enemy move towards the player and 'attack' them 
        enemyRb.AddForce(lookDirection * speed);
    }
}
