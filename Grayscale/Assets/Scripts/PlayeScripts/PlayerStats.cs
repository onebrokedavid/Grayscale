using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void takeDmg(int dmgAmt){
		health -= dmgAmt;
		checkDeathStatus();
	}

	void checkDeathStatus(){
		if (health <= 0) {
			//Destroy ();

		}
	}
}
