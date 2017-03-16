using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public int MaxHP = 100;
	public int HP = 100;
	public RectTransform HPbar;
	public float HPscale;

	private float time;
	private bool invulnerable;
	public float invulnerabletime;
	private float hittime;
	public GameManager gm;


	//public AudioClip impact;
	//AudioSource audio;

	void Start()
	{
		gm = FindObjectOfType (typeof(GameManager)) as GameManager;
		invulnerable = false;
		if (gameObject.GetComponent<Player1Controller> () != null) {
			HP = gm.getP1HP ();
		}
		else if (gameObject.GetComponent<Player2Controller> () != null) {
			HP = gm.getP2HP ();
		}
		//audio = GetComponent<AudioSource> ();
	}

	void Update(){
		time += Time.deltaTime;
		HPbar.sizeDelta = new Vector2 (HP * HPscale, HPbar.sizeDelta.y);
		if (invulnerable) 
		{
			if ((time - hittime) > invulnerabletime)
				invulnerable = false;
		}
	}

	public void Hit (int damage) 
	{
		if (!invulnerable) {
			invulnerable = true;
			hittime = time;
			HP = HP - damage;
			HPbar.sizeDelta = new Vector2 (HP * HPscale, HPbar.sizeDelta.y);
			if (HP <= 0) {
				HP = 0;
				//audio.PlayOneShot (impact, 1.0F);

				if (gameObject.CompareTag ("Enemy")) 
					gameObject.SetActive(false);
				else {
					gameObject.SetActive (false);
					gm.endGame();
				}
			}
		}

	}
}