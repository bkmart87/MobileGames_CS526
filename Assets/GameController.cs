using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameObject player;
	public static GameObject enemy;
	public static GameObject gameMessageUi;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Peter");
		enemy = GameObject.Find ("Wolf");
		gameMessageUi = GameObject.Find ("GameMessageUI");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void GameOver() {
		Debug.Log ("GameOver");
		player.GetComponent<playerController> ().Stop ();
		enemy.GetComponent<EnemyController> ().Stop();
		NoteButtonController.noteSpeed = 0;
		gameMessageUi.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Game Over";


	}

	public static void GameWin() {
		Debug.Log ("GameWin");
		player.GetComponent<playerController> ().speedMin = true;
		enemy.GetComponent<EnemyController> ().Stop();
		NoteButtonController.noteSpeed = 0;
		gameMessageUi.GetComponentInChildren<UnityEngine.UI.Text> ().text = "You Win";


	}
}
