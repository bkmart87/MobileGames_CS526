using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameEndBestStreak : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text> ().text = BestStreakTextController.bestStreak.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
