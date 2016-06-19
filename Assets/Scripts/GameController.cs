using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	public GameObject enemy;
	public GameObject gameMessageUi;
	public GameObject scoreText;
	public GameObject bestStreakText;
	public GameObject notes;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Peter");
		enemy = GameObject.Find ("Wolf");
		gameMessageUi = GameObject.Find ("GameMessageUI");
		notes = GameObject.Find ("Notes");

		GameStart ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameStart() {
		Debug.Log ("Game Start");
		ScoreTextController.score = 0;
		BestStreakTextController.score = 0;
		notes.SetActive (true);

	}

	public void GameOver() {
		Debug.Log ("GameOver");
		player.GetComponent<playerController> ().Stop ();
		enemy.GetComponent<EnemyController> ().Stop();
		NoteButtonController.noteSpeed = 0;
		notes.SetActive (false);
		gameMessageUi.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Game Over";


	}

	public void GameWin() {
		//Debug.Log ("GameWin");
		player.GetComponent<playerController> ().speedMin = true;
		enemy.GetComponent<EnemyController> ().Stop();
		NoteButtonController.noteSpeed = 0;
		notes.SetActive (false);
		gameMessageUi.GetComponentInChildren<UnityEngine.UI.Text> ().text = "You Win";


		Invoke("stopPlayer", 3f);

	}

	void stopPlayer() {
		player.GetComponent<playerController> ().Stop ();
	}
}
