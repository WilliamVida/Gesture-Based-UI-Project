using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From https://www.youtube.com/watch?v=AI8XNNRpTTw&ab_channel=AlexanderZotov.
public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    float randomYPosition;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randomYPosition = Random.Range(1.8f, 4f);
            whereToSpawn = new Vector2(transform.position.x, transform.position.y + randomYPosition);
            Instantiate(enemyPrefab, whereToSpawn, Quaternion.identity);
        }
    }

}
