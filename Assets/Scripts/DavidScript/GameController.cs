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
	public GameObject miniMapUI;

	public int wolfHit = 0;
	public int obstacleHit = 0;
	public int totalObstacle = 0;
	public static float rate = 0f;

	// global varible for game status
	public static bool gameHasStarted = false;
	public static bool gameIsOver = false;

	void Awake () {
		levelSetting [level].SetActive (true);
		wolfHit = 0;
		obstacleHit = 0;
		totalObstacle = 0;
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
		//gameMessageUi.GetComponentInChildren<UnityEngine.UI.Text> ().text = "You Win";
		miniMapUI.SetActive(false);
		player.GetComponent<PlayerController> ().controllable = false;
		// game is over, stop recording
		gameIsOver = true;


		Statistics.wolfHit = wolfHit;
		Statistics.obstacleHit = obstacleHit;
		Statistics.totalObstacle = totalObstacle;
		Statistics.hit = wolfHit + obstacleHit;
		Statistics.grade = getGrade (wolfHit + obstacleHit);



		Invoke("GameWinDelay", 4f);

	}

	void GameWinDelay() {
		player.GetComponent<PlayerController> ().Stop ();
		notes.SetActive (false);
		touchArea.SetActive (false);
		SceneManager.LoadScene ("WinScene");
	}

	int getGrade(int hit) {
		if (hit == 0) {
			return 1; //S
		} else if (hit <= 5) {
			return 2; // A
		} else if (hit <= 10) {
			return 3; // B
		} else if (hit <= 15) {
			return 4; // C
		} else if (hit <= 20) {
			return 5; // D
		} else if (hit <= 25) {
			return 6; // E
		} else {
			return 7; // F
		}
	}
}
