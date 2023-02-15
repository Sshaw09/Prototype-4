using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Varible used for number of enemies in game
    public int enemyCount;
    //Variable to get the enemyPrefab
    public GameObject enemyPrefab;
    //Float that is used the set a spawn range 
    private float SpawnRange = 9;
    //Number of enemies in the wave
    public int waveNumber = 1;
    //Variable for the powerup
    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    }

    void Update()
    {
        //Finds the number of enemies that are in the game
        enemyCount = FindObjectsOfType<Enemy>().Length;

        //If there are no enemies in the game, the number of enemies in the new wave go up by one
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);

            SpawnPowerUp();
        }
    }
    // Update is called once per frame
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        //
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //Makes the enemy spawn at a random location on the island 
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

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

    //This method spawns a new powerup in the scene
    void SpawnPowerUp()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }
}
