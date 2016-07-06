using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class NoteMovement : MonoBehaviour {

	public GameObject baseNote;
	public GameObject errorSound = null;
	public GameObject dest;
	public GameObject game;
	public GameObject player;

	//note speed
	float lastClickTime = 0f;
	public float maxSpeed = 9f;
	public float minSpeed = 3f;
	public float slope = -3f;
	public float streakSlope = 0f;

	//note position 
	float initPosX = 0f;
	float[] initPosYArray = {0,59,92,92,133,133,-75,-40,-40,-6,-6,26,26};
	float gapY = 22f;
	public float gapX = 140f;
	float rightBoundX = 447f;

	//note variables
	public int noteIndex = 0;
	public string[] noteArray;
	public GameObject lastNote = null;
	public List<GameObject> nextNotes = new List<GameObject>();
	public float lastNoteLength = 0f;
	public GameObject glowbit;
	public int nextNotesIndex = 0;
	public int noteCountsInTouchArea = 0;

	//sound variable
	public GameObject[] soundArray;

	public float progressScale = 0f;

	//read music file
	public TextAsset musicFile = null;
	string[] noteIndexArray = { "0", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };

	bool hasDest = false;

	//sprite change
	public Sprite highSprite;
	public Sprite blendSprite;


	// Use this for initialization
	void Start () {
		noteArray = Load ();
		GetNotes ();
		lastNoteLength = lastNote.transform.localPosition.x - glowbit.transform.localPosition.x;
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		if (lastNote != null && progressScale <= 1) { //get the game progress in percentage
			progressScale = 1 - (lastNote.transform.localPosition.x - glowbit.transform.localPosition.x) / lastNoteLength;
		}


		if (!hasDest && lastNote != null && lastNote.transform.localPosition.x < rightBoundX + 300f) {  // set destination when last note generate
			Debug.Log("Dest");
			hasDest = true;
			GameObject myDest = Instantiate (dest);
			myDest.transform.SetParent (game.transform);
			myDest.transform.localPosition = new Vector3 (player.transform.localPosition.x + 40f, myDest.transform.localPosition.y, myDest.transform.localPosition.z);
		}
	}

	void GenerateNote(string s, float x) { //generate note GameObject to move in chart
		if(s.Equals("*")) return; //this is empty
		string[] sArray = s.Split (',');
		for (int i = 0; i < sArray.Length; i++) { 
			int index = NoteToIndex (sArray[i]);
			//Debug.Log ("index: " + index);
			GameObject note = Instantiate (baseNote, new Vector3 (x, initPosYArray [(index - 1) % 12 + 1], 0), Quaternion.identity) as GameObject;
			note.transform.SetParent (gameObject.transform, false);
			note.GetComponentInChildren<UnityEngine.UI.Text> ().text = sArray[i];
			note.GetComponent<NoteButtonController> ().sound = soundArray [index];
			if (sArray.Length > 1) { // double click initialization
				note.GetComponent<NoteButtonController> ().isDouble = true;
				if(i == 1) {
					GameObject neighbor = nextNotes [nextNotes.Count - 1];
					note.GetComponent<NoteButtonController> ().neighbor = neighbor;
					neighbor.GetComponent<NoteButtonController> ().neighbor = note;
				}
			}
			//5D1F1F80 FF878EFF
			if (sArray [i] [sArray [i].Length - 2] == 'b') {
				note.GetComponentInChildren<Image> ().sprite = blendSprite;
			}
			else if (sArray [i] [sArray[i].Length - 1] == '5') { // change color
				note.GetComponentInChildren<Image> ().sprite = highSprite;
			}

			nextNotes.Add (note);
			note.GetComponent<NoteButtonController> ().index = nextNotes.Count - 1;
			lastNote = note;
		}
	}

	//get index of note string (like "Eb4" -- 4)
	public int NoteToIndex(string s) {
		int index = 0;
		if (s [s.Length - 1] == '5')
			index = 12;
		s = s.Substring (0, s.Length - 1);
		for (int i = 1; i < noteIndexArray.Length; i++) {
			if(s.Equals(noteIndexArray[i])) {
				index += i;
				break;
			}
		}
		return index;
	}

	public void ClickTouchArea() { // call when click on touch area
		if (nextNotesIndex < nextNotes.Count && !NoteButtonController.pause) {
			// there is note in touch area
			//if (nextNotes [nextNotesIndex].transform.localPosition.x <= NoteButtonController.triggerRight) {// there is note in touch area
			if(noteCountsInTouchArea > 0) {
				GameObject myErrorSound = Instantiate (errorSound);
				BestStreakTextController.score = 0;
				/*
				if (NoteButtonController.pause) {
					NoteButtonController.pause = false;
					NoteButtonController.noteSpeed = minSpeed;
				} else {*/
					NoteButtonController.noteSpeed = calculateSpeed ();
					player.GetComponent<PlayerController>().speedMin = true;
				//}
				GameObject headNote = nextNotes[nextNotesIndex];
				if (headNote.GetComponent<NoteButtonController> ().isDouble && headNote.GetComponent<NoteButtonController> ().neighbor != null) { // destroy both notes in double click
					headNote.GetComponent<NoteButtonController> ().neighbor.GetComponent<NoteButtonController> ().DestroyButton ();
				}
				headNote.GetComponent<NoteButtonController> ().DestroyButton ();
			} else { //note has not came to touch area yet 
				NoteButtonController.noteSpeed = calculateSpeed ();

			}
		}
	}

	public float calculateSpeed() {
		float clickTimeInterval = Time.time - lastClickTime;
		if (clickTimeInterval < 0.01f)
			return NoteButtonController.noteSpeed;
		lastClickTime = Time.time;	
		//Debug.Log ("interval: " + clickTimeInterval);
		float speed = slope * clickTimeInterval + maxSpeed + streakSlope * (float)BestStreakTextController.score;
		if (speed > maxSpeed)
			speed = maxSpeed;
		else if (speed < minSpeed)
			speed = minSpeed;
		//Debug.Log ("Speed: " + speed);
		return speed;
	}

	//load music file
	string[] Load (){
		return System.Text.RegularExpressions.Regex.Split(musicFile.text, @"\s+");
	}

	void GetNotes() { // generate all notes at start
		for (int i = 0; i < noteArray.Length; i++) {
			GenerateNote (noteArray [i], initPosX + i * gapX);
		}
	}


	//no use now 
	Vector3 ScreenToCanvasPoint(Vector3 pos) {
		GameObject canvas = GameObject.Find ("Canvas");
		float canvasWidth = canvas.GetComponent<RectTransform> ().rect.width;
		float canvasHeight = canvas.GetComponent<RectTransform> ().rect.height;
		float newX = (pos.x / Screen.width - 0.5f) * canvasWidth;
		float newY = (pos.y / Screen.height - 0.5f) * canvasHeight;
		return new Vector3 (newX, newY, 0f);
	}
		
}
