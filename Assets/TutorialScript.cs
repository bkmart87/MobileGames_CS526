using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

	private static int numHints = 10;
	private string[] hints = new string[numHints];
	int count = 0;

	public RectTransform note;

	// Use this for initialization
	void Start () {
		count = 0;
		hints[0] = "Hi, Welcome To Peter and The Wolf Game!";
		hints[1] = "Press the notes correctly to contorl the speed of PETER!";
		hints[2] = "Now, Please press the note! "; 
		hints[3] = "Great! "; 
		hints[4] = " "; 
		hints[5] = " "; 
		hints[6] = " "; 
		hints[7] = " "; 
		hints[8] = " "; 
		hints[9] = " ";

		gameObject.GetComponent<Text> ().text = hints [count];
	}

	public void clickEvent(){
		count++;
		if (count < numHints) {
			gameObject.GetComponent<Text> ().text = hints [count];
		}

		//note come out
		if (count == 2) {
			Instantiate (note);
		}
	}

}
