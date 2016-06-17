using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameEndScore : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
		gameObject.GetComponent<Text> ().text = "Score: " + PlaySong.totalCorrect;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
