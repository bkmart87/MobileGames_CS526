using UnityEngine;
using System.Collections;

public class NotesSound : MonoBehaviour {

	// Use this for initialization
	AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource> ();
	
		StartCoroutine(Sound ());
	}
	

	IEnumerator Sound () {
		audio.Play ();
		yield return new WaitForSeconds(audio.clip.length);
		Destroy (gameObject);
	}
}
