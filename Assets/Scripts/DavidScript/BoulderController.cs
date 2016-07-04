using UnityEngine;
using System.Collections;

public class BoulderController : MonoBehaviour {
	public GameObject player;
	public float gapX = 14f;
	public float forceX = 0.15f;
	bool isFall = false;

	Rigidbody2D myRB;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myRB.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.gameIsOver) {
			gameObject.SetActive (false);
		}
		float distance = transform.position.x - player.transform.position.x;
		if (!isFall && distance > 0f && distance < gapX ) {
			Fall ();
		}
	
	}

	void OnCollisionEnter2D(Collision2D other) { // player hit the boulder lose 1hp;
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			if (player.GetComponent<PlayerController> ().invincible == false) {
				player.GetComponent<PlayerController> ().hpDown = true;
			}
			Destroy (gameObject);
		}
	}
		

	public void Fall() {
		myRB.isKinematic = false;
		isFall = true;
		myRB.AddForce (new Vector3(-forceX,0,0));
	}
}
