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
        Destroy(gameObject, 8f);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            score.AddScore(scoreToGive);
            Destroy(gameObject);
        }
    }

}
