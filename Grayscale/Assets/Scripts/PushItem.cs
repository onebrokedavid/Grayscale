using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushItem : MonoBehaviour {
    bool whileHolding = false;
    bool touchingObject = false;
    bool reset = true;
    float moveRight,moveLeft;
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
                collObjHolder.transform.position = new Vector3((playerPos.x - moveRight), (playerPos.y), collObj.transform.position.z);
            else if (Input.GetKey("d") && playerPos.x <boxPos.x || Input.GetKey("a") && playerPos.x < boxPos.x)
            {
                collObjHolder.transform.position = new Vector3((playerPos.x + moveRight), (playerPos.y), collObj.transform.position.z);
            }
	    else if (!Input.GetKey("a") && !Input.GetKey("d") && playerPos.x >boxPos.x)
            {
                collObjHolder.transform.position = new Vector3((playerPos.x - moveRight), (playerPos.y), collObj.transform.position.z);
            }
	    else if (!Input.GetKey("a") && !Input.GetKey("d") && playerPos.x <boxPos.x)
            {
                collObjHolder.transform.position = new Vector3((playerPos.x + moveRight), (playerPos.y), collObj.transform.position.z);
            }
            if (Input.GetKeyUp("f"))
            {
                whileHolding = false;
                reset = true;
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
        if (touching)
        {
            playerPos = transform.position;
            boxDist = playerPos - collObj.transform.position;
            if (Input.GetKey("f"))
            {
                Debug.Log("Holding object");
                whileHolding = true;
                //drag object
                collObj.transform.position = new Vector3((playerPos.x - boxDist.x), (playerPos.y - boxDist.y));

            }
            if(Input.GetKeyUp("f"))
            {
                Debug.Log("Released object");
            }
        }
    }
}
