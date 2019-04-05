 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public GameObject Sound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            var vel = GetComponent<Rigidbody>().velocity;      //to get a Vector3 representation of the velocity
            float speed = vel.magnitude;             // to get magnitude

            //The following formula is used to determine the soundwave size:
            //(Sqrt(speed) * mass) / (2 * PI)

            float tempValue = Mathf.Sqrt(speed);
            tempValue = tempValue * GetComponent<Rigidbody>().mass;
            tempValue = tempValue / (2 * Mathf.PI);

            GameObject sound = Instantiate(Sound) as GameObject;        //Create sound bubble

            sound.transform.position = transform.position;              //Move sound bubble to position of object that "made" it
            sound.transform.localScale = new Vector3(tempValue, tempValue, tempValue);          //Change the scale of the sound bubble
            sound.SetActive(true);                                      //Reveal the bubble

            Debug.Log("Speed: " + speed + ", Mass: " + GetComponent<Rigidbody>().mass);
        }
        else
        {
        }
    }
}
