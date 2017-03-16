using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	private XP x;

	void Start(){
		x = FindObjectOfType (typeof(XP)) as XP;
	}

	void OnTriggerEnter(Collider other)
    {
		Destroy(gameObject);
 
		if (other.transform.root.gameObject.CompareTag ("Enemy")) {
			other.transform.root.gameObject.GetComponent<Health>().Hit (20 + (5 * (x.getclevel() - 1)));
		}
    }
}
