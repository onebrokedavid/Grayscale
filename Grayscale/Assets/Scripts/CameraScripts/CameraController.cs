using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector3 offset;     // Holds a vector of a set distance between player and camera
    private Vector3 lookDown;
    private Vector3 lookLeft;
    private Vector3 lookRight;
    private Vector3 lookUp;

    public GameObject player;   // Object that will be following
    public Rigidbody playerRB;

    public float look;

    void Start()
    {
        // Set the offset at start of game
        offset = transform.position - player.transform.position;
        playerRB = player.GetComponent<Rigidbody>();
        transform.position = transform.position + offset;

        lookDown = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
        lookUp = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        lookLeft = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
        lookRight = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
    }

    void LateUpdate()
    {
        Debug.Log("offset: " + offset);
        Debug.Log("player: " + player.transform.position);
        Debug.Log("camera: " + transform.position);

        if (Input.GetKey(KeyCode.DownArrow))
        {
            // freeze the player
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
            transform.position = Vector3.Lerp(transform.position, lookDown, 0.02f);
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            // freeze the player
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
            transform.position = Vector3.Lerp(transform.position, lookUp, 0.02f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // freeze the player
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
            transform.position = Vector3.Lerp(transform.position, lookLeft, 0.02f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // freeze the player
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
            transform.position = Vector3.Lerp(transform.position, lookRight, 0.02f);
        }
        else
        {   
            // Set camera's position to players current position plus the offset
            playerRB.constraints = RigidbodyConstraints.FreezeRotation;
            transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.8f);
        }
    }
}
