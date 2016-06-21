using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

	GameObject player;
	GameObject bg;
	public GameObject newBg;
	GameObject bgs;
	float bgRight = 46f;
	float camRight = 33f;
	float gapX = 87f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Peter");
		bg = GameObject.Find ("BG");
		bgs = GameObject.Find ("BGs");


	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.localPosition;
		transform.localPosition = new Vector3(player.transform.localPosition.x, pos.y, pos.z);
		if (GetComponent<Camera> ().WorldToViewportPoint (bg.transform.position).x < 0.5f) { 
			float oldX = bg.transform.localPosition.x;
			bg = Instantiate (newBg);
			bg.transform.SetParent (bgs.transform);
			bg.transform.localPosition = new Vector3 (oldX + gapX, bg.transform.localPosition.y, bg.transform.localPosition.z);


		}
	}
}
