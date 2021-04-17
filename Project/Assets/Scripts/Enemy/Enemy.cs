using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Declare variables.
    public int maxHealth = 100;
    public int health = 100;
    public HealthBar healthBar;
    public int scorePoints;
    public GameObject deathEffect;

    // Initialise.
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Suffer damage method.
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Score.scoreCount += scorePoints;
            Die();
        }
    }

    // Destroy the game object when they die..
    void Die()
    {
        var effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        GameObject.Destroy(effect, 2f);
        Destroy(gameObject);
    }

}
