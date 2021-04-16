using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDestroyer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Power Up"))
        {
            Destroy(other.gameObject);
        }
    }

}
