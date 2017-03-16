using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour {
	public string Load;
	void OnTriggerEnter(Collider other)
	{
		//https://docs.unity3d.com/ScriptReference/Object.FindObjectsOfType.html
		if(other.gameObject.CompareTag("Player"))
		{
			SpiderAI[] si = FindObjectsOfType (typeof(SpiderAI)) as SpiderAI[];
			foreach (SpiderAI s in si) {
				s.isLoading = true;
			}

			RatAI[] ri = FindObjectsOfType (typeof(RatAI)) as RatAI[];
			foreach (RatAI r in ri) {
				r.isLoading = true;
			}

			BatAI[] bi = FindObjectsOfType (typeof(BatAI)) as BatAI[];
			foreach (BatAI b in bi) {
				b.isLoading = true;
			}

			GameManager gm = FindObjectOfType (typeof(GameManager)) as GameManager;
			Player1Controller p1 = FindObjectOfType (typeof(Player1Controller)) as Player1Controller;
			Player2Controller p2 = FindObjectOfType (typeof(Player2Controller)) as Player2Controller;
			gm.setP1HP(p1.gameObject.GetComponent<Health> ().HP);
			gm.setP2HP(p2.gameObject.GetComponent<Health> ().HP);
				
			SceneManager.LoadSceneAsync (Load, LoadSceneMode.Single);
		}
	}
}
