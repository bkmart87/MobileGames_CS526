using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour {

	public static float count = 0f;

	Camera cam;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start!!!!");
		cam = GameObject.Find ("Main Camera").GetComponent<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = cam.WorldToViewportPoint (transform.position);
		Debug.Log (pos.ToString());
	}
		
	public void Click1() {
		SceneManager.LoadScene ("DavidTest2");
	}

	public void Click2() {
		SceneManager.LoadScene ("DavidTest");
	}
		
}
