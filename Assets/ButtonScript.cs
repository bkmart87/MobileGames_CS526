using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
			
	}

	public void BigMove() {
		Vector3 currentPos = GetComponent<RectTransform> ().localPosition;
		GetComponent<RectTransform> ().localPosition = new Vector3 (currentPos.x - 100, currentPos.y, currentPos.z);
	}

	public void Move() {
		Vector3 currentPos = GetComponent<RectTransform> ().localPosition;
		GetComponent<RectTransform> ().localPosition = new Vector3 (currentPos.x - 1, currentPos.y, currentPos.z);
	}
}
