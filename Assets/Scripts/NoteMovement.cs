using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class NoteMovement : MonoBehaviour {

	public GameObject baseNote;

	//note position 
	float initPosX = 447;
	float initPosY = 126;
	float gapY = 22;
	float gapX = 120;

	//note variables
	public int noteIndex = 0;
	public List<int> noteArray = new List<int>();
	public GameObject lastNote = null;

	//sound variable
	public GameObject[] soundArray;


	// Use this for initialization
	void Start () {
		for (int i = 0; i < 7; i++) {
			noteArray.Add (i);
		}


	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 pos = Input.mousePosition;
			pos = ScreenToCanvasPoint (pos);
			Debug.Log (pos.ToString());
		}

	
	}

	void FixedUpdate () {
		if (noteIndex < noteArray.Count) {
			//Debug.Log (lastNote.transform.position.x + "");
			if (lastNote == null) {
				lastNote = GenerateNote (noteArray [noteIndex]);
				noteIndex++;
			} else if(initPosX - lastNote.transform.localPosition.x > gapX){
				lastNote = GenerateNote (noteArray [noteIndex]);
				noteIndex++;
			}
		}
	}

	GameObject GenerateNote(int index) {
		GameObject note = Instantiate (baseNote, new Vector3(initPosX, initPosY - index * 34, 0), Quaternion.identity) as GameObject;
		note.transform.SetParent (gameObject.transform, false);
		note.GetComponentInChildren<UnityEngine.UI.Text>().text = "" + (char)('A' + index);
		note.GetComponent<NoteButtonController> ().sound = soundArray [index];
		return note;
	}

	Vector3 ScreenToCanvasPoint(Vector3 pos) {
		GameObject canvas = GameObject.Find ("Canvas");
		float canvasWidth = canvas.GetComponent<RectTransform> ().rect.width;
		float canvasHeight = canvas.GetComponent<RectTransform> ().rect.height;
		float newX = (pos.x / Screen.width - 0.5f) * canvasWidth;
		float newY = (pos.y / Screen.height - 0.5f) * canvasHeight;
		return new Vector3 (newX, newY, 0f);
	}
}
