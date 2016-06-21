using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	float minSpeed = 7f;
	float midSpeed = 10f;
	float maxSpeed = 20f;
	public float wolfSpeed = 5f;
	public static float currentSpeed = 5f;
	public playerController pc = null;
	public GameObject wolfMessage = null;

	float inCameraDistance = 5f;

	bool stop = false;

	Rigidbody2D myRB;
	Animator myAnim;


	void Awake() {
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponentInParent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		currentSpeed = wolfSpeed;
		stop = false;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = getPlayerDistance ();
		if (distance > inCameraDistance) {
			wolfMessage.GetComponent<UnityEngine.UI.Text> ().text = "Wolf " + (int)distance + "M behind";
		} else {
			wolfMessage.GetComponent<UnityEngine.UI.Text> ().text = "";
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

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			GameObject.Find("Game").GetComponent<GameController>().GameOver ();
		}
	}

	float getPlayerDistance() {
		float distance = (pc.transform.localPosition.x - transform.localPosition.x - 4f) / 4f;
		//Debug.Log ("Distance: " + distance);
		return distance;
	}
}
