using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
	Player1Controller p1;
	Player2Controller p2;
	GameManager gm;
	private bool first;
	public int count;
	public GameObject panel;
	public Text one;
	public Text two;
	public Text three;
	public Text four;
	public Text five;
	public Text six;
	public Text seven;

	void Start () {
		gm = FindObjectOfType (typeof(GameManager)) as GameManager;
		first = true;
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		p1 = FindObjectOfType (typeof(Player1Controller)) as Player1Controller;
		p2 = FindObjectOfType (typeof(Player2Controller)) as Player2Controller;
		if (first == true && gm.town == true && p1 != null && p2 != null) {
			p1.canmove = false;
			p2.canmove = false;
			first = false;
			panel.gameObject.SetActive (true);
			one.gameObject.SetActive (true);
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			if (count <= 6) {
				if (gm.town == true) {
					//p1.canmove = false;

					switch (count) 
					{
					case 0:
						one.gameObject.SetActive (false);
						two.gameObject.SetActive (true);
						count += 1;
						break;
					case 1:
						two.gameObject.SetActive (false);
						three.gameObject.SetActive (true);
						count += 1;
						break;
					case 2:
						three.gameObject.SetActive (false);
						four.gameObject.SetActive (true);
						count += 1;
						break;
					case 3:
						four.gameObject.SetActive (false);
						five.gameObject.SetActive (true);
						count += 1;
						break;
					case 4:
						five.gameObject.SetActive (false);
						six.gameObject.SetActive (true);
						count += 1;
						break;
					case 5:
						six.gameObject.SetActive (false);
						seven.gameObject.SetActive (true);
						count += 1;
						break;
					case 6:
						seven.gameObject.SetActive (false);
						panel.gameObject.SetActive (false);
						p1.canmove = true;
						p2.canmove = true;
						count += 1;
						break;
					}
				}
			}

		}
	}
}
