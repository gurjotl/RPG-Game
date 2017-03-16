using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldronf : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.transform.root.gameObject.CompareTag ("Finish")) {
			other.gameObject.SetActive (false);
		}
	}
}
