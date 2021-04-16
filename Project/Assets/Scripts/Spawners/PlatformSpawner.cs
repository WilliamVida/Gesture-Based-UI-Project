﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From https://www.youtube.com/watch?v=E7gmylDS1C4&ab_channel=PressStart.
// From https://www.youtube.com/playlist?list=PLiyfvmtjWC_XmdYfXm2i1AQ3lKrEPgc9-.
public class PlatformSpawner : MonoBehaviour
{

    public GameObject[] platformPrefabs;
    public GameObject coinPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    public Transform spawnPoint;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public float distanceBetween;
    public GameObject obstacles;
    public float obstacleChance = 45;
    public int randomPlatform;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(SpawnPlatforms());
    }

    private void GeneratePlatforms()
    {
        randomPlatform = Random.Range(0, platformPrefabs.Length);
        GameObject a = Instantiate(platformPrefabs[randomPlatform]) as GameObject;

        if (transform.position.x < spawnPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            a.transform.position = new Vector3(transform.position.x + distanceBetween + 15, Random.Range(-screenBounds.y + 2, screenBounds.y - 2));

            if (Random.Range(0f, 100f) < obstacleChance)
            {
                Instantiate(obstacles, new Vector3(a.transform.position.x, a.transform.position.y + 0.877692f, 0), transform.rotation);
            }
            else
            {
                Instantiate(coinPrefab, new Vector3(a.transform.position.x, a.transform.position.y + 1.0f, 0), transform.rotation);
            }
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
