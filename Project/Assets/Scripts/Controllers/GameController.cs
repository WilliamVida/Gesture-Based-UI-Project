using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    void Start()
    {
        Time.timeScale = 1f;
        playerStartPoint = thePlayer.transform.position;
    }

    void Update()
    {

    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCoroutine");
    }

    public IEnumerator RestartGameCoroutine()
    {
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        thePlayer.transform.position = playerStartPoint;
        thePlayer.gameObject.SetActive(true);
    }

}
