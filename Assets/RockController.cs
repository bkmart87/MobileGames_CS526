using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) { // player hit the destination and then "you win".
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			player.GetComponent<PlayerController> ().hpDown = true;
			Destroy (gameObject);
		}
	}
}
