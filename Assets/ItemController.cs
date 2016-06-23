using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {
	public bool isViolin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0,Time.deltaTime*100,0);
	}

	void OnTriggerEnter2D(Collider2D other) { // player hit the destination and then "you win".
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			if (isViolin) {
				Debug.Log ("get item");
				ScoreTextController.score += 20;
				Destroy (gameObject);
			}
		}
	}
}
