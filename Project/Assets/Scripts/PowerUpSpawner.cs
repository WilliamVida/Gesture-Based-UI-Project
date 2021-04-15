using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    public GameObject[] powerUpPrefabs;
    float randomYPosition;
    Vector2 whereToSpawn;
    public float spawnRate = 8f;
    float nextSpawn = 0.0f;
    public int randomPowerUp;

    void Start()
    {

    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randomYPosition = Random.Range(-4f, 4f);

            randomPowerUp = Random.Range(0, powerUpPrefabs.Length);
            Debug.Log("randomPowerUp " + powerUpPrefabs[randomPowerUp].name);

            whereToSpawn = new Vector2(transform.position.x, transform.position.y + randomYPosition);
            Instantiate(powerUpPrefabs[randomPowerUp], whereToSpawn, Quaternion.identity);
        }
    }

}
