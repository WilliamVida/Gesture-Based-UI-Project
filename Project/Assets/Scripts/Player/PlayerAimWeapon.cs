using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class that aims the weapons at the mouse position.
// From https://www.youtube.com/watch?v=fuGQFdhSPg4&ab_channel=CodeMonkey.
public class PlayerAimWeapon : MonoBehaviour
{

    // Declare variables.
    private Transform aimTransform;

    // Initialise.
    void Update()
    {
        HandleAiming();
    }

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        aimTransform.eulerAngles = new Vector3(0, 0, angle - 11);
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

}
