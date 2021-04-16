using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From https://www.youtube.com/watch?v=CLSiRf_OrBk&ab_channel=Brackeys.
public class IncreasedAmmoPowerUp : MonoBehaviour
{

    public int multiplier = 2;
    public bool isInCamera = false;

    void Start()
    {
        Destroy(gameObject, 8f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    void PickUp(Collider2D player)
    {
        Weapon weapon = player.GetComponentInChildren<Weapon>();
        weapon.currentAmmo = (weapon.maxAmmo * multiplier);
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        isInCamera = false;
    }

    void OnBecameVisible()
    {
        isInCamera = true;
    }

}
