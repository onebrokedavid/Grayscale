using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGround : MonoBehaviour {
    public GameObject gm;
    
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay");
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "moveableObject")
        {
            Debug.Log("Entered Sound tag if-statement");
            //this.SetActive(false);
        }
    }
}
