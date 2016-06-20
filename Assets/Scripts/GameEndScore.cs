using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameEndScore : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
		gameObject.GetComponent<Text> ().text = "Score: " + ScoreTextController.score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
