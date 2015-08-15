using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clock : MonoBehaviour {

	private float timeLeft;
	private int minsPerSec = 60 ;
	private int minsPerMatch = 180;
	private int mins;
	private int seconds;
	private string clockSymbol;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft = minsPerMatch - Time.timeSinceLevelLoad;
		mins = (int)(timeLeft/minsPerSec);
		seconds = (int)timeLeft - (mins * 60);
		if (seconds < 10)
			clockSymbol = ":0";
		else
			clockSymbol = ":";
		GetComponent<Text>().text = mins+clockSymbol+seconds;
	}
}
