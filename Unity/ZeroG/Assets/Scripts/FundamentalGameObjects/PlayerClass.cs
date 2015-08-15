using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {

	public enum Country {Japan, USA, China, Russia};
	public Country country;
	public int playerNum;
	public Color myColor;

	SpriteRenderer[] playerSprites; 

	// Use this for initialization
	void Start () {
	
		colorPicker ();
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void colorPicker() {

		switch (country) {

			case Country.China:
				myColor = Color.yellow;
				break;
			case Country.USA:
				myColor = Color.blue;
				break;
			case Country.Japan:
				myColor = Color.red;
				break;
			case Country.Russia:
				myColor = Color.white;
				break;
			
		}

		playerSprites = GetComponentsInChildren<SpriteRenderer> ();
		foreach (SpriteRenderer sp in playerSprites) {
			sp.color = myColor;
		}

	}

}
