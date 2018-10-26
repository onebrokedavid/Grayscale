using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public bool jump;
    public bool floating;
	public float directionRight;
	public float directionLeft;
	public float directionUp;
	public float jumpSpeed;
    public float speed;
    public float glide;
    public float timeFloat = 1.0f;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();
		jump = false;
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
    }
	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Ground" && jump) {
			jump = false;
            floating = false;
            timeFloat = 1.0f;
		}
	}

	void DetectInput(){

		//if pressing A and not pressing D, move left
		if (Input.GetKey (KeyCode.A) && !(Input.GetKey(KeyCode.D))){
			Vector3 newDirection = new Vector3 (-directionLeft,0,0);
			rb.AddForce (newDirection*speed);
		}

		//if pressing D and not pressing A, move right
		if (!(Input.GetKey (KeyCode.A)) && Input.GetKey (KeyCode.D)) {
			Vector3 newDirection = new Vector3 (directionRight,0,0);
			rb.AddForce (newDirection*speed);
		} 
        //if pressing space and on ground, jump
		if(Input.GetKeyDown(KeyCode.Space) && !jump){
			Vector3 newDirection = new Vector3(0,directionUp,0);
			rb.AddForce (newDirection*jumpSpeed);
            jump = true;
		}
        //if pressing space and floating, glide
        if(Input.GetKey(KeyCode.Space) && floating)
        {
            Vector3 newVector = new Vector3(0, glide, 0);
            rb.AddForce(newVector);
        }
	}
}
