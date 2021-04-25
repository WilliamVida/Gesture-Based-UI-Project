using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for parallax effect of the background image.
// Parallax effect from https://www.youtube.com/watch?v=zit45k6CUMk&ab_channel=Dani.
public class Parallax : MonoBehaviour
{

    // Declare variables.
    private float length, startPosition;
    public GameObject cam;
    public float parallaxEffect;

    // Initialise.
    void Start()
    {
        startPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);

        if (temp > startPosition + length)
            startPosition += length;
        else if (temp < startPosition - length)
            startPosition -= length;
    }

}
