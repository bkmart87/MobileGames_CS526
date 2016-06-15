using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NoteController : MonoBehaviour {

	public Sprite clickSprite;

	public float initialSpeed = PlaySong.MIN_SPEED; // moving speed of notes
	
	public static float noteSpeed = PlaySong.MIN_SPEED;  // moving speed of notes
	public GameObject sound; //sound of every note

	public static int pause = 0; // all the notes stopped if pause == 1 ; when note is in the left boundry 

	// Use this for initialization
	void Start () {
		
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (-initialSpeed, 0 ,0);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(pause == 1){
			noteSpeed = 0;
		}
	 
		GetComponent<Rigidbody2D> ().velocity = new Vector3 (-noteSpeed, 0 ,0);
		if ((PlaySong.clickSpeed < Time.time - PlaySong.lastClickTime))
			noteSpeed = PlaySong.MIN_SPEED;


	}


	void OnTriggerExit2D()
	{
		//GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
		//Destroy (gameObject, .1f);
		if (gameObject.GetComponent<Image> ().sprite != clickSprite) {
			pause = 1;
		}

		//gameObject.GetComponent<Image>().sprite 
	}

	void OnMouseDown(){
		//Debug.Log (Input.mousePosition);
		if (PlaySong.nextNotes.Count > PlaySong.notesCount) {
			if (PlaySong.nextNotes [PlaySong.notesCount].gameObject == gameObject && transform.position.x <= PlaySong.TRIGGER_RIGHT) {
				pause = 0;
				NoteController.noteSpeed = PlaySong.calculateSpeed ();

				Instantiate (sound, transform.position, Quaternion.identity);
				gameObject.GetComponent<Image> ().sprite = clickSprite;
				Destroy (gameObject,.2f);
				PlaySong.notesCount++;
				PlaySong.totalCorrect++;
				PlaySong.bestStreak++;
			} 
		} 
	}
}
