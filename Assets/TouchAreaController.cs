using UnityEngine;
using System.Collections;

public class TouchAreaController : MonoBehaviour {
	public GameObject errorSound = null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click() {
		GameObject myErrorSound = Instantiate(errorSound);

		UnityEngine.UI.Text inputStatus = GameObject.Find ("InputStatusText").GetComponent<UnityEngine.UI.Text> ();
		playerController pc = GameObject.Find ("Peter").GetComponent<playerController> ();
		BestStreakTextController.score = 0;
		inputStatus.text = "Wrong!";
		pc.speedMin = true;

	}
}
