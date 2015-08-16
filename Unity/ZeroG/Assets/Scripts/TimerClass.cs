using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class TimerClass : MonoBehaviour {

	public enum Country {Japan, USA, China, Russia};
	private float timeLeft;
	private int minsPerSec = 60 ;
	private int secsPerMatch = 63;
	private int mins;
	private int seconds;
	private int countDownNum;
	private float timePassed;
	private string clockSymbol;
	private Action endGame;
	public GameObject LeaderBoard;
	public GameObject Timer;
	public GameObject CountDown;
	public int[] finalScores;
	
	// Use this for initialization
	void Start () {
		endGame += stopTimer;
		endGame += computeFinalScores;
		endGame += showLeaderBoard;
	}
	
	// Update is called once per frame
	void Update () {
		timePassed = Time.timeSinceLevelLoad;
		timeLeft = secsPerMatch - (int)timePassed;
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

	void computeFinalScores(){
		//finalScores [0] = ControlCenter.Instance.Team1Score;
		//finalScores [1] = ControlCenter.Instance.Team1Score;
		CountDown.GetComponent<Text> ().text = ("Team1: " + ControlCenter.Instance.Team1Score + "  Team2: " + ControlCenter.Instance.Team2Score);
		CountDown.active = true;
	}
	
	void showLeaderBoard(){
		LeaderBoard.active = true;
	}
	
}