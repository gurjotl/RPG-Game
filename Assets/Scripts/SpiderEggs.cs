using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpiderEggs : MonoBehaviour {
	private GameManager gm;
	public Text continuetext;
	public int deathXP;
	private bool entered = false;

	void Start(){
		gm = FindObjectOfType (typeof(GameManager)) as GameManager;
	}

	void Update(){
		if (Input.GetKey (KeyCode.Space)) {
			if (entered) {
				gm.gameObject.GetComponent<XP> ().addXP (deathXP);
				gm.dungeontwo = true;
				SceneManager.LoadSceneAsync ("Town", LoadSceneMode.Single);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			continuetext.gameObject.SetActive (true);
			entered = true;
		}
	}

	void OnTriggerExit(){
		entered = false;
		continuetext.gameObject.SetActive (false);
	}
}
