using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public bool jump;
	public float directionRight;
	public float directionLeft;
	public float directionUp;
	public float jumpSpeed;
	public float speed;
	private Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();
		jump = false;
	}

	// Update is called once per frame
	void Update () {
		DetectInput ();
	}

	void OnCollisionEnter (Collision other){
		if (other.gameObject.tag == "Ground" && jump) {
			jump = false;
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

		if(Input.GetKeyDown(KeyCode.Space) && !jump){
			Vector3 newDirection = new Vector3(0,directionUp,0);
			rb.AddForce (newDirection*jumpSpeed);
			jump = true;
		}
	}
}
