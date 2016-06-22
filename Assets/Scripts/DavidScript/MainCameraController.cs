using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

	public GameObject player;
	public GameObject bg;
	public GameObject newBg;
	public GameObject bgs;
	float gapX = 87f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.localPosition;
		transform.localPosition = new Vector3(player.transform.localPosition.x, pos.y, pos.z);
		if (GetComponent<Camera> ().WorldToViewportPoint (bg.transform.position).x < 0.5f) { //dynamic generate new background when camera arrive the center of the current background
			float oldX = bg.transform.localPosition.x;
			bg = Instantiate (newBg);
			bg.transform.SetParent (bgs.transform);
			bg.transform.localPosition = new Vector3 (oldX + gapX, bg.transform.localPosition.y, bg.transform.localPosition.z);
		}
	}
}
