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