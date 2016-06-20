using UnityEngine;
using System.Collections;

public class ScoreTextController : MonoBehaviour {
	public static int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<UnityEngine.UI.Text> ().text = "Score " + score.ToString ();
	}
}
