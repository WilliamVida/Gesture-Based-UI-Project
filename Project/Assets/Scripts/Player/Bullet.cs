using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 20;
    public GameObject hitEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Enemy")
        {
            Debug.Log("hit " + hitInfo.name);
            Enemy enemy = hitInfo.GetComponent<Enemy>();

            if (enemy != null)
            {
                var effect = Instantiate(hitEffect, transform.position, transform.rotation);
                GameObject.Destroy(effect, 2f);
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        if (hitInfo.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }

}
