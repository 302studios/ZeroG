using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class TimerClass : MonoBehaviour {
	
	private float timeLeft;
	private int minsPerSec = 60 ;
	private int minsPerMatch = 183;
	private int mins;
	private int seconds;
	private int countDownNum;
	private float timePassed;
	private string clockSymbol;
	private Action endGame;
	public GameObject LeaderBoard;
	public GameObject Timer;
	public GameObject CountDown;
	
	// Use this for initialization
	void Start () {
		endGame += stopTimer;
		endGame += showLeaderBoard;
	}
	
	// Update is called once per frame
	void Update () {
		timePassed = Time.timeSinceLevelLoad;
		timeLeft = minsPerMatch - (int)timePassed;
		if (timeLeft > 0) {
			if (timePassed > 3f){
				CountDown.active = false;
				Timer.active = true;
			}
			mins = (int)(timeLeft / minsPerSec);
			seconds = (int)timeLeft - (mins * 60);
			if (seconds < 10)
				clockSymbol = ":0";
			else
				clockSymbol = ":";
			Timer.GetComponent<Text>().text = mins + clockSymbol + seconds;
			countDownNum = 3 - (int)timePassed;
			CountDown.GetComponent<Text>().text = ""+countDownNum+"";
		}
		else {
			endGame();
		}
	}
	
	void stopTimer(){
		Timer.active = false;
	}
	
	void showLeaderBoard(){
		LeaderBoard.active = true;
	}
}