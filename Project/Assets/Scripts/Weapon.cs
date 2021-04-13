using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate(bulletPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.80f), gameObject.transform.rotation);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Instantiate (bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);
    }

}
