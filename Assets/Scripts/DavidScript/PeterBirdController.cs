using UnityEngine;
using System.Collections;

public class PeterBirdController : MonoBehaviour {
	public GameObject playerBody;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(playerBody.transform.position,new Vector3 (0,1,0),60*Time.deltaTime);
		transform.Rotate (new Vector3 (0, -60*Time.deltaTime, 0)); 
	}
}
