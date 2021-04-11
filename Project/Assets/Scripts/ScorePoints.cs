using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoints : MonoBehaviour
{

    public int scoreToGive;
    private Score score;

    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            score.AddScore(scoreToGive);
            gameObject.SetActive(false);
            // Destroy(gameObject);
        }
    }

}
