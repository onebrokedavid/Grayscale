using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed, airSpeed=0.0f;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("a"))
        {
            transform.position = (new Vector3(transform.position.x - speed, transform.position.y, transform.position.z));
            //GetComponent<Rigidbody>().AddForce(-Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.position = (new Vector3(transform.position.x + speed, transform.position.y, transform.position.z));


            //GetComponent<Rigidbody>().AddForce(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey("w"))
        {
            if (transform.position.y <=4 && airSpeed<=0)
            {
                airSpeed = .2f;
                transform.position = (new Vector3(transform.position.x, transform.position.y+airSpeed, transform.position.z));

            }
        }
        if (airSpeed > 0)
            airSpeed -= .01f;
      transform.position = (new Vector3(transform.position.x, transform.position.y + airSpeed, transform.position.z));
    }
}
