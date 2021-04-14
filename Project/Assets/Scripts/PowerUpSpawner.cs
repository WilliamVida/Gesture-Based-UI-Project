using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    public GameObject powerUpPrefabs;
    float randomYPosition;
    Vector2 whereToSpawn;
    public float spawnRate = 8f;
    float nextSpawn = 0.0f;

    // speed increase + invincibility
    // invincibility
    // special weapon
    // increased damage
    // larger bullet

    void Start()
    {

    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randomYPosition = Random.Range(0f, 3.8f);
            whereToSpawn = new Vector2(transform.position.x, transform.position.y + randomYPosition);
            Instantiate(powerUpPrefabs, whereToSpawn, Quaternion.identity);
        }
    }

}
