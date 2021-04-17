using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From https://www.youtube.com/watch?v=wkKsl1Mfp5M&ab_channel=Brackeys.
public class Bullet : MonoBehaviour
{

    // Declare variables.
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 20;
    public GameObject hitEffect;

    // Initialise.
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // When the bullet touches an object.
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // If the bullet touches an enemy.
        if (hitInfo.gameObject.tag == "Enemy")
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();

            if (enemy != null)
            {
                var effect = Instantiate(hitEffect, transform.position, transform.rotation);
                GameObject.Destroy(effect, 2f);
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        // If the bullet touches an obstacle.
        if (hitInfo.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    // Destroy the bullet when the bullet leaves the camera.
    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }

}
