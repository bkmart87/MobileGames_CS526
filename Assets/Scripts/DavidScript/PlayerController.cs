using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//movement variables
	public float maxSpeed;
	public float minSpeed;

	public GameObject hpUi;
	public GameObject game;

	//control speed bool
	public bool speedUp;
	public bool speedDown;
	public bool speedMin;
	public bool speedZero;
	public bool jump;
	public float jumpHeight;
	public float jumpDistance;
	public static float currentSpeed = 0f;
	public bool hit;
	public bool hitDie;
	public bool hpUp;
	public bool hpDown;


	public int maxHp = 3;
	int hp = 3;

	bool grounded = true;


	//jump manipulation
	float groundY = 3.40f;



	Rigidbody2D myRB;
	Animator myAnim;


	bool facingRight;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = GetComponentInChildren<Animator> ();

		facingRight = true;
		grounded = true;
		currentSpeed = minSpeed;
	
	}


	
	// Update is called once per frame
	void Update() {
		
		if (transform.localPosition.y > groundY) {
			grounded = false;
			//Debug.Log ("jumping!");
			transform.Translate (jumpDistance, 0, 0);
		} else {
			grounded = true;
		}
		if(grounded) Jump ();


	}



	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		GetSpeed ();
		// currentSpeed += move * 0.1f; ///test!!!
		myAnim.SetFloat ("Speed", Mathf.Abs(currentSpeed));

		myRB.velocity = new Vector2 (currentSpeed , myRB.velocity.y);

		GetHit ();
		GetHp ();

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
			GetComponentInChildren<PeterTextController> ().Show ("Speed Up");
			speedUp = false;
		} else if (speedDown && currentSpeed > minSpeed) {
			currentSpeed -= 2f;
			if (currentSpeed < minSpeed)
				currentSpeed = minSpeed;
			GetComponentInChildren<PeterTextController> ().Show ("Speed Down");
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

	void GetHit() {
		if (hit) {
			hit = false;
			myAnim.SetInteger ("HitPoints", 1);
			myAnim.SetTrigger ("Hit");
		}

		if (hitDie) {
			hitDie = false;
			myAnim.SetInteger ("HitPoints", 0);
			myAnim.SetTrigger ("Hit");
			Debug.Log ("hit die game over");
			game.GetComponent<GameController> ().GameOver ();
		}
		
	}

	void GetHp() {
		if (hpUp == true) {
			hpUp = false;
			if (hp < maxHp) {
				hp++;
				GetComponentInChildren<PeterTextController> ().Show ("HP +1");
				hpUi.GetComponent<HpUIController> ().addHp (1);
			}

		} else if (hpDown == true) {
			hpDown = false;
			hp--;
			GetComponentInChildren<PeterTextController> ().Show ("HP -1");
			hpUi.GetComponent<HpUIController> ().addHp (-1);
			if (hp > 0) {
				hit = true;
				speedUp = true;
			} else {
				hitDie = true;
			}
		}
		//hpUi.GetComponentInChildren<UnityEngine.UI.Text> ().text = "HP " + hp; // hp ui change

	}
}
