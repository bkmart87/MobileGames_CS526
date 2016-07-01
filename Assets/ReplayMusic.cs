using UnityEngine;
using System.Collections;

public class ReplayMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (RecordInGameMusic.soundData.Count > 1) {
			AudioSource audio = GetComponent<AudioSource> ();
			AudioClip audioClip = AudioClip.Create ("replaySound", RecordInGameMusic.soundData.Count, 2, 44100, false);
			audioClip.SetData (RecordInGameMusic.soundData.ToArray (), 0);
			audio.clip = audioClip;
			audio.Play ();
		}

//		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
