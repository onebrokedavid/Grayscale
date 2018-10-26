using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushItem : MonoBehaviour {
    bool whileHolding = false;
    bool touchingObject = false;
    bool reset = true;
    float moveRight, otherMass;
    private Rigidbody rb;
    GameObject collObj; //object colliding with player
    GameObject collObjHolder;
    Vector3 playerPos, boxPos, boxDist;

	// Use this for initialization
	void Start () {
        moveRight = 1.1f;
	}

	
	// Update is called once per frame
	void Update () {
        PickUpObject(touchingObject);
        if (whileHolding)
        {
            playerPos = transform.position;
            boxPos = collObjHolder.transform.position;
            boxDist = playerPos - collObjHolder.transform.position;
            if (Input.GetKey("a") && playerPos.x >boxPos.x || Input.GetKey("d") && playerPos.x > boxPos.x)
                collObjHolder.transform.position = new Vector3((playerPos.x - moveRight), (playerPos.y-boxDist.y), collObj.transform.position.z);
            else if (Input.GetKey("d") && playerPos.x <boxPos.x || Input.GetKey("a") && playerPos.x < boxPos.x)
            {
                collObjHolder.transform.position = new Vector3((playerPos.x + moveRight), (playerPos.y-boxDist.y), collObj.transform.position.z);
            }
	    else if (!Input.GetKey("a") && !Input.GetKey("d") && playerPos.x >boxPos.x)
            {
                collObjHolder.transform.position = new Vector3((playerPos.x - moveRight), (playerPos.y-boxDist.y), collObj.transform.position.z);
            }
	    else if (!Input.GetKey("a") && !Input.GetKey("d") && playerPos.x <boxPos.x)
            {
                collObjHolder.transform.position = new Vector3((playerPos.x + moveRight), (playerPos.y-boxDist.y), collObj.transform.position.z);
            }
            if (Input.GetKeyUp("f"))
            {
                whileHolding = false;
                reset = true;
                Vector3 direction = new Vector3(0, 10, 9);
                rb.useGravity = true;
                gameObject.GetComponent<Movement>().jump = false;
                gameObject.GetComponent<Rigidbody>().mass = 1;
            }
        }
	}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "moveableObject")
        {
            Debug.Log("Player touching.");
            touchingObject = true;
            collObj = collision.gameObject;
            if (reset)
            {
                if (collision.rigidbody) {
                    rb = collision.rigidbody;
                    otherMass= collision.gameObject.GetComponent<Rigidbody>().mass;
                }
                collObjHolder = collObj;
                reset = false;
            }
        }
        else
        {
            Debug.Log("Something else is touching.");
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Player no longer touching.");
        touchingObject = false;
    }

    void PickUpObject(bool touching)
    {
        if (touching && !whileHolding)
        {
            playerPos = transform.position;
            boxDist = playerPos - collObj.transform.position;
            if (Input.GetKey("f"))
            {
                gameObject.GetComponent<Rigidbody>().mass +=otherMass;
                gameObject.GetComponent<Movement>().jump = true;
                Debug.Log("Holding object");
                whileHolding = true;
                //drag object
                collObj.transform.position = new Vector3((playerPos.x - boxDist.x), (playerPos.y - boxDist.y));
                rb.useGravity = false;
            }
            if(Input.GetKeyUp("f"))
            {
                Debug.Log("Released object");
            }
        }
    }
}

