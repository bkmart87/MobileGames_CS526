using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour 
{
	/*
	public string levelName ="Level0"; 

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Application.LoadLevel(levelName); 
		}
	}*/

	public void level1(){
		Application.LoadLevel("DavidScene");
	}

	public void levelTutorial(){
		Application.LoadLevel("TutorialScene");	
	}

	public void levelMainMenu(){
		Application.LoadLevel("level0");
	}

	public void levelGameOver(){
		Application.LoadLevel("GameOver");
	}
}
