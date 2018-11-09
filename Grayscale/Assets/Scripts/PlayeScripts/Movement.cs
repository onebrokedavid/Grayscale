using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public bool jump;
    public bool floating;
	public float direction;
	public float directionUp;
	public float jumpSpeed;
    public float speed;
    public float glide;
    public float timeFloat = 1.0f;
    public bool climbable;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();
		jump = false;
        climbable = false;
	}

    // Update is called once per frame
    void Update()
    {
        DetectInput();
        
        if (timeFloat <= 0)
        {
            floating = true;
        }
        else if(timeFloat > 0 && jump)
        {
            timeFloat -= Time.deltaTime;
        }
        PlayerClimbLadder();
    }


	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Ground" && jump) {
			jump = false;
            floating = false;
            timeFloat = 1.0f;
		}

        // If player enters ladder, then set climbable to true
        if (other.gameObject.tag == "Ladder")
        {
            climbable = true;
        }
    }

    /// <summary>
    /// OnCollisionStay method, Set collisions that player stays
    /// Ladder: While on stay, player can begin climbing
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionStay(Collision other)
    {
        // if collision is with that of a ladder, and you stay with ladder, then climbable is optional
        if (other.gameObject.tag == "Ladder")
        {
            climbable = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;    // turn off gravity, to go up
        }
    }

    /// <summary>
    /// OnCollisionExit method, Set collisions that player Exits out of
    /// Ladder: When exit, set climbable to false
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionExit(Collision other)
    {
        // If player exits ladder, then set climbable to false
        if (other.gameObject.tag == "Ladder")
        {
            climbable = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true; // turn gravity back on
        }
    }

    void DetectInput(){

		//if pressing A and not pressing D, move left
		if (Input.GetKey (KeyCode.A) && !(Input.GetKey(KeyCode.D))){
			rb.AddForce (new Vector3(-direction, 0, 0) * speed);
		}

		//if pressing D and not pressing A, move right
		if (!(Input.GetKey (KeyCode.A)) && Input.GetKey (KeyCode.D)) {
			rb.AddForce (new Vector3(direction, 0, 0) * speed);
		} 
        //if pressing space and on ground, jump
		if(Input.GetKeyDown(KeyCode.Space) && !jump){
			rb.AddForce (new Vector3(0, directionUp, 0) * jumpSpeed);
            jump = true;
		}
        //if pressing space and floating, glide
        if(Input.GetKey(KeyCode.Space) && floating)
        {
            rb.AddForce(new Vector3(0, glide, 0));
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
