using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;         // Changeable value, players speed
    public float jumpVelocity;  // Changeable value, jump velocity1
    private bool jumped;        // Bool value, assigned when player jumps
    private bool climbable;     // Bool value, assigned when player climbs ladder

    // Use this for initialization
    void Start() {
        jumped = false;     // Initialize jumped to false
        climbable = false;  // Initialize climbable to false
    }

    // Update is called once per frame
    void Update() {
        PlayerMovement();       // Player moves from left to right
        PlayerJump();           // Player jumps
        PlayerClimbLadder();    // Player climbs up a ladder
    }

    /// <summary>
    /// OnCollisionEnter method, Set collisions that player enters
    /// Ground: Used to set jumped to false, when player hits the ground
    /// Ladder: Set climbable to true
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        // If player lands back on ground, set jumped to false, so player can jump again
        if (collision.gameObject.tag == "Ground")
        {
            jumped = false;
        }

        // If player enters ladder, then set climbable to true
        if (collision.gameObject.tag == "Ladder")
        {
            climbable = true;
        }
    }

    /// <summary>
    /// OnCollisionStay method, Set collisions that player stays
    /// Ladder: While on stay, player can begin climbing
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay(Collision collision)
    {
        // if collision is with that of a ladder, and you stay with ladder, then climable is optional
        if (collision.gameObject.tag == "Ladder")
        {
            climbable = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;    // turn off gravity, to go up
        }
    }

    /// <summary>
    /// OnCollisionExit method, Set collisions that player Exits out of
    /// Ladder: When exit, set climbable to false
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        // If player exits ladder, then set climbable to false
        if (collision.gameObject.tag == "Ladder")
        {
            climbable = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true; // turn gravity back on
        }
    }

    /// <summary>
    /// PlayerMovement method, basic movement of player, left and right
    /// </summary>
    private void PlayerMovement()
    {
        // move player right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            //GetComponent<Rigidbody>().velocity = Vector3.left * speed;
        }
        // move player left
        if (Input.GetKey(KeyCode.A))
        {
            //GetComponent<Rigidbody>().velocity = Vector3.right * speed;
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        }
    }

    /// <summary>
    /// PlayerJump method, when space bar is pressed, player jumps
    /// </summary>
    private void PlayerJump()
    {
        // Player Jumps on space bar, as long as jumped == false
        if (Input.GetKeyDown(KeyCode.Space) && !jumped)
        {
            jumped = !jumped;
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
        }

    }

    /// <summary>
    /// PlayerClimbLadder method, player can climb ladder
    /// </summary>
    private void PlayerClimbLadder()
    {
        // when pressed W, player climbs up ladder
        if (Input.GetKey(KeyCode.W) && climbable == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        }
        // when pressed S, player climbs down ladder
        if (Input.GetKey(KeyCode.S) && climbable == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
        }
    }
}
