using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaySong : MonoBehaviour {

	public static float MAX_SPEED = 40.0f; // maximum moving speed of note
	public static float MIN_SPEED = 10.0f;  // min moving speed of note
 	public static float MAX_CLICK_SPEED = 0.15f; // time spend from last click time to this click time
	public static float SLOPE = -25.0f;

	//seven notes
	public RectTransform Note;

	public static List<RectTransform> nextNotes = new List<RectTransform>(); // next note list
	public static int notesCount = 0; // number of finished notes  

	public static int totalCorrect = 0; // correct notes
	public static int bestStreak = 0; // 

	public float songlength = 0;

	public Transform scoreText;
	public Transform streakText;

	public static float lastClickTime = 0; //time last clicked 
	public static float clickSpeed = 0;   // time - lastClickTime 

	//Ray ray;
	//RaycastHit hit;
	//GameObject target;
	int count=0;
	int netcount = 0;
	// Use this for initialization
	void Start () {
		
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

		songlength += Time.deltaTime*(NoteController.noteSpeed/PlaySong.MIN_SPEED);
		//Debug.Log (songlength);
		scoreText.GetComponent<TextMesh> ().text = "Score:" + totalCorrect.ToString ();
		streakText.GetComponent<TextMesh> ().text = "BestStreak:" + bestStreak.ToString ();
		/*
		if (songlength >= 16.0 && songlength <= 16.005) {
			nextNotes.Add( (RectTransform)Instantiate (NoteA, NoteA.position, NoteA.rotation) );
		}
		if (songlength >= 1 && songlength <= 1.025) {
			nextNotes.Add( (RectTransform)Instantiate (NoteB, NoteB.position, NoteB.rotation) );
		}
		if (songlength >= 3.5 && songlength <= 3.525) {
			nextNotes.Add((RectTransform)Instantiate (NoteC, NoteC.position, NoteC.rotation));
		}
		if (songlength >= 6.0&& songlength <= 6.025) {
			nextNotes.Add((RectTransform)Instantiate (NoteD, NoteD.position, NoteD.rotation));
		}
		if (songlength >= 8.5 && songlength <= 8.505) {`
			nextNotes.Add((RectTransform)Instantiate (NoteE, NoteE.position, NoteE.rotation));
		}
		if (songlength >= 11 && songlength <= 11.005) {
			nextNotes.Add((RectTransform)Instantiate (NoteF, NoteF.position, NoteF.rotation));
		}
		if (songlength >= 13.5 && songlength <= 13.505) {
			nextNotes.Add((RectTransform)Instantiate (NoteG, NoteG.position, NoteG.rotation));
		}
		if (songlength >= 18.5 && songlength <= 18.505) {
			nextNotes.Add((RectTransform)Instantiate (NoteA, NoteA.position, NoteA.rotation));
		}*/
		netcount++;
		if (netcount == 40) {
			netcount = 0;
			count++;
//			if (count % 7 == 1) {
//				nextNotes.Add ((RectTransform)Instantiate (NoteA, NoteA.position, NoteA.rotation));
//			}
//			if (count % 7 == 2) {
//				nextNotes.Add ((RectTransform)Instantiate (NoteB, NoteB.position, NoteB.rotation));
//			}
//			if (count % 7 == 3) {
//				nextNotes.Add ((RectTransform)Instantiate (NoteC, NoteC.position, NoteC.rotation));
//			}
//			if (count % 7 == 4) {
//				nextNotes.Add ((RectTransform)Instantiate (NoteD, NoteD.position, NoteD.rotation));
//			}
//			if (count % 7 == 5) {
//				nextNotes.Add ((RectTransform)Instantiate (NoteE, NoteE.position, NoteE.rotation));
//			}
//			if (count % 7 == 6) {
//				nextNotes.Add ((RectTransform)Instantiate (NoteF, NoteF.position, NoteF.rotation));
//			}
//			if (count % 7 == 0) {
//				nextNotes.Add ((RectTransform)Instantiate (NoteG, NoteG.position, NoteG.rotation));
//			}
		}

	}


	void OnMouseDown(){
		
		NoteController.noteSpeed = calculateSpeed ();

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

	void OnTriggerStay2D(Collider2D other)
	{
		
		//Debug.Log (other.gameObject.name);
		//if (Input.GetMouseButtonDown (0)) {
			//ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//Debug.Log (Input.mousePosition);
			//if (Physics.Raycast (ray, out hit, 10000)) {
				
				//target = hit.collider.gameObject;
				//Debug.Log (target.name);
				/*
				if ((Input.GetMouseButtonDown (0)) && (other.gameObject.name == "NoteA(Clone)") && (target.name == "NoteA(Clone)")) {
					destroyA = "y";
				}

				if ((Input.GetMouseButtonDown (0)) && (other.gameObject.name == "NoteB(Clone)") && (target.name == "NoteB(Clone)")) {
					destroyB = "y";
				}

				if ((Input.GetMouseButtonDown (0)) && (other.gameObject.name == "NoteC(Clone)") && (target.name == "NoteC(Clone)")) {
					destroyC = "y";
				}

				if ((Input.GetMouseButtonDown (0)) && (other.gameObject.name == "NoteD(Clone)") && (target.name == "NoteD(Clone)")) {
					destroyD = "y";
				}

				if ((Input.GetMouseButtonDown (0)) && (other.gameObject.name == "NoteE(Clone)") && (target.name == "NoteE(Clone)")) {
					destroyE = "y";
				}

				if ((Input.GetMouseButtonDown (0)) && (other.gameObject.name == "NoteF(Clone)") && (target.name == "NoteF(Clone)")) {
					destroyF = "y";
				}

				if ((Input.GetMouseButtonDown (0)) && (other.gameObject.name == "NoteG(Clone)") && (target.name == "NoteG(Clone)")) {
					destroyG = "y";
				}*/
		/*
				if ((other.gameObject.name == "NoteA(Clone)") && (target.name == "NoteA(Clone)")) {
					destroyA = "y";
				}

				if ((other.gameObject.name == "NoteB(Clone)") && (target.name == "NoteB(Clone)")) {
					destroyB = "y";
				}

				if ((other.gameObject.name == "NoteC(Clone)") && (target.name == "NoteC(Clone)")) {
					destroyC = "y";
				}

				if ((other.gameObject.name == "NoteD(Clone)") && (target.name == "NoteD(Clone)")) {
					destroyD = "y";
				}

				if ((other.gameObject.name == "NoteE(Clone)") && (target.name == "NoteE(Clone)")) {
					destroyE = "y";
				}

				if ((other.gameObject.name == "NoteF(Clone)") && (target.name == "NoteF(Clone)")) {
					destroyF = "y";
				}

				if ((other.gameObject.name == "NoteG(Clone)") && (target.name == "NoteG(Clone)")) {
					destroyG = "y";
				}
			}
		}*/

	}
}
