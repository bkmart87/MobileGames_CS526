using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReplayMusic : MonoBehaviour {

	public static List<float> soundData = new List<float>();
	private int cnt = 0;
	// Use this for initialization
	void Start () {
		
	}

	void OnAudioFilterRead (float[] data, int channels) {
		if (GameController.gameHasStarted && !GameController.gameIsOver) {
			for (int i = 0; i < data.Length; i++) {
				soundData.Add (data [i]);
			}
			if (cnt == 0) {
				Debug.Log ("Recording begin");
				cnt++;
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
