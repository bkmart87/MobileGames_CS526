using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	//speed 
	float minSpeed = 8.4f;
	float midSpeed = 10f;
	float maxSpeed = 20f;
	float preSpeed = 0f;

	public float wolfSpeed = 5f;
	public static float currentSpeed = 5f;
	public GameObject player;
	public GameObject wolfMessage = null;
	public GameObject game = null;

	public float distance;
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
		distance = getPlayerDistance ();
		if (distance > inCameraDistance) {
			wolfMessage.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Wolf " + (int)distance + "M";
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
		preSpeed = currentSpeed;
		currentSpeed = 0f;
		stop = true;
	}

	void OnTriggerEnter2D(Collider2D other) { //hit player 
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			//game.GetComponent<GameController>().GameOver ();
			game.GetComponent<GameController>().wolfHit++;
			player.GetComponent<PlayerController>().hpDown = true;
			myAnim.SetTrigger ("Bite");
			if (player.GetComponent<PlayerController> ().hp > 0) {
				Stop ();
				Invoke ("RecoverSpeed", 4f); // wolf will stop for 4 sec and then recover previous speed
			}
		}

	}

	public void RecoverSpeed() {
		currentSpeed = preSpeed;
		stop = false;
	}




	float getPlayerDistance() { //get enemy distance to playr
		float distance = (player.transform.localPosition.x - transform.localPosition.x - 4f) / 4f;
		//Debug.Log ("Distance: " + distance);
		return distance;
	}
}
