using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPLoot : MonoBehaviour {
	private GameManager gm;

	public int deathXP;

	void Start(){
		gm = FindObjectOfType (typeof(GameManager)) as GameManager;
	}
		
	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			gm.gameObject.GetComponent<XP> ().addXP (deathXP);
			Destroy (gameObject);
		}
	}
}
