using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector3 offset;     // Holds a vector of a set distance between player and camera
    public GameObject player;   // Object that will be following

    void Start()
    {
        // Set the offset at start of game
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Set camera's position to players current position plus the offset
        transform.position = player.transform.position + offset;
    }
}
