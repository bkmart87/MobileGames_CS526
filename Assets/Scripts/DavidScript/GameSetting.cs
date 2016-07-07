using UnityEngine;
using System.Collections;

public class GameSetting : MonoBehaviour {

	public GameObject mainCamera;
	public GameObject notes;

	//item
	public int violinNum;
	public float violinProb;
	public int heartNum;
	public float heartProb;
	public int shieldNum;
	public float shieldProb;



	//obstacle
	public int spikeNum;
	public float spikeProb;
	public int boulderNum;
	public float boulderProb;

	//notes
	public float notesMaxSpeed;
	public float notesMinSpeed;
	public float gapX;
	public TextAsset musicFile;




	void Awake() {
		MainCameraController mcc = mainCamera.GetComponent<MainCameraController> ();
		NoteMovement nm = notes.GetComponent<NoteMovement> ();

		//item
		mcc.violinNum = violinNum;
		mcc.violinProb = violinProb;
		mcc.heartNum = heartNum;
		mcc.heartProb = heartProb;
		mcc.shieldNum = shieldNum;
		mcc.shieldProb = shieldProb;

		//obstacle
		mcc.rockNum = spikeNum;
		mcc.rockProb = spikeProb;
		mcc.boulderNum = boulderNum;
		mcc.boulderProb = boulderProb;

		//notes
		nm.maxSpeed = notesMaxSpeed;
		nm.minSpeed = notesMinSpeed;
		nm.gapX = gapX;
		nm.musicFile = musicFile;


	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
