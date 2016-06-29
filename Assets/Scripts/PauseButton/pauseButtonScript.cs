using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pauseButtonScript : MonoBehaviour {

	public GameObject popup;

	//three level scenes -- index
	private int level1 = 2;
	private int level2 = 3;
	private int level3 = 4;
	// Use this for initialization
	void Start () {
		//popup = GameObject.Find ("popup");
		popup.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pauseButtonClickEvent(){

		NoteButtonController.pause = true;
		popup.SetActive (true);

	}
		
	public void replayEvent(){
		SceneManager.LoadScene(Application.loadedLevelName);
	}

	public void exitEvent(){
		NoteButtonController.pause = false;
		popup.SetActive (false);
	}
}
