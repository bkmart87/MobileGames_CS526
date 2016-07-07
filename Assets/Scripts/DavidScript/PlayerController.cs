using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//movement variables
	public float maxSpeed;
	public float minSpeed;

	public GameObject hpUi;
	public GameObject game;
	public GameObject peterBird;
	public GameObject peterBody;
	public GameObject miniMapUI;

	public bool controllable;

	//control speed bool
	public bool speedUp;
	public bool speedDown;
	public bool speedMin;
	public bool speedZero;
	public bool jump;
	public float jumpHeight;
	public float jumpDistance;
	public float currentSpeed = 0f;
	public bool hit;
	public bool hitDie;
	public bool hpUp;
	public bool hpDown;
	public bool getShield;
	public bool invincible;
	int shieldNum = 0;


	public int maxHp = 3;
	public int hp = 3;

	bool grounded = true;


	//jump manipulation
	float groundY = 3.40f;



	Rigidbody2D myRB;
	Animator myAnim;


	bool facingRight;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myAnim = peterBody.GetComponentInChildren<Animator> ();

		controllable = true;
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
		if(controllable && grounded) Jump ();


	}



	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		if (controllable) {
			GetSpeed ();
			GetHit ();
			GetHp ();
		}
		myAnim.SetFloat ("Speed", Mathf.Abs(currentSpeed));
		myRB.velocity = new Vector2 (currentSpeed , myRB.velocity.y);

		if (move > 0 && !facingRight) { //flip peter's body
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
				//hp++;
				//GetComponentInChildren<PeterTextController> ().Show ("HP +1");
				//hpUi.GetComponent<HpUIController> ().addHp (1);
			}

		} else if (hpDown == true && !invincible) {
			hpDown = false;
			miniMapUI.GetComponent<MiniMapController> ().Hit ();
			//hp--;
			GetComponentInChildren<PeterTextController> ().Show ("Hit!");
			//hpUi.GetComponent<HpUIController> ().addHp (-1);
			if (hp > 0) {
				hit = true;
				//speedUp = true;
			} else {
				hitDie = true;
			}
		}
		//hpUi.GetComponentInChildren<UnityEngine.UI.Text> ().text = "HP " + hp; // hp ui change

	}

	public void GetShield() {
		invincible = true;
		shieldNum++;
		GetComponentInChildren<PeterTextController> ().Show ("Bird Shield");
		peterBird.SetActive (true);
		peterBird.GetComponent<Animator> ().SetBool ("Fade", false);
		Invoke ("FadeShield", 9f);
		Invoke ("DropShield", 12f); //shiled time 

	}

	public void FadeShield() {
		if (shieldNum == 1) {
			peterBird.GetComponent<Animator> ().SetBool ("Fade", true);
		}
	}

	void DropShield() {
		shieldNum--;
		if (shieldNum == 0) {
			invincible = false;
			peterBird.GetComponent<Animator> ().SetBool ("Fade", false);
			peterBird.SetActive (false);
		}
	}
}
