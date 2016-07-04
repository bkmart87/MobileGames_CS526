using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseButtonScript : MonoBehaviour {

	public GameObject popup;

	public Text levelText;

	//three level scenes -- index
	private int levelName; 


	//peter' speed before pause
	private float lastSpeedPeter = 0;

	//wolf speed control for Pause
	EnemyController wolfControl;

	// Use this for initialization
	void Start () {
		//popup = GameObject.Find ("popup");
		levelName = GameController.level;
		levelText.text = "LEVEL: " + levelName;
		popup.SetActive (false);
		wolfControl = GameObject.Find ("Wolf").GetComponent<EnemyController> ();

	}
	
	// Update is called once per frame
	void Update () {
	
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
}
