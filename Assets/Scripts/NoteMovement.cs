using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class NoteMovement : MonoBehaviour {

	public string musicFileName = "";

	public GameObject baseNote;
	public GameObject empyNote;
	public float noteSpeed;

	//note position 
	float initPosX = 447;
	//float initPosY = 126;
	float[] initPosYArray = {0,53,86,115,-63,-35,-6,23};
	float gapY = 22;
	float gapX = 120;

	//note variables
	public int noteIndex = 0;
	public List<char> noteArray = new List<char>();
	public GameObject lastNote = null;

	//sound variable
	public GameObject[] soundArray;


	// Use this for initialization
	void Start () {
		Load (Application.dataPath + "/MusicFiles/" + musicFileName);
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate () {
		if (noteIndex < noteArray.Count) {
			//Debug.Log (lastNote.transform.position.x + "");
			if (lastNote == null) {
				lastNote = GenerateNote (NoteLetterToIndex(noteArray [noteIndex]));
				noteIndex++;
			} else if(initPosX - lastNote.transform.localPosition.x > gapX){
				lastNote = GenerateNote (NoteLetterToIndex(noteArray [noteIndex]));
				noteIndex++;
			}
		}
	}

	GameObject GenerateNote(int index) {
		GameObject note = Instantiate (baseNote, new Vector3(initPosX, initPosYArray[index], 0), Quaternion.identity) as GameObject;
		note.transform.SetParent (gameObject.transform, false);
		note.GetComponentInChildren<UnityEngine.UI.Text>().text = "" + IndexToNoteLetter(index);
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

	char IndexToNoteLetter(int index) {
		if (index == 0)
			return '.';
		if (index <= 5) {
			return (char)('C' + (index - 1));
		} else {
			return (char)('A' + (index - 6));
		}
	}

	int NoteLetterToIndex(char c) {
		if (c == '.')
			return 0;
		if (c <= 'B')
			return (int)(c - 'A') + 6;
		else
			return (int)(c - 'C') + 1;
	}

	void Load(string fileName){
		string line;
		StreamReader theReader = new StreamReader (fileName, Encoding.Default);
		using (theReader) {
			do {
				line = theReader.ReadLine ();
				if (line != null) {
					char[] entries = line.ToCharArray();//Split (' ');
					if (entries.Length > 0) {
						for(int i =0;i<entries.Length;i++)
							noteArray.Add(entries[i]);
						//Debug.Log(entries[i]);
					}
				}
			} while(line != null);
			theReader.Close ();
		}
	}
		
}
