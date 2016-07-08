using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {
	public bool isViolin;
	public bool isHeart;
	public bool isShield;

	public GameObject sound = null;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,Time.deltaTime*100,0);
	}

	void OnTriggerEnter2D(Collider2D other) { // player hit the destination and then "you win".
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			Instantiate (sound);
			if (isViolin) { // violin bonus
				Debug.Log ("get violin");
				ScoreTextController.score += 20;
				other.gameObject.GetComponentInChildren<PeterTextController>().Show ("Score + 20");

			} else if (isHeart) {
				Debug.Log ("get heart");
				ScoreTextController.score += 5;
				other.gameObject.GetComponentInChildren<PeterTextController>().Show ("Score + 5");
				//other.gameObject.GetComponentInParent<PlayerController> ().hpUp = true; // player add hp
			} else if (isShield) {
				Debug.Log ("get shield");
				other.gameObject.GetComponentInParent<PlayerController> ().GetShield (); // get shield to be invincible
			}
			Destroy (gameObject);
		}
	}
}
