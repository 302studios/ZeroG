using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {

	public enum Country {Japan, USA, China, Russia};
	public Country country;
	public int playerNum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.A))
			ControllerInput ();

	}

	void ControllerInput () {

		Debug.Log ("Horizontal Axis: " + Input.GetAxis ("Horizontal"));
		Debug.Log ("Vertical Axis: " + Input.GetAxis ("Vertical"));
	}
}
