using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class PlaySong : MonoBehaviour {
	//trigger part
	public static float TRIGGER_RIGHT = -38; // x value of the trigger right boundry 
	//notes speed control part
	public static float MAX_SPEED = 40.0f; // maximum moving speed of note
	public static float MIN_SPEED = 10.0f;  // min moving speed of note
 	public static float MAX_CLICK_SPEED = 0.15f; // time spend from last click time to this click time
	public static float SLOPE = -25.0f;

	public static float lastClickTime = 0; //time last clicked 
	public static float clickSpeed = 0;   // current time - lastClickTime 

	//seven notes part
	public RectTransform NoteA;
	public RectTransform NoteB;
	public RectTransform NoteC;
	public RectTransform NoteD;
	public RectTransform NoteE;
	public RectTransform NoteF;
	public RectTransform NoteG;


	private Vector3 locA = new Vector3 (47.3f,12f,0f);
	private Vector3 locB = new Vector3 (47.3f,7.7f,0f);
	private Vector3 locC = new Vector3 (47.3f,3.4f,0f);
	private Vector3 locD = new Vector3 (47.3f,-0.9f,0f);
	private Vector3 locE = new Vector3 (47.3f,-5.2f,0f);
	private Vector3 locF = new Vector3 (47.3f,-9.5f,0f);
	private Vector3 locG = new Vector3 (47.3f,-13.8f,0f);



	//song generating part
	public static float GAP_NOTE = 15.0f; // gap distance between two notes
	public static float START_LOCATION = 47.3f; // start location of generated note

	public static List<char> songNotes = new List<char> ();//{'A','B','C','D','E','F','G','B','C','A','D','F','E','G','A','B','C','D','E','F','G'};
	public static int songNotesCount = 0; // index of the song list
	public RectTransform lastNote; // keep track of the last generated note


	//next click note for the player
	public static List<RectTransform> nextNotes = new List<RectTransform>(); // next note list
	public static int notesCount = 0; // number of finished notes  

	//score counting part
	public static int totalCorrect = 0; // correct notes
	public static int bestStreak = 0; // 
	public Transform scoreText;
	public Transform streakText;

	//click effect part
	public GameObject tap_glow;

	public GameObject errorSound;



	//Ray ray;
	//RaycastHit hit;
	//GameObject target;

	// Use this for initialization
	void Start () {
		Load ("Assets/MusicFiles/test.txt");

		TRIGGER_RIGHT += gameObject.transform.position.x;
		START_LOCATION += gameObject.transform.position.x;

	}
	
	// Update is called once per frame
	void Update(){
		/*
		if (Input.GetMouseButtonDown (0)) {
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Debug.Log (Input.mousePosition);
		}*/

	}


	void FixedUpdate () {
		/*
		if (Input.GetMouseButtonDown (0)) {
			Vector3 pPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Debug.Log (pPosition);
			Instantiate (tap_glow,pPosition,tap_glow.transform.rotation);
		}*/
		scoreText.GetComponent<TextMesh> ().text = "Score:" + totalCorrect.ToString ();
		streakText.GetComponent<TextMesh> ().text = "BestStreak:" + bestStreak.ToString ();
		if (songNotesCount < songNotes.Count) {
			if (lastNote == null) {
				generateNote (songNotes [songNotesCount]);
				songNotesCount++;
			} 
			else {
				
				if (START_LOCATION - lastNote.position.x > GAP_NOTE) {
					generateNote (songNotes [songNotesCount]);
					songNotesCount++;
				}
			}
		}
	
	}

	void generateNote(char noteChar){
		if (noteChar == 'A') {
			nextNotes.Add (lastNote = (RectTransform)Instantiate (NoteA, gameObject.transform.position+locA, NoteA.rotation));
		}
		if (noteChar == 'B') {
			nextNotes.Add (lastNote =(RectTransform)Instantiate (NoteB, gameObject.transform.position+locB, NoteB.rotation));
		}
		if (noteChar == 'C') {
			nextNotes.Add (lastNote =(RectTransform)Instantiate (NoteC, gameObject.transform.position+locC, NoteC.rotation));
		}
		if (noteChar == 'D') {
			nextNotes.Add (lastNote =(RectTransform)Instantiate (NoteD, gameObject.transform.position+locD, NoteD.rotation));
		}
		if (noteChar == 'E') {
			nextNotes.Add (lastNote =(RectTransform)Instantiate (NoteE, gameObject.transform.position+locE, NoteE.rotation));
		}
		if (noteChar == 'F') {
			nextNotes.Add (lastNote =(RectTransform)Instantiate (NoteF, gameObject.transform.position+locF, NoteF.rotation));
		}
		if (noteChar == 'G') {
			nextNotes.Add (lastNote =(RectTransform)Instantiate (NoteG, gameObject.transform.position+locG, NoteG.rotation));
		}
		lastNote.SetParent (gameObject.transform);
	}


	void OnMouseDown(){
		NoteController.pause = 0;
		NoteController.noteSpeed = PlaySong.calculateSpeed ();
		if (PlaySong.nextNotes.Count > PlaySong.notesCount) {
			if (PlaySong.nextNotes [PlaySong.notesCount].gameObject.transform.position.x <= PlaySong.TRIGGER_RIGHT) {
				bestStreak =  0;
				Instantiate (errorSound, transform.position, Quaternion.identity);
				Destroy (PlaySong.nextNotes [PlaySong.notesCount].gameObject);
				PlaySong.notesCount++;
			} 
		}

	}

	public static float calculateSpeed(){
		PlaySong.clickSpeed = Time.time - PlaySong.lastClickTime;
		PlaySong.lastClickTime = Time.time;	
		//Debug.Log (clickSpeed);
		float speed = PlaySong.SLOPE*(PlaySong.clickSpeed - PlaySong.MAX_CLICK_SPEED) + PlaySong.MAX_SPEED;
		if (speed > PlaySong.MAX_SPEED)
			speed = PlaySong.MAX_SPEED;
		if (speed < PlaySong.MIN_SPEED)
			speed = PlaySong.MIN_SPEED;
		Debug.Log (speed);
		return speed;
	}
		
	private bool Load(string fileName){
		Debug.Log("Start");
		string line;
		StreamReader theReader = new StreamReader (fileName, Encoding.Default);
		using (theReader) {
			do {
				line = theReader.ReadLine ();
				if (line != null) {
					char[] entries = line.ToCharArray();//Split (' ');
					if (entries.Length > 0) {
						for(int i =0;i<entries.Length;i++)
							songNotes.Add(entries[i]);
							//Debug.Log(entries[i]);
					}
				}
			} while(line != null);
			theReader.Close ();
			return true;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		
		//Debug.Log (other.gameObject.name);
		//if (Input.GetMouseButtonDown (0)) {
		//ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		//Debug.Log (Input.mousePosition);
		//if (Physics.Raycast (ray, out hit, 10000)) {

		//target = hit.collider.gameObject;
		//Debug.Log (target.name);
	}

}
