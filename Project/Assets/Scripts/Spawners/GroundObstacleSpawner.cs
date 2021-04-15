using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From https://www.youtube.com/watch?v=AI8XNNRpTTw&ab_channel=AlexanderZotov.
public class GroundObstacleSpawner : MonoBehaviour
{

    public GameObject obstaclePrefab;
    Vector2 whereToSpawn;
    public float obstacleChance = 30;

    void Update()
    {
        if (Random.Range(0f, 100f) < obstacleChance)
        {
            Instantiate(obstaclePrefab, whereToSpawn, Quaternion.identity);
        }
    }

}
