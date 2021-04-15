using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// From https://www.youtube.com/watch?v=CLSiRf_OrBk&ab_channel=Brackeys.
public class IncreasedSpeedPowerUp : MonoBehaviour
{

    public int multiplier = 5;
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

}
