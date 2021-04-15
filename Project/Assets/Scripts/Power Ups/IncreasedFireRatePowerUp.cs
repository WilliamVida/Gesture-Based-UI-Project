using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From https://www.youtube.com/watch?v=CLSiRf_OrBk&ab_channel=Brackeys.
public class IncreasedFireRatePowerUp : MonoBehaviour
{

    public int multiplier = 2;
    public float duration = 10f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        Weapon weapon = player.GetComponentInChildren<Weapon>();
        weapon.fireRate /= multiplier;
        weapon.reloadTime /= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        weapon.fireRate *= multiplier;
        weapon.reloadTime *= multiplier;
        Destroy(gameObject);
    }

}
