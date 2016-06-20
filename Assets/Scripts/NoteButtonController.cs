using UnityEngine;
using System.Collections;

public class NoteButtonController : MonoBehaviour {


	public GameObject sound = null;

	public static float triggerRight = -148f;
	public float triggerLeft = -400f;

	public static bool pause = false;
	public static float noteSpeed = 2f;
	float tempSpeed = 0f;

	//PlayerController script
	playerController pc;
	NoteMovement notemovement;

	//hold button for jumping
	bool holdButton = false;
	float holdTime = 0f;
	float totalHoldTime = 0.3f;

	public bool isDouble = false;

	/*
	float perfectX;
	float perfectInteval = 25f;
	static int perfectCount = 0;
	*/

	// Use this for initialization
	void Awake() {

		//noteSpeed = notemovement.noteSpeed;
	}

	void Start () {
		notemovement = GameObject.Find ("Notes").GetComponent<NoteMovement> ();
		GetComponent<UnityEngine.UI.Button> ().interactable = false;
		triggerRight = GameObject.Find ("Glowbit").transform.localPosition.x;
		RectTransform touchRect = GameObject.Find ("TouchArea").GetComponent<RectTransform> ();
		triggerLeft = touchRect.localPosition.x - touchRect.rect.width / 2f;
		pc = GameObject.Find ("Peter").GetComponent<playerController> ();
		Debug.Log ("note speed: " + noteSpeed);


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

		ScoreTextController.score++;
		BestStreakTextController.score++;

		if (pause) {
			pause = false; //if pause, start moving 
			noteSpeed = NoteMovement.minSpeed;
			pc.speedMin = true;

		} else {
			if(!isDouble) noteSpeed = notemovement.calculateSpeed ();
			pc.speedUp = true;
		}
		notemovement.nextNotes [notemovement.nextNotesIndex++] = null;
		Destroy (gameObject);

	}

	public void Down() {
		holdButton = true;
		tempSpeed = noteSpeed;
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



				ScoreTextController.score++;
				BestStreakTextController.score++;
				pc.speedUp = true;

				if (pause) {
					pause = false; //if pause, start moving 
					noteSpeed = NoteMovement.minSpeed;
					pc.speedMin = true;

				} else {
					if(!isDouble) noteSpeed = notemovement.calculateSpeed ();
					pc.speedUp = true;
				}

				pc.jump = true;
				holdButton = false;
				notemovement.nextNotes [notemovement.nextNotesIndex++] = null;
				Destroy (gameObject);
			}
		}
	}

}
