using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NoteButtonController : MonoBehaviour {

	public int index;

	public GameObject sound = null;
	public GameObject neighbor = null;

	public static float triggerRight = -148f;
	public float triggerLeft = -400f;

	public static bool pause = false;
	public static float noteSpeed = 2f;

	//PlayerController script
	PlayerController pc;
	NoteMovement notemovement;

	//hold button for jumping
	bool holdButton = false;
	float holdTime = 0f;
	float totalHoldTime = 0.19f;

	public bool isDouble = false;

	bool isTouchable = false;

	public bool calculated = false;

	//sprite change 
	//public Sprite clickSprite;

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
		pc = GameObject.Find ("Peter").GetComponent<PlayerController> ();
		RectTransform touchRect = GameObject.Find ("TouchArea").GetComponent<RectTransform> ();
		triggerRight = GameObject.Find ("Glowbit").transform.localPosition.x;
		GetComponent<UnityEngine.UI.Button> ().interactable = false;
		triggerLeft = touchRect.localPosition.x - touchRect.rect.width / 2f;
	}

	// Update is called once per frame
	void Update () { // move note
		if (!isTouchable && transform.localPosition.x < triggerRight) { // enter touch area
			isTouchable = true;
			GetComponent<UnityEngine.UI.Button> ().interactable = true;
			GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
			notemovement.noteCountsInTouchArea++;
			 
		}
		// miss one note
		if (transform.localPosition.x <= triggerLeft){  //button should disapeear if it's to left bound
			//pause = true;

			BestStreakTextController.score = 0;
			noteSpeed = notemovement.minSpeed;
			pc.speedMin = true;
			Instantiate (notemovement.errorSound);

			DestroyButton ();

		}
		if (!pause) {
			Move ();
		} else {
			//noteSpeed = 0;
			pc.speedZero = true;
		}
		Hold ();

	}
		

	public void Move() {
		Vector3 currentPos = GetComponent<RectTransform> ().localPosition;
		GetComponent<RectTransform> ().localPosition = new Vector3 (currentPos.x - noteSpeed, currentPos.y, currentPos.z);

	}

	public void Click() { //onclick call

		Instantiate (sound);

		//gameObject.GetComponent<Image> ().sprite = clickSprite;

		ScoreTextController.score++;
		BestStreakTextController.score++;

		if (pause) {
			pause = false; //if pause, start moving 
			noteSpeed = notemovement.minSpeed;
			pc.speedMin = true;

		} else {
			CalculateSpeed ();
			pc.speedUp = true;
		}
		Debug.Log ("Click button");
		DestroyButton ();

	}

	public void Down() {
		holdButton = true;
	}

	public void Up() {
		holdButton = false;
		holdTime = 0f;
	}

	public void Hold() { //hold button effect
		if (isTouchable && holdButton) {
			holdTime += Time.deltaTime;
			if (holdTime > totalHoldTime) {
				GameObject mySound = Instantiate (sound);
				Debug.Log ("Jump");



				ScoreTextController.score++;
				BestStreakTextController.score++;
				pc.speedUp = true;

				if (pause) {
					pause = false; //if pause, start moving 
					noteSpeed = notemovement.minSpeed;
					pc.speedMin = true;

				} else {
					CalculateSpeed ();
					//pc.speedUp = true;
				}

				pc.jump = true;
				holdButton = false;
				DestroyButton ();
			}
		}
	}

	void CalculateSpeed() {
		if (isDouble) {
			if (neighbor != null && neighbor.GetComponent<NoteButtonController> ().calculated == false) {
				noteSpeed = notemovement.calculateSpeed ();
				calculated = true;
			}
		} else {
			noteSpeed = notemovement.calculateSpeed ();
		}
		
	}

	public void DestroyButton() {
		notemovement.noteCountsInTouchArea--;
		notemovement.nextNotes[index] = null;
		if (index == notemovement.nextNotesIndex) { // this note is the head note of nextNoteArray
			while (notemovement.nextNotesIndex < notemovement.nextNotes.Count && notemovement.nextNotes [notemovement.nextNotesIndex] == null)
				notemovement.nextNotesIndex++;
		}
		Destroy (gameObject);
	}

}
