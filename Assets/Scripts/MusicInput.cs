using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;


public class MusicInput : MonoBehaviour {

	static float startPosX = 440.0f;
	static int NoteTypeCount = 7;

	static List<char> notes = new List<char>();


	public RectTransform[] UINote = new RectTransform[NoteTypeCount];

	Vector3[] initPos = new Vector3[NoteTypeCount];




	// Use this for initialization
	void Start () {
		Load ("Assets/MusicFiles/Song1.txt");
		/*
		RectTransform noteA = (RectTransform) Instantiate (NoteA);
		noteA.SetParent (this.transform);
		noteA.localPosition = posA;
		noteA.localScale = new Vector3 (1, 1, 1);
		*/


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		
	}

	void GenerateNote(int index) {
		RectTransform newNote = (RectTransform)Instantiate (UINote [index]);
		newNote.SetParent (this.transform);
		newNote.localPosition = initPos [index];
		newNote.localScale = new Vector3 (1, 1, 1);
		
	}


	//Load music notes from files to List<char> notes
	private void Load(string fileName){
		string line;
		StreamReader theReader = new StreamReader (fileName, Encoding.Default);
		using (theReader) {
			do {
				line = theReader.ReadLine ();
				if (line != null) {
					char[] entries = line.ToCharArray();//Split (' ');
					if (entries.Length > 0) {
						for(int i =0;i<entries.Length;i++)
							notes.Add(entries[i]);
					}
				}
			} while(line != null);
			theReader.Close ();
		}
	}
}
