using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=E7gmylDS1C4&ab_channel=PressStart
// https://www.youtube.com/playlist?list=PLiyfvmtjWC_XmdYfXm2i1AQ3lKrEPgc9-
public class PlatformSpawner : MonoBehaviour
{

    public GameObject platformPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    public Transform spawnPoint;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public float distanceBetween;
    public GameObject obstacles;
    public float obstacleChance = 45;
    // private float minHeight;
    // public Transform maxHeightPoint;
    // private float maxHeight;
    // private int numberOfPlatforms = 0;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(SpawnPlatforms());
    }

    private void GeneratePlatforms()
    {
        GameObject a = Instantiate(platformPrefab) as GameObject;

        // if (transform.position.x < spawnPoint.position.x && GameObject.FindGameObjectsWithTag("Player").Length <= 6)
        if (transform.position.x < spawnPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            // heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            // if (heightChange > maxHeight)
            // {
            //     heightChange = maxHeight;
            // }
            // else if (heightChange < minHeight)
            // {
            //     heightChange = minHeight;
            // }

            // transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);
            a.transform.position = new Vector3(transform.position.x + distanceBetween + 15, Random.Range(-screenBounds.y + 1, screenBounds.y - 3));

            if (Random.Range(0f, 100f) < obstacleChance)
            {
                Debug.Log("chance");
                Instantiate(obstacles, new Vector3(a.transform.position.x, a.transform.position.y + 1.486f, 0), transform.rotation);
            }

            // coins
            // coinSpawner.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));

            // transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }

    IEnumerator SpawnPlatforms()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            GeneratePlatforms();
        }
    }

}
