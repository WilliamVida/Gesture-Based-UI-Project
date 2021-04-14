using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        // if (col.gameObject.tag == "Platform")
        {
            Destroy(col.gameObject);
        }
    }

}
