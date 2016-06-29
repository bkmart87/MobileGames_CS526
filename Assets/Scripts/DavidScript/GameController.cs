using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;
	public GameObject gameMessageUi;
	public GameObject notes;
	public GameObject touchArea;

	// Use this for initialization
	void Start () {
		GameStart ();
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void GameStart() { // game start with initialization
		ScoreTextController.score = 0;
		BestStreakTextController.score = 0;
		NoteButtonController.noteSpeed = notes.GetComponent<NoteMovement>().minSpeed;
		NoteButtonController.pause = false;
		Debug.Log ("Game Start");

	}

	public void GameOver() { 
		Debug.Log ("GameOver");
		player.GetComponent<PlayerController> ().Stop ();
		Debug.Log ("After hit die");
		enemy.GetComponent<EnemyController> ().Stop();
		NoteButtonController.noteSpeed = 0f;
		notes.SetActive (false);
		touchArea.SetActive (false);
		gameMessageUi.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Game Over";

		Invoke("GameOverDelay", 2f);


	}

	void GameOverDelay() {
		Debug.Log ("GameOverDelay");
		SceneManager.LoadScene ("GameOver");
	}

	public void GameWin() {
		Debug.Log ("GameWin");
		player.GetComponent<PlayerController> ().speedMin = true;
		enemy.GetComponent<EnemyController> ().Stop();
		NoteButtonController.noteSpeed = 0f;
		notes.SetActive (false);
		touchArea.SetActive (false);
		gameMessageUi.GetComponentInChildren<UnityEngine.UI.Text> ().text = "You Win";


		Invoke("GameWinDelay", 3f);

	}

	void GameWinDelay() {
		player.GetComponent<PlayerController> ().Stop ();
		SceneManager.LoadScene ("WinScene");
	}
}
