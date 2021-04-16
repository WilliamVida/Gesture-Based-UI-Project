using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public static float scoreCount;
    public float pointsPerSeconds;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreCount = 0;
        scoreText.text = "Score: " + 0000;
    }

    void Update()
    {
        scoreCount += pointsPerSeconds * Time.deltaTime;
        scoreText.text = "Score: " + scoreCount.ToString("F0");
    }

    public void AddScore(int scoreToAdd)
    {
        scoreCount += scoreToAdd;
    }

}
