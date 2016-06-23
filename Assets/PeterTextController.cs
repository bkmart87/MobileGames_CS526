using UnityEngine;
using System.Collections;

public class PeterTextController : MonoBehaviour {
	bool showtext = false;
	float currentTime = 0f;
	Vector3 initPos;

	// Use this for initialization
	void Start () {
		initPos = transform.localPosition;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (showtext == true) {
			currentTime += Time.deltaTime;
			transform.Translate (0, 0.1f, 0);
			if (currentTime > 0.3f) {
				currentTime = 0f;
				showtext = false;
				transform.localPosition = initPos;
				GetComponent<TextMesh> ().text = "";
			}
		}
	}

	public void Show(string s) {
		GetComponent<TextMesh> ().text = s;
		showtext = true;
	}
}
