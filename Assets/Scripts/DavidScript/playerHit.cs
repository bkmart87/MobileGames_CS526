using UnityEngine;
using System.Collections;

public class playerHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			//Destroy (gameObject);
			playerController.currentSpeed = 0f;
			EnemyController.currentSpeed = 0f;
		}
	}
}
