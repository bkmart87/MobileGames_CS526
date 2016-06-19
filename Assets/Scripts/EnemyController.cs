using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public static float currentSpeed = 5f;
	public playerController pc = null;

	Rigidbody2D myRB;
	Animator myAnim;


	void Awake() {
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponentInParent<Animator> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		myAnim.SetFloat ("Speed", Mathf.Abs(currentSpeed));
		myRB.velocity = new Vector2 (currentSpeed, 0);

	}

	public void Stop() {
		currentSpeed = 0;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			GameObject.Find("Game").GetComponent<GameController>().GameOver ();
		}
	}
}
