using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
		//Application.LoadLevel("DavidScene");
		SceneManager.LoadScene ("DavidScene");

	}

	public void level2(){
		//Application.LoadLevel("DavidScene");
		SceneManager.LoadScene ("DavidScene");
	}

	public void level3(){
		//Application.LoadLevel("DavidScene");
		SceneManager.LoadScene ("DavidScene");
	}

	public void levelTutorial(){
		//Application.LoadLevel("TutorialScene");
		SceneManager.LoadScene ("TutorialScene");
	}

	public void levelMainMenu(){
		//Application.LoadLevel("level0");
		Time.timeScale = 1.0f;
		SceneManager.LoadScene ("level0");
	}

	public void levelGameOver(){
		//Application.LoadLevel("GameOver");
		SceneManager.LoadScene ("GameOver");
	}
}
