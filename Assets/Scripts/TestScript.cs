using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;


public class TestScript : MonoBehaviour {

	public List<string> noteArray = new List<string> ();
	public TextAsset test;

	public string[] noteIndexArray = { "0", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click() {
		Debug.Log (test.text);
		string[] sArray = test.text.Split ('\n');
		for (int i = 0; i < sArray.Length; i++) {
			Debug.Log ("s: " + sArray [i] + "length: " + sArray[i].Length);
			NoteToIndex (sArray [i]);
		}
	}

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
		Debug.Log ("index = " + index);
		return index;
	}


}
