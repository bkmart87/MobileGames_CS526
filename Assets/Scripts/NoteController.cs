using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NoteController : MonoBehaviour {

	public float initialSpeed; // moving speed of notes
	
	public static float noteSpeed = 10;
	public GameObject sound; //sound of every note

	// Use this for initialization
	void Start () {
		
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (-initialSpeed, 0 ,0);
	}
	
	// Update is called once per frame
	void Update () {
		//testSpeed++;
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (-noteSpeed, 0 ,0);
		if ((PlaySong.clickSpeed < Time.time - PlaySong.lastClickTime))
			noteSpeed = 10;
	}


	void OnTriggerExit2D()
	{
		//GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
		Destroy (gameObject, .1f);
		PlaySong.notesCount++;
		PlaySong.bestStreak = 0; 
	}

	void OnMouseDown(){
		//Debug.Log (Input.mousePosition);
		NoteController.noteSpeed = PlaySong.calculateSpeed ();
		if (PlaySong.nextNotes.Count > PlaySong.notesCount) {
			if (PlaySong.nextNotes [PlaySong.notesCount].gameObject == gameObject && transform.position.x <= -24) {
				Instantiate (sound, transform.position, Quaternion.identity);
				Destroy (gameObject);
				PlaySong.notesCount++;
				PlaySong.totalCorrect++;
				PlaySong.bestStreak++;
			} 
			else {
				PlaySong.bestStreak = 0;		
			}
		} 
		else {
			PlaySong.bestStreak = 0;
		}
	
	}
}
