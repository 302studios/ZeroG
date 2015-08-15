using UnityEngine;
using System.Collections;

public class ControlCenter : Singleton<ControlCenter> {

	
	public void Awake() 
    {
        
	}

    public void Quit() 
    {
        Application.Quit();
    }

    public void LoadTeamSelect()
    {
        Application.LoadLevel("Team Select");
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public void LoadGame()
    {
        Application.LoadLevel("Game");
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public void LoadScore()
    {
        Application.LoadLevel("Score");
        GameObject.DontDestroyOnLoad(gameObject);
    }

    public override void Destroyed()
    {
        //TO DO
    }
}
