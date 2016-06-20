using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

	private static int numHints = 10;
	private string[] hints = new string[numHints];
	int count = 0;

	public GameObject baseNote;
	public GameObject cameraUI;

	private GameObject noteA;
	private GameObject noteB;


	// Use this for initialization
	void Start () {
		count = 0;
		hints[0] = "Hi, Welcome To Peter and The Wolf Game!";
		hints[1] = "You need to press the notes correctly to contorl the moving speed of PETER!";
		hints[2] = "You can press the note when the note reached the left side of the glow!"; 
		hints[3] = "Now, Please press the note A which was already on the left side of the glow! "; 
		hints[4] = "Great! If you press note B which was still on the right side, nothing happened!"; 
		hints[5] = "Now! Try to press the note B when it's moving!"; 
		hints[6] = "Congratulations! You learned how to PLAY the music!"; 
		hints[7] = ""; 
		hints[8] = " "; 
		hints[9] = " ";

		gameObject.GetComponent<Text> ().text = hints [count];

		TutorialNotesController.pause = true;
		noteA = GameObject.Find ("NoteUIButtonA");
		noteB = GameObject.Find ("NoteUIButtonB");
		noteA.SetActive (false);
		noteB.SetActive (false);
	}

	public void clickEvent(){
		if ((count == 3 && noteA.activeSelf) || (count == 5 && noteB.activeSelf)) {
			;
		} else {
			count++;
			if (count < numHints) {
				gameObject.GetComponent<Text> ().text = hints [count];
			}

			//note come out
			if (count == 3) {
				cameraUI.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().enabled = 
					!cameraUI.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().enabled;
				noteA.SetActive (true);
				noteB.SetActive (true);
			}

			//note B starts moving
			if (count == 5) {
				TutorialNotesController.pause = false;	
			}

			if (count == 6) {
				cameraUI.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().enabled = 
					!cameraUI.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().enabled;
				GameObject text = GameObject.Find ("ButtonText");
				text.GetComponent<Text> ().text = "END";
			}

			if (count == 7) {
				Application.LoadLevel ("level0");
			}
		}
	}

}
