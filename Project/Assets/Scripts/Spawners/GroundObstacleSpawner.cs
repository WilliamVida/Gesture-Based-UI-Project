using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From https://www.youtube.com/watch?v=AI8XNNRpTTw&ab_channel=AlexanderZotov.
public class GroundObstacleSpawner : MonoBehaviour
{

    public GameObject[] obstaclePrefabs;
    Vector2 whereToSpawn;
    public int obstacleChance = 30;
    public float spawnTime = 8f;
    float nextSpawn = 0.0f;
    int randomObstacle;

    void Update()
    {
        if (Time.time > nextSpawn && Random.Range(0, 100) < obstacleChance)
        {
            randomObstacle = Random.Range(0, obstaclePrefabs.Length);
            nextSpawn = Time.time + spawnTime;
            whereToSpawn = new Vector2(transform.position.x, transform.position.y);
            Instantiate(obstaclePrefabs[randomObstacle], whereToSpawn, Quaternion.identity);
        }
    }

}
