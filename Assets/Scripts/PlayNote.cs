using UnityEngine;
using System.Collections;

public class PlayNote : MonoBehaviour {

	public Sprite clickedSprite; 
	private Sprite unclickedSprite;
	public float semitone_offset = 0;
	public bool thisIsLastKey = false;

	private int round = -1;
	// Use this for initialization
	void Awake()
	{
		unclickedSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
	}
	void OnMouseDown()
	{
		gameObject.GetComponent<SpriteRenderer>().sprite = clickedSprite; 
		PlayNoteSound ();
		Invoke("TurnOff", 0.2f);
		MoveCharts.chartMoveSpeed = GameManager.calculateSpeed ();
	}

	void OnBecameInvisible() {
		if (thisIsLastKey) {
			GameManager.lastNotePlayed = true;
		}
	}

	void TurnOff()
	{
//		this.gameObject.SetActive (false); 
		gameObject.GetComponent<SpriteRenderer>().sprite = unclickedSprite; 
//		Destroy(gameObject);
	}

	void PlayNoteSound() {
		GetComponent<AudioSource>().pitch = Mathf.Pow (2f, semitone_offset/12.0f);
		GetComponent<AudioSource>().Play ();	
	}
}
