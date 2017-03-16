using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
	public Button restart;
	public Button quit;
//	public GameObject mainmenu;
//	public GameObject helpmenu;
	public GameManager gm;
	public GameObject losepanel;

	void Start () {
		restart.onClick.AddListener (restartGame);
		quit.onClick.AddListener (quitGame);
		gm = FindObjectOfType (typeof(GameManager)) as GameManager;
	}

	void restartGame(){
		Time.timeScale = 1;

		SpiderAI[] si = FindObjectsOfType (typeof(SpiderAI)) as SpiderAI[];
		foreach (SpiderAI s in si) {
			s.isRestarting = true;
		}

		RatAI[] ri = FindObjectsOfType (typeof(RatAI)) as RatAI[];
		int count = 0;
		foreach (RatAI r in ri) {
			count += 1;
			r.isRestarting = true;
		}

		BatAI[] bi = FindObjectsOfType (typeof(BatAI)) as BatAI[];
		foreach (BatAI b in bi) {
			b.isRestarting = true;
		}

		gm.setP1HP (100);
		gm.setP2HP (100);
		losepanel.gameObject.SetActive (false);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

//	void helpMenu(){
//		helpmenu.SetActive (true);
//		mainmenu.SetActive (false);
//	}

	void quitGame(){
		Application.Quit();
	}

//	void backMenu(){
//		mainmenu.SetActive (true);
//		helpmenu.SetActive (false);
//	}
}
