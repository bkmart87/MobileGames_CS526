using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	//movement variables
	public float maxSpeed;
	public float minSpeed;
	public bool speedUp;
	public bool speedDown;
	public static float currentSpeed = 0f;


	Rigidbody2D myRB;
	Animator myAnim;
	int preBestStreak = 0;

	bool facingRight;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();

		facingRight = true;
		currentSpeed = minSpeed;
		preBestStreak = PlaySong.bestStreak;
	
	}


	
	// Update is called once per frame
	void Update() {


	}



	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		GetSpeed ();
		myAnim.SetFloat ("Speed", Mathf.Abs(currentSpeed));

		myRB.velocity = new Vector2 (currentSpeed, myRB.velocity.y);

		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}

	}

	void GetSpeed() {



		if (PlaySong.bestStreak > preBestStreak) {
			speedUp = true;
		}


		if (speedUp && currentSpeed < maxSpeed) {
			currentSpeed += 2;
			if (currentSpeed > maxSpeed)
				currentSpeed = maxSpeed;
			speedUp = false;
		}
		else if(speedDown && currentSpeed > minSpeed) {
			currentSpeed -= 2;
			if (currentSpeed < minSpeed)
				currentSpeed = minSpeed;
			speedDown = false;
		}

		if (NoteController.pause == 1) {
			currentSpeed = minSpeed;
		}

		preBestStreak = PlaySong.bestStreak;
			

	}

	public void Stop() {
		currentSpeed = 0;
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
