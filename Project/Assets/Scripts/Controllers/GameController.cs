using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;
    public GameObject gameOverMenu;

    void Start()
    {
        Time.timeScale = 1f;
        playerStartPoint = thePlayer.transform.position;
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);
        }
    }

}
