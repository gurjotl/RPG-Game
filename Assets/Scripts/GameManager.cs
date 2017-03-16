using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject losepanel;
	public Text LevelUp;
	private int player1HP = 100;
	private int player2HP = 100;
	private float lactive;
	private float timer;
	public GameObject canvas;

	public bool dungeonone;
	public bool dungeontwo;
	public bool dungeonthree;
	public bool town;

	void Start (){
		DontDestroyOnLoad (gameObject);
		dungeonone = false;
		dungeontwo = false;
		dungeonthree = false;
		town = false;
	}

	void Update () 
	{
//		if(Input.GetKeyDown(KeyCode.R))
//		{
//			Time.timeScale = 1;
//
//			SpiderAI[] si = FindObjectsOfType (typeof(SpiderAI)) as SpiderAI[];
//			foreach (SpiderAI s in si) {
//				s.isRestarting = true;
//			}
//
//			RatAI[] ri = FindObjectsOfType (typeof(RatAI)) as RatAI[];
//			int count = 0;
//			foreach (RatAI r in ri) {
//				count += 1;
//				r.isRestarting = true;
//			}
//
//			BatAI[] bi = FindObjectsOfType (typeof(BatAI)) as BatAI[];
//			foreach (BatAI b in bi) {
//				b.isRestarting = true;
//			}
//
//			setP1HP (100);
//			setP2HP (100);
//			losepanel.gameObject.SetActive (false);
//			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
//		}
		checkTownStarted ();

		timer += Time.deltaTime;
		if (LevelUp.IsActive ()) {
			if ((timer - lactive) > 3) {
				LevelUp.gameObject.SetActive (false);
			}
		}
	}

	public void checkTownStarted(){
		if (town) {
			canvas.gameObject.SetActive (true);
		}
	}
	public void endGame(){
		Time.timeScale = 0;
		losepanel.gameObject.SetActive (true);
	}

	public int getP1HP(){
		return player1HP;
	}

	public int getP2HP(){
		return player2HP;
	}

	public void setP1HP(int HP){
		player1HP = HP;
	}

	public void setP2HP(int HP){
		player2HP = HP;
	}

	public void levelup(){
		LevelUp.gameObject.SetActive(true);
		lactive = timer;
	}
}