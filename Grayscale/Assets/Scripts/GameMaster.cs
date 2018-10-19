using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

	GameObject player = new GameObject();

	// Use this for initialization
	void Start () {
		if (player == null) {
			Debug.Log ("Error: Player not found.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
