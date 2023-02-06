using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Variable to get the enemyPrefab
    public GameObject enemyPrefab;
    //Float that is used the set a spawn range 
    private float SpawnRange = 9;
    // Start is called before the first frame update
    void Start()
    {
        //Makes the enemy spawn at a random location on the island 
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        //Generates a random X position that is between -9 and 9 
        float SpawnPosX = Random.Range(-SpawnRange, SpawnRange);
        //Generates a random Y position that is between -9 and 9
        float SpawnPosY = Random.Range(-SpawnRange, SpawnRange);

        //Gets a new Vector3 position making the ball spawn at a random X and Y but always at a Y of 0 
        Vector3 randomPos = new Vector3(SpawnPosX, 0, SpawnPosY);

        return randomPos;

    }
}
