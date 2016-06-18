using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Peter");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.localPosition;
		transform.localPosition = new Vector3(player.transform.localPosition.x, pos.y, pos.z);
	}
}
