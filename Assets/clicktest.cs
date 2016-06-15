using UnityEngine;
using System.Collections;

public class clicktest : MonoBehaviour {

	public int num = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Test() {
		Debug.Log ("load button");
		num++;
	}
}
