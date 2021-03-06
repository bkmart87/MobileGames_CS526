﻿using UnityEngine;
using System.Collections;

public class MiniMapController : MonoBehaviour {
	public GameObject mapPeter;
	public GameObject mapWolf;
	public GameObject mapStart;
	public GameObject mapDestination;

	public GameObject enemy;
	public GameObject notes;


	float startX = 0f;
	float length = 0f;
	float lastNoteLength;


	public float scale = 0f;
	public float distance = 0.2f;

	float driftYPeter = 0.11f;
	float driftYWolf = -0.12f;
	float mapPeterCenter;
	float mapWolfCenter;

	Animator mapPeterAnim;

	// Use this for initialization
	void Start () {
		startX = mapStart.transform.localPosition.x;
		length = mapDestination.transform.localPosition.x - mapStart.transform.localPosition.x;
		mapPeterCenter = mapPeter.transform.localPosition.y;
		mapWolfCenter = mapWolf.transform.localPosition.y;
		mapPeterAnim = mapPeter.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		driftYPeter = Swing (mapPeter, mapPeterCenter, 2f, driftYPeter);
		driftYWolf = Swing (mapWolf, mapWolfCenter, 2f, driftYWolf);
		scale = notes.GetComponent<NoteMovement> ().progressScale;
		mapPeter.transform.localPosition = new Vector3 (startX + length * scale, mapPeter.transform.localPosition.y, mapPeter.transform.localPosition.z);
		distance = enemy.GetComponent<EnemyController> ().distance * 5f;
		mapWolf.transform.localPosition = new Vector3 (mapPeter.transform.localPosition.x - distance, mapWolf.transform.localPosition.y, mapWolf.transform.localPosition.z);
	}

	float Swing (GameObject obj, float center, float y, float driftY) {
		obj.transform.localPosition = new Vector3 (obj.transform.localPosition.x, obj.transform.localPosition.y + driftY, obj.transform.localPosition.z);
		if (obj.transform.localPosition.y >= center + y || obj.transform.localPosition.y <= center - y) {
			//Debug.Log ("drifty " + driftY);
			driftY *= -1f;
			obj.transform.localPosition = new Vector3 (obj.transform.localPosition.x, obj.transform.localPosition.y + driftY, obj.transform.localPosition.z);
		} 
		return driftY;
		
	}

	public void Hit() {
		mapPeterAnim.SetTrigger ("peterHited");
	}

}
