using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airEffect : MonoBehaviour {

    public float hoverForce;

	void OnTriggerStay(Collider other)
    {
        Debug.Log("object inside of trigger");
        Vector3 newDirection = new Vector3(0, hoverForce, 0);
        other.attachedRigidbody.AddForce(newDirection);
    }
}
