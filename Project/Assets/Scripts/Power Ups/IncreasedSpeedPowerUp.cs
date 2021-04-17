using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From https://www.youtube.com/watch?v=CLSiRf_OrBk&ab_channel=Brackeys.
public class IncreasedSpeedPowerUp : MonoBehaviour
{

    // Declare variables.
    public int multiplier = 5;
    public float duration = 10f;
    public bool isInCamera = false;

    // If the power up touches the player.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    // Apply the effects.
    IEnumerator PickUp(Collider2D player)
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.moveSpeed *= multiplier;

        GameObject gameController = GameObject.Find("Game Controller");
        Score score = gameController.GetComponent<Score>();
        score.pointsPerSeconds *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        playerController.moveSpeed /= multiplier;
        score.pointsPerSeconds /= multiplier;
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
