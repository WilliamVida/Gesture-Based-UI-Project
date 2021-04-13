﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=E7gmylDS1C4&ab_channel=PressStart
// https://www.youtube.com/playlist?list=PLiyfvmtjWC_XmdYfXm2i1AQ3lKrEPgc9-
public class DeployPlatforms : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    public Transform spawnPoint;
        public float distanceBetweenMin;
    public float distanceBetweenMax;
    public float distanceBetween;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        // a.transform.position = new Vector2(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y));
        if (transform.position.x < spawnPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            // platformSelector = Random.Range(0, theObjectPools.Length);

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
            a.transform.position = new Vector3(transform.position.x+distanceBetween, Random.Range(-screenBounds.y, screenBounds.y));

            // Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);


            // if (Random.Range(0f, 100f) < coinSpawnChance)
            // {
            //     coinSpawner.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
            // }

            // transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }



    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }


}
