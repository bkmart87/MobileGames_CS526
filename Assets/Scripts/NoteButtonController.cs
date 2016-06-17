using UnityEngine;
using System.Collections;

public class NoteButtonController : MonoBehaviour {


	public GameObject sound = null;

	float triggerRight = -148f;
	float triggerLeft = -400f;

	public static bool click = false;
	public static bool pause = false;
	public static float noteSpeed = 2f;

	float perfectX;
	float perfectInteval = 25f;
	static int perfectCount = 0;

	// Use this for initialization
	void Start () {
		noteSpeed = GameObject.Find ("Notes").GetComponent<NoteMovement> ().noteSpeed;
		GetComponent<UnityEngine.UI.Button> ().interactable = false;
		triggerRight = GameObject.Find ("Glowbit").transform.localPosition.x;
		RectTransform touchRect = GameObject.Find ("TouchArea").GetComponent<RectTransform> ();
		triggerLeft = touchRect.localPosition.x - touchRect.rect.width / 2f;
		perfectX = GameObject.Find ("PerfectLine").transform.localPosition.x;


	}

	// Update is called once per frame
	void Update () {
		if(transform.localPosition.x < triggerRight) GetComponent<UnityEngine.UI.Button> ().interactable = true;
		if (transform.localPosition.x <= triggerLeft)
			pause = true;
		if (!pause) {
			Move ();
		} else {
			GameObject.Find ("Peter").GetComponent<playerController> ().speedZero = true;
		}

	}

	public void BigMove() {
		Vector3 currentPos = GetComponent<RectTransform> ().localPosition;
		GetComponent<RectTransform> ().localPosition = new Vector3 (currentPos.x - 100f, currentPos.y, currentPos.z);
	}

	public void Move() {
		Vector3 currentPos = GetComponent<RectTransform> ().localPosition;
		GetComponent<RectTransform> ().localPosition = new Vector3 (currentPos.x - noteSpeed, currentPos.y, currentPos.z);
	}

	public void ClickNote() {

		GameObject mySound = Instantiate (sound);
		click = true;
		pause = false;
		ScoreTextController.score++;
		BestStreakTextController.score++;


		float x = transform.localPosition.x;
		UnityEngine.UI.Text inputStatus = GameObject.Find ("InputStatusText").GetComponent<UnityEngine.UI.Text> ();
		playerController pc = GameObject.Find ("Peter").GetComponent<playerController> ();
		if (x >= perfectX - perfectInteval && x <= perfectX + perfectInteval) {
			perfectCount++;
			inputStatus.text = "Perfect X " + perfectCount.ToString();
			pc.speedUp = true;
		} else if (x >= perfectX + perfectInteval) {
			inputStatus.text = "Fast!";
			perfectCount = 0;
			pc.speedDown = true;
		} else {
			inputStatus.text = "Slow!";
			perfectCount = 0;
			pc.speedDown = true;
		}

		Destroy (gameObject);

	}
}
