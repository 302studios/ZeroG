using UnityEngine;
using System.Collections;

public class PlayerClass : MonoBehaviour {

    public PlayerData Data;

	// Use this for initialization
	void Start () {
	
	}

    public void LoadPlayerData(PlayerData data)
    {
        Data = data;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn(Transform spawnPoint){

	}

	void Pause(){

	}
}
