using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushItem : MonoBehaviour {
    string objectTag;
    bool whileHolding = false;
    bool touchingObject = false;
    bool reset = true;
    bool interacting = false;
    float moveRight;
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
        if(touchingObject)
        {
            switch(objectTag)
            {
                case "moveableObject":
                    Debug.Log("in contact w/ moveableObject");
                    PickUpObject();
                    break;
                case "readableObject":
                    ReadObject();
                    break;
                case "speakNPC":
                    SpeakNPC();
                    break;
                default: break;
            }
        }


        if (whileHolding)
        {
            playerPos = transform.position;
            boxPos = collObjHolder.transform.position;
            boxDist = playerPos - collObjHolder.transform.position;


            if (Input.GetKey("a") && playerPos.x > boxPos.x || Input.GetKey("d") && playerPos.x > boxPos.x)
            {
                collObjHolder.transform.position = new Vector3((playerPos.x - moveRight), (playerPos.y), collObj.transform.position.z);
            }

            else if (Input.GetKey("d") && playerPos.x < boxPos.x || Input.GetKey("a") && playerPos.x < boxPos.x)
            {
                collObjHolder.transform.position = new Vector3((playerPos.x + moveRight), (playerPos.y), collObj.transform.position.z);
            }

            else if (!Input.GetKey("a") && !Input.GetKey("d") && playerPos.x > boxPos.x)
            {
                collObjHolder.transform.position = new Vector3((playerPos.x - moveRight), (playerPos.y), collObj.transform.position.z);
            }

            else if (!Input.GetKey("a") && !Input.GetKey("d") && playerPos.x < boxPos.x)
            {
                collObjHolder.transform.position = new Vector3((playerPos.x + moveRight), (playerPos.y), collObj.transform.position.z);
            }

            if (Input.GetKeyUp("f"))
            {
                Debug.Log("Released object");
                whileHolding = false;
                reset = true;
                //Vector3 direction = new Vector3(0, 10, 9);
                rb.useGravity = true;
            }
        }
	}



    private void OnCollisionEnter(Collision collision)
    {
        objectTag = collision.gameObject.tag;

        if (objectTag == "moveableObject")
        {
            Debug.Log("Can move object.");
            touchingObject = true;
            collObj = collision.gameObject;
            if (reset)
            {
                if (collision.rigidbody) {
                    rb = collision.rigidbody;
                }
                collObjHolder = collObj;
                reset = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        objectTag = other.gameObject.tag;
        if (objectTag == "readableObject")
        {
            touchingObject = true;
            Debug.Log("Can read object.");
        }

        else if (objectTag == "speakNPC")
        {
            touchingObject = true;
            Debug.Log("Can speak to.");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Player no longer touching.");
        touchingObject = false;
        objectTag = "None";
    }



    //Drag objects
    void PickUpObject()
    {
        playerPos = transform.position;
        boxDist = playerPos - collObj.transform.position;

        //While holding f, drag object
        if (Input.GetKey("f"))
        {
            Debug.Log("Holding object");
            whileHolding = true;
            //drag object
            collObj.transform.position = new Vector3((playerPos.x - boxDist.x), (playerPos.y - boxDist.y));
            rb.useGravity = false;
        }
    }

    //Read objects
    void ReadObject()
    {
        //while holding e, read object
        if (Input.GetKeyDown("e"))
        {
            switch (interacting)
            {
                case false:
                    Debug.Log("Reading.");
                    interacting = true;
                    break;
                case true:
                    Debug.Log("No longer reading.");
                    interacting = false;
                    break;
                default:break;

            }
        }
    }

    //Talk to NPC
    void SpeakNPC()
    {
        //while holding e, NPC speaks
        if (Input.GetKeyDown("e"))
        {
            switch (interacting)
            {
                case false:
                    Debug.Log("NPC speaking.");
                    interacting = true;
                    break;
                case true:
                    Debug.Log("No longer speaking.");
                    interacting = false;
                    break;
                default: break;

            }
        }
    }
}
