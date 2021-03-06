﻿using UnityEngine;
using System.Collections;

public class TutorialPeterController : MonoBehaviour {

	//movement variables
	public float maxSpeed;
	public float minSpeed;

	//control speed bool
	public bool speedUp;
	public bool speedDown;
	public bool speedMin;
	public bool speedZero;
	public bool jump;
	public float jumpHeight;
	public static float currentSpeed = 0f;



	Rigidbody2D myRB;
	Animator myAnim;


	bool facingRight;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();

		facingRight = true;
		currentSpeed = minSpeed;

	}



	// Update is called once per frame
	void Update() {
		Debug.Log ("Update!");
		Jump ();


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




		if (speedUp && currentSpeed < maxSpeed) {

			currentSpeed += 2f;
			if (currentSpeed > maxSpeed)
				currentSpeed = maxSpeed;
			speedUp = false;
		} else if (speedDown && currentSpeed > minSpeed) {
			currentSpeed -= 2f;
			if (currentSpeed < minSpeed)
				currentSpeed = minSpeed;
			speedDown = false;
		} else if (speedDown && currentSpeed == 0f) {
			currentSpeed = minSpeed;
			speedDown = false;
		}

		if (speedMin) {
			currentSpeed = minSpeed;
			speedMin = false;
		}

		if (speedZero) {
			currentSpeed = 0f;
			speedZero = false;
		}
	}

	public void Stop() {
		currentSpeed = 0f;
	}

	void Jump() {
		if (jump) {
			Debug.Log ("Jump function!");
			myRB.AddForce (new Vector2 (0, jumpHeight));
			jump = false;
		}
	}


	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
