using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

	private static int numHints = 12;
	private string[] hints = new string[numHints];
	int count = 0;

	public GameObject baseNote;
	public GameObject cameraUI;

	private GameObject noteA;
	private GameObject noteB;
	private GameObject noteC;
	private GameObject noteD;
	private GameObject noteE;


	private PlayerController peter;


	// Use this for initialization
	void Start () {
		count = 0;
		hints[0] = "Hi, Welcome To Peter and The Wolf Game!";
		hints[1] = "You need to press the notes correctly to control the moving speed of PETER!";
		hints[2] = "You can press the note when the note reached the left side of the glow!"; 
		hints[3] = "Now, Please press the note A4 which was already on the left side of the glow! "; 
		hints[4] = "Great! If you press note B4 which was still on the right side, nothing happened!"; 
		hints[5] = "Now! Try to press the note B when it's moving!"; 
		hints[6] = "You need to use tow fingers to press the notes if two notes appeared at the same time!";
		hints[7] = "You need to use tow fingers to press the notes if two notes appeared at the same time!";
		hints[8] = "You can make Peter to jump by holding the note down for a while!";
		hints[9] = "You can make Peter to jump by holding the note down for a while!";
		hints[10] = "Congratulations! You learned how to PLAY the music!"; 
		hints[11] = "Try your best to press notes correctly as much as you can! Save the PETER!"; 


		gameObject.GetComponent<Text> ().text = hints [count];

		TutorialNotesController.pause = true;
		noteA = GameObject.Find ("NoteUIButtonA");
		noteB = GameObject.Find ("NoteUIButtonB");
		noteC = GameObject.Find ("NoteUIButtonC");
		noteD = GameObject.Find ("NoteUIButtonD");
		noteE = GameObject.Find ("NoteUIButtonE");
		//peter = GameObject.Find ("Peter").GetComponent<PlayerController> ();

		noteA.SetActive (false);
		noteB.SetActive (false);
		noteC.SetActive (false);
		noteD.SetActive (false);
		noteE.SetActive (false);

		//clear the score text
		ScoreTextController.score = 0;
		BestStreakTextController.score = 0;
	}

	public void clickEvent(){
		if ((count == 3 && noteA.activeSelf) || (count == 5 && noteB.activeSelf) || (count == 7 && noteC.activeSelf && noteD.activeSelf)) {
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

			if (count == 6 || count == 8 || count == 10) {
				cameraUI.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().enabled = 
					!cameraUI.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().enabled;
				
			}

			if (count == 7) {
				cameraUI.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().enabled = 
					!cameraUI.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().enabled;
				noteC.SetActive (true);
				noteD.SetActive (true);
			}

			if (count == 9) {
				cameraUI.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().enabled = 
					!cameraUI.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized> ().enabled;
				TutorialNotesController.pause = true;
				noteE.SetActive (true);
			}


			if (count == 11) {
				GameObject text = GameObject.Find ("ButtonText");
				text.GetComponent<Text> ().text = "END";
			}
			if (count == 12) {
				Application.LoadLevel ("level0");
			}
		}
	}

}
