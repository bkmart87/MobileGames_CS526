using UnityEngine;
using System.Collections;

public class MoveCharts : MonoBehaviour {

	public static float chartMoveSpeed = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vspeed = new Vector3 (-chartMoveSpeed, 0, 0);
		this.transform.position += (vspeed * Time.deltaTime);
	}
}
