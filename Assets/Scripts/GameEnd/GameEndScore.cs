using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameEndScore : MonoBehaviour {
	private int totalScore; 
	// Use this for initialization
	void Start () {
		totalScore = ScoreTextController.score + BestStreakTextController.bestStreak * 3;
		gameObject.GetComponent<Text> ().text = totalScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
