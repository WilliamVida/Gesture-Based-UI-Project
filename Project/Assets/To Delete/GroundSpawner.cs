using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject ground;
    public Transform spawnPoint;

    void Start()
    {

    }


    void Update()
    {
        if (transform.position.x < spawnPoint.position.x)
        {
            Instantiate(ground, transform.position, transform.rotation);
        }
    }

}
