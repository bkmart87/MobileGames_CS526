using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//speed 
	float minSpeed = 7.5f;
	float midSpeed = 10f;
	float maxSpeed = 20f;

	public float wolfSpeed = 5f;
	public static float currentSpeed = 5f;
	public GameObject player;
	public GameObject wolfMessage = null;
	public GameObject game = null;

	float inCameraDistance = 5f;

	bool stop = false;

	Rigidbody2D myRB;
	Animator myAnim;


	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponentInChildren<Animator> ();
		currentSpeed = wolfSpeed;
		stop = false;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = getPlayerDistance ();
		if (distance > inCameraDistance) {
			wolfMessage.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Wolf " + (int)distance + "M behind";
		} else {
			wolfMessage.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";
		}
		//Debug.Log ("wolf speed: " + wolfSpeed);
		if (!stop) {
			if (distance > 2f && distance < inCameraDistance)
				currentSpeed = minSpeed;
			else if (distance > 10f)
				currentSpeed = maxSpeed;
		}
	}

	void FixedUpdate() {
		myAnim.SetFloat ("Speed", Mathf.Abs(currentSpeed));
		myRB.velocity = new Vector2 (currentSpeed, 0);

	}

	public void Stop() {
		currentSpeed = 0;
		stop = true;
	}

	void OnTriggerEnter2D(Collider2D other) { //hit player then game over
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			game.GetComponent<GameController>().GameOver ();
		}

	}

	float getPlayerDistance() { //get enemy distance to playr
		float distance = (player.transform.localPosition.x - transform.localPosition.x - 4f) / 4f;
		//Debug.Log ("Distance: " + distance);
		return distance;
	}
}
