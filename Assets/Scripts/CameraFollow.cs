using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Fields
    [SerializeField]
    GameObject player;

    private float playerx;
    private float playery;
    void Update()
    {
        // Get player x y and set to camera position
        playerx = player.transform.position.x;
        playery = player.transform.position.y;
        transform.position = new Vector3(playerx, playery, -10);
    }
}
