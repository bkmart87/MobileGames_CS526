using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseButtonScript : MonoBehaviour {

	public GameObject popup;

	public Text levelText;

	public Text ButtonText1;
	public Text ButtonText2;

	//three level scenes -- index
	private int levelName; 


	//peter' speed before pause
	private float lastSpeedPeter = 0;

	//wolf speed control for Pause
	EnemyController wolfControl;

	// Use this for initialization
	void Start () {
		//popup = GameObject.Find ("popup");
		popup.SetActive (false);
		wolfControl = GameObject.Find ("Wolf").GetComponent<EnemyController> ();

	}
	
	// Update is called once per frame
	void Update () {
		levelName = GameController.level;
		levelText.text = "LEVEL: " + levelName.ToString();
		ShowLevelButtonName ();
		//Debug.Log (levelText.text.ToString ());
	}

	public void pauseButtonClickEvent(){

		//lastSpeedPeter = PlayerController.currentSpeed;
		//wolfControl.Stop ();

		NoteButtonController.pause = true;
		popup.SetActive (true);
		Time.timeScale = 0.0f;



	}
		
	public void replayEvent(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(Application.loadedLevelName);
	}

	public void exitEvent(){
		

		NoteButtonController.pause = false;
		popup.SetActive (false);
		Time.timeScale = 1.0f;
		//PlayerController.currentSpeed = lastSpeedPeter;
		//wolfControl.RecoverSpeed ();

	}

	public void LevelButton1(){
		if (levelName == 1) {
			GameController.level = 2;
			SceneManager.LoadScene ("DavidScene");	
		} 
		else {
			GameController.level = 1;
			SceneManager.LoadScene ("DavidScene");	
		} 
		Time.timeScale = 1.0f;
	}

	public void LevelButton2(){
		if (levelName == 3) {
			GameController.level = 2;
			SceneManager.LoadScene ("DavidScene");
		} 
		else {
			GameController.level = 3;
			SceneManager.LoadScene ("DavidScene");
		}
		Time.timeScale = 1.0f;
	}

	void ShowLevelButtonName(){

		if (levelName == 1) {
			ButtonText1.text = "GO LEVEL2";	
			ButtonText2.text = "GO LEVEL3";
		} 
		else if (levelName == 2) {
			ButtonText1.text = "GO LEVEL1";	
			ButtonText2.text = "GO LEVEL3";
		} 
		else {
			ButtonText1.text = "GO LEVEL1";	
			ButtonText2.text = "GO LEVEL2";
		}
	}

}
