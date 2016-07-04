using UnityEngine;
using System.Collections;

public class BestStreakTextController : MonoBehaviour {
	public static int score = 0;
	public static int bestStreak = 0;

	// Use this for initialization
	void Start () {
		bestStreak = 0;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<UnityEngine.UI.Text> ().text = "Streak " + score.ToString ();
		if (score > bestStreak) {
			bestStreak = score;
		}
	}
}
