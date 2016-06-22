using UnityEngine;
using System.Collections;

public class DestController : MonoBehaviour {
	GameObject game;

	// Use this for initialization
	void Start () {
		game = GameObject.Find ("Game");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) { // player hit the destination and then "you win".
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			game.GetComponent<GameController>().GameWin();
		}
	}
}
