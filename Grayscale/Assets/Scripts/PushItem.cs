using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushItem : MonoBehaviour {

    bool touchingObject = false;
    GameObject collObj; //object colliding with player
    Vector3 playerPos, boxPos, boxDist;

	// Use this for initialization
	void Start () {
        
	}

	
	// Update is called once per frame
	void Update () {
        PickUpObject(touchingObject);
	}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "moveableObject")
        {
            Debug.Log("Player touching.");
            touchingObject = true;
            collObj = collision.gameObject;
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

                //drag object
                collObj.transform.position = new Vector3((playerPos - boxDist).x, (playerPos - boxDist).y);

            }
            if(Input.GetKeyUp("f"))
            {
                Debug.Log("Released object");
            }
        }
    }
}
