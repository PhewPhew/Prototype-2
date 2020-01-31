using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float minSpawnInterval = 2.0f;
    private float maxSpawnInterval =  5.0f;

    private bool isSpawning;
    // Start is called before the first frame update
    void Start()
    {
        isSpawning = false;
    }

    void Update()
        //spawns balls at random time between 2f and 5f
    {
        if (!isSpawning)
        {
            float timer = Random.Range(minSpawnInterval, maxSpawnInterval);
            Invoke("SpawnRandomBall", timer);
            isSpawning = true;
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        int ballIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        //resets the ball true
        isSpawning = false;
    }
    
}