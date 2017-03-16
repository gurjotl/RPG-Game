using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP : MonoBehaviour {
	public int XPTotal;
	public RectTransform XPbar;
	public Text Clevel;
	public Text Nlevel;
	public Text LevelUp;

	private GameManager gm;
	private int cint;
	private int nint;
	private int next;
	private float scale;
	private bool max;

	void Start () {
		gm = FindObjectOfType (typeof(GameManager)) as GameManager;
		XPTotal = gm.gameObject.GetComponent<XP> ().getXP();
		cint = 1;
		nint = 2;
		next = 1;
		scale = 5.0f;
		max = false;
	}

	void Update () {
		if (!max) {
			XPbar.sizeDelta = new Vector2 (XPTotal * scale, XPbar.sizeDelta.y);
			if (XPTotal >= (100 * next)) {
				XPTotal = 0;
				next += 1;
				scale = 5.0f;
				scale = scale / next;
				cint += 1;
				nint += 1;

				if (cint == 6) {
					max = true;
					Clevel.text = "";
					Nlevel.text = "     MAX";
					XPTotal = (100 * (int)scale);
				}

				if (!max) {
					Clevel.text = cint.ToString ();
					Nlevel.text = nint.ToString ();
				}

				gm.levelup ();
			}
		}
	}

	public int getclevel(){
		return cint;
	}

	public int getXP(){
		return XPTotal;
	}

	public void setXP(int new_XP){
		XPTotal = new_XP;
	}

	public void addXP(int add_XP){
		XPTotal += add_XP;
	}
}
