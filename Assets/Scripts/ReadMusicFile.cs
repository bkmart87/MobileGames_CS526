using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class ReadMusicFile : MonoBehaviour {

	// Use this for initialization
	/*
	void Start () {
		
		Load ("../MusicFiles/test.txt");
	}*/
	
	public static bool Load(string fileName){
		Debug.Log("Start");
		string line;
		StreamReader theReader = new StreamReader (fileName, Encoding.Default);
		using (theReader) {
			do {
				line = theReader.ReadLine ();
				if (line != null) {
					string[] entries = line.Split (' ');
					if (entries.Length > 0) {
						Debug.Log(entries.ToString());
					}
				}
			} while(line != null);
			theReader.Close ();
			return true;
		}
	}

}
