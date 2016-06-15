using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class NoteMovement : MonoBehaviour {

	public GameObject baseNote;

	float initPosX = 447;
	float initPosY = 126;
	float gapY = 22;
	float gapX = 120;

	public int noteIndex = 0;
	public List<int> noteArray = new List<int>();
	public GameObject lastNote = null;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 7; i++) {
			noteArray.Add (i);
		}


	
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< Updated upstream
=======
		if (Input.GetMouseButtonDown (0)) {
			Vector3 pos = Input.mousePosition;
			GameObject mouse = new GameObject ();
			mouse.transform.position = pos;
			Debug.Log (mouse.transform.position.ToString());
			GameObject canvas = GameObject.Find ("Canvas");
			mouse.transform.SetParent (canvas.transform);
			mouse.transform.localPosition = ScreenToCanvasPoint (pos);
			Debug.Log (mouse.transform.localPosition.ToString());
			Debug.Log (Screen.width.ToString() + ", " + Screen.height.ToString());

			float w = canvas.GetComponent<RectTransform> ().rect.width;
			Debug.Log (w.ToString ());
		}
>>>>>>> Stashed changes
	
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
