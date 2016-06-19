using UnityEngine;
using System.Collections;

public class TutorialErrorTouch : MonoBehaviour {
	public GameObject errorSound;

	public void Click() {
		GameObject myErrorSound = Instantiate(errorSound);

		TutorialPeterController pc = GameObject.Find ("Peter").GetComponent<TutorialPeterController> ();
		BestStreakTextController.score = 0;
		pc.speedMin = true;

	}
}

