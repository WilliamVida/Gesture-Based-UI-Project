using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to set the score points for an object.
public class ScorePoints : MonoBehaviour
{

    // Declare variables.
    public int scoreToGive;
    private Score score;

    // Initialise.
    void Start()
    {
        score = FindObjectOfType<Score>();
        Destroy(gameObject, 8f);
    }

    // If the object touches the player.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            score.AddScore(scoreToGive);
            Destroy(gameObject);
        }
    }

}
