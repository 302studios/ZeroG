using UnityEngine;
using System.Collections;

public class GoalClass : MonoBehaviour {

	public enum Country {Japan, USA, China, Russia};
	public Country country;
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
		Debug.Log (mins+clockSymbol+seconds);

	}
}
