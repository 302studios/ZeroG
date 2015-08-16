using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DisplayFinalScores : MonoBehaviour {

	public List<PlayerData> _playerData;
	private PlayerData.Country winningCountry;
	private GameObject[] players;
	public GameObject WinningTeam;
	public GameObject Team1Score;
	public GameObject Team2Score;
	public GameObject Team1Flag;
	public GameObject Team2Flag;
	public GameObject P1Score;
	public GameObject P2Score;
	public GameObject P3Score;
	public GameObject P4Score;

	// Use this for initialization
	void Start () {
		DefineTeamStats ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void DefineTeamStats (){
		_playerData = ControlCenter.Instance._playerData;
		int T1Score = ControlCenter.Instance.Team1Score;
		int T2Score = ControlCenter.Instance.Team2Score;
		if (T1Score > T2Score)
			FindWinningCountry ("Team 1");
		else if (T2Score > T1Score)
			FindWinningCountry ("Team 2");
		else 
			FindWinningCountry ("Tie");
		DisplayTotals (T1Score,T2Score);
	}

	void DisplayTotals(int T1Score, int T2Score){
		Team1Score.GetComponent<Text> ().text = "" + T1Score + "";
		Team2Score.GetComponent<Text> ().text = "" + T2Score + "";
	}

	void FindWinningCountry(string winner){
		foreach (PlayerData player in _playerData) {
			if (player.PlayerNum < 2 && winner == "Team 1"){
				winningCountry = player.PlayerCountry;
				DisplayWinner(winningCountry);
			}
			else if (player.PlayerNum >= 2 && winner == "Team 2"){
				winningCountry = player.PlayerCountry;
				DisplayWinner(winningCountry);
			}
			else{
				Tie();
			}
		}
	}

	void DisplayWinner(PlayerData.Country winningCountry){

	}

	void Tie(){
		WinningTeam.GetComponent<Image> ().overrideSprite = GetComponent ("Tie");
	}


}
