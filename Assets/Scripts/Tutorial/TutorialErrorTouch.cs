using UnityEngine;
using System.Collections;

public class TutorialErrorTouch : MonoBehaviour {
	public GameObject errorSound;

	public void Click() {
		GameObject myErrorSound = Instantiate(errorSound);

		PlayerController pc = GameObject.Find ("Peter").GetComponent<PlayerController> ();
		BestStreakTextController.score = 0;
		//pc.speedMin = true;

	}
}

