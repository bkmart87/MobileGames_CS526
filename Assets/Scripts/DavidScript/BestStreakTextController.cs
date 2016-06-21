using UnityEngine;
using System.Collections;

public class BestStreakTextController : MonoBehaviour {
	public static int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<UnityEngine.UI.Text> ().text = "Best Streak " + score.ToString ();
	
	}
}
