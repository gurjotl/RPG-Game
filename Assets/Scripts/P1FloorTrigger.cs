using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1FloorTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.transform.root.gameObject.name == "Player 1"){
			GetComponent<Renderer> ().material.color = Color.white;
		}
	}
}
