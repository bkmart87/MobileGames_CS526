using UnityEngine;
using System.Collections;

public class TutorialNotesController : MonoBehaviour {

	public GameObject sound;

	float triggerRight = -148f;
	float triggerLeft = -400f;

	public static bool pause = false;
	public static float noteSpeed = 2f;

	//PlayerController script
	PlayerController pc;

	//hold button for jumping
	bool holdButton = false;
	float holdTime = 0f;
	float totalHoldTime = 0.3f;

	void Start () {
		GetComponent<UnityEngine.UI.Button> ().interactable = false;
		triggerRight = GameObject.Find ("Glowbit").transform.localPosition.x;
		RectTransform touchRect = GameObject.Find ("TouchArea").GetComponent<RectTransform> ();
		triggerLeft = touchRect.localPosition.x - touchRect.rect.width / 2f;
		pc = GameObject.Find ("Peter").GetComponent<PlayerController> ();


	}

	// Update is called once per frame
	void Update () {
		if(transform.localPosition.x < triggerRight) GetComponent<UnityEngine.UI.Button> ().interactable = true;
		if (transform.localPosition.x <= triggerLeft)
			pause = true;
		if (!pause) {
			Move ();
		} else {
			pc.speedZero = true;
		}

		Hold ();

	}


	public void Move() {
		Vector3 currentPos = GetComponent<RectTransform> ().localPosition;
		GetComponent<RectTransform> ().localPosition = new Vector3 (currentPos.x - noteSpeed, currentPos.y, currentPos.z);
	}

	public void Click() {

		GameObject mySound = Instantiate (sound);
		//pause = false; //if pause, start moving
		ScoreTextController.score++;
		BestStreakTextController.score++;
		//pc.speedUp = true;
		gameObject.SetActive (false);
		//Destroy (gameObject);

	}

	public void Down() {
		holdButton = true;
	}

	public void Up() {
		holdButton = false;
		holdTime = 0f;
	}

	public void Hold() {
		if (holdButton) {
			holdTime += Time.deltaTime;
			if (holdTime > totalHoldTime) {
				GameObject mySound = Instantiate (sound);
				Debug.Log ("Jump");
				pc.jump = true;
				holdButton = false;
				Destroy (gameObject);
			}
		}
	}
}
