using UnityEngine;
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

	// Use this for initialization
	void Start () {
		startX = mapStart.transform.localPosition.x;
		length = mapDestination.transform.localPosition.x - mapStart.transform.localPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
		scale = notes.GetComponent<NoteMovement> ().progressScale;
		mapPeter.transform.localPosition = new Vector3 (startX + length * scale, mapPeter.transform.localPosition.y, mapPeter.transform.localPosition.z);
		distance = enemy.GetComponent<EnemyController> ().distance * 5f;
		mapWolf.transform.localPosition = new Vector3 (mapPeter.transform.localPosition.x - distance, mapWolf.transform.localPosition.y, mapWolf.transform.localPosition.z);
	}
}
