using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
	public static int level;

	public GameObject[] levelSetting;
	public GameObject player;
	public GameObject enemy;
	public GameObject gameMessageUi;
	public GameObject notes;
	public GameObject touchArea;

	// global varible for game status
	public static bool gameHasStarted = false;
	public static bool gameIsOver = false;

	void Awake () {
		levelSetting [level].SetActive (true);
	}


	// Use this for initialization
	void Start () {
		gameHasStarted = false;
		gameIsOver = false;
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
		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("Obstacle"), LayerMask.NameToLayer("Obstacle"));

		// game has started, begin recording
		gameHasStarted = true;
		Debug.Log ("Game Start");

	}

	public void GameOver() { 
		Debug.Log ("GameOver");
		player.GetComponent<PlayerController> ().Stop ();
		Debug.Log ("After hit die");
		enemy.GetComponent<EnemyController> ().Stop();
		NoteButtonController.noteSpeed = 0f;
		player.GetComponent<PlayerController> ().controllable = false;
		notes.SetActive (false);
		touchArea.SetActive (false);
		gameMessageUi.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Game Over";

		// game is over, stop recording
		gameIsOver = true;
		Invoke("GameOverDelay", 2f);
	}

	void GameOverDelay() {
		Debug.Log ("GameOverDelay");
		SceneManager.LoadScene ("GameOver");
	}

	public void GameWin() {
		Debug.Log ("GameWin");
		player.GetComponent<PlayerController> ().currentSpeed = player.GetComponent<PlayerController> ().minSpeed;
		enemy.GetComponent<EnemyController> ().Stop();
		gameMessageUi.GetComponentInChildren<UnityEngine.UI.Text> ().text = "You Win";
		player.GetComponent<PlayerController> ().controllable = false;
		// game is over, stop recording
		gameIsOver = true;

		Invoke("GameWinDelay", 4f);

	}

	void GameWinDelay() {
		player.GetComponent<PlayerController> ().Stop ();
		notes.SetActive (false);
		touchArea.SetActive (false);
		SceneManager.LoadScene ("WinScene");
	}
}
