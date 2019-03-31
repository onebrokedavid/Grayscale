using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffect : MonoBehaviour {
    // get falling object's mass and velocity, then increase collider
    // Use this for initialization
    Rigidbody rb;
    public GameObject soundSphere;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Create sphere collider
    public void CreateCollider()
    {
        Instantiate(soundSphere);
        soundSphere.transform.position = transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            CreateCollider();
        }
    }
}
