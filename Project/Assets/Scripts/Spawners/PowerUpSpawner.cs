using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    // Declare variables.
    public GameObject[] powerUpPrefabs;
    float randomYPosition;
    Vector2 whereToSpawn;
    public float spawnRate = 8f;
    float nextSpawn = 0.0f;
    public int randomPowerUp;

    void Update()
    {
        // If enough time has passed then spawn a random power-up at a random y position.
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randomYPosition = Random.Range(-4f, 4f);
            randomPowerUp = Random.Range(0, powerUpPrefabs.Length);
            whereToSpawn = new Vector2(transform.position.x, transform.position.y + randomYPosition);
            Instantiate(powerUpPrefabs[randomPowerUp], whereToSpawn, Quaternion.identity);
        }
    }

}
