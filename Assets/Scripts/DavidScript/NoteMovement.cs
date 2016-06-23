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
	public static float maxSpeed = 9f;
	public static float minSpeed = 3f;
	float slope = -3f;
	float streakSlope = 0f;

	//note position 
	float initPosX = 447;
	float[] initPosYArray = {0,59,92,92,133,133,-75,-40,-40,-6,-6,26,26};
	float gapY = 22;
	float gapX = 140;

	//note variables
	public int noteIndex = 0;
	public string[] noteArray;
	public GameObject lastNote = null;
	public List<GameObject> nextNotes = new List<GameObject>();
	public int nextNotesIndex = 0;

	//sound variable
	public GameObject[] soundArray;

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
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate () {
		if (noteIndex < noteArray.Length) { // generate new node from noteArray
			if (lastNote == null) {
				GenerateNote (noteArray[noteIndex]);
				noteIndex++;
			} else if(initPosX - lastNote.transform.localPosition.x > gapX){
				GenerateNote (noteArray[noteIndex]);
				noteIndex++;
			}
		}

		if (noteIndex == noteArray.Length && !hasDest) {  // set destination when last note generate
			hasDest = true;
			GameObject myDest = Instantiate (dest);
			myDest.transform.SetParent (game.transform);
			//Debug.Log (player.transform.localPosition.x.ToString ());
			myDest.transform.localPosition = new Vector3 (player.transform.localPosition.x + 50f, myDest.transform.localPosition.y, myDest.transform.localPosition.z);
		}
	}

	void GenerateNote(string s) { //generate note GameObject to move in chart
		string[] sArray = s.Split (',');
		for (int i = 0; i < sArray.Length; i++) { 
			int index = NoteToIndex (sArray[i]);
			//Debug.Log ("index: " + index);
			GameObject note = Instantiate (baseNote, new Vector3 (initPosX, initPosYArray [index % 12], 0), Quaternion.identity) as GameObject;
			note.transform.SetParent (gameObject.transform, false);
			note.GetComponentInChildren<UnityEngine.UI.Text> ().text = sArray[i];
			note.GetComponent<NoteButtonController> ().sound = soundArray [index];
			if (sArray.Length > 1) {
				note.GetComponent<NoteButtonController> ().isDouble = true;
			}
			//5D1F1F80 FF878EFF
			if (sArray [i] [sArray [i].Length - 2] == 'b') {
				note.GetComponentInChildren<Image> ().sprite = blendSprite;
			}
			else if (sArray [i] [sArray[i].Length - 1] == '5') { // change color
				/*
				ColorBlock cb = note.GetComponent<UnityEngine.UI.Button> ().colors;
				cb.highlightedColor = new Color (204f / 255f, 84f / 255f, 144f / 255f, 1f);
				cb.normalColor = new Color (204f / 255f, 84f / 255f, 144f / 255f, 1f);
				cb.disabledColor = new Color (255f / 255f, 192f / 255f, 203f / 255f, 1f);
				note.GetComponent<UnityEngine.UI.Button> ().colors = cb;*/
				note.GetComponentInChildren<Image> ().sprite = highSprite;
			}

			nextNotes.Add (note);
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
		if (nextNotesIndex < nextNotes.Count) {
			if (nextNotes [nextNotesIndex].transform.localPosition.x <= NoteButtonController.triggerRight) {// there is note in touch area
				GameObject myErrorSound = Instantiate (errorSound);
				BestStreakTextController.score = 0;

				if (NoteButtonController.pause) {
					NoteButtonController.pause = false;
					NoteButtonController.noteSpeed = minSpeed;
				} else {
					NoteButtonController.noteSpeed = calculateSpeed ();
					player.GetComponent<PlayerController>().speedMin = true;
				}
				Destroy (nextNotes [nextNotesIndex]);
				nextNotes [nextNotesIndex++] = null;
			} else { //note has not came to touch area yet 
				NoteButtonController.noteSpeed = calculateSpeed ();

			}
		}
	}

	public float calculateSpeed() {
		float clickTimeInterval = Time.time - lastClickTime;
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
		
		if(System.Environment.NewLine == "\n")
			return musicFile.text.Split ('\n');
		else
			return musicFile.text.Split (' ');
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
