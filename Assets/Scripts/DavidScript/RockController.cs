using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour {

	public GameObject game;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) { // player hit the rock lose 1hp;
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			if (player.GetComponent<PlayerController> ().invincible == false) {
				player.GetComponent<PlayerController> ().hpDown = true;
				game.GetComponent<GameController> ().obstacleHit++;
				Destroy (gameObject);
			}
		}
	}
}
