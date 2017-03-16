using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2FloorTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.transform.root.gameObject.name == "Player 2"){
			GetComponent<Renderer> ().material.color = Color.white;
		}
	}
}
