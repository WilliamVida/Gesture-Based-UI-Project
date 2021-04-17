using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// From https://www.youtube.com/watch?v=wkKsl1Mfp5M&ab_channel=Brackeys.
public class Weapon : MonoBehaviour
{

    // Declare variables.
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject muzzleFlash;
    [Range(0, 5)]
    public int framesToFlash = 1;
    bool isFlashing = false;
    public bool canFire = true;
    public float fireRate = 0.4f;
    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    public bool isReloading = false;
    public TextMeshProUGUI ammoRemainingText;
    private AudioSource audioSource;

    // Initialise.
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ammoRemainingText.text = "Ammo: " + 00;
        currentAmmo = maxAmmo;

        if (muzzleFlash != null)
        {
            muzzleFlash.SetActive(false);
        }
    }

    void Update()
    {
        ammoRemainingText.text = "Ammo: " + currentAmmo;

        // If the weapon is reloading.
        if (isReloading)
        {
            ammoRemainingText.text = "Reloading";
            return;
        }

        // Reload key.
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        // If the ammo is 0 then reload.
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        // If the weapon can fire.
        if (Input.GetKey(KeyCode.Mouse0) && canFire)
        {
            StartCoroutine(Shoot());
        }
    }

    // Fire rate from https://answers.unity.com/comments/1720017/view.html.
    IEnumerator Shoot()
    {
        audioSource.Play();
        canFire = false;
        currentAmmo--;
        var shot = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject.Destroy(shot, 3.5f);
        yield return new WaitForSeconds(fireRate);
        canFire = true;

        if (muzzleFlash != null && !isFlashing)
        {
            StartCoroutine(DoFlash());
        }
    }

    // Weapon reloading from https://www.youtube.com/watch?v=kAx5g9V5bcM&ab_channel=Brackeys.
    public IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void OnEnable()
    {
        isReloading = false;
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
