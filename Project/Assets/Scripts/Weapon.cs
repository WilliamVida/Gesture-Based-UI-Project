using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject muzzleFlash;
    [Range(0, 5)]
    public int framesToFlash = 1;
    bool isFlashing = false;

    void Start()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if (muzzleFlash != null && !isFlashing)
        {
            StartCoroutine(DoFlash());
        }
    }

    // Muzzle flash from https://www.youtube.com/watch?v=VbTPD8brf2g&ab_channel=IndieNuggets.
    IEnumerator DoFlash()
    {

        muzzleFlash.SetActive(true);
        var framesFlashed = 0;
        isFlashing = true;

        while (framesFlashed <= framesToFlash)
        {
            framesFlashed++;
            yield return null;
        }

        muzzleFlash.SetActive(false);
        isFlashing = false;
    }

}
