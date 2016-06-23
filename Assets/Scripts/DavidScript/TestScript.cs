using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class TestScript : MonoBehaviour {

	public static float count = 0f;
	public TextAsset temp;

	Camera cam;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start!!!!");
		cam = GameObject.Find ("MainCamera").GetComponent<Camera> ();
		string[] s = temp.text.Split (Environment.NewLine.ToCharArray());
		for (int i = 0; i < s.Length; i++) {
			Debug.Log ("s: " + s [i]);
		}

	}
	
	// Update is called once per frame
	void Update () {
		/*
		Vector3 pos = cam.WorldToViewportPoint (transform.position);
		Debug.Log (pos.ToString());
		*/
	}
		
	public void Click1() {
		SceneManager.LoadScene ("DavidTest2");
	}

	public void Click2() {
		SceneManager.LoadScene ("DavidTest");
	}
		
}
