using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameEndBestStreak : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text> ().text = "BestStreak: " + BestStreakTextController.bestStreak;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
