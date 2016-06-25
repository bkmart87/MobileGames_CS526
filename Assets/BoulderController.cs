using UnityEngine;
using System.Collections;

public class BoulderController : MonoBehaviour {
	public GameObject player;
	public float gapX = 14f;
	public float fallSpeed = 1f;
	bool isFall = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float distance = transform.position.x - player.transform.position.x;
		if (!isFall && distance > 0f && distance < gapX ) {
			Fall ();
		}
	
	}

	void OnTriggerEnter2D(Collider2D other) { // player hit the boulder lose 1hp;
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			player.GetComponent<PlayerController> ().hpDown = true;
			Destroy (gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other) { // player hit the boulder lose 1hp;
		if (other.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			Destroy (gameObject);
		}
	}

	public void Fall() {
		GetComponent<Rigidbody2D> ().gravityScale = fallSpeed;
		isFall = true;
	}
}
