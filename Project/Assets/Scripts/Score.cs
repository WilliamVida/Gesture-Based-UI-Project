using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    public float scoreCount;
    public float pointsPerSeconds;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Score: " + 0000;
    }

    void Update()
    {
        scoreCount += pointsPerSeconds * Time.deltaTime;
        scoreText.text = "Score: " + scoreCount.ToString("F0");
    }

}
