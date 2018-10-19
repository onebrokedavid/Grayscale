using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour {

	GameObject other = new GameObject();

	// Use this for initialization
	void Start () {
		
	}

	void onTriggerStay(){
		
		if (other.tag == "Grabbable" && Input.GetKeyDown(KeyCode.F)) {
			//GrabItem (other);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	void GrabItem(){
		
	}
}
