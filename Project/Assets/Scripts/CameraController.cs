using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public PlayerController playerController;
    private Vector3 lastPlayerPosition;
    private float distanceToMove;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        lastPlayerPosition = playerController.transform.position;
    }

    void Update()
    {
        distanceToMove = playerController.transform.position.x - lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        lastPlayerPosition = playerController.transform.position;
    }

}
