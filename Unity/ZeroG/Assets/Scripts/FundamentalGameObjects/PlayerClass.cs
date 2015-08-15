using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {
<<<<<<< HEAD
	
	public enum Country {Japan, USA, China, Russia};
	public Country country;
	public int playerNum;
	public Color myColor;
	
	SpriteRenderer[] playerSprites; 
	
=======

    public PlayerData Data;

>>>>>>> origin/master
	// Use this for initialization
	void Start () {
		
		colorPicker ();
	}

    public void LoadPlayerData(PlayerData data)
    {
        Data = data;
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