using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airEffect : MonoBehaviour {

    public float hoverForce;
    public float pushForce;

	void OnTriggerStay(Collider other)
    {
        Debug.Log("object inside of trigger");
        Vector3 newDirection = new Vector3(pushForce, hoverForce, 0);
        other.attachedRigidbody.AddForce(newDirection);
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Movement>().jump = true;
        }
    }
}
