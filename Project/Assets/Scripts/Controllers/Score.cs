using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Class to keep track of the score and set the score gained per second by the player.
public class Score : MonoBehaviour
{

    // Declare variables.
    public static float scoreCount;
    public float pointsPerSeconds;
    public TextMeshProUGUI scoreText;

    // Initialise.
    void Start()
    {
        scoreCount = 0;
        scoreText.text = "Score: " + 0000;
    }

    // Add the points and time.
    void Update()
    {
        scoreCount += pointsPerSeconds * Time.deltaTime;
        scoreText.text = "Score: " + scoreCount.ToString("F0");
    }

    // Add score method.
    public void AddScore(int scoreToAdd)
    {
        scoreCount += scoreToAdd;
    }

}
