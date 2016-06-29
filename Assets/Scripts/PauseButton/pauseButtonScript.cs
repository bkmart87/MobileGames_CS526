using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pauseButtonScript : MonoBehaviour {

	public GameObject popup;

	//three level scenes -- index
	private int level1 = 2;
	private int level2 = 3;
	private int level3 = 4;

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
