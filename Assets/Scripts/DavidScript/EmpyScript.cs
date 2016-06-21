using UnityEngine;
using System.Collections;

public class EmpyScript : MonoBehaviour {
	float noteSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		noteSpeed = NoteButtonController.noteSpeed;
		Move ();
		if (transform.localPosition.x < -400) {
			Destroy (gameObject);
		}
		
	}

	public void Move() {
		Vector3 currentPos = GetComponent<RectTransform> ().localPosition;
		GetComponent<RectTransform> ().localPosition = new Vector3 (currentPos.x - noteSpeed, currentPos.y, currentPos.z);
	}
}
