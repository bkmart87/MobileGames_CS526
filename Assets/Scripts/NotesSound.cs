using UnityEngine;
using System.Collections;

public class NotesSound : MonoBehaviour {

	// Use this for initialization
	AudioSource audio;

	void Awake() {
		audio = GetComponent<AudioSource> ();
		StartCoroutine(Sound ());
	}

	void Start () {

	}
	

	IEnumerator Sound () {
		Debug.Log ("Sound!");
		audio.Play ();
		yield return new WaitForSeconds(audio.clip.length);
		Destroy (gameObject);
	}
}
