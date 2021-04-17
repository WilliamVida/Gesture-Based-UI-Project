using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From https://www.youtube.com/watch?v=CLSiRf_OrBk&ab_channel=Brackeys.
public class IncreasedAmmoPowerUp : MonoBehaviour
{

    // Declare variables.
    public int multiplier = 2;
    public bool isInCamera = false;

    // Initialise.
    void Start()
    {
        Destroy(gameObject, 8f);
    }

    // If the power up touches the player.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    // Apply the effects.
    void PickUp(Collider2D player)
    {
        Weapon weapon = player.GetComponentInChildren<Weapon>();
        weapon.currentAmmo = (weapon.maxAmmo * multiplier);
        Destroy(gameObject);
    }

    // Check if the power up is in the camera for the voice commands.
    void OnBecameInvisible()
    {
        isInCamera = false;
    }

    void OnBecameVisible()
    {
        isInCamera = true;
    }

}
