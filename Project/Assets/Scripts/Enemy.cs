using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;


    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        // healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    // Set the death sounds and destroy the game object.
    void Die()
    {
        // AudioSource.PlayClipAtPoint(deathSound, transform.position, volume);
        // var effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        // GameObject.Destroy(effect, 2f);
        Destroy(gameObject);
    }

}
