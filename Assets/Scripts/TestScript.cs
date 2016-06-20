using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour {

	public static float count = 0f;

	// Use this for initialization
	void Start () {
		Debug.Log ("Start!!!!");
		
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
		//Debug.Log ("test: " + count);
	}
		
	public void Click1() {
		SceneManager.LoadScene ("DavidTest2");
	}

	public void Click2() {
		SceneManager.LoadScene ("DavidTest");
	}


}
